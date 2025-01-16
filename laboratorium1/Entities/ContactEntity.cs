using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laboratorium1.Entities;

[Table("contacts")]
public class ContactEntity
{
    public int Id { get; set; }

    [MaxLength(50)] 
    [Required] 
    public string FirstName { get; set; }

    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }

    [Column("birth_date")]
    public DateOnly DateBirt { get; set; }
    
    public string PhoneNumber { get; set; }

}