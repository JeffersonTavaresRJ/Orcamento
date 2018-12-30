using Project.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Project.Repository.Mapping
{
    public class PerfilMenuMap : EntityTypeConfiguration<PerfilMenu>
    {
        public PerfilMenuMap()
        {
            ToTable("Perfil_Menu");

            HasKey(pm => new { pm.IdPerfil, pm.IdMenu });

            Property(pm => pm.IdPerfil)
                .HasColumnName("IdPerfil")
                .IsRequired();

            Property(pm => pm.IdMenu)
               .HasColumnName("IdMenu")
               .IsRequired();

        }
    }
}
