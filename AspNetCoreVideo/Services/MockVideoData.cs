using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Enteties;
using AspNetCoreVideo.Models;


namespace AspNetCoreVideo.Services
{
	public class MockVideoData : IVideoData
	{
		private List<Video> _videos;

		public MockVideoData()
		{
			_videos = new List<Video>
			{
				new Video { Id = 1, Genre = Models.Genres.Animates, Title = "Shreck" },
				new Video { Id = 2, Genre = Models.Genres.Romance,Title = "Unbreakable" },
				new Video { Id = 3, Genre = Models.Genres.Action,Title = "Tron" },
				new Video { Id = 4, Genre = Models.Genres.Comedy,Title = "Troy" },
				new Video { Id = 5, Genre = Models.Genres.Animates,Title = "Memento" }
			};
		}

		public IEnumerable<Video> GetAll()
		{
			return _videos;
		}
		public Video Get(int Id)
		{
			return _videos.FirstOrDefault(video => video.Id.Equals(Id));
		}

		public void Add(Video newVideo)
		{
			newVideo.Id = _videos.Max(v => v.Id) + 1;
			_videos.Add(newVideo);
		}
	}
}
