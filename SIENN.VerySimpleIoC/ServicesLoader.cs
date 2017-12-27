using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIENN.DbAccess.Context;
using System;

namespace SIENN.VerySimpleIoC
{
    public static class ServicesLoader
    {
        public static void RegisterComponents(ref IServiceCollection services)
        {
            // TODO: move connection string outside
            services.AddDbContext<SiennContext>(options => options.UseSqlServer("Server=JUSTYNA-PC;Database=Sienn1;User Id=SiennUser;Password=SiennPass;"));
        }
    }
}
