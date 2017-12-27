using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SIENN.BusinessInterfaces.Contracts;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Repositories;
using SIENN.Services;
using System;

namespace SIENN.VerySimpleIoC
{
    public static class ServicesLoader
    {
        public static void RegisterComponents(ref IServiceCollection services)
        {
            // TODO: move connection string outside
            services.AddDbContext<SiennContext>(options => options.UseSqlServer("Server=JUSTYNA-PC;Database=Sienn1;User Id=SiennUser;Password=SiennPass;"));

            // Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<IUnitService, UnitService>();

            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
        }
    }
}
