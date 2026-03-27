using Microsoft.EntityFrameworkCore;

namespace Features.Files;

public class FileContext : DbContext {
    public DbSet<BackupFile> Files { get; set; }
    public DbSet<BackUpAudit> BackUpAudits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=BackerUpper.db");
        base.OnConfiguring(optionsBuilder);
    }
}

public class BackupFileDbHandler() {
    public void AddBackupFile(BackupFile file){
        using var dbContext = new FileContext();
        dbContext.Add(file);
        dbContext.SaveChanges();
    }
}
