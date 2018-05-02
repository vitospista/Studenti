using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CorsoEnaip2018_AspNetCoreTest1.Test
{
    [TestClass]
    public class HomeIntegrationTest
    {
        private string getContentRoot()
        {
            var path = PlatformServices.Default.Application.ApplicationBasePath;
            var dir = new DirectoryInfo(path).Parent.Parent.Parent.Parent;
            var contentRoot = Path.GetFullPath(Path.Combine(
                dir.FullName,
                "CorsoEnaip2018_AspNetCoreTest1"));

            return contentRoot;
        }

        [TestMethod]
        public async Task View_shows_Items()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(getContentRoot())
                .UseEnvironment("Development")
                .UseStartup<Startup>();

            var server = new TestServer(builder);

            var client = server.CreateClient();

            var result = await client.GetAsync("/");
            //result.EnsureSuccessStatusCode();
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            var content = await result.Content.ReadAsStringAsync();

            var html = new HtmlDocument();
            html.LoadHtml(content);

            //very similar to a standard XmlDocument
            //var xml = new XmlDocument();
            //xml.LoadXml(content);

            var h1 = html.DocumentNode.Descendants("h1").First();
            Assert.IsTrue(h1.InnerText.Contains("Testing"));

            var valueTd = html.DocumentNode.Descendants("td").ToList()[4];
            Assert.AreEqual("1.234,32", valueTd.InnerText);

            var test = html.QuerySelectorAll(".btn");
        }
    }
}
