using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Descricao { get; set; }

        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [StringLength(50)]
        public string? Categoria { get; set; }

        [StringLength(20)]
        public string? Codigo { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public bool Ativo { get; set; } = true;
    }
}
