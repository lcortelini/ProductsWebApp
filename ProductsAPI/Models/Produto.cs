using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "O nome do produto deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataInclusao { get; set; }
    }
}
