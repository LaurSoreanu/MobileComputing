using HotelManagement.BusinessEntities;
using HotelManagement.BusinessService.Authentification;
using HotelManagement.BusinessService.Interfaces;
using HotelManagement.DataModel.Model;
using HotelManagement.DataServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BusinessService.Implementation
{

	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IPasswordHasher _passwordHasher;
		private readonly IUnitOfWork _unitOfWork;

		public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher, IUnitOfWork unitOfWork)
		{
			_userRepository = userRepository;
			_passwordHasher = passwordHasher;
			_unitOfWork = unitOfWork;
		}

		public async Task Register(NewUser newUser)
		{

			var user = new User
			{
				Email = newUser.Email,
				Username = newUser.Username,
				Password = _passwordHasher.HashPassword(newUser.Password)
			};

			_userRepository.Add(user);
			await _unitOfWork.CommitChangesAsync();
		}

		public async Task<UserModel> Login(string username, string password)
		{
			UserModel response = null;

			var user = await _userRepository.GetByUserName(username);

			if (user == null)
			{
				throw new DataException($"cannot find a user with the given username: {username}");
			}
			else
			{
				var passwordResult = _passwordHasher.VerifyHashedPassword(user.Password, password);

				switch (passwordResult)
				{
					case PasswordValidationResult.Success:
						response = UserModel.FromEntity(user);
						break;
					case PasswordValidationResult.SuccessRehashNeeded:
						throw new NotSupportedException("Password needs to be changed");
					case PasswordValidationResult.Failed:
						response = null;
						break;
				}

				return response;
			}
		}
	}
}
