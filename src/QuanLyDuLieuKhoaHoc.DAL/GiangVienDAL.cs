using QuanLyDuLieuKhoaHoc.DAL.Helper;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial class GiangVienDAL : IGiangVienDAL
    {
        private IDatabaseHelper _dbHelper;
        public GiangVienDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<GiangVienModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "giangvien_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiangVienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        // DS giảng viên có đề tài 
        public List<GiangVienModel> GetGV_DT()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Allgiangvien_co_detai");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiangVienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        // DS giảng viên có sách
        public List<GiangVienModel> GetGV_Sach()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Allgiangvien_co_sach");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiangVienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        // DS giảng viên có bài báo 
        public List<GiangVienModel> GetGV_BBao()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "Allgiangvien_co_baibao");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiangVienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public GiangVienModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "giangvien_getID",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiangVienModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(GiangVienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "giangvien_create",
                "@Id", model.Id,
                "@UserId", model.UserId,
                "@Id_BoMon", model.Id_BoMon,
                "@TenGV", model.TenGV,
                "@HinhAnh", model.HinhAnh,
                "@NgaySinh", model.NgaySinh,
                "@GioiTinh", model.GioiTinh,
                "@NoiSinh", model.NoiSinh,
                "@DiaChi", model.DiaChi,
                "@TinHoc", model.TinHoc,
                "@ChucVu", model.ChucVu,
                "@ChucDanh", model.ChucDanh,
                "@Sdt", model.Sdt,
                "@Email", model.Email
                );
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

        public bool Delete(string id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "giangvien_delete",
                "@Id", id);
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
        public bool Update(GiangVienModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "giangvien_update",
                "@Id", model.Id,
                "@UserId", model.UserId,
                "@Id_BoMon", model.Id_BoMon,
                "@TenGV", model.TenGV,
                "@HinhAnh", model.HinhAnh,
                "@NgaySinh", model.NgaySinh,
                "@GioiTinh", model.GioiTinh,
                "@NoiSinh", model.NoiSinh,
                "@DiaChi", model.DiaChi,
                "@TinHoc", model.TinHoc,
                "@ChucVu", model.ChucVu,
                "@ChucDanh", model.ChucDanh,
                "@Sdt", model.Sdt,
                "@Email", model.Email);
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

        public List<GiangVienModel> Search(int pageIndex, int pageSize, out long total, string hoten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "giangvien_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                     "@hoten", hoten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<GiangVienModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GiangVienModel Get_ThongTin_TK(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "lay_thong_tin",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<GiangVienModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

    }
}
