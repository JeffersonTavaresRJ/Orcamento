using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Project.Repository.Mapping
{
    public class PerfilMap : EntityTypeConfiguration<Perfil>
    {
        public PerfilMap()
        {
            ToTable("Perfil");

            HasKey(p=>p.IdPerfil);

            Property(p => p.IdPerfil)
                .HasColumnName("Id")
                .IsRequired();

            Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
