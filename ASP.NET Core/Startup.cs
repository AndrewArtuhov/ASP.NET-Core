using ASP.NET_Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public record Person(string Name, string Age);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var profiles = new List<Profile>();
            using (var db = new DataModel())
            {
                profiles = db.Profiles.ToList();
            }
            app.Run(async (context) =>
            {
                List<Person> person = new List<Person>();
                foreach (var profile in profiles)
                {
                    person.Add(new(profile.Name, profile.Age));                  
                }
                await context.Response.WriteAsJsonAsync(person);
            });
        }
    }
}
