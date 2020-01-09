using Digital.Habitat.Api.Application.Services.Loans;
using Digital.Habitat.Api.Data.Repositories;
using Digital.Habitat.Api.Data.Repositories.UnitOfWorks;
using Digital.Habitat.Api.Domain.Repositories;
using Digital.Habitat.Api.Domain.Repositories.UnitOfWorks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Digital.Habitat.Api.Web
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

            // Repositories
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ILoanRepository, LoanRepository>();
            services.AddSingleton<ICompanyRepository, CompanyRepository>();

            // Services
            services.AddSingleton<ILoanService, LoanService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
