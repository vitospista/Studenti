using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CorsoEnaip2018_dyn_web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                // www.localhost:12321/...?day=6&month=3&city=Trieste&day=7

                if (context.Request.Query.Count > 0)
                {
                    // esercizio: stampare tutti i parametri della query,
                    // nella forma <chiave1> : { <valore1>, <valore2> }
                    // nella forma <chiave2> : { <valore3>, <valore4> }
                    foreach (var q in context.Request.Query.Keys)
                    {
                        var sv = context.Request.Query[q];

                        var keyValue = q + " = {" + sv + "}" + Environment.NewLine;

                        await context.Response.WriteAsync(keyValue);

                        //StringValues è simile a un array di stringhe string[]
                        // Query lavora come un Dictionary<string, string[]>

                        // Request.Query è un Dictionary<string, StringValues>
                    }
                }
            });
        }
    }
}
