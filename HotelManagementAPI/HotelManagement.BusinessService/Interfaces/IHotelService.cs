using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.BusinessEntities;

namespace HotelManagement.BusinessService.Interfaces
{
	public interface IHotelService
	{
		IEnumerable<HotelModel> GetHotels();
		Task<bool> SaveHotel(string path);
	}
}
