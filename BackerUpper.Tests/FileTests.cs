using System.Data;
using Microsoft.Data.Sqlite;
using Features;

namespace BackerUpper.Tests;

public class FilesTests
{
    [Fact]
    public void GetSqliteConnectionString_ReturnsExpectedFormat()
    {
        SqliteConnection connection = Files.GetSqliteConnection();
        Assert.True(connection.State == ConnectionState.Open, "Expected connection to be Open");
    }

    [Fact]
    public void GetSqliteConnection_CreatesDatabaseWithSetupRows()
    {
        try
        {
            using SqliteConnection connection = Files.GetSqliteConnection();
            Assert.Equal(ConnectionState.Open, connection.State);

            using SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT bit_mask, name FROM setup ORDER BY bit_mask";
            using SqliteDataReader reader = command.ExecuteReader();

            Assert.True(reader.Read(), "Reader expected to be readable but was not");
            Assert.Equal(1, reader.GetInt32(0));
            Assert.Equal("work", reader.GetString(1));

            Assert.True(reader.Read());
            Assert.Equal(2, reader.GetInt32(0));
            Assert.Equal("personal", reader.GetString(1));

            Assert.False(reader.Read());
        }
        finally
        {
            File.Delete("configFiles.Sqlite");
        }
    }
}
