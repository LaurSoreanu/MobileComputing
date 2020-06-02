using HotelManagement.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelManagement.DataModel.Model
{
	public class Hotel : IIdentifiable
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Column(TypeName = "NVARCHAR(100)")]
		public string Name { get; set; }

		public byte[] ImageData { get; set; }
	}
}
