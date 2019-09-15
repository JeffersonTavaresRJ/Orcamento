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
               : base(ConfigurationManager.ConnectionStrings["OrcamentoLocal"].ConnectionString)
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
            

            /*foi utulizado para tratar erro na utilização do linq to sql
              para carregar os valores dos objetos filhos de cada classe.
              Foi solucionado implementando "join" nas consultas linq 
              (ex.: classe MenuPersistence, método ListarMenu() :*/

            //Configuration.LazyLoadingEnabled = lazyLoadingEnabled;

            Configuration.LazyLoadingEnabled = false;
        }

        //Regra 3) Sobrescrever o método OnModelCreating        
        //para configurar as entidades mapeadas no projeto.. 
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PerfilMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new ItemContaMap());
            modelBuilder.Configurations.Add(new GrupoMap());
            modelBuilder.Configurations.Add(new FormaPagamentoMap());
            modelBuilder.Configurations.Add(new ContaMap());
            //modelBuilder.Configurations.Add(new PerfilMenuMap());
        }

        //Regra 4) Declarar um DbSet para cada entidade..         
        //permitir a realizar as operações de CRUD no banco de dados 

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<ItemConta> ItemConta { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Conta> Conta { get; set; }
        //public DbSet<PerfilMenu> PerfilMenu { get; set; }
    }
}
