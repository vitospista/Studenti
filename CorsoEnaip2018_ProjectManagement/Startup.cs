using CorsoEnaip2018_ProjectManagement.DataAccess;
using CorsoEnaip2018_ProjectManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace CorsoEnaip2018_ProjectManagement
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<
                IRepository<Project>,
                SqlProjectRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var ci = new CultureInfo("en-US");

            CultureInfo.DefaultThreadCurrentCulture = ci;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Project}/{action=Index}/{id?}");
            });
        }

        /*
         * ProjectManagement
         * 
         * Gestione progetti di un'azienda.
         * Ogni progetto ha:
         * Nome - stringa
         * Cliente - stringa
         * Manager - stringa
         * DataInizio - data    <-- data in cui inizia il progetto
         * DataFine - data      <-- data in cui lo si finisce
         * DataConsegna - data   <-- data promessa al cliente
         * Prezzo - decimal <-- è il prezzo che pagherà il cliente
         * Costo - decimal  <-- il costo degli sviluppatori
         * 
         * Pagine:
         *  lista di progetti,
         *  modifica progetto,
         *  eliminazione progetto
         * 
         * 
         * 
         */
    }
}
