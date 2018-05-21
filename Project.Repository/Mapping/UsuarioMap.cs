using Project.Entity;
using System.Data.Entity.ModelConfiguration;// mapeamentos..

namespace Project.Repository.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        //construtor..
        public UsuarioMap()
        {
            ToTable("Usuario");

            //chave primária
            HasKey(u => u.IdUsuario);

            //propriedades..
            Property(u => u.IdUsuario)
                .HasColumnName("Id")
                .HasMaxLength(4)
                .IsRequired();

            Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(50)
                .IsRequired();

            Property(u => u.IdPerfil)
                .HasColumnName("Id_Perfil")
                .IsRequired();


            HasRequired(u => u.Perfil)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(u => u.IdPerfil);

            Property(u => u.Status)
                .HasColumnName("Status")
                .HasMaxLength(1)
                .IsRequired();

        }
    }
}
