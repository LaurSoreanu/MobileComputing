using HotelManagement.DataModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BusinessEntities
{
	public class UserModel
	{
		public int Id { get; set; }

		public string Username { get; set; }


		public static UserModel FromEntity(User user)
		{
			return new UserModel
			{
				Id = user.Id,
				Username = user.Username
			};
		}
	}
}
