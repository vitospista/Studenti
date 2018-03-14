using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.Primitives;
using CorsoEnaip2018_SuperHeroes.Models;
using CorsoEnaip2018_SuperHeroes.DataAccess;

namespace CorsoEnaip2018_SuperHeroes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<
                IRepository<SuperHero>,
                SuperHeroSqlRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /*
             * ASP.NET funziona come catena di MIDDLEWARE
             * 
             */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                // prima aggiungo delle logiche
                context.Response.Headers.Add(
                    "custom-header",
                    new StringValues("custom-header-value"));

                // poi chiamo il middleware successivo
                await next();
            });

            app.Use(async (context, next) =>
            {
                // prima eseguo il middleware successivo
                await next();

                // poi modifico il risultato del middleware successivo
                // aggiungendo le logiche di questo middleware
                if (context.Response.StatusCode == 404)
                {
                    await context.Response
                        .WriteAsync("Pagina non trovataaaaa");
                }
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
