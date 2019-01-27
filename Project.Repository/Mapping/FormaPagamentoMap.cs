using Project.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Project.Repository.Mapping
{
    public class FormaPagamentoMap : EntityTypeConfiguration<FormaPagamento>
    {
        public FormaPagamentoMap()
        {
            ToTable("Forma_Pagamento");

            HasKey(f => f.Id);

            Property(f => f.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(f => f.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(50)
                .IsRequired();

            Property(f => f.Status)
                .HasColumnName("Status")
                .HasMaxLength(1)
                .IsRequired();
                
        }
    }
}
