using System.Text;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using StoreSystem.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using StoreSystem.Controllers;

namespace StoreSystem
{
	public class Startup
	{
		private IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers().AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.IgnoreNullValues = true;
			});

			services.AddMvc(option => option.EnableEndpointRouting = false);

			services.AddDbContext<StoreContext>(opt => opt.UseSqlServer(Configuration["Azure:ConnectionString"]));
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseMvc();

			app.UseAuthentication();
			app.UseAuthorization();
		}
	}
}