using APIlib;
using Common.DAO.Access;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace SpeedFramework.APILib.Models.Authentication
{
    public class AccountContext : IAccountContext
    {
        public string Domain { get; set; }
        public string ConnectionString { get; set; }

        public string default_username { get; set; }
        public string default_password { get; set; }
        public string default_role { get; set; }
        public string ServerDirectoryRoot { get; set; }
        public AccountContext(IHttpContextAccessor httpContextAccessor)
        {

            HttpContext httpContext = httpContextAccessor.HttpContext;
            init(httpContext);
        }

        public AccountContext(HttpContext httpContext)
        {

            init(httpContext);
        }

        public void init(HttpContext httpContext)
        {

            string domain = null;
            StringValues value = new StringValues();
            httpContext.Request.Headers.TryGetValue("domain", out value);
            domain = value.FirstOrDefault();
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            // Duplicate here any configuration sources you use.
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();
            string connection = configuration.GetValue(typeof(string), "AppSettings:ConnectionStrings:AccountConnection").ToString();

            DbContextOptions<AccountDbContext> options = new DbContextOptionsBuilder<AccountDbContext>().UseSqlServer(connection).Options;
            AccountDbContext db = new AccountDbContext(options);
            UserAccount userAccount = db.UserAccounts.Where(m => m.Domain == domain).FirstOrDefault();
            this.ConnectionString = userAccount.ConnectionString;
            this.default_username = userAccount.default_username;
            this.default_password = userAccount.default_password;
            this.default_role = userAccount.default_role;
            this.ServerDirectoryRoot = userAccount.ServerDirectoryRoot;
            db.Dispose();

        }
    }

    public class AccountDbContext : DbContext {

        public DbSet<UserAccount> UserAccounts { get; set; }
        public AccountDbContext(DbContextOptions<AccountDbContext> options) :base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder dbModelBuilder)
        {
            dbModelBuilder.HasDefaultSchema("common");
        }

    }

    public class UserAccount
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public string ConnectionString { get; set; }
        public string default_username { get; set; }
        public string default_password { get; set; }
        public string default_role { get; set; }
        public string ServerDirectoryRoot { get; set; }

    }
}