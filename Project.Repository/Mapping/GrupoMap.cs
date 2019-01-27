using Project.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Project.Repository.Mapping
{
    public class GrupoMap :EntityTypeConfiguration<Grupo>
    {
        public GrupoMap()
        {
            ToTable("Grupo");

            HasKey(g => g.Id);

            Property(g => g.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(g => g.IdGrupo)
                .HasColumnName("IdGrupo")
                .IsOptional();

            Property(g => g.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(50)
                .IsRequired();

            Property(g => g.Status)
                .HasColumnName("Status")
                .HasMaxLength(1)
                .IsRequired();

            //auto-relacionamento..
            HasMany(g => g.Grupos)
                .WithOptional()
                .HasForeignKey(g => g.IdGrupo);

        }
    }
}
