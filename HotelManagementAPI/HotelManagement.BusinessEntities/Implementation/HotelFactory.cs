using HotelManagement.BusinessEntities.Interfaces;
using HotelManagement.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BusinessEntities.Implementation
{
	public class HotelFactory : IHotelFactory
	{
		public IEnumerable<HotelModel> CreateEnumerableFrom(IEnumerable<Hotel> hotels)
		{
			var result = new List<HotelModel>();

			foreach(Hotel hotel in hotels)
			{
				result.Add(CreateFrom(hotel));
			}

			return result;
		}

		private HotelModel CreateFrom(Hotel hotel)
		{
			return new HotelModel()
			{
				Name = hotel.Name,
				Img = hotel.ImageData,
				Description = ""
			};
		}
	}
}
