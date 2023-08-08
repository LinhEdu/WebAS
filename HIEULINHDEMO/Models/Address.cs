using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIEULINHDEMO.Models;

public class Address
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Position { get; set; }
    
    [Required]
    public int PeopleId { get; set; }
    [ForeignKey("PeopleId")]
    public People People { get; set; }
}