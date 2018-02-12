﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                .HasColumnName("Id_Usuario")
                .HasMaxLength(4)
                .IsRequired();

            Property(u => u.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .IsRequired();

            Property(u => u.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(10)
                .IsRequired();

            Property(u => u.Status)
                .HasColumnName("Status")
                .HasMaxLength(1)
                .IsRequired();

        }
    }
}
