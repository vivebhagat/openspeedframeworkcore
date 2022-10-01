using Common.DAO.Access;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Custom.UiSetup.Widget;
using System;
using System.Threading.Tasks;

namespace DAO.CQ.Custom.UiSetup.Widget.WidgetDataCQ.Command
{
    public class EditWidgetDataCommand : ICommand    
    {
        public bool Inactive { get; set; }
        public string Name { get; set; }
        public int? ScriptId { get; set; }
        public string ApplicationNumber { get; set; }
        public string LegacyNumber { get; set; }
    }

    public class EditWidgetDataCommandHandler : ICommandHandler<EditWidgetDataCommand>
    {
        public IUserContext userContext { get; set; }
        public IAccountContext accountContext { get; set; }
        public IModelContext db { get; set; }
        public EditWidgetDataCommandHandler(IModelContext db, IUserContext userContext, IAccountContext accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

        public async Task Handle(EditWidgetDataCommand command)
        {
            /* var validator = new AddNewProductCommandValidator();
            /ValidationResult results = validator.Validate(command);
            bool validationSucceeded = results.IsValid;
            if (!validationSucceeded)
            {
                var failures = results.Errors.ToList();
                var message = new StringBuilder();
                failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
                throw new ValidationException(message.ToString());
            }
            */
            var widgetData = new WidgetData
            {
                Name = command.Name,
                CreatedDate = DateTime.Now
            };

            this.db.WidgetDatas.Update(widgetData);
            await this.db.GetDbContext().SaveChangesAsync();
            //Command must be processed asynchronously, so I used an Emty Task.
            //In the real world, saving data is an asynchronous operation, we use something like _context. SaveChangesAsync ();
            await Task<int>.Run(() => { });
        }
    }
}
