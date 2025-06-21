using kolokwiumPoprawa.Models;
using Microsoft.EntityFrameworkCore;
using Task = kolokwiumPoprawa.Models.Task;

namespace kolokwiumPoprawa.Data;

public class AppDatabaseContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Language> Languages { get; set; }
    public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);
        
        mb.Entity<Task>().ToTable("Task");
        mb.Entity<Record>().ToTable("Record");
        mb.Entity<Student>().ToTable("Student");
        mb.Entity<Language>().ToTable("Language");

        mb.SeedData();
        
        mb.Entity<Task>()
            .HasOne(t => t.Record)
            .WithOne(r => r.Task);
        
        mb.Entity<Student>()
            .HasOne(t => t.Record)
            .WithOne(r => r.Student);
        
        mb.Entity<Language>()
            .HasOne(t => t.Record)
            .WithOne(r => r.Language);
    }
}