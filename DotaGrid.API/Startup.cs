using DotaGrid.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaGrid.API
{
    public class Startup
    {
        /// <summary>
        /// Startup klassen kj�res n�r apiet starter (fra program). Denne klassen holder p� connection stringen og programmet snakker med databasen
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
            
            var connection = @"Server=donau.hiof.no;
                             Database=sjriis;
                             User id=sjriis;
                             Password=a^4<A-U/;
                             MultipleActiveResultSets=True";
            
            
            //local
            //var connection = @"Server=(localdb)\MSSQLLocalDB;Database=sjriis;Trusted_Connection=True;ConnectRetryCount=0";
            

            services.AddDbContext<HeroContext>(options => options.UseSqlServer(connection));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection(); //Denne ga meg en del error, om du f�r Https problemer. Skru det av

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
