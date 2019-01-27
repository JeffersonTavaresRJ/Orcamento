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

            Property(c => c.IdGrupo)
                .HasColumnName("IdGrupo")
                .IsOptional();

            Property(c => c.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(50)
                .IsRequired();

            Property(c => c.Status)
                .HasColumnName("Status")
                .HasMaxLength(1)
                .IsRequired();

            Property(c => c.TipoConta)
                .HasColumnName("TipoConta")
                .HasMaxLength(1)
                .IsRequired();

            //relacionamento fk..
            HasRequired(c => c.Grupo)
                .WithMany(g => g.Contas)
                .HasForeignKey(c => c.IdGrupo);

        }
    }
}
