using Project.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Project.Repository.Mapping
{
    public class ItemContaMap : EntityTypeConfiguration<ItemConta>
    {
        public ItemContaMap()
        {
            ToTable("Item_Conta");

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

            Property(c => c.TipoItemConta)
                .HasColumnName("TipoItemConta")
                .HasMaxLength(1)
                .IsRequired();

            //relacionamento fk..
            HasRequired(c => c.Grupo)
                .WithMany(g => g.ItemContas)
                .HasForeignKey(c => c.IdGrupo);

        }
    }
}
