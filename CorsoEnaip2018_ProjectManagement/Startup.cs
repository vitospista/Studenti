using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CorsoEnaip2018_ProjectManagement
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
