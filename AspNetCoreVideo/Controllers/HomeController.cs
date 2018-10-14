using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Enteties;
using AspNetCoreVideo.Services;
using AspNetCoreVideo.ViewModels;

namespace AspNetCoreVideo.Controllers
{
	public class HomeController : Controller
	{
		IVideoData _videos;
		public HomeController(IVideoData videos)
		{
			_videos = videos;
		}

		public ViewResult Index()
		{

			var model = _videos.GetAll().Select(video => new VideoViewModel
			{
				Id = video.Id,
				Title = video.Title,
				Genre = Enum.GetName(typeof(Genres), video.GenreId)
			});


			return View(model);
		}

		public IActionResult Details(int id)
		{
			var video = _videos.Get(id);
			if (video == null) return RedirectToAction("Index");
			
			return View(new VideoViewModel
			{
				Id = video.Id,
				Title = video.Title,
				Genre = Enum.GetName(typeof(Genres), video.GenreId)
			});
		}

	}
}
