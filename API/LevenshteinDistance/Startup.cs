using AutoMapper;
using LD.API.DependencyConfig;
//using LD.API.Helper;
using LD.Domain.AutoMapper;
using LD.Domain.DTO;
using LD.SQL.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevenshteinDistance
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
            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              var audienceConfig = Configuration.GetSection("Audience");
              var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(audienceConfig["Secret"]));

              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuerSigningKey = true,
                  IssuerSigningKey = signingKey,
                  ValidateIssuer = true,
                  ValidIssuer = audienceConfig["Iss"],
                  ValidateAudience = true,
                  ValidAudience = audienceConfig["Aud"],
                  ValidateLifetime = true,
                  ClockSkew = TimeSpan.Zero,
                  RequireExpirationTime = true

              };
          });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowAllOrigin", options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                );
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Levenshtein Distance",
                    Description = "Levenshtein Distance - Micro Service.",
                    TermsOfService = "None",
                    // Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Below lines can be commented
            //services.AddMvc(options =>
            //{
            //    options.ModelBinderProviders.Insert(0, new ModelBinderProvider());
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddFluentValidation();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (context) =>
                {
                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(e => new ErrorMessage() { error = e.ErrorMessage })).ToList();

                    var result = new ServiceResponse
                    {
                        success = false,
                        msg = "Validation Errors",
                        errorlst = errors
                    };

                    return new BadRequestObjectResult(result);
                };
            });

            //  services.Configure<IISOptions>(options => options.ForwardWindowsAuthentication = true);
            var connectionString = Configuration.GetConnectionString("DotNetCoreConnection");
            services.AddDbContext<LDDBContext>(d => d.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            services.AddDbContext<LDDBContext>(options =>
            options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(90)));
            services.AddAutoMapper(typeof(Mapping));
            services.AddLogging();
            /// configure dependancies. 
            /// 
            DependencyConfig dependancy = new DependencyConfig(services, Configuration);
            dependancy.ConfigureServices();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            string url = Configuration[string.Format("{0}:ApiBaseURL", Configuration["Api:Default"])];

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors("AllowAllOrigin");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url + "/swagger/v1/swagger.json", "Levenshtein Distance APIs");
                c.RoutePrefix = string.Empty;
            });
            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
