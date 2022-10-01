using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SpeedFramework.Common.CoreModels;
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
    public interface IModelContext 
    {
        DbSet<ApplicationEntity> ApplicationEntities { get; set; }
        DbSet<ApplicationEntityAccessExpression> ApplicationEntityAccessExpressions { get; set; }
        DbSet<ApplicationEntityProperty> ApplicationEntityProperties { get; set; }
        DbSet<Communication> Communications { get; set; }
        DbSet<CommunicationTemplateRoleRecieverMap> CommunicationTemplateRoleRecieverMaps { get; set; }
        DbSet<CommunicationTemplate> CommunicationTemplates { get; set; }
        DbSet<CommunicationTemplateUserRecieverMap> CommunicationTemplateUserRecieverMaps { get; set; }
        DbSet<CommunicationType> CommunicationTypes { get; set; }
        DbSet<CustomPageLink> CustomPageLinks { get; set; }
        DbSet<CustomPage> CustomPages { get; set; }
        DbSet<Dashboard> Dashboards { get; set; }
        DbSet<EntityScript> EntityScripts { get; set; }
        DbSet<FieldEvent> FieldEvents { get; set; }
        DbSet<Field> Fields { get; set; }



        DbSet<FieldType> FieldTypes { get; set; }
        DbSet<Filter> Filters { get; set; }
        DbSet<FilterField> FilterFields { get; set; }
        DbSet<FilterList> FilterLists { get; set; }
        DbSet<FilterResultField> FilterResultFields { get; set; }
        DbSet<FormEvent> FormEvents { get; set; }
        DbSet<FormFieldMap> FormFieldMaps { get; set; }
        DbSet<Form> Forms { get; set; }
        DbSet<IntUser> IntUsers { get; set; }
        DbSet<Label> Labels { get; set; }
        DbSet<OptionList> OptionLists { get; set; }
        DbSet<Option> Options { get; set; }
        DbSet<Organization> Organizations { get; set; }
        DbSet<OwnershipEntityAccess> OwnershipEntityAccesses { get; set; }
        DbSet<PageAccess> PageAccesses { get; set; }
        DbSet<PageLink> PageLinks { get; set; }
        DbSet<Script> Scripts { get; set; }
        DbSet<StateActionAccess> StateActionAccesses { get; set; }
        DbSet<StateAction> StateActions { get; set; }
        DbSet<StateActionStatement> StateActionStatements { get; set; }
        DbSet<UserDefinedRoleMap> UserDefinedRoleMaps { get; set; }
        DbSet<UserDefinedRole> UserDefinedRoles { get; set; }
        DbSet<UserDefinedRoleToUserMap> UserDefinedRoleToUserMaps { get; set; }
        DbSet<WidgetData> WidgetDatas { get; set; }
        DbSet<WidgetParameter> WidgetParameters { get; set; }
        DbSet<WidgetParameterType> WidgetParameterTypes { get; set; }
        DbSet<Widget> Widgets { get; set; }
        DbSet<WidgetTemplate> WidgetTemplates { get; set; }
        DbSet<WidgetType> WidgetTypes { get; set; }

        DbSet<ApplicationFile> ApplicationFiles { get; set; }
        DbSet<ApplicationFileGroup> ApplicationFileGroups { get; set; }
        DbSet<ServerDirectory> ServerDirectories { get; set; }
        DbSet<ApplicationFileType> ApplicationFileTypes { get; set; }
        DbSet<GroupToApplicationFileMapping> GroupToApplicationFileMappings { get; set; }



        int SaveChanges();
//        IModelContext Create();
        IList<T> GetClassByType<T>();
        IList<string> GetClassByTypeNames<T>(IModelContext db);
        

        void MarkCreatedDate(Auditable auditable);
        void MarkModifiedDate(Auditable auditable);
      //  DbSet<T> Set<T>() where T : class, TEntity;

        void SetStateAsAdded<T>(T @object) where T : class, TEntity;
        void SetStateAsModified<T>(T @object) where T : class, TEntity;
        void SetObjectStateAsModified(object @object);
        void SetStateAsNotModified(Auditable @object);
        void SetStateAsDetached<T>(T @object) where T : class, TEntity;
        void SetPropertyAsNotModified(TEntity @object, string s);
    //    DbSet Set(Type propertyType);
     //   DbRawSqlQuery GetRawQuery(Type t, string s, params object[] o);
        DbContext GetDbContext();
        void Dispose();
    }
}