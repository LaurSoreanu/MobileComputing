using HotelManagement.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessService.Interfaces
{
	public interface IUserService
	{
		Task Register(NewUser newUser);

		Task<UserModel> Login(string username, string password);
	}
}
