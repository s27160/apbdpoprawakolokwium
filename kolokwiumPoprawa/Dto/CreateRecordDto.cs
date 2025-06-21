namespace kolokwiumPoprawa.Dto;

public class CreateRecordDto
{
    public int LanguageId { get; set; }
    public int StudentId { get; set; }
    public TaskDto Task { get; set; }
    public long ExecutionTime { get; set; }
    public DateTime CreatedAt { get; set; }
}