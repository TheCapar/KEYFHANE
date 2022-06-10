using System.ComponentModel.DataAnnotations;

namespace KeyfHane.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public virtual Profile Profile { get; set; }
        public int ProfileId { get; set; }
    }
}
