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
                var requestType = context.Request.Method;

                // esercizio: stampare tutti i parametri della query,
                // nella forma <chiave1> : { <valore1>, <valore2> }
                // nella forma <chiave2> : { <valore3>, <valore4> }
                if (context.Request.Path == "/")
                {
                    var html =
                       "<!DOCTYPE html>" +
                       "<html>" +
                           "<body>" +
                               $"<p>Elenco di parametri della query:</p>" +
                               "<ul>";

                    foreach (var q in context.Request.Query.Keys)
                    {
                        var sv = context.Request.Query[q];

                        //StringValues è simile a un array di stringhe string[]
                        // Query lavora come un Dictionary<string, string[]>
                        // Request.Query è un Dictionary<string, StringValues>

                        var keyValue = $"{q} = {{ {sv} }}{Environment.NewLine}";

                        var li = $"<li>{keyValue}</li>";

                        html += li;
                    }

                    html +=
                                "</ul>" +
                            "</body>" +
                        "</html>";

                    await context.Response.WriteAsync(html);
                }
                else
                {
                    var pathValues = context.Request.Path.Value.Split('/');

                    if (pathValues[1] == "meteo") //    /meteo/...
                    {
                        if (string.Equals(pathValues[2], "trieste", StringComparison.InvariantCultureIgnoreCase)) //  /meteo/trieste/..
                        {
                            var html =
                                "<!DOCTYPE html>" +
                                "<html>" +
                                    "<head>" +
                                        "<meta charset=\"utf-8\" />" +
                                    "</head>" +
                                    "<body>" +
                                        $"<p style=\"color:red;\">La temperatura a Trieste è 10°</p>" +
                                    "</body>" +
                                "</html>";

                            await context.Response.WriteAsync(html);
                        }
                        else if (pathValues[2] == "udine")  //  /meteo/udine/..
                        {
                            var html =
                                "<!DOCTYPE html>" +
                                "<html>" +
                                    "<body>" +
                                        $"<p>La temperatura a Udine è 7°</p>" +
                                    "</body>" +
                                "</html>";

                            await context.Response.WriteAsync(html);
                        }
                    }
                }
            });
        }
    }
}
