using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Security.Cryptography;
using DATN_Demo.Data;
using DATN_Demo.Shared.Dtos;
using DATN_Demo.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace DATN_Demo.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ApplicationDbContext _context;
		public AuthController(IConfiguration configuration, ApplicationDbContext context)
		{
			_configuration = configuration;
			_context = context;
		}
		[Route("signup")]
		[HttpPost]
		public async Task<ActionResult<User>> Register(UserDto request)
		{
			CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
			var NewUser = new User
			{
				UserName = request.Username,
				PasswordHash = passwordHash,
				PasswordSalt = passwordSalt,
				RoleID = Guid.Parse("7EFA4454-3935-4567-898C-F4AAE5237210")

			};
			await _context.Users.AddAsync(NewUser);
			await _context.SaveChangesAsync();
			return Ok(NewUser);
		}

		[Route("login")]
		[HttpPost]

		public async Task<ActionResult<string>> Login(UserDto request)
		{
			if (GetUser(request) == null)
			{
				return BadRequest("user not found");
			}
		
			if (!VerifyPasswordHash(request.Password, GetUser(request).PasswordHash,GetUser(request).PasswordSalt ))
			{
				return BadRequest("wrong password");
			}
			string token = CreateToken(GetUser(request));
			return token;
		}


		private string CreateToken(User user)
		{
			var GetRoleByUser = (
					from a in _context.Users join
					b in _context.Roles on a.RoleID equals b.RoleID
					where a.UserName == user.UserName
					select new
					{
						b.Name
					
					}
				).ToList();			  

			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName),	
				
			};
			if (GetRoleByUser.Any())
			{
				var roles = GetRoleByUser.Select(r => r.Name);
				claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Roles, role)));
			}

			var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
			
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: creds
				) ;
			var jwt = new JwtSecurityTokenHandler().WriteToken(token);
			return jwt;

		}

		private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512(passwordSalt))
			{
				var ComputePasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				return ComputePasswordHash.SequenceEqual(passwordHash);
			}
		}

		private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
		{
			using (var hmac = new HMACSHA512())
			{
				passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
				passwordSalt = hmac.Key;

			}
		}


		private  User GetUser(UserDto request)
		{
			return  _context.Users.FirstOrDefault(p => p.UserName == request.Username);
		}

	}
}
