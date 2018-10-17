using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVideo.Enteties;

namespace AspNetCoreVideo.Services
{
	public interface IVideoData
	{
		IEnumerable<Video> GetAll();
		Video Get(int Id);

		void Add(Video video);
	}
}
