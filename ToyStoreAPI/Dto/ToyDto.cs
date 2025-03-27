using System.ComponentModel.DataAnnotations;

namespace ToyStoreAPI.Dto
{
    public class ToyDto
    {
        [Required(ErrorMessage = "O nome do brinquedo é obrigatório.")]
        [MinLength(2, ErrorMessage = "O nome deve ter pelo menos 2 caracteres.")]
        public string NameToy { get; set; }
        public string TypeToy { get; set; }
        public string Rating { get; set; }
        public string ToySize { get; set; }
        [Required(ErrorMessage = "O preço do brinquedo é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Price { get; set; }
    }
}
