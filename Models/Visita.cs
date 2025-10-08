using System.ComponentModel.DataAnnotations;

namespace CrudApp.Models
{
    public class Visita
    {
        public int Id { get; set; }

        [Required]
        public int ImovelId { get; set; }

        [Required]
        public int ClienteId { get; set; }        [Required]
        public DateTime DataVisita { get; set; }

        [Required]
        public DateTime HoraInicio { get; set; }

        [Required]
        public DateTime HoraFim { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Agendada"; // Agendada, Confirmada, Realizada, Cancelada

        [StringLength(100)]
        public string? NomeInteressado { get; set; }

        [StringLength(15)]
        public string? TelefoneInteressado { get; set; }

        [StringLength(100)]
        public string? EmailInteressado { get; set; }

        [StringLength(500)]
        public string? Observacoes { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        // Navegação
        public virtual Imovel? Imovel { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
