using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webapi.Data.Helpers;
using webapi.Data.Repositories;
using webapi.Domain.Entities;
using webapi.Domain.Helpers;
using webapi.Domain.Repositories;
using webapi.Domain.Services;

namespace webapi.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAttendedService, AttendedService>();
            services.AddScoped<IEvaluatorService, EvaluatorService>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IRepository<Attended>, Repository<Attended>>();
            services.AddScoped<IRepository<Evaluator>, Repository<Evaluator>>();
            services.AddScoped<IRepository<Contact>, Repository<Contact>>();
            services.AddScoped<IRepository<Tutor>, Repository<Tutor>>();
            services.AddScoped<IAttendedRepository, AttendedRepository>();
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors(options => {
                options.AddPolicy(MyAllowSpecificOrigins, builder => {
                    builder.WithOrigins("http://localhost:8080")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
