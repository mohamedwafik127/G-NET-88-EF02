using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp12;

[Table("EventOrganizers")]
public class Organizer
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(150)]
    public string? CompanyName { get; set; }        

    public bool IsVerified { get; set; }

    public OrganizerProfile? Profile { get; set; }
    public ICollection<Event> Events { get; set; } = new List<Event>();
}