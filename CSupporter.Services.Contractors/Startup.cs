using AutoMapper;
using CSupporter.Services.Contractors.Data.DbContexts;
using CSupporter.Services.Contractors.Mappings;
using CSupporter.Services.Contractors.Models;
using CSupporter.Services.Contractors.Repositories;
using CSupporter.Services.Contractors.Repositories.IRepositories;
using CSupporter.Services.Contractors.Services;
using CSupporter.Services.Contractors.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace CSupporter.Services.Contractors
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
            services.AddDbContext<ContractorDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddHttpClient<IFactureAPIService, FactureAPIService>();
            services.AddScoped<IContractorService, ContractorService>();
            services.AddTransient<IContractorRepository, ContractorRepository>();
            services.AddScoped<IFactureAPIService, FactureAPIService>();

            SD.FacturesAPI = Configuration["ServiceUrls:FacturesAPI"];

            IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CSupporter.Services.Contractors", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CSupporter.Services.Contractors v1"));
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
