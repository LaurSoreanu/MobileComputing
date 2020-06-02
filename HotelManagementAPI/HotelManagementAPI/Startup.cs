using Alexinea.Autofac.Extensions.DependencyInjection;
using Autofac;
using HotelManagement.DataServices;
using HotelManagement.DataServices.Settings;
using HotelManagementAPI.Domain;
using HotelManagementAPI.Filters;
using HotelManagementAPI.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Reflection;
using System.Text;


namespace HotelManagementAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
			services.Configure<ConfigSettings>(options => Configuration.GetSection("ConfigSettings").Bind(options));

			services.AddControllers(options =>
               options.CacheProfiles.Add("Default", new CacheProfile()
               {
                   Duration = Configuration.GetValue<int>("CacheDuration")
               })
            ).AddControllersAsServices();

            services.AddSerilogServices(Configuration).AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    corsPolicyBuilder => corsPolicyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = Configuration["ConfigSettings:Issuer"],
						ValidAudience = Configuration["ConfigSettings:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ConfigSettings:TokenSecretKey"]))
					};
				});

			services.Configure<MigrationsSettings>(Configuration.GetSection("MigrationsSettings"));
            services.AddResponseCaching();
            services.AddScoped<ApiExceptionFilter>();

            services.AddSingleton(Configuration);
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModule(new WebModule());
            builder.Populate(services);
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            app.UseStaticFiles();
            app.UseResponseCaching();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("AllowAllOrigins");

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            UpdateDatabase(app);
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var migrationsSettings = serviceScope.ServiceProvider.GetService<IOptions<MigrationsSettings>>().Value;

                if (migrationsSettings != null && migrationsSettings.AutomaticDatabaseMigrations)
                {
                    using (var context = serviceScope.ServiceProvider.GetService<Entities>())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
