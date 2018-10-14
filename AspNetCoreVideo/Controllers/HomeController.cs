using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Models;

namespace AspNetCoreVideo.Controllers
{
	public class HomeController : Controller
	{
		IHostingEnvironment _enviroment;
		public HomeController(IHostingEnvironment env)
		{
			_enviroment = env;
		}

		public ViewResult Index()
		{
			var model = new Video
			{
				Id = 1,
				Title = "Shreck"
			};
			return View(model);
		}

	}
}
