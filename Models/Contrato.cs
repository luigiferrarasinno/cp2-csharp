using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Contrato
    {
        public int Id { get; set; }

        [Required]
        public int ImovelId { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoContrato { get; set; } = string.Empty; // Venda, Locacao

        [Required]
        [StringLength(30)]
        public string NumeroContrato { get; set; } = string.Empty;

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        public int? DuracaoMeses { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Ativo"; // Ativo, Encerrado, Cancelado

        [StringLength(500)]
        public string? Observacoes { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // Navegação
        public virtual Imovel? Imovel { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
