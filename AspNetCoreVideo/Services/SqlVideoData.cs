using AspNetCoreVideo.Data;
using AspNetCoreVideo.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVideo.Services
{
	public class SqlVideoData : IVideoData
	{
		private VideoDbContext _db;
		public SqlVideoData(VideoDbContext db)
		{
			_db = db;
		}

		public void Add(Video video)
		{
			_db.Add(video);
			_db.SaveChanges();
		}

		public Video Get(int Id)
		{
			return _db.Find<Video>(Id);
		}

		public IEnumerable<Video> GetAll()
		{
			return _db.Videos;
		}
	}
}
