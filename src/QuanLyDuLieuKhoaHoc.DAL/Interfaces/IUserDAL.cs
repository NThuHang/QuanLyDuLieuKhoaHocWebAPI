using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface IUserDAL
    {
        UserModel GetUser(string username, string password);
        UserModel GetThongTin(string id);
        bool DoiMatKhau(UserModel model);
        UserModel GetMenu(string id);
    }
}
