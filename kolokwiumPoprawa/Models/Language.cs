using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwiumPoprawa.Models;

[Table("Language")]
public class Language
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName = "varchar(100) UNIQUE")]
    public string Name { get; set; }
    
    public Record Record { get; set; }
}