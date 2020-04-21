using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcMovie.Service.Api.Extensions;
using MvcMovie.Service.Domain;
using MvcMovie.Service.Infrastructure.Database;

namespace MvcMovie.Service.Api
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
            services.AddControllers();
            services.AddDbContext<MvcMovieContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MvcMovieContext")));
                //options.UseSqlite(Configuration.GetConnectionString("MvcMovieContext")));

            services.AddScoped<IMovieService, MovieService>();
            services.AddApiVersioningAndExplorer();
            services.AddSwaggerGeneration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            
            app.UseSwagger();
            app.UseSwaggerUIAndAddApiVersionEndPointBuilder(provider);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}