using HotelManagement.BusinessEntities;
using HotelManagement.BusinessService.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class HotelController : BaseController
	{
		private readonly IHotelService _hotelService;

		public HotelController(IHotelService hotelService)
			: base()
		{
			_hotelService = hotelService;
		}

		[HttpGet]
		public IEnumerable<HotelModel> GetHotels()
		{
			return _hotelService.GetHotels();
		}

		//[HttpPost]
		//[AllowAnonymous]
		//public async Task<bool> SaveHotel([FromBody]HotelModel path)
		//{
		//	return await _hotelService.SaveHotel(path.Img);
		//}
	}
}
