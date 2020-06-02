using HotelManagement.BusinessEntities;
using HotelManagement.BusinessEntities.Interfaces;
using HotelManagement.BusinessService.Interfaces;
using HotelManagement.DataModel.Model;
using HotelManagement.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessService.Implementation
{
	public class HotelService : IHotelService
	{
		private IHotelRepository _hotelRepository;
		private IHotelFactory _hotelFactory;
		private readonly IUnitOfWork _unitOfWork;

		public HotelService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork, IHotelFactory hotelFactory)
		{
			_hotelRepository = hotelRepository;
			_unitOfWork = unitOfWork;
			_hotelFactory = hotelFactory;
		}

		public IEnumerable<HotelModel> GetHotels()
		{
			var hotels = _hotelRepository.GetAllValues();

			return _hotelFactory.CreateEnumerableFrom(hotels);
		}

		public async Task<bool> SaveHotel(string path)
		{
			path = "C://Users//Laur//Desktop//di2.jpg";

			FileStream fs = new FileStream(path, FileMode.Open);

			MemoryStream ms = new MemoryStream();

			fs.CopyTo(ms);

			Hotel hotel = new Hotel()
			{
				Name = "name",
				ImageData = ms.ToArray()
			};

			 _hotelRepository.Add(hotel);

			try
			{
				await _unitOfWork.CommitChangesAsync();
			}
			catch(Exception e)
			{
				return false;
			}

			return true;
		}
	}
}
