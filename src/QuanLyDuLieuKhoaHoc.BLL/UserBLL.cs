using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuanLyDuLieuKhoaHoc.DAL;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial class UserBLL : IUserBLL
    {
        private IUserDAL _res;
        private string Secret;
        public UserBLL(IUserDAL res, IConfiguration configuration)
        {
            Secret = configuration["AppSettings:Secret"];
            _res = res;
        }

        public UserModel XacThuc(string username, string password)
        {
            var user = _res.GetUser(username, password);
            // return null if User not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                   // new Claim(ClaimTypes.Role, user.TenQuyen.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;

        }

        public UserModel GetThongTin(string id)
        {
            return _res.GetThongTin(id);
        }

        public bool DoiMatKhau(UserModel model)
        {
            return _res.DoiMatKhau(model);
        }

    }
}