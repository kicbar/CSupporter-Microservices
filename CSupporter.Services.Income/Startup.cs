using CSupporter.Services.Income.Data.DbContexts;
using CSupporter.Services.Income.Models;
using CSupporter.Services.Income.Repositories;
using CSupporter.Services.Income.Repositories.IRepositories;
using CSupporter.Services.Income.Services;
using CSupporter.Services.Income.Services.HostedServices;
using CSupporter.Services.Income.Services.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CSupporter.Services.Income
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
                services.AddDbContext<IncomeDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddHttpClient<IFactureAPIService, FactureAPIService>();

            services.AddScoped<IFactureAPIService, FactureAPIService>();
            services.AddTransient<IIncomeCalculateService, IncomeCalculateService>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();
            services.AddHostedService<TimedHostedService>();

            SD.FacturesAPI = Configuration["ServiceUrls:FacturesAPI"];

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CSupporter.Services.Income", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CSupporter.Services.Income v1"));
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
