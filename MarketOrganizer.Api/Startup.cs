using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MarketOrganizer.Data.Models;
using MarketOrganizer.Api.Interfaces;
using MarketOrganizer.Api.Services;
using MarketOrganizer.Api.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;

namespace MarketOrganizer.Api
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
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddCors();

      var appSettingsSection = Configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);
      var appSettings = appSettingsSection.Get<AppSettings>();
      var secretKey = Encoding.ASCII.GetBytes(appSettings.Secret);

      ConfigureAuth(services, secretKey);
      services.AddScoped<IMarketService<Item>, ItemService>()
        .AddScoped<IMarketService<Cart>, CartService>()
        .AddScoped<IMarketService<SoldItem>, SoldItemService>()
        .AddScoped<IMarketService<Store>, StoreService>()
        .AddScoped<IMarketService<StoreItem>, StoreItemService>()
        .AddScoped<IAuthService<User>, AuthService>()
        .AddDbContext<ItemsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbString")));
    }

    private Action<AuthenticationOptions> addAuthConfig = x =>
        {
          x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        };

    private void ConfigureAuth(IServiceCollection services, byte[] key)
    {
      services.AddAuthentication(addAuthConfig).AddJwtBearer(x =>
       {
         x.RequireHttpsMetadata = false;
         x.SaveToken = true;
         x.TokenValidationParameters = new TokenValidationParameters
         {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(key),
           ValidateIssuer = false,
           ValidateAudience = false,
           ValidateLifetime = true
         };
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
      app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
      app.UseAuthentication();
      app.UseMvc();
    }
  }
}
