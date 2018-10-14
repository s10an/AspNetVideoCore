using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Enteties;

namespace AspNetCoreVideo.Services
{
	public class MockVideoData : IVideoData
	{
		private IEnumerable<Video> _videos;

		public MockVideoData()
		{
			_videos = new List<Video>
			{
				new Video { Id = 1, GenreId = 2, Title = "Shreck" },
				new Video { Id = 2, GenreId = 4,Title = "Unbreakable" },
				new Video { Id = 3, GenreId = 3,Title = "Tron" },
				new Video { Id = 4, GenreId = 2,Title = "Troy" },
				new Video { Id = 4, GenreId = 1,Title = "Memento" }
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
	}
}
