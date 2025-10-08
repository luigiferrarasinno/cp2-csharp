using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [StringLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(15)]
        public string? Telefone { get; set; }

        [StringLength(200)]
        public string? Endereco { get; set; }

        [StringLength(50)]
        public string? Cidade { get; set; }

        [StringLength(2)]
        public string? Estado { get; set; }

        [StringLength(8)]
        public string? Cep { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
