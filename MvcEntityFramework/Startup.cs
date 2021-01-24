using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //VARIABLE PARA PODER RECUPERAR EL OBJETO DE LA INYECCION
        IConfiguration Configuration { get; set; }
        //PARA PODER ACCEDER AL APPSETINGS.JSON NECESITAMOS INYECCION DE DEPENDENCIAS
        //EN LA PUBLIC CLASS STARTUP DE LA INTERFACE IConfiguration
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;User ID=SA;Password=MCSD2020";
            //string cadenaJson = Configuration.GetConnectionString("CasaMySQLHospital");
            //services.AddSingleton<IDepartamentosContext>(context =>
            //new DepartamentosContextSQL(cadena));
            //new DepartamentosContextMySQL(cadenaJson));
            services.AddTransient<RepositoryEmpleados>();
            services.AddDbContext<EmpleadosContext>(options => options.UseSqlServer(cadena));

            services.AddTransient<RepositoryEnfermos>();
            services.AddDbContext<EnfermosContext>(options => options.UseSqlServer(cadena));

            //RESOLVEMOS LA DEPENDENCIA PARA EL REPOSITORIO
            services.AddTransient<RepositoryHospital>();
            services.AddTransient<RepositoryPlantilla>();
            //PARA USAR CONTEXTOS PUROS DbContext DE Entity Framework DEBEMOS USAR UN METODO
            //ESPECIAL PARA IoC QUE ES .AddDbContext
            services.AddTransient<RepositoryDoctores>();
            services.AddTransient<RepositoryEmpleadosHospital>();
            services.AddDbContext<HospitalContext>(options => options.UseSqlServer(cadena));


            //LAS DEPENDENCIAS DE OBJETOS SE RESUELVEN EN LOS SERVICIOS DE LA APP
            //OPC 1:
            //  AddTransient<>, que genera un objeto por cada peticion de inyeccion
            //services.AddTransient<Coche>();
            //OPC 2:
            //  CREAR UNA UNICA INSTANCIA DE UN OBJETO PARA TODAS LAS PETICIONES DE INYECCION
            //  AddSingleton<>
            //services.AddSingleton<ICoche>(z=>new Deportivo("Ferrari", "Testarossa","Testarossa.jpg", 220));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                        );
            });
        }
    }
}
