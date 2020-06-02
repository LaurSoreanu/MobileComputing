using HotelManagement.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.DataModel.Model
{
	public class User : IIdentifiable
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "NVARCHAR(100)")]
		public string Email { get; set; }

		[Required]
		[Column(TypeName = "NVARCHAR(100)")]
		public string Username { get; set; }

		[Required]
		[Column(TypeName = "NVARCHAR(100)")]
		public string Password { get; set; }
	}
}
