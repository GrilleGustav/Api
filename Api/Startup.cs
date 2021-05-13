using AutoMapper;
using Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Account;
using Microsoft.AspNetCore.Identity;
using Entities.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Api.Jwt;
using Microsoft.AspNetCore.HttpOverrides;
using Services.Interfaces;
using Services;
using Newtonsoft.Json;

namespace Api
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
      services.ConfigureCors();
      services.ConfigureIISIntegration();
      services.ConfigureSqlContext(Configuration);
      services.ConfigureRepositoryManager();
      services.ConfigureLoggerService();
      services.AddAutoMapper(typeof(Startup));

      services.AddIdentity<User, IdentityRole>(opt =>
      {
        opt.Password.RequiredLength = 7;
        opt.Password.RequireDigit = false;

        opt.User.RequireUniqueEmail = true;

        opt.Lockout.AllowedForNewUsers = true;
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
        opt.Lockout.MaxFailedAccessAttempts = 3;
      })
        .AddEntityFrameworkStores<RepositoryContext>()
        .AddDefaultTokenProviders();

      services.Configure<DataProtectionTokenProviderOptions>(opt =>
      opt.TokenLifespan = TimeSpan.FromHours(2));

      var jwtSettings = Configuration.GetSection("JwtSettings");
      services.AddAuthentication(opt =>
      {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(options =>
      {
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,

          ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
          ValidAudience = jwtSettings.GetSection("validAudience").Value,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
        };
      });

      services.AddScoped<JwtHandler>();
      services.AddScoped<IEmailServerSettingsService, EmailServerSettingsService>();
      services.AddScoped<IEmailSenderSettingsService, EmailSenderSettingsService>();
      services.AddScoped<IEmailTemplateSettingsService, EmailTemplateSettingsService>();


      services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
      }

      //app.UseHttpsRedirection();
      app.UseStaticFiles();

      app.UseCors("CorsPolicy");

      app.UseForwardedHeaders(new ForwardedHeadersOptions
      {
        ForwardedHeaders = ForwardedHeaders.All
      });

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
