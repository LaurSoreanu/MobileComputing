using HotelManagement.DataContracts.Interfaces;
using HotelManagement.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DataServices.Interfaces
{
	public interface IUserRepository : IGenericRepository<User>
	{
		Task<User> GetByUserName(string username);

	}
}
