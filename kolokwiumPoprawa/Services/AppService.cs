using kolokwiumPoprawa.Data;
using kolokwiumPoprawa.Dto;
using kolokwiumPoprawa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = kolokwiumPoprawa.Models.Task;

namespace kolokwiumPoprawa.Services;

public class AppService
{
    private AppDatabaseContext _context { get; set; }

    public AppService(AppDatabaseContext context)
    {
        _context = context;
    }

    public List<RecordDto> GetRecords(SearchRecordsDto searchRecordsDto)
    {
        IQueryable<Record> records = _context.Records
            .Include(r => r.Student)
            .Include(r => r.Language)
            .Include(r => r.Task);

        if (searchRecordsDto.LanguageId != null)
        {
            records = records.Where(r => r.LanguageId == searchRecordsDto.LanguageId);
        }
        
        if (searchRecordsDto.TaskId != null)
        {
            records = records.Where(r => r.TaskId == searchRecordsDto.TaskId);
        }

        if (searchRecordsDto.CreatedAt != null)
        {
            records = records.Where(r => r.CreatedAt == searchRecordsDto.CreatedAt.Value);
        }

        return records.Select(record => new RecordDto()
            {
                Id = record.Id,
                Language = new LanguageDto() { Id = record.Language.Id, Name = record.Language.Name },
                Task = new TaskDto()
                    { Id = record.Task.Id, Description = record.Task.Description, Name = record.Task.Name },
                Student = new StudentDto()
                {
                    Id = record.Student.Id, Email = record.Student.Email, FirstName = record.Student.FirstName,
                    LastName = record.Student.LastName
                },
                CreatedAt = record.CreatedAt.ToString("MM/dd/yyyy H:mm:ss"),
                ExecutionTime = record.ExecutionTime,
            })
            .ToList();
    }

    public object InsertRecord(CreateRecordDto createRecordDto)
    {
        if (!_context.Languages.Any(l => l.Id == createRecordDto.LanguageId))
            throw new ApplicationException("Language not found");

        if (!_context.Students.Any(s => s.Id == createRecordDto.StudentId))
            throw new ApplicationException("Student not found");

        int taskId;

        if (createRecordDto.Task.Id == null)
        {
            var task = new Task()
            {
                Name = createRecordDto.Task.Name,
                Description = createRecordDto.Task.Description,
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();

            taskId = task.Id;
        }
        else
        {
            if (!_context.Tasks.Any(t => t.Id == createRecordDto.Task.Id))
                throw new ApplicationException("Task not found");
            taskId = createRecordDto.Task.Id.Value;
        }

        var record = new Record()
        {
            LanguageId = createRecordDto.LanguageId,
            StudentId = createRecordDto.StudentId,
            TaskId = taskId,
            ExecutionTime = createRecordDto.ExecutionTime,
            CreatedAt = DateTime.Now
        };
        _context.Records.Add(record);
        _context.SaveChanges();

        return new
        {
            id = record.Id
        };
    }
}