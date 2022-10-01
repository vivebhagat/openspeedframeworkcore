using System.Collections.Generic;
using System.Linq;
using System;
using Common.Helper;
using Common.Standard;
using Common.DAO.Access;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{

    public class FieldRepository : GenericActivableRepository<Field>, IFieldRepository
    {
        public override string entity_name
        {
            get { return "Field"; }
            set { value = "Field"; }
        }
        public override string entity_label
        {
            get { return "Field"; }
            set { value = "Field"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public FieldRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }

   

        public override void Validate(Field o)
        {
            Dignos.CheckException(o==null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name & m.ApplicationEntityPropertyId == o.ApplicationEntityPropertyId);           
        }

        public IEnumerable<Option> GetOptions(int Id)
        {
            int c = _set.Where(m => m.Id == Id).Count();
            Dignos.CheckException(c == 0, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError(entity_label));
            string type = _set.Where(m => m.Id == Id).FirstOrDefault().FieldType.Name;
            Dignos.CheckException(type != "DROPDOWN", StandardMessage.ERR_ENTITY_INVALID.FormatError(entity_label));
            int _c = db.OptionLists.Where(m => m.FieldId == Id).Count();

            Dignos.CheckException(_c == 0, "Option List is not configured.");
            int listId = db.OptionLists.Where(m => m.FieldId == Id).FirstOrDefault().Id;

            List<Option> list = db.Options.Where(m => m.OptionListId == listId).ToList();

            return list;
        }


        public IEnumerable<Field> GetForEntity(int Id)
        {
            int c = db.ApplicationEntities.Where(m => m.Id == Id).Count();
            Dignos.CheckException(c == 0, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Entity"));

            List<int> properties = db.ApplicationEntityProperties.Where(m => m.ApplicationEntityId == Id).Select(m=>m.Id).ToList();

            IEnumerable<Field> fields = db.Fields.Where(m => properties.Contains(m.ApplicationEntityPropertyId.Value)).ToList();
            return fields;
        }


        public override IQueryable<Field> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(Field form)
        {
        }

        public override void AfterAdd(Field t)
        {
 
        }

        public override void BeforeEdit(Field category)
        {
        }

        public override void AfterEdit(Field t)
        {
         
        }

        public void Dispose()
        {
        }

        public override void BeforeNavigationFieldBind(Field t)
        {
            
        }
    }
 }
