using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.Domain
{
	public class ConfigSettings
	{
		public string TokenSecretKey { get; set; }
		public int TokenExpiration { get; set; }
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public string ConnectionString { get; set; }
		public string AppUrl { get; set; }
	}
}
