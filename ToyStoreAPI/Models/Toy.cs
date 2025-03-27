using System.ComponentModel.DataAnnotations;

namespace ToyStoreAPI.Models
{
    public class Toy
    {
        [Key]
        public int IdToy { get; set; }
        [Required]
        public string NameToy { get; set; }
        public string TypeToy { get; set; }
        public string Rating { get; set; }
        public string ToySize { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
