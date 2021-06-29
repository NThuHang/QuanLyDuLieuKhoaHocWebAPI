using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial interface IUserBLL
    {
        UserModel XacThuc(string username, string password);
        UserModel GetThongTin(string id);
        bool DoiMatKhau(UserModel model);
        UserModel GetMenu(string id);
    }
}
