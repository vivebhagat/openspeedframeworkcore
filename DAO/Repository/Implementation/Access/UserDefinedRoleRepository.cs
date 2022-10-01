using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.DAO.Access;
using Common.Helper;
using Common.Standard;
using SpeedFramework.DAO.Commmon;
using SpeedFramework.DAO.Model.Access;
using SpeedFramework.DAO.Model.Custom.Filter;
using SpeedFramework.DAO.Repository.Interfaces;

namespace SpeedFramework.DAO.Repository.Implementation
{
    public class UserDefinedRoleRepository : GenericActivableRepository<UserDefinedRole>, IUserDefinedRoleRepository
    {

        public override string entity_name
        {
            get { return "Role"; }
            set { value = "Role"; }
        }
        public override string entity_label
        {
            get { return "Role"; }
            set { value = "Role"; }
        }

        Dictionary<string, string> _labels = new Dictionary<string, string> { };

        public override Dictionary<string, string> labels
        {
            get { return _labels; }
            set { value = _labels; }
        }

        public UserDefinedRoleRepository(IModelContext db,  IUserContext userContext, IAccountContext accountContext) : base(db, userContext, accountContext)
        {
            this.db = db;
            this.userContext = userContext;
            this.accountContext = accountContext;
        }


        public IEnumerable<UserDefinedRole> GetRoleMap()
        {
            IEnumerable<UserDefinedRole> definedRoles = db.UserDefinedRoleToUserMaps.Where(m => m.IntUser.Id == this.userContext.CurrentUserId & !m.Inactive).Select(m => m.Role).ToList();
            return definedRoles;
        }

        public bool UnmapUserFromRole(int userid, int roleid)
        {
            int uCount = db.IntUsers.Where(m => m.Id == userid).Count();
            Dignos.CheckException(uCount != 1, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("User"));
            int rCount = db.UserDefinedRoles.Where(m => m.Id == roleid).Count();
            Dignos.CheckException(rCount != 1, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Role"));

            UserDefinedRoleToUserMap map = db.UserDefinedRoleToUserMaps.Where(m => m.RoleId == roleid & m.IntUserId == userid & m.Inactive).FirstOrDefault();

            if (map == null)
            {
                return true;
            }
            else
            {
                if (map.Inactive)
                {
                    map.Inactive = false;
                    db.SetStateAsModified(map);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool MapUserToRole(int userid, int roleid)
        {
            int uCount = db.IntUsers.Where(m => m.Id == userid).Count();
            Dignos.CheckException(uCount != 1, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("User"));
            int rCount = db.UserDefinedRoles.Where(m => m.Id == roleid).Count();
            Dignos.CheckException(rCount != 1, StandardMessage.ERR_ENTITY_NOT_EXIST.FormatError("Role"));

            UserDefinedRoleToUserMap map = db.UserDefinedRoleToUserMaps.Where(m => m.RoleId == roleid & m.IntUserId == userid).FirstOrDefault();

            if (map == null)
            {
                map = new UserDefinedRoleToUserMap
                {
                    IntUserId = userid,
                    RoleId = roleid,
                    Inactive = true
                };
                db.SetStateAsAdded(map);
                db.SaveChanges();
                return true;
            }
            else
            {
                if (map.Inactive)
                {
                    return true;
                }
                else
                {
                    map.Inactive = true;
                    db.SetStateAsModified(map);
                    db.SaveChanges();
                    return true;
                }
            }
        }


        public IEnumerable<UserDefinedRoleToUserMap> GetFullRoleMap(int Id)
        {
            IEnumerable<UserDefinedRoleToUserMap> current_map = db.UserDefinedRoleToUserMaps.Where(m => m.IntUserId == Id).ToList();
            IEnumerable<UserDefinedRole> all_roles = db.UserDefinedRoles.ToList();

            List<int> roles = current_map.Select(x => x.RoleId.Value).ToList();
            IEnumerable<UserDefinedRole> not_mapped_roles = db.UserDefinedRoles.Where(m => !(roles.Contains(m.Id))).ToList();
            List<UserDefinedRoleToUserMap> not_mapped_objects = new List<UserDefinedRoleToUserMap>();

            foreach (UserDefinedRole r in not_mapped_roles)
            {
                not_mapped_objects.Add(new UserDefinedRoleToUserMap
                {
                    IntUserId = Id,
                    Inactive = true,
                    RoleId = r.Id,
                    Role = r
                });
            }
            not_mapped_objects.AddRange(current_map);

            return not_mapped_objects;
        }

        public override void Validate(UserDefinedRole o)
        {
            Dignos.CheckException(o == null, StandardMessage.ERR_NO_DETAILS);
            Dignos.CheckException(string.IsNullOrEmpty(o.Name), StandardMessage.ERR_REQUIRED_FIELD.FormatError("Name"));

            CheckDuplicate(o, m => m.Name == o.Name);
        }

        public override IQueryable<UserDefinedRole> GetAccessFilterdSet()
        {
            return _set;
        }

        public override void BeforeAdd(UserDefinedRole o)
        {
        }

        public override void AfterAdd(UserDefinedRole o)
        {
        }

        public override void BeforeEdit(UserDefinedRole o)
        {
        }

        public override void AfterEdit(UserDefinedRole o)
        {
        }

        /*
        public List<Tuple<string, object>> GetOwnershipEntityAccessMap()
        {
            List<Tuple<string, object>> keyValuePairs = new List<Tuple<string, object>>();
            List<OwnershipEntityAccess> ownershipEntityAccesses = db.OwnershipEntityAccesses.Where(m => m.IntUserId == userContext.CurrentUserId & !m.Inactive).ToList();

            foreach (OwnershipEntityAccess ownershipEntityAccess in ownershipEntityAccesses)
            {
                if (ownershipEntityAccess.eId != 0)
                {
                    Type t = Type.GetType(ownershipEntityAccess.ApplicationEntity.Name);

                    IQueryable set = db.GetDbContext().Set(t.AssemblyQualifiedName).AsQueryable();
                    ParameterExpression pe = Expression.Parameter(t, "_obj");
                    Expression left = Expression.Property(pe, "Id");
                    Expression right = Expression.Constant(ownershipEntityAccess.eId);
                    Expression final = Expression.Equal(left, right);
                    FilterEngine filterEngine = new FilterEngine();
                    MethodCallExpression whereCallExpression = Expression.Call(typeof(Queryable),
                    "Where",
                    new Type[] { t },
                    set.Expression, Expression.Lambda(final, new ParameterExpression[] { pe }));
                    IQueryable _results = set.Provider.CreateQuery(whereCallExpression);

//                    object o = db.Database.SqlQuery(t, _results.ToString(), new object[] { }).ToListAsync().Result;

                    object o = db.GetRawQuery(t, _results.ToString(), new object[] { }).ToListAsync().Result;
                    keyValuePairs.Add(new Tuple<string, object>(ownershipEntityAccess.ApplicationEntity.DisplayName, o));
                }
                else
                {
                    keyValuePairs.Add(new Tuple<string, object>(ownershipEntityAccess.ApplicationEntity.DisplayName, new object[] { new { Id = 0, Name = "Allow Any" }}));
                }
            }

            return keyValuePairs;
        }*/

        public override void BeforeNavigationFieldBind(UserDefinedRole o)
        {
            
        }
    }
}