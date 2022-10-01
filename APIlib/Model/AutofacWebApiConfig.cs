using Common.DAO.Access;
using DAO.CQ;
using DAO.CQ.Access.PagAccessCQ.Query;
using DAO.CQ.Custom.UiSetup.Widget.WidgetDataCQ.Command;
using Microsoft.Extensions.DependencyInjection;
using SpeedFramework.APILib.Models.Attributs;
using SpeedFramework.APILib.Models.Authentication;
using SpeedFramework.DAO.Repository.Implementation;
using SpeedFramework.DAO.Repository.Interfaces;
using WebApi.Helpers;
using WebApi.Services;

namespace SpeedFramework.APILib.Models
{
    public class AutofacWebApiConfig
    {
        /*
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {),typeof( 

            Container = builder.Build();

            return Container;
        }*/


        public static void BuildContatainer(IServiceCollection builder)
        {
          //  builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.AddScoped(typeof(IOwnershipEntityAccessRepository),typeof( OwnershipEntityAccessRepository));
            builder.AddScoped(typeof(IApplicationEntityAccessExpressionRepository),typeof(ApplicationEntityAccessExpressionRepository));

            builder.AddScoped(typeof(IWidgetRepository),typeof(WidgetRepository));
            builder.AddScoped(typeof(IWidgetDataRepository),typeof(WidgetDataRepository));
            builder.AddScoped(typeof(IWidgetTypeRepository),typeof(WidgetTypeRepository));
            builder.AddScoped(typeof(IWidgetTemplateRepository),typeof(WidgetTemplateRepository));
            builder.AddScoped(typeof(IWidgetParameterRepository),typeof(WidgetParameterRepository));
            builder.AddScoped(typeof(IWidgetParameterTypeRepository),typeof(WidgetParameterTypeRepository));

            builder.AddScoped(typeof(IIntUserRepository),typeof(IntUserRepository));
            builder.AddScoped(typeof(ICommunicationRepository),typeof(CommunicationRepository));
            builder.AddScoped(typeof(IUserDefinedRoleToUserMapRepository),typeof(UserDefinedRoleToUserMapRepository));
            builder.AddScoped(typeof(ICommunicationTypeRepository),typeof(CommunicationTypeRepository));
            builder.AddScoped(typeof(ICommunicationTemplateRepository),typeof(CommunicationTemplateRepository));
            builder.AddScoped(typeof(ICommunicationTemplateUserRecieverMapRepository),typeof(CommunicationTemplateUserRecieverMapRepository));
            builder.AddScoped(typeof(ICommunicationTemplateRoleRecieverMapRepository),typeof(CommunicationTemplateRoleRecieverMapRepository));
            builder.AddScoped(typeof(IFilterResultFieldRepository),typeof(FilterResultFieldRepository));
            builder.AddScoped(typeof(IStateActionRepository),typeof(StateActionRepository));
            builder.AddScoped(typeof(IStateActionAccessRepository),typeof(StateActionAccessRepository));
            builder.AddScoped(typeof(IStateActionStatementRepository),typeof(StateActionStatementRepository));
            builder.AddScoped(typeof(ICustomPageRepository),typeof(CustomPageRepository));
            builder.AddScoped(typeof(ICustomPageLinkRepository),typeof(CustomPageLinkRepository));
            builder.AddScoped(typeof(IFilterListRepository),typeof(FilterListRepository));
            
            builder.AddScoped(typeof(IUserContext),typeof(UserContext));
            builder.AddScoped(typeof(IStageService), typeof(StageService));

            builder.AddScoped(typeof(WebApiClaimsUserFilter), typeof(WebApiClaimsUserFilter));
            builder.AddScoped(typeof(ClaimsAuthorization), typeof(ClaimsAuthorization));

            builder.AddScoped(typeof(IFilterRepository),typeof(FilterRepository));
            builder.AddScoped(typeof(IFilterFieldRepository),typeof(FilterFieldRepository));
            builder.AddScoped(typeof(IEntityScriptRepository),typeof(EntityScriptRepository));
            builder.AddScoped(typeof(IPageAccessRepository),typeof(PageAccessRepository));
            builder.AddScoped(typeof(IUserDefinedRoleRepository),typeof(UserDefinedRoleRepository));
            builder.AddScoped(typeof(IPageLinkRepository),typeof(PageLinkRepository));
            builder.AddScoped(typeof(IOptionListRepository),typeof(OptionListRepository));
            builder.AddScoped(typeof(IOptionRepository),typeof(OptionRepository));
            builder.AddScoped(typeof(IFormApplicationEntityMapRepository),typeof(FormApplicationEntityMapRepository));
            builder.AddScoped(typeof(IFormRepository),typeof(FormRepository));
            builder.AddScoped(typeof(IFieldRepository),typeof(FieldRepository));
            builder.AddScoped(typeof(IFormEventRepository),typeof(FormEventRepository));
            builder.AddScoped(typeof(IFieldEventRepository),typeof(FieldEventRepository));
            builder.AddScoped(typeof(IFormFieldMapRepository),typeof(FormFieldMapRepository));
            builder.AddScoped(typeof(IApplicationEntityRepository),typeof(ApplicationEntityRepository));
            builder.AddScoped(typeof(IApplicationEntityPropertyRepository),typeof(ApplicationEntityPropertyRepository));
            builder.AddScoped(typeof(IFieldTypeRepository),typeof(FieldTypeRepository));
            builder.AddScoped(typeof(IIntUserRepository),typeof(IntUserRepository));
            builder.AddScoped(typeof(IDashboardRepository),typeof(DashboardRepository));
            builder.AddScoped(typeof(IScriptRepository),typeof(ScriptRepository));
            builder.AddScoped(typeof(IOrganizationRepository),typeof(OrganizationRepository));


            builder.AddScoped(typeof(IApplicationFileRepository),typeof(ApplicationFileRepository));
            builder.AddScoped(typeof(IApplicationFileGroupRepository),typeof(ApplicationFileGroupRepository));
            builder.AddScoped(typeof(IApplicationFileTypeRepository),typeof(ApplicationFileTypeRepository));
            builder.AddScoped(typeof(IGroupToApplicationFileMappingRepository),typeof(GroupToApplicationFileMappingRepository));
            builder.AddScoped(typeof(IServerDirectoryRepository),typeof(ServerDirectoryRepository));
            builder.AddScoped(typeof(IGlobalRepository),typeof(GlobalRepository));
            builder.AddScoped(typeof(AppSettings), typeof(AppSettings));            
            builder.AddScoped(typeof(IAccountContext),typeof(AccountContext));
            builder.AddScoped(typeof(ICommandHandler<AddWidgetDataCommand>), typeof(AddWidgetDataCommandHandler));
            builder.AddScoped(typeof(ICommandHandler<EditWidgetDataCommand>), typeof(EditWidgetDataCommandHandler));
            builder.AddScoped(typeof(IQueryHandler<CheckLinkQuery>), typeof(CheckLinkQueryHandler));

            //            builder.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.AddHttpContextAccessor();
        //    builder.AddScoped<HttpContext>(c=>((HttpContextBase)new HttpContextWrapper(HttpContext.Current))).As<HttpContextBase));

        }
    }
    
}
