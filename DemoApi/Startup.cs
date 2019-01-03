using AutoMapper;
using DemoApi.Data;
using DemoApi.Data.Repositories;
using DemoApi.Logic;
using DemoApi.Logic.Processors;
using DemoApi.Logic.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoApi
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
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<CustomersProcessor>();
            services.AddScoped<CustomersRepository>();

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
                opt.Filters.Add(new CorsAuthorizationFilterFactory("AllowMyOrigin"));
            })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerValidator>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<BenHowardDevContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BenHowardDevDatabase")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("http://lazerpanther-001-site2.atempurl.com", "https://localhost:44309", "http://localhost:65432")
                .WithMethods("GET", "POST", "PUT", "DELETE"));
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("AllowMyOrigin");
        }
    }
}