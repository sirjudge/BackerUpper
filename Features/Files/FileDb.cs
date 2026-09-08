using Microsoft.EntityFrameworkCore;

namespace Features.Files;

//Built off this documentation
//https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
public class FileContext : DbContext {
    public DbSet<BackupFile> Files { get; set; }
    public DbSet<BackUpAudit> BackUpAudits { get; set; }
    public DbSet<CopyOptions> CopyOptions { get; set; }

    public string DbPath { get; }

    public FileContext()
    {
        const Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "backerUpper.db");
    }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

//TODO: This should be internal I think so only things within the Files namespace
//can access it
public class BackupFileDbHandler() {
    public List<BackupFile> GetBackupFiles()
    {
        using var dbContext = new FileContext();
        return dbContext.Files.ToList();
    }

    public BackupFile GetBackupFile(int backupFileId){
        using var dbContext = new FileContext();
        return dbContext.Files
            .Where(file => file.BackUpId == backupFileId)
            .First();
    }

    public void AddBackupFile(BackupFile file){
        using var dbContext = new FileContext();
        dbContext.Add(file);
        dbContext.SaveChanges();
    }

    public void UpdateBackupFile(BackupFile file){
        if (!file.BackUpId.HasValue){
            throw new ArgumentException("Backup file Id is null when it should not be when updating backup file");
        }

        using var dbContext = new FileContext();
        var currentFile = GetBackupFile(file.BackUpId.Value);
        currentFile.FileName = file.FileName;
        currentFile.FilePath = file.FilePath;
        currentFile.LastModified = DateTime.Now;
    }

    public void RemoveBackupFile(int backupFileId){
        var file = GetBackupFile(backupFileId);
        RemoveBackupFile(file);
    }

    public void RemoveBackupFile(BackupFile file){
        using var dbContext = new FileContext();
        dbContext.Remove(file);
        dbContext.SaveChanges();
    }
}
