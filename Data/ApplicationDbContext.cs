using Microsoft.EntityFrameworkCore;
using CrudApp.Models;

namespace CrudApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Visita> Visitas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações para Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("RM98047_97648_CLIENTE", "RM98047");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(e => e.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Cpf).HasColumnName("CPF").HasMaxLength(14).IsRequired();
                entity.Property(e => e.Email).HasColumnName("EMAIL").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Telefone).HasColumnName("TELEFONE").HasMaxLength(15);
                entity.Property(e => e.Endereco).HasColumnName("ENDERECO").HasMaxLength(200);
                entity.Property(e => e.Cidade).HasColumnName("CIDADE").HasMaxLength(50);
                entity.Property(e => e.Estado).HasColumnName("ESTADO").HasMaxLength(2);
                entity.Property(e => e.Cep).HasColumnName("CEP").HasMaxLength(8);
                entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO");
            });

            // Configurações para Produto
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("RM98047_97648_PRODUTO", "RM98047");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(e => e.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO").HasMaxLength(500);
                entity.Property(e => e.Preco).HasColumnName("PRECO").HasPrecision(10, 2).IsRequired();
                entity.Property(e => e.Quantidade).HasColumnName("QUANTIDADE").IsRequired();
                entity.Property(e => e.Categoria).HasColumnName("CATEGORIA").HasMaxLength(50);
                entity.Property(e => e.Codigo).HasColumnName("CODIGO").HasMaxLength(20);
                entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO");                entity.Property(e => e.Ativo).HasColumnName("ATIVO")
                    .HasConversion<int>()
                    .IsRequired();
            });

            // Configurações para Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("RM98047_97648_USUARIO", "RM98047");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(e => e.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasColumnName("EMAIL").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Senha).HasColumnName("SENHA").HasMaxLength(255).IsRequired();
                entity.Property(e => e.Tipo).HasColumnName("TIPO").HasMaxLength(20).IsRequired();
                entity.Property(e => e.Ativo).HasColumnName("ATIVO")
                    .HasConversion<int>()
                    .IsRequired();                entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO");
                entity.Property(e => e.UltimoAcesso).HasColumnName("ULTIMO_ACESSO");
            });

            // Configurações para Imovel
            modelBuilder.Entity<Imovel>(entity =>
            {
                entity.ToTable("RM98047_97648_IMOVEL", "RM98047");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(e => e.Titulo).HasColumnName("TITULO").HasMaxLength(100).IsRequired();
                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO").HasMaxLength(500).IsRequired();
                entity.Property(e => e.TipoImovel).HasColumnName("TIPO_IMOVEL").HasMaxLength(20).IsRequired();
                entity.Property(e => e.Finalidade).HasColumnName("FINALIDADE").HasMaxLength(20).IsRequired();
                entity.Property(e => e.ValorVenda).HasColumnName("VALOR_VENDA").HasPrecision(12, 2).IsRequired();
                entity.Property(e => e.ValorLocacao).HasColumnName("VALOR_LOCACAO").HasPrecision(10, 2).IsRequired();
                entity.Property(e => e.Endereco).HasColumnName("ENDERECO").HasMaxLength(200).IsRequired();
                entity.Property(e => e.Bairro).HasColumnName("BAIRRO").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Cidade).HasColumnName("CIDADE").HasMaxLength(50).IsRequired();
                entity.Property(e => e.Estado).HasColumnName("ESTADO").HasMaxLength(2).IsRequired();
                entity.Property(e => e.Cep).HasColumnName("CEP").HasMaxLength(8).IsRequired();
                entity.Property(e => e.Quartos).HasColumnName("QUARTOS");
                entity.Property(e => e.Banheiros).HasColumnName("BANHEIROS");
                entity.Property(e => e.Vagas).HasColumnName("VAGAS");
                entity.Property(e => e.AreaTotal).HasColumnName("AREA_TOTAL").HasPrecision(10, 2);
                entity.Property(e => e.AreaConstruida).HasColumnName("AREA_CONSTRUIDA").HasPrecision(10, 2);
                entity.Property(e => e.Proprietario).HasColumnName("PROPRIETARIO").HasMaxLength(100);
                entity.Property(e => e.TelefoneProprietario).HasColumnName("TELEFONE_PROPRIETARIO").HasMaxLength(15);
                entity.Property(e => e.Status).HasColumnName("STATUS").HasMaxLength(20).IsRequired();
                entity.Property(e => e.Ativo).HasColumnName("ATIVO").HasConversion<int>().IsRequired();
                entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO");
            });

            // Configurações para Contrato
            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.ToTable("RM98047_97648_CONTRATO", "RM98047");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(e => e.ImovelId).HasColumnName("IMOVEL_ID").IsRequired();
                entity.Property(e => e.ClienteId).HasColumnName("CLIENTE_ID").IsRequired();
                entity.Property(e => e.TipoContrato).HasColumnName("TIPO_CONTRATO").HasMaxLength(20).IsRequired();
                entity.Property(e => e.NumeroContrato).HasColumnName("NUMERO_CONTRATO").HasMaxLength(30).IsRequired();
                entity.Property(e => e.Valor).HasColumnName("VALOR").HasPrecision(12, 2).IsRequired();
                entity.Property(e => e.DataInicio).HasColumnName("DATA_INICIO").IsRequired();
                entity.Property(e => e.DataFim).HasColumnName("DATA_FIM");
                entity.Property(e => e.DuracaoMeses).HasColumnName("DURACAO_MESES");
                entity.Property(e => e.Status).HasColumnName("STATUS").HasMaxLength(20).IsRequired();
                entity.Property(e => e.Observacoes).HasColumnName("OBSERVACOES").HasMaxLength(500);
                entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO");
                
                entity.HasOne(e => e.Imovel)
                    .WithMany()
                    .HasForeignKey(e => e.ImovelId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(e => e.Cliente)
                    .WithMany()
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configurações para Visita
            modelBuilder.Entity<Visita>(entity =>
            {
                entity.ToTable("RM98047_97648_VISITA", "RM98047");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();
                entity.Property(e => e.ImovelId).HasColumnName("IMOVEL_ID").IsRequired();
                entity.Property(e => e.ClienteId).HasColumnName("CLIENTE_ID").IsRequired();
                entity.Property(e => e.DataVisita).HasColumnName("DATA_VISITA").IsRequired();
                entity.Property(e => e.HoraInicio).HasColumnName("HORA_INICIO").IsRequired();
                entity.Property(e => e.HoraFim).HasColumnName("HORA_FIM").IsRequired();
                entity.Property(e => e.Status).HasColumnName("STATUS").HasMaxLength(20).IsRequired();
                entity.Property(e => e.NomeInteressado).HasColumnName("NOME_INTERESSADO").HasMaxLength(100);
                entity.Property(e => e.TelefoneInteressado).HasColumnName("TELEFONE_INTERESSADO").HasMaxLength(15);
                entity.Property(e => e.EmailInteressado).HasColumnName("EMAIL_INTERESSADO").HasMaxLength(100);
                entity.Property(e => e.Observacoes).HasColumnName("OBSERVACOES").HasMaxLength(500);
                entity.Property(e => e.DataCadastro).HasColumnName("DATA_CADASTRO");
                
                entity.HasOne(e => e.Imovel)
                    .WithMany()
                    .HasForeignKey(e => e.ImovelId)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne(e => e.Cliente)
                    .WithMany()
                    .HasForeignKey(e => e.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
