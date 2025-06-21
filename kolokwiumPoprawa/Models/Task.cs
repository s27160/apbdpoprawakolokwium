using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwiumPoprawa.Models;

[Table("Task")]
public class Task
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string Name { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(2000)")]
    public string Description { get; set; }
    
    public Record Record { get; set; }
}