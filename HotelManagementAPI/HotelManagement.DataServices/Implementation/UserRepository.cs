using HotelManagement.DataModel.Model;
using HotelManagement.DataServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DataServices.Implementation
{
	public class UserRepository : GenericRepository<User>, IUserRepository
	{
		protected override string TableName => "User";


		public UserRepository(Entities dbContext) : base(dbContext)
		{
		}

		public async Task<User> GetByUserName(string username)
		{
			return await DbContext.User.SingleOrDefaultAsync(u => u.Username == username);
		}
	}
}
