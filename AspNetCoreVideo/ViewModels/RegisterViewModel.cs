using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreVideo.ViewModels
{

	public class RegisterViewModel
	{
		[Required, MaxLength(255)]
		public string UserName { get; set; }

		[Required, DataType(DataType.Password)]
		public string Password { get; set; }

		[Required, DataType(DataType.Password), Compare(nameof(Password))]
		public string ConfirmedPassword { get; set; }


	}
}
