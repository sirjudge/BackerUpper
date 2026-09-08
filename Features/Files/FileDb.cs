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

    public BackupFile GetBackupFile(Guid backupFileId){
        using var dbContext = new FileContext();
        return dbContext.Files
            .First(file => file.BackUpId == backupFileId);
    }

    //TODO: if adding we have a fileId what that about
    //do we just Guid it? I think that good idea because too lazy to do otherwise
    public void AddBackupFile(BackupFile file){
        using var dbContext = new FileContext();
        dbContext.Add(file);
        dbContext.SaveChanges();
    }

    public void UpdateBackupFile(BackupFile file){
        using var dbContext = new FileContext();
        var currentFile = GetBackupFile(file.BackUpId);
        currentFile.FileName = file.FileName;
        currentFile.FilePath = file.FilePath;
        currentFile.LastModified = DateTime.Now;
    }

    public void RemoveBackupFile(Guid backupFileId){
        var file = GetBackupFile(backupFileId);
        RemoveBackupFile(file);
    }

    public void RemoveBackupFile(BackupFile file){
        using var dbContext = new FileContext();
        dbContext.Remove(file);
        dbContext.SaveChanges();
    }
}
