using Aplication.Controllers;
using Aplication.Interfaces;
using Aplication.Validators.Usuario;
using Domain.Interfaces;
using Domain.Services;
using Infraestrutura.DataBaseContext;
using Infraestrutura.Repository.Interface.Base;
using Infraestrutura.Repository.Interface.Usuario;
using Infraestrutura.Repository.ReadRepository;
using Infraestrutura.Repository.WriteRepository;
using Microsoft.EntityFrameworkCore;

namespace CrossCutting.IOC
{
    public static class DependencyInjectory
    {
        public static void Injectory(this IServiceCollection services, WebApplicationBuilder builder)
        {
            //Validators
            services.AddScoped<IUsuarioValidator, UsuarioValidator>();
            
            //Aplicação
            services.AddScoped<IUsuarioApp, UsuarioApp>();
            services.AddScoped<IAuthApp, AuthApp>();
            
            //Domínio
            services.AddScoped<IUsuarioService, UsuarioService>();

            //Repositorio
            services.AddScoped(typeof(IBaseReadRepository<>), typeof(BaseReadRepository<>));
            services.AddScoped(typeof(IBaseWriteRepository<>), typeof(BaseWriteRepository<>));
            services.AddScoped<IUsuarioReadRepository, UsuarioReadRepository>();
            services.AddScoped<IUsuarioWriteRepository, UsuarioWriteRepository>();
            
            //Context
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        }
        
    }
}
