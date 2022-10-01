using Common.Helper;
using Common.Standard;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Core.Model.UiSetup;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class LabelRepository
    {
        IModelContext db { get; set; }
        public LabelRepository(IModelContext db)
        {
            this.db = db;
        }

        public IEnumerable<Label> GetAll()
        {
            return db.Labels;
        }


        public Label Get(int Id)
        {
            Label pb = db.Labels.Where(m => m.Id == Id).FirstOrDefault();
            Dignos.CheckException(pb == null, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Label"));
            return pb;
        }

        public string GetLabel(string Name)
        {
            Label pb = db.Labels.Where(m => m.Name == Name).FirstOrDefault();
            if (pb == null)
            {
                return Name;
            }
//            Dignos.CheckException(pb == null, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Label"));
            return pb.Value;
        }

        public int Add(Label pb)
        {
            Validate(pb);
            db.Labels.Add(pb);
            db.SaveChanges();
            return pb.Id;
        }

        public bool Edit(Label pb)
        {
            Validate(pb);
            db.SetStateAsModified(pb);
            db.SaveChanges();
            return true;
        }

        public void Validate(Label o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(String.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));
            Dignos.CheckException(String.IsNullOrEmpty(o.Value), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Value"));

            if (o.Id == 0)
            {
                int count = db.Labels.Where(m => m.Name == o.Name).Count();
                Dignos.CheckException(count > 0, StandardMessage.ERR_DUPLICATE_RECORD.FormatError("Label"));
            }
            else
            {
                int count = db.Labels.Where(m => m.Id == o.Id).Count();
                Dignos.CheckException(count == 0, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Label"));

                int c = db.Labels.Where(m => m.Id == o.Id & m.Name == o.Name).Count();
                int _c = db.Labels.Where(m => m.Id != o.Id & m.Name == o.Name).Count();

                Dignos.CheckException(c + _c > 1, StandardMessage.ERR_DUPLICATE_RECORD.FormatError("Label"));
            }
        }
    }
}