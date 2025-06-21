using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwiumPoprawa.Models;

[Table("Record")]
public class Record
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int LanguageId { get; set; }
    
    [Required]
    public int TaskId { get; set; }
    
    [Required]
    public int StudentId { get; set; }
    
    [Required]
    [Column(TypeName = "bigint")]
    public long ExecutionTime { get; set; }
    
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedAt { get; set; }
    
    public Language Language { get; set; }
    public Student Student { get; set; }
    public Task Task { get; set; }
}