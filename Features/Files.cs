using Microsoft.Data.Sqlite;

namespace Features;

public static class Files {
    private const string SqliteDbFileName = "configFiles.Sqlite";

    public static string GetSqliteConnectionString() =>
        $"Data Source={SqliteDbFileName}";

    public static SqliteConnection GetSqliteConnection(){
        var connection = new SqliteConnection(GetSqliteConnectionString());

        if (!File.Exists(SqliteDbFileName)){
            connection.Open();
            using var command = connection.CreateCommand();
            command.CommandText =
                """
                CREATE TABLE IF NOT EXISTS setup (
                    bit_mask INTEGER PRIMARY KEY,
                    name TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS files (
                    file_name TEXT NOT NULL,
                    date_first_added TEXT,
                    date_last_synced TEXT,
                    id UNIQUEIDENTIFIER PRIMARY KEY,
                    setup_bit_mask INTEGER NOT NULL,
                    FOREIGN KEY (setup_bit_mask) REFERENCES setup(bit_mask)
                );

                INSERT OR IGNORE INTO setup (bit_mask, name)
                VALUES (1, 'work'), (2, 'personal');
                """;
            command.ExecuteNonQuery();
        }

        return connection;
    }

    public static void GetFileBackupList(){
        using var command = GetSqliteConnection().CreateCommand();
        command.CommandText = """
            SELECT *
            FROM files
            """;
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var name = reader.GetString(0);
        }
    }

    public static void SaveFileBackupList(){
        throw new NotImplementedException();
    }
}
