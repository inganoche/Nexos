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
using Nexos.Core.Interfaces;
using Nexos.Infrastructure.Repositories;
using Nexos.Infrastructure.Data;
using Nexos.Infrastructure.Seed;
using Nexos.Infrastructure.Filters;
using FluentValidation.AspNetCore;
using Nexos.Service.Interfaces;
using Nexos.Service.Sevices;
using Microsoft.OpenApi.Models;

namespace Nexos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // mepper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //boot
            services.AddControllers(op => op.Filters.Add<GlobalExceptionFilter>())
                .AddNewtonsoftJson(o => { 
                    o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                   // o.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });

            //ConnectionString
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            //Migrations
            var migrationsAssembly = "Nexos.Infrastructure";
            services.AddDbContext<NexosContext>(p => p.UseSqlServer(connectionString, s => s.MigrationsAssembly(migrationsAssembly)));

            //Inject Dependence
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IEditorialService, EditorialService>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IEditorialRepository, EditorialRepository>();


            services.AddSwaggerGen(swg=> {
                swg.SwaggerDoc("v01", new OpenApiInfo { Title="Project Nexos API Books", Version="v01" });
            });


            ////filters -Validador
            services.AddMvc(op =>
            {
                //op.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(op =>
            {
                op.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SeedNexos.SeedNexosServerData(app);

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(sw=> {
                sw.SwaggerEndpoint("/swagger/v01/swagger.json","Nexos API Book");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
