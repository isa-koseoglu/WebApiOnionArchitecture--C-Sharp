using HotelFinder.Bisuiness.Abstcract;
using HotelFinder.Bisuiness.ConCreate;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.ConCreate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IHotelService, HotelManager>();
            services.AddSingleton<IHotelRepository, HotelRepository>();
            services.AddSwaggerDocument(p => p.PostProcess = (doc =>
            {
                doc.Info.Title = "Hotel CRUD Proccessing";
                doc.Info.Version = "1.0.0.12";
                doc.Info.Contact = new NSwag.OpenApiContact()
                {
                    Name = "?sa K?SEO?LU",
                    Email = "iletisim@isakoseoglu.dev",
                    Url = "http://isakoseoglu.dev"
                };
            }));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
