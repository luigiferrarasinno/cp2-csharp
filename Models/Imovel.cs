using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Imovel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string TipoImovel { get; set; } = string.Empty; // Casa, Apartamento, Comercial, Terreno

        [Required]
        [StringLength(20)]
        public string Finalidade { get; set; } = string.Empty; // Venda, Locacao, Ambos

        [Required]
        public decimal ValorVenda { get; set; }

        [Required]
        public decimal ValorLocacao { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        [StringLength(2)]
        public string Estado { get; set; } = string.Empty;

        [Required]
        [StringLength(8)]
        public string Cep { get; set; } = string.Empty;

        public int Quartos { get; set; }

        public int Banheiros { get; set; }

        public int Vagas { get; set; }

        public decimal AreaTotal { get; set; }

        public decimal AreaConstruida { get; set; }

        [StringLength(100)]
        public string? Proprietario { get; set; }

        [StringLength(15)]
        public string? TelefoneProprietario { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Disponivel"; // Disponivel, Ocupado, Manutencao

        public bool Ativo { get; set; } = true;

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
