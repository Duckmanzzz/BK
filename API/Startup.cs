//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using DLL;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection.Extensions;
//using Microsoft.OpenApi.Models;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using Services.Repositories.Implimentations;
//using Services.Repositories.Interfaces;
//using AutoMapper;
////using Services.Hubs;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using System.Text;
using AutoMapper;
using DLL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.Hubs;
using Services.Repositories.Implimentations;
using Services.Repositories.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace API
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
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection"),
            dta => dta.MigrationsAssembly("DLL").UseRowNumberForPaging()));

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Kho",
                    Version = "beta",
                    Contact = new OpenApiContact
                    {
                        Name = "Anonymus Software",
                        Email = "chubodoi1108@gmail.com",
                    },
                });
                c.AddSecurityDefinition("Bearer", //Name the security scheme
                   new OpenApiSecurityScheme
                   {
                       Description = "JWT Authorization header using the Bearer scheme.",
                       Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                       Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                   });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
            });
            services.AddAutoMapper();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IExportInvoiceRespositories, ExportInvoiceRespositories>();
            services.AddScoped<IUserRespositories, UserRespositories>();
            services.AddScoped<IExportInvoiceDetailRepositories, ExportInvoiceDetailRespositories>();
            services.AddScoped<IImportIvoiceRepositories, ImportInvoiceRespositories>();
            services.AddScoped<IImportIvoiceDetailRepositories, ImportInvoiceDetailRespositories>();
            services.AddScoped<IStockRepositories, StockRepositories>();
            services.AddScoped<IStockDetailRepositories, StockDetailRepositories>();
            services.AddScoped<IMechandiseRepositories, MechandiseRepositories>();
            services.AddScoped<IUnitRepositories, UnitRepositories>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                          {
                              var accessToken = context.Request.Query["access_token"];

                              var path = context.HttpContext.Request.Path;
                              if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/signalr")))
                              {
                                  context.Token = accessToken;
                              }
                              return Task.CompletedTask;
                          }
                    };

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                       .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost", "http://localhost:4200", "http://localhost:8100")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddSignalR();
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
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
            });
            app.Use(async (ctx, next) =>
            {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
