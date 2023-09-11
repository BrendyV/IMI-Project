using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repositories;
using Imi.Project.Api.Core.Interfaces.Services;
using Imi.Project.Api.Core.Services;
using Imi.Project.Api.Infrastructure.Data;
using Imi.Project.Api.Infrastructure.Repositories;
using Imi.Project.Mobile.Domain.Api;
using Imi.Project.Mobile.Domain.Api.Interfaces;
using Imi.Project.Mobile.Domain.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace Imi.Project.Api
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
            services.AddCors();
            services.AddDbContext<AnimalDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase")));


            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<AnimalDbContext>();

            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IKindRepository, KindRepository>();
            services.AddScoped<IContinentRepository, ContinentRepository>();
            services.AddScoped<ISocialRepository, SocialRepository>();
            services.AddScoped<IBreedingRepository, BreedingRepository>();
            services.AddScoped<IDietRepository, DietRepository>();
            services.AddScoped<IAnimalService, AnimalsService>();
            services.AddScoped<IBreedingService, BreedingService>();
            services.AddScoped<IContinentService, ContinentService>();
            services.AddScoped<IDietService, DietService>();
            services.AddScoped<IKindService, KindService>();
            services.AddScoped<ISocialService, SocialService>();
            services.AddScoped<IImageService, ImageService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddHttpClient<IApiAnimalRepository, ApiAnimalService>(c =>
            {
                c.BaseAddress = new Uri("https://172.30.85.148:5001");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Imi.Project.Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });


            services.AddAuthentication(option =>
                {
                    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwtOptions =>
                {
                    jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["JWTConfiguration:Issuer"],
                        ValidAudience = Configuration["JWTConfiguration:Audience"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration["JWTConfiguration:SigningKey"]))
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanRead",
                    policy =>
                    {
                        policy.RequireClaim("HasApprovedTermsAndConditions", new string[] { "True", "true" });
                    });
                options.AddPolicy("CanEdit", policy =>
                {
                    policy.RequireClaim("HasApprovedTermsAndConditions", new string[] { "True", "true" });
                    policy.RequireRole("Admin", "admin", "User", "user");
                });
                options.AddPolicy("CanCreate", policy =>
                {
                    policy.RequireClaim("HasApprovedTermsAndConditions", new string[] { "True", "true" });
                    policy.RequireRole("Admin", "admin", "User", "user");
                });
                options.AddPolicy("CanDelete", policy =>
                {
                    policy.RequireClaim("HasApprovedTermsAndConditions", new string[] { "True", "true" });
                    policy.RequireRole("Admin", "admin");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Imi.Project.Imi"));
            }

            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}