using Microsoft.Data.Sqlite;
using System.Data;

namespace Features;

public enum SetupType {
    Personal = 1,
    Work = 2,
    Shared = 4
}

public class BackupFile(){
    public required string FileName { get; init; }
    public required SetupType SetupType { get; init; }
    public DateTime DateFirstAdded { get; init; }
    public DateTime DateLastSynced { get; init; }
}


public static class Files {
    private const string SqliteFileName = "configfiles.sqlite";

    private static string GetSqliteConnectionString() =>
        $"data source={SqliteFileName}";

    public static DataTable CreateFileListDataTable(List<BackupFile> fileList){
        DataTable dt = new DataTable();
        dt.Columns.Add("FileName");
        return dt;
    }

    public static SqliteConnection GetSqliteConnection(){
        SqliteConnection connection = new (GetSqliteConnectionString());
        connection.Open();
        if (File.Exists(SqliteFileName))
        {
            Console.WriteLine($"Found DB file:", Path.GetFullPath(SqliteFileName));
            using SqliteCommand tableExistsQuery = connection.CreateCommand();
            tableExistsQuery.CommandText  =
                """
                SELECT EXISTS(
                    SELECT 1
                    FROM sqlite_master
                    WHERE type="table" AND name="files"
                );
                """;
            using var reader = tableExistsQuery.ExecuteReader();
            if (reader.Read() && reader.GetBoolean(0)){
                return connection;
            }
        }

        using SqliteCommand command = connection.CreateCommand();
        command.CommandText =
            """
            create table if not exists setup (
                bit_mask integer primary key,
                name text not null
            );
            insert or ignore into setup (bit_mask, name)
            values (1, 'work'), (2, 'personal'), (4, 'shared');

            create table if not exists files (
                file_name text not null,
                date_first_added text,
                date_last_synced text,
                id uniqueidentifier primary key,
                setup_bit_mask integer not null,
                foreign key (setup_bit_mask) references setup(bit_mask)
            );
            """;
        command.ExecuteNonQuery();

        return connection;
    }

    public static SetupType IntToSetupType(int setupMask) =>
        setupMask switch
        {
            1 => SetupType.Personal,
            2 => SetupType.Work,
            3 => SetupType.Shared,
            _ => throw new InvalidDataException($"Extracted Setup type not supported:{setupMask}")
        };

    public static List<BackupFile> GetBackupFileList(){
        using var command = GetSqliteConnection().CreateCommand();
        command.CommandText =
            """
            select
                file_name,
                date_first_added,
                date_last_synced,
                setup_bit_mask
            from files
            """;

        List<BackupFile> filePathList = [];
        using SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int setupMask = reader.GetInt16(reader.GetOrdinal("setup_bit_mask"));
            SetupType setupType = IntToSetupType(setupMask);
            string fileName = reader.GetString(reader.GetOrdinal("file_name"));
            DateTime dateFirstAdded = reader.GetDateTime(reader.GetOrdinal("date_first_added"));
            DateTime dateLastSynced = reader.GetDateTime(reader.GetOrdinal("date_last_synced"));
            BackupFile file = new (){
                FileName = fileName,
                SetupType = setupType,
                DateFirstAdded = dateFirstAdded,
                DateLastSynced = dateLastSynced,
            };
            filePathList.Add(file);
        }
        return filePathList;
    }

    public static void SaveFileBackupList(List<BackupFile> fileList){

        SqliteConnection sqliteConnection = GetSqliteConnection();
        foreach (BackupFile file in fileList)
        {
            using SqliteCommand command = sqliteConnection.CreateCommand();
            command.CommandText =
                """
                insert or ignore into files (
                    file_name,
                    date_first_added,
                    date_last_synced,
                    setup_bit_mask
                ) VALUES (@file_name, @date_first_added, @date_last_synced, @setup_bit_mask);
                """;
            command.Parameters.AddWithValue("@file_name", file.FileName);
            command.Parameters.AddWithValue("@date_first_added", DateTime.Now);
            command.Parameters.AddWithValue("@date_last_synced", DateTime.Now);
            command.Parameters.AddWithValue("@setup_bit_mask", file.SetupType);

            int numberOfRowsReturned = command.ExecuteNonQuery();
            switch (numberOfRowsReturned)
            {
                case -1:
                    throw new DataMisalignedException("Expected an insert command but a -1 was returned which indicates a select statement was run instead");
                case 0:
                    throw new DataMisalignedException("Expected 1 row inserted but got no rows instead");
                case > 1:
                    throw new DataMisalignedException("Expected 1 row returned but got " + numberOfRowsReturned);
            }
        }
    }
}
