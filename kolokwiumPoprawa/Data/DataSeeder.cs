using kolokwiumPoprawa.Models;
using Microsoft.EntityFrameworkCore;
using Task = kolokwiumPoprawa.Models.Task;

namespace kolokwiumPoprawa.Data;

public static class DataSeeder
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>().HasData(
            new Task { Id = 1, Name = "Task1", Description = "Description for Task1" },
            new Task { Id = 2, Name = "Task2", Description = "Description for Task2" }
        );

        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Jakub", LastName = "Daniel", Email = "jakub.Daniel@pjatk.pl" },
            new Student { Id = 2, FirstName = "Julia", LastName = "Daniel", Email = "julia.Daniel@pjatk.pl" }
        );

        modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, Name = "English" },
            new Language { Id = 2, Name = "Spanish" }
        );

        modelBuilder.Entity<Record>().HasData(
            new Record { Id = 1, LanguageId = 1, TaskId = 1, StudentId = 1, ExecutionTime = 123456, CreatedAt = DateTime.Now },
            new Record { Id = 2, LanguageId = 2, TaskId = 2, StudentId = 2, ExecutionTime = 654321, CreatedAt = DateTime.Now }
        );
    }
}