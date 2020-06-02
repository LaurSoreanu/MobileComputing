using HotelManagement.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BusinessEntities.Interfaces
{
	public interface IHotelFactory
	{
		IEnumerable<HotelModel> CreateEnumerableFrom(IEnumerable<Hotel> hotels);
	}
}
