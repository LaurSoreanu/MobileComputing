using HotelManagement.BusinessEntities;
using HotelManagement.BusinessService.Interfaces;
using HotelManagementAPI.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementAPI.Controllers
{
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class UserController : BaseController
	{
		private readonly IUserService _userService;
		private ConfigSettings _configSettings;

		public UserController(IUserService userService, IOptions<ConfigSettings> configSettings)
			: base()
		{
			_userService = userService;
			_configSettings = configSettings.Value;
		}

		//[HttpGet]
		//[AllowAnonymous]
		//public bool Login(string username, string password)
		//{
		//	return true;
		//}


		[Route("login")]
		[HttpGet]
		[AllowAnonymous]
		public async Task<IActionResult> Login(string userName, string password)
		{
			var userModel = await _userService.Login(userName, password);

			var userClaims = new List<Claim>
				{
					//new Claim(ClaimTypes.Email, userModel.UserName),
					new Claim(ClaimTypes.Name, userModel.Username),
					//new Claim(ClaimTypes.Role, userModel.Roles.ToString())
				};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configSettings.TokenSecretKey));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				 issuer: _configSettings.Issuer,
				 audience: _configSettings.Audience,
				 claims: userClaims,
				 expires: DateTime.Now.AddHours(_configSettings.TokenExpiration),
				 signingCredentials: credentials
			);

			return Ok(new
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				userModel.Username,
				userModel.Id,
			});
		}

		[Route("register")]
		[HttpPost]
		[AllowAnonymous]
		public async Task Register([FromBody] NewUser newUser)
		{
			await _userService.Register(newUser);
		}
	}
}
