using Common.DAO.Access;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Services;

namespace SpeedFramework.APILib.Models.Authentication
{
    public class AuthContext : IdentityDbContext<CommonApplicationUser>
    {
        public AuthContext(IAccountContext actountContext)
            : base()
        {
            CheckTableExistsAndCreateIfMissing(this);
        }

        private void MigrateIfNotSetup()
        {
            try
            {
                this.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private static void CheckTableExistsAndCreateIfMissing(DbContext dbContext)
        {

                var scriptStart = $"";
                const string scriptEnd = "GO";
                var script = dbContext.Database.GenerateCreateScript();

            //                var tableScript = script.Split(scriptStart).Last().Split(scriptEnd);
            //               var first = $"{scriptStart} {tableScript.First()}";

            string[] batches = script.Split(new[] { "\nGO" }, StringSplitOptions.None);
            foreach (string batch in batches)
            {
                try
                {
                    dbContext.Database.ExecuteSqlRaw(batch);
                }
                catch (SqlException e)
                {
                    if (!(e.Message.StartsWith("There is already an object named ") || e.Message.StartsWith("The operation failed because an index or statistics with name")))
                    { 
                        throw e;
                    }
                }
            }
            
        }

        public AuthContext(DbContextOptions<AuthContext> options) : base(options)
        {
            CheckTableExistsAndCreateIfMissing(this);
        }

        protected override void OnModelCreating(ModelBuilder dbModelBuilder)
        {
            dbModelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(dbModelBuilder);
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }

}