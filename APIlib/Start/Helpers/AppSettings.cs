using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace WebApi.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public Action<SqlServerDbContextOptionsBuilder> AccountConnection { get; internal set; }
    }
}