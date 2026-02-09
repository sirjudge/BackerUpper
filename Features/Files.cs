using Microsoft.Data.Sqlite;

namespace Features;

public static class Files {
    private const string SqliteFileName = "configfiles.sqlite";

    private static string GetSqliteConnectionString() =>
        $"data source={SqliteFileName}";

    public static SqliteConnection GetSqliteConnection(){
        SqliteConnection connection = new (GetSqliteConnectionString());
        connection.Open();
        if (File.Exists(SqliteFileName))
        {
            return connection;
        }

        using SqliteCommand command = connection.CreateCommand();
        command.CommandText =
            """
            create table if not exists setup (
                bit_mask integer primary key,
                name text not null
            );
            insert or ignore into setup (bit_mask, name)
            values (1, 'work'), (2, 'personal');

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

    public static List<string> GetBackupFileList(){
        using var command = GetSqliteConnection().CreateCommand();
        command.CommandText =
            """
            select
                file_name,
                date_first_added,
                date_last_synced,
            from files
            """;

        List<string> filePathList = [];
        using SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            filePathList.Add(name);
        }
        return filePathList;
    }

    public static void SaveFileBackupList(){
        using SqliteCommand command = GetSqliteConnection().CreateCommand();
        command.CommandText =
            """
            insert or ignore into files (
                file_name,
                date_first_added,
                date_last_synced,
                setup_bit_mask
            ) VALUES (@file_name, @date_first_added, @date_last_synced, @setup_bit_mask);
            """;
        command.Parameters.AddWithValue("@file_name", "setup");
        command.Parameters.AddWithValue("@date_first_added", DateTime.Now);
        command.Parameters.AddWithValue("@date_last_synced", DateTime.Now);
        command.Parameters.AddWithValue("@setup_bit_mask", 1);

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
