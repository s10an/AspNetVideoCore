﻿using AspNetCoreVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreVideo.ViewModels
{
	public class VideoEditViewModel
	{
		public int Id { get; set; }
		[Required, MinLength(3), MaxLength(80)]
		public string Title { get; set; }
		[Display(Name ="Film Genre")]
		public Genres Genre { get; set; }
	}
}
