using Common.DAO.Access;
using DAO.CQ;
using DAO.CQ.Access.PagAccessCQ.Query;
using DAO.CQ.Custom.UiSetup.Widget.WidgetDataCQ.Command;
using Microsoft.AspNetCore.Mvc;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.APILib.Controllers
{
    public class WidgetDataController : GenericActivableAuthCompleteBaseController<WidgetData>
    {
        public IWidgetDataRepository _service;
        private readonly ICommandHandler<AddWidgetDataCommand> _addWidgetDataCommandHandler;
        private readonly ICommandHandler<EditWidgetDataCommand> _editWidgetDataCommandHandler;
        private readonly IQueryHandler<CheckLinkQuery> _getWidgetDataByIdQueryHandler;

        public WidgetDataController(IWidgetDataRepository service, IUserContext userContext, IAccountContext accountContext,
            ICommandHandler<AddWidgetDataCommand> addWidgetDataCommandHandler,
             ICommandHandler<EditWidgetDataCommand> editWidgetDataCommandHandler,
             IQueryHandler<CheckLinkQuery> getWidgetDataByIdQueryHandler
            )  : base(service)
        {
            _service = service;
            _userContext = userContext;
            _accountContext = accountContext;
            _addWidgetDataCommandHandler = addWidgetDataCommandHandler;
            _editWidgetDataCommandHandler = editWidgetDataCommandHandler;
            _getWidgetDataByIdQueryHandler = getWidgetDataByIdQueryHandler;
        }

        [HttpPost]
        public IActionResult AddWigetData(AddWidgetDataCommand widgetData)
        {
            _addWidgetDataCommandHandler.Handle(widgetData);
            return NoContent();
        }

        [HttpPost]
        public IActionResult EditWigetData(EditWidgetDataCommand widgetData)
        {
            _editWidgetDataCommandHandler.Handle(widgetData);
            return NoContent();
        }

        [HttpPost]
        public IActionResult GetWidgetData(CheckLinkQuery getWidgetDataByIdQuery)
        {
            return Ok(_getWidgetDataByIdQueryHandler.Handle(getWidgetDataByIdQuery));
        }

        /*
        [HttpGet]
        public ServiceResult<Dictionary<string, object>> GetWidgetData(int Id, int wId)
        {
            return ResultProcessor.Process(() =>_service.GetWidgetData(Id, wId));
        }
        */
    }
}
