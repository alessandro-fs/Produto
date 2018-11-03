using Produto.Domain.Entities;
using Produto.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace Produto.Infra.Data.Context
{
    public class Contexto : DbContext
    {
        public Contexto()
            :base("ProdutoMetadados")
        {

        }
        #region DB SET'S
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Celula> Celulas { get; set; }
        public DbSet<Setor> Setores { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //--
            //CONFIGURAR POR DEFAULT PK NA TABELA QUE TERMINE COM ID
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //--
            //CONFIGURAR PARA CAMPO STRING VIR COMO VARCHAR E NÃO CHAR
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //--
            //QUANDO NÃO DISSER O VALOR DA STRING, POR PADRÃO SERÁ 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            #region MODELBUILDER CONFIG
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UnidadeConfiguration());
            modelBuilder.Configurations.Add(new CelulaConfiguration());
            modelBuilder.Configurations.Add(new SetorConfiguration());
            #endregion
        }

        //--
        //SOBRESCREVER MÉTODO SAVECHANGES PARA CAMPO DATA CADASTRO
        public override int SaveChanges()
        {
            try
            {
                #region DataCadastro, DataAlteracao
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DataCadastro").IsModified = false;
                    }
                }

                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAlteracao") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("DataAlteracao").IsModified = false;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                    }
                }
                #endregion

                #region UsuarioCadastro, UsuarioAlteracao
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UsuarioCadastro") != null))
                {
                    if (entry.State == EntityState.Modified)
                        entry.Property("UsuarioCadastro").IsModified = false;
                }

                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("UsuarioAlteracao") != null))
                {
                    if (entry.State == EntityState.Added)
                        entry.Property("UsuarioAlteracao").IsModified = false;
                }
                #endregion

                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Exception _exception = ex;
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        _exception = new InvalidOperationException(message, _exception);
                    }
                }
                throw _exception;
            }

        }
    }
}
