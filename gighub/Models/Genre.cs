using System.ComponentModel.DataAnnotations;

namespace gighub.Models
{
    public class Genre
    {
        public byte id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}