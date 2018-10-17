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
				Genre = video.Genre.ToString()
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
				Genre = video.Genre.ToString()
			});
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(VideoEditViewModelcs model)
		{
			if (ModelState.IsValid)
			{
				var video = new Video
				{
					Title = model.Title,
					Genre = model.Genre
				};
				_videos.Add(video);
				return RedirectToAction("Details", new { Id = video.Id });
			}
			return View();
		}

	}
}
