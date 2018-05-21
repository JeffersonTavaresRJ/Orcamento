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

            HasRequired(m => m.Menu)
                .WithMany(m => m.PerfilMenu)
                .HasForeignKey(m => m.IdMenu)
                .WillCascadeOnDelete(false);


            HasRequired(p => p.Perfil)
                .WithMany(p => p.PerfilMenu)
                .HasForeignKey(p => p.IdPerfil)
                .WillCascadeOnDelete(false);


        }
    }
}
