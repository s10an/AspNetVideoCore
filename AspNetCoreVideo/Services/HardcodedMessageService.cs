using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVideo.Services
{
	public class HardcodedMessageService : IMessageService
	{
		public string GetMessage()
		{
			return "Hello from HardcodedMessageService!";
		}
	}
}
