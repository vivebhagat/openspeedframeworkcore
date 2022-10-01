using Common.DAO.Access;
using Common.Exceptions;
using Common.Helper;
using Common.Standard;
using SpeedFramework.DAO.BAL.Scripting;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Custom.Scripting;
using SpeedFramework.DAO.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedFramework.DAO.Repository.Implementation
{

    public class ScriptRepository: GenericActivableRepository<Script>, IScriptRepository
    {

        public override string entity_name
        {
            get { return "Script"; }
            set { value = "Script"; }
        }
        public override string entity_label
        {
            get { return "Script"; }
            set { value = "Script"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public ScriptRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext,accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }


        public dynamic RunScript(dynamic o, int Id)
        {
            Script s = db.Scripts.Where(m => m.Id == Id).FirstOrDefault();
            Validate(s);
            try
            {
                string a = s.Text;
                return ScriptEngine.Execute(o, a);
            }
            catch (Exception e)
            {
                throw new DataProcessingException("Error occured while executing script. : "+e.Message);
            }
        }


      

        public override void Validate(Script o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError( "Name"));
            Dignos.CheckException(String.IsNullOrEmpty(o.Text), entity_label + " is empty.");
            CheckDuplicate(o, m => m.Name == o.Name);
        }

        public override IQueryable<Script> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(Script script)
        {

        }

        public override void AfterAdd(Script t)
        {

        }

        public override void BeforeEdit(Script t)
        {

        }

        public override void AfterEdit(Script t)
        {
        }

        public override void BeforeNavigationFieldBind(Script t)
        {
            
        }
    }
}
