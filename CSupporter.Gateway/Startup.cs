using CSupporter.Gateway.Options;
using CSupporter.Gateway.Services;
using CSupporter.Gateway.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CSupporter.Gateway
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
            services.AddHttpClient<IFactureAPIService, FactureAPIService>();
            services.AddHttpClient<IProductAPIService, ProductAPIService>();
            services.AddHttpClient<IPositionAPIService, PositionAPIService>();

            services.AddScoped<IContractorAPIService, ContractorAPIService>();
            services.AddScoped<IFactureAPIService, FactureAPIService>();
            services.AddScoped<IProductAPIService, ProductAPIService>();
            services.AddScoped<IPositionAPIService, PositionAPIService>();
            services.AddScoped<IGatewayService, GatewayService>();

            SD.ContractorsAPI = Configuration["ServiceUrls:ContractorsAPI"];
            SD.FacturesAPI = Configuration["ServiceUrls:FacturesAPI"];
            SD.ProductsAPI = Configuration["ServiceUrls:ProductsAPI"];

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CSupporter.Gateway", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CSupporter.Gateway v1"));
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
