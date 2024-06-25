using Microsoft.IdentityModel.Tokens;
using Partify.Domain.Entities.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Partify.Service.Helpers;

public static class AuthHelper
{
	public static string GenerateToken(User user)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var tokenKey = Encoding.UTF8.GetBytes(EnvironmentHelper.JwtKey);
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
			{
				 new Claim("Id", user.Id.ToString()),
				 new Claim("Phone", user.Phone.ToString()),
				 new Claim(ClaimTypes.Role, "User")
			}),
			Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(EnvironmentHelper.TokenLifeTimeInHour)),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}
