using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tp.Restaurante.AccessData;
using Tp.Restaurante.AccessData.Commands;
using Tp.Restaurante.AccessData.Queries;
using Tp.Restaurante.Application.Services;
using Tp.Restaurante.Domain.Commands;
using Tp.Restaurante.Domain.Entities;
using Tp.Restaurante.Domain.Queries;
using Tp.Restaurante.Domain.Validation;

namespace Tp.Restaurante.API
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

            services.AddControllers().AddFluentValidation();
            var connectionstring = Configuration.GetSection("ConnectionString").Value;
            // EF Core
            services.AddDbContext<RestauranteDbContext>(options => options.UseSqlServer(connectionstring));

            // SQLKata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionstring);
            });


            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IMercaderiaService, MercaderiaService>();
            services.AddTransient<IComandaService, ComandaService>();
            services.AddTransient<IMercaderiaQuery, MercaderiaQuery>();
            services.AddTransient<IComandaQuery, ComandaQuery>();

            services.AddTransient<IValidator<Mercaderia>, MercaderiaValidator>();
            services.AddTransient<IValidator<Comanda>, ComandaValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Menu Digital Documentacion",
                    Version = "v1",
                    Description = "REST API para la aplicacion de un Menu Digital para un Restaurante",
                    Contact = new OpenApiContact()
                    {
                        Name = "Nicolas Acu�a",
                        Email = "a.nico.1998@hotmail.com"
                    }
                } );
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Menu Digital API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
