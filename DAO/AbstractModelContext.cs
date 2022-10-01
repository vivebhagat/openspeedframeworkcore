using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.DAO.Access;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using SpeedFramework.Common.CoreModels;

namespace SpeedFramework.DAO.Commmon
{
    public abstract class AbstractModelContext : DbContext
    {
        protected IAccountContext AccountContext { get; set; }
        public AbstractModelContext(IAccountContext accountContext) : base(new DbContextOptionsBuilder<AbstractModelContext>().UseSqlServer(accountContext.ConnectionString).Options) //(new IDbContextOptions { new SqlConnectionStringBuilder(accountContext.ConnectionString}))
        {
            this.AccountContext = accountContext;
        }
        
        public AbstractModelContext() : base()
        {

        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.AccountContext.ConnectionString);
        }



        public IList<T> GetClassByType<T>()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                              .Where(p => typeof(T)
                              .IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface)
                              .Select(c => (T)Activator.CreateInstance(c)).ToList();
        }
        public IList<string> GetClassByTypeNames<T>(IModelContext db)
        {
          //  MetadataWorkspace workspace = ((IObjectContextAdapter)db.GetDbContext()).ObjectContext.MetadataWorkspace;
        //    ObjectItemCollection itemCollection = (ObjectItemCollection)(workspace.GetItemCollection(DataSpace.OSpace));

          //  List<EntityType> _entityTypes = itemCollection.OfType<EntityType>()
           //     .ToList();
            List<string> result = new List<string>();


            List<IEntityType> _entityTypes = db.GetDbContext().Model.GetEntityTypes().ToList();

            IList<Tuple<string, string>> _result = new List<Tuple<string,string>>();
            List<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            List<Type> all_types = new List<Type>();
            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    all_types.AddRange(assembly.GetTypes().ToList());
                }
                catch (Exception _e)
                {
                }
            }
            foreach (EntityType type in _entityTypes)
            {
                Type objectType = all_types.Where(m => m.FullName == type.FullName()).FirstOrDefault();
                // _result.Add(new Tuple<string, string>(objectType.AssemblyQualifiedName));
                result.Add(objectType.AssemblyQualifiedName);
            }

            return result;
        }

       

  //      public abstract IModelContext Create();

        /*
        public IDbSet<T> Set<T>() where T : class, TEntity
        {
            return base.Set<T>();
        }
        

        public DbSet Set(Type type) 
        {            
            return base.Set(type);
        }*/

        public void MarkCreatedDate(Auditable auditable)
        {

            auditable.CreatedDate = DateTime.Now;
        }

        public void MarkModifiedDate(Auditable auditable)
        {
            auditable.ModifiedDate = DateTime.Now;
            base.Entry(auditable).Property(m => m.CreatedDate).IsModified = false;
        }


        public void SetStateAsAdded<T>(T @object) where T : class, TEntity
        {
            base.Entry(@object).State = EntityState.Added;
        }

        public DbContext GetDbContext()
        {
            return (DbContext)this;
        }

        public void SetStateAsNotModified(Auditable @object)
        {
            base.Entry(@object).Property(m => m.CreatedDate).IsModified = false;
            base.Entry(@object).Property(m => m.ModifiedDate).IsModified = false;
        }

        public void SetPropertyAsNotModified(TEntity @object, string s)
        {
            base.Entry(@object).Property(s).IsModified = false;
        }

        public void SetStateAsModified<T>(T @object) where T : class, TEntity
        {
            base.Entry(@object).State = EntityState.Modified;
        }
        public void SetObjectStateAsModified(object @object)
        {
            base.Entry(@object).State = EntityState.Modified;
        }

        public void SetStateAsDetached<T>(T @object) where T : class, TEntity
        {
            base.Entry(@object).State = EntityState.Detached;
        }
        /*
        public DbRawSqlQuery GetRawQuery(Type t, string s, params object[] o)
        {
            return Database.GetDbConnection().CreateCommand();
            SqlQuery(t, s,o);
        }*/
    }
}