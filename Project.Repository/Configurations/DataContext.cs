using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.Entity;

using Project.Entity;
using Project.Repository.Mapping;

namespace Project.Repository.Configurations
{
    //Regra 1) Herdar DbContext 
    public class DataContextOrcamento : DbContext
    {
        //Regra 2) Construtor que envie para o DbContext a connectionstring 

        public DataContextOrcamento() 
            : base (@"Data Source=LAPTOP-A2L56V3Q\SQLEXPRESS;Initial Catalog=Orcamento;Integrated Security=True"
                  /*ConfigurationManager.ConnectionStrings["Orcamento"].ConnectionString*/)
        {

        }

        //Regra 3) Sobrescrever o método OnModelCreating        
        //para configurar as entidades mapeadas no projeto.. 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PerfilMap());
        }

        //Regra 4) Declarar um DbSet para cada entidade..         
        //permitir a realizar as operações de CRUD no banco de dados 

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
    }
}
