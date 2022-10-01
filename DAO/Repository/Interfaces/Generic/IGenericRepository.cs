using Common.DAO.Access;
using Common.Filter;
using Microsoft.EntityFrameworkCore;
using SpeedFramework.Common.CoreModels;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Core.Model.UiSetup;
using SpeedFramework.DAO.Model.Custom.Communication;
using SpeedFramework.DAO.Model.Custom.Entity;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Model.Custom.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpeedFramework.DAO.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class, TEntity
    {
        IUserContext userContext { get; set; }
        IModelContext db { get; set; }
        DbSet<T> _set { get; set; }
        string Print(int templateId, int oId);
        string entity_name { get; set; }
        string entity_label { get; set; }
        IEnumerable<T> GetAll();
        void CheckDuplicate(T t, Expression<Func<T, bool>> dupQuery);
        ApplicationEntity GetEntity();
        FilterResult<T> GetFiltered(int Id, IEnumerable<FilterField> filterFields,IUserContext userContext, int s, int n);
       
        T Get(int Id);
        T Get(string name);
        int Add(T o);
        Form GetForm();
        bool Edit(T o);
        void Validate(T o);
        IEnumerable<CommunicationTemplate> GetTemplates(int Id);
        IEnumerable<StateActionStatement> GetStateActionStatements(int Id);
        bool EditAction(T _object, int Id);
        Task<FilterResult<T>> GetUIFiltered(int? Id, string value, IEnumerable<FilterField> filterFields, IUserContext userContext, int s, int n);
        bool Delete(int Id);
    }



}
