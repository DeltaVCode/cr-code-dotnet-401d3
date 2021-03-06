using DemoWeb.Data;
using DemoWeb.Services;
using DemoWeb.Services.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb
{
    public class Startup
    {
        // 1. Place to store config
        public IConfiguration Configuration { get; }

        // 2. Populate config via magic
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Make sure controllers have what they need
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "School Demo",
                    Version = "v1",
                });
            });

            services.AddDbContext<SchoolDbContext>(options => {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                if (connectionString == null)
                    throw new InvalidOperationException("Connection string is not set.");
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<ICourseRepository, DatabaseCourseRepository>();
            services.AddTransient<IStudentRepository, DatabaseStudentRepository>();
            services.AddTransient<ITranscriptRepository, DatabaseTranscriptRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Student Demo");
                options.RoutePrefix = "docs";
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Make sure controllers work
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    context.Response.Redirect("/docs"); // Temp redirect
                    // await context.Response.WriteAsync($"Hello World from path {context.Request.Path}!");
                });
            });
        }
    }
}
