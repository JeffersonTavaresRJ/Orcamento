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

            //muito para muitos.. 
            //o mapeamento pode ser feito em uma só classe
            HasMany(Perfil => Perfil.Menus)
                .WithMany(Menu => Menu.Perfis)
                .Map(x => {
                    x.ToTable("Perfil_Menu");
                    x.MapLeftKey("IdPerfil");
                    x.MapRightKey("IdMenu");
                    });
        }
    }
}
