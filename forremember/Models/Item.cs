using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace forremember.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [DisplayName("The Price")]
        public decimal Price { get; set; }
        public DateTime CreatedItem { get; set; }
    }
}
