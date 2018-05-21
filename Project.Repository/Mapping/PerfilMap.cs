using Project.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Project.Repository.Mapping
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("Perfil");

            HasKey(p=>p.Id);

            Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
