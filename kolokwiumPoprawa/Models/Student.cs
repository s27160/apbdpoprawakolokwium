using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwiumPoprawa.Models;

[Table("Student")]
public class Student
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string FirstName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100)")]
    public string LastName { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(250) UNIQUE")]
    public string Email { get; set; }
    
    public Record Record { get; set; }
}