using EmpresasEmpleadosApi.Data.DBContext;
using EmpresasEmpleadosApi.Data.Repository;
using EmpresasEmpleadosApi.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmpresasEmpleadosApi.Ioc
{
    public static class Dependencia
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmpresaEmpleadosDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlString"));
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //services.AddScoped<ISaleRepository, SaleRepository>();
            //services.AddAutoMapper(typeof(AutoMapperProfile));

            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<IDashBoardService, DashBoardService>();
            //services.AddScoped<IMenuService, MenuService>();
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IRolService, RolService>();
            //services.AddScoped<ISaleService, SaleService>();
            //services.AddScoped<IUserService, UserService>();
        }
    }
}
