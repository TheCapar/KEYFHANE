using System.ComponentModel.DataAnnotations;

namespace KeyfHane.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string AboutMe { get; set; }
        public string City { get; set; }
    }
}
