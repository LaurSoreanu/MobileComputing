using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.BusinessService.Authentification
{
	public interface IPasswordHasher
	{
		string GeneratePassword();
		string HashPassword(string password);
		PasswordValidationResult VerifyHashedPassword(string hashedPassword, string providedPassword);
	}
}
