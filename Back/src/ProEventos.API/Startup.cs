using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProEventos.Persistence;

namespace ProEventos.API
{
    public class Startup
    {
        // IConfiguration está sendo injetado, ele acessa o appsettings
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ProEventosContext>( //faço a referência do BD
                context => context.UseSqlite(Configuration.GetConnectionString("Default")) //coloco a string de conexão que
                //estará configurada no appsttingsDevelopment.json
            );
            services.AddControllers(); //arquitetura mvc //**
            services.AddCors();
            services.AddSwaggerGen(c => //trabalha por meio de versão
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //abaixo temos o contrato
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting(); //**

            app.UseAuthorization();

            app.UseCors(
                //permite acesso a qualquer cabeçalho, qualquer método e origem
                 acesso => acesso.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
            );

            app.UseEndpoints(endpoints => //**
            {
                endpoints.MapControllers();
            });

            //**
            //o controller será chamado quando o uso de determinada rota (app.UseRouting();) 
            //te retornar determinado endpoint
        }
    }
}
