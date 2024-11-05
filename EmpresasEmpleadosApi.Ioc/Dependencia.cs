using EmpresasEmpleadosApi.Bussiness.Services;
using EmpresasEmpleadosApi.Bussiness.Services.Interfaces;
using EmpresasEmpleadosApi.Data.DBContext;
using EmpresasEmpleadosApi.Data.Repository;
using EmpresasEmpleadosApi.Data.Repository.Interface;
using EmpresasEmpleadosApi.Utilities;
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

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IEmpleadoService, EmpleadoService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IEmpresaEmpleadoService, EmpresaEmpleadoService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            //services.AddScoped<IMenuService, MenuService>();
           

         

        }
    }
}
