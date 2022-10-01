using Common.DAO.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Model.Custom.FileSystem;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Model.Custom.Scripting;
using SpeedFramework.DAO.Model.Custom.StateMachine;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;

namespace SpeedFramework.DAO.Commmon
{
    class DummyAccountContext : IAccountContext
    {
        public string Domain { get; set; }
        public string ConnectionString { get; set; }
        public string default_username { get; set; }
        public string default_password { get; set; }
        public string default_role { get; set; }
        public string ServerDirectoryRoot { get; set; }
    }
    public class ModelContextFactory : IDesignTimeDbContextFactory<ModelContext>
    {
    
        public ModelContext CreateDbContext(string[] args)
        {
            
            IAccountContext accountContext = new DummyAccountContext();
            accountContext.ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\vivek\Desktop\Transfer laptop\SpeedFrameworksCore\SpeedFrameworksCore\SpeedFrameworksCore\Data\SPFCore.mdf;Initial Catalog=SPFCore;Integrated Security=True";
            ModelContext m = new ModelContext(accountContext);
            return m;
        }
    }

    public class ModelContext : AbstractModelContext, IModelContext
    {
        public ModelContext(IAccountContext accountContext) : base(accountContext)
        {
//            this.Database.EnsureCreated();
            //  string s = base.Database.Connection.DataSource;
            //  this.Configuration.LazyLoadingEnabled = true;
            //  this.Configuration.ProxyCreationEnabled = true;
        }
        
/*        public ModelContext() : base()
        {
           // this.Database.EnsureCreated();
            //    string s = base.Database.Connection.DataSource;
            //   this.Configuration.LazyLoadingEnabled = true;
            //   this.Configuration.ProxyCreationEnabled = true;
        }*/


        public DbSet<Widget> Widgets { get; set; }
        public DbSet<ApplicationEntityAccessExpression> ApplicationEntityAccessExpressions { get; set; }
        public DbSet<WidgetData> WidgetDatas { get; set; }
        public DbSet<WidgetParameter> WidgetParameters { get; set; }
        public DbSet<WidgetParameterType> WidgetParameterTypes { get; set; }
        public DbSet<WidgetTemplate> WidgetTemplates { get; set; }
        public DbSet<WidgetType> WidgetTypes { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<CommunicationType> CommunicationTypes { get; set; }
        public DbSet<CommunicationTemplate> CommunicationTemplates { get; set; }
        public DbSet<CommunicationTemplateUserRecieverMap> CommunicationTemplateUserRecieverMaps { get; set; }
        public DbSet<CommunicationTemplateRoleRecieverMap> CommunicationTemplateRoleRecieverMaps { get; set; }
        public DbSet<ApplicationEntityProperty> ApplicationEntityProperties { get; set; }
        public DbSet<ApplicationEntity> ApplicationEntities { get; set; }
        public DbSet<FormEvent> FormEvents { get; set; }
        public DbSet<FieldEvent> FieldEvents { get; set; }
        public DbSet<FilterResultField> FilterResultFields { get; set; }
        public DbSet<StateAction> StateActions { get; set; }
        public DbSet<StateActionAccess> StateActionAccesses { get; set; }
        public DbSet<StateActionStatement> StateActionStatements { get; set; }
        public DbSet<FilterList> FilterLists { get; set; }
        public DbSet<CustomPage> CustomPages { get; set; }
        public DbSet<CustomPageLink> CustomPageLinks { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<EntityScript> EntityScripts { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<FilterField> FilterFields { get; set; }
        public DbSet<FieldType> FieldTypes { get; set; }
        public DbSet<FormFieldMap> FormFieldMaps { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<OptionList> OptionLists { get; set; }
        public DbSet<PageAccess> PageAccesses { get; set; }
        public DbSet<PageLink> PageLinks { get; set; }
        public DbSet<UserDefinedRole> UserDefinedRoles { get; set; }
        public DbSet<UserDefinedRoleMap> UserDefinedRoleMaps { get; set; }
        public DbSet<UserDefinedRoleToUserMap> UserDefinedRoleToUserMaps { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Script> Scripts { get; set; }
        public DbSet<IntUser> IntUsers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OwnershipEntityAccess> OwnershipEntityAccesses { get; set; }


        public DbSet<ApplicationFile> ApplicationFiles { get; set; }
        public DbSet<ApplicationFileGroup> ApplicationFileGroups { get; set; }
        public DbSet<ServerDirectory> ServerDirectories { get; set; }
        public DbSet<ApplicationFileType> ApplicationFileTypes { get; set; }
        public DbSet<GroupToApplicationFileMapping> GroupToApplicationFileMappings { get; set; }




        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.HasDefaultSchema("data");

        }

        /*
        public override IModelContext Create()
        {
            return new ModelContext();
        }*/
        
    }
}
