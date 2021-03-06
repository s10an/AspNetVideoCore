﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Data;
using AspNetCoreVideo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using AspNetCoreVideo.Entities;
using Microsoft.Extensions.FileProviders;

namespace AspNetCoreVideo
{
	public class Startup
	{
		private IConfiguration configuration;
		public IConfiguration Configuration { get => configuration; set => configuration = value; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true);

			if (env.IsDevelopment()) builder.AddUserSecrets<Startup>();

			Configuration = builder.Build();

		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			var conn = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<VideoDbContext>(options => options.UseSqlServer(conn));
			services.AddMvc();
			services.AddSingleton<IMessageService, ConfigurationMessageService>();
			services.AddScoped<IVideoData, SqlVideoData>();
			services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<VideoDbContext>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService msg)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseAuthentication();
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(
				Path.Combine(Directory.GetCurrentDirectory(), @"Lib")),
				RequestPath = new PathString("/lib")
			});
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync($"{env.ApplicationName} - {msg.GetMessage()}");
			});
		}
	}
}
