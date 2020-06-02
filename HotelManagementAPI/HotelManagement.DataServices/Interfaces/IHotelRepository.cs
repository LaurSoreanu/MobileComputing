using HotelManagement.DataContracts.Interfaces;
using HotelManagement.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.DataServices.Interfaces
{
	public interface IHotelRepository : IGenericRepository<Hotel>
	{
		IEnumerable<Hotel> GetAllValues();
	}
}
