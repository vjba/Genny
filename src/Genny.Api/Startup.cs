using AspNetCoreRateLimit;
using Genny.Api.Services;
using Microsoft.OpenApi.Models;

namespace Genny.Api
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
            services.AddOptions();
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));
            services.AddInMemoryRateLimiting();

            services.AddControllers();

            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddSingleton<IGeneratorService, GeneratorService>();

            services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Genny",
                Description = "An ASP.NET Core Web API for generating data",
                Contact = new OpenApiContact
                {
                    Name = "vjba",
                    Url = new Uri("https://github.com/vjba/Genny/")
                },
                License = new OpenApiLicense
                {
                    Name = "GPL-3.0 License",
                    Url = new Uri("https://github.com/vjba/Genny/blob/main/LICENSE")
                }
            }));

            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIpRateLimiting();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapHealthChecks("/health");
                });
        }
    }
}
