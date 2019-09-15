using Project.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Project.Repository.Mapping
{
    public class ContaMap : EntityTypeConfiguration<Conta>
    {
        public ContaMap()
        {
            ToTable("Conta");

            HasKey(c => c.Id);

            Property(c => c.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(c => c.Descricao)
                .HasColumnName("Descricao")
                .IsRequired();

            Property(c => c.Status)
                .HasColumnName("Status")
                .HasMaxLength(1)
                .IsRequired();
        }
    }
}
