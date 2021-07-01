using QuanLyDuLieuKhoaHoc.DAL.Helper;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial class UserDAL : IUserDAL
    {
        private IDatabaseHelper _dbHelper;
        public UserDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public UserModel GetUser(string username, string password)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "dang_nhap",
                     "@Ten_TK", username,
                     "@MatKhau", password);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public UserModel GetThongTin(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "lay_thong_tin",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<UserModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserModel GetTaiKhoan(string tentk, string password)
        {
            throw new NotImplementedException();
        }

        //Đổi mật khẩu
        public bool DoiMatKhau(UserModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "doi_mat_khau",
                "@TenGV", model.Password);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
