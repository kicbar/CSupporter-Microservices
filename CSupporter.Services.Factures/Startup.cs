using AutoMapper;
using CSupporter.Services.Factures.Data;
using CSupporter.Services.Factures.Data.DbContexts;
using CSupporter.Services.Factures.Mappings;
using CSupporter.Services.Factures.Models;
using CSupporter.Services.Factures.Repositories;
using CSupporter.Services.Factures.Repositories.IRepositories;
using CSupporter.Services.Factures.Services;
using CSupporter.Services.Factures.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CSupporter.Services.Factures
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IContractorAPIService, ContractorAPIService>();

            services.AddDbContext<FactureDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<FacturesSeeder>();

            services.AddScoped<IFactureService, FactureService>();
            services.AddTransient<IFactureRepository, FactureRepository>();

            services.AddScoped<IContractorAPIService, ContractorAPIService>();

            SD.ContractorsAPI = Configuration["ServiceUrls:ContractorsAPI"];

            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CSupporter.Services.Factures", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FacturesSeeder facturesSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CSupporter.Services.Factures v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            facturesSeeder.Seed();
        }
    }
}
