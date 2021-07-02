using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyDuLieuKhoaHoc.BLL;
using QuanLyDuLieuKhoaHoc.Model;

namespace QuanLyDuLieuKhoaHoc.BackendServer.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserBLL _userBLL;
        public UsersController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }

        [AllowAnonymous]
        [HttpPost("xacthuctk")]
        public IActionResult XacThuc([FromBody] XacThucUserModel model)
        {
            var taikhoan = _userBLL.XacThuc(model.Username, model.Password);

            if (taikhoan == null)
                return null;
                 BadRequest(new { message = "Tên đăng nhập hoặc mật khẩu của bạn không chính xác!" });

            return Ok(taikhoan);
        }

        [Route("doimk")]
        [HttpPost]
        public UserModel UpdateUser([FromBody] UserModel model)
        {
            _userBLL.DoiMatKhau(model);
            return model;
        }

        [Route("getthongtin/{id}")]
        [HttpGet]
        public UserModel GetThongTin(string id)
        {
            return _userBLL.GetThongTin(id);
        }


    }
}
