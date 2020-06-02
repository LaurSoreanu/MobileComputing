using HotelManagement.DataModel.Model;
using HotelManagement.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelManagement.DataServices.Implementation
{
	public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
	{
		protected override string TableName => "Hotel";

		public HotelRepository(Entities dbContext) : base(dbContext)
		{
		}

		public IEnumerable<Hotel> GetAllValues()
		{
			return this.DbContext.Hotel.ToList();
		}
	}
}
