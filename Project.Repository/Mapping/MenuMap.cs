using Project.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Project.Repository.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            ToTable("Menu");

            HasKey(m => m.Id);

            Property(m => m.Id)
                .HasColumnName("Id")
                .IsRequired();

            Property(m => m.IdMenu)
                .HasColumnName("IdMenu")
                .IsOptional();

            Property(m => m.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(50)
                .IsRequired();

            Property(m => m.Path)
                .HasColumnName("Path")
                .HasMaxLength(200)
                .IsRequired();

            Property(m => m.Status)
                .HasColumnName("Status")
                .HasMaxLength(1)
                .IsRequired();


            //auto-relacionamento..
            HasMany(m => m.Menus)
                .WithOptional()
                .HasForeignKey(m=>m.IdMenu);


        }
    }
}
