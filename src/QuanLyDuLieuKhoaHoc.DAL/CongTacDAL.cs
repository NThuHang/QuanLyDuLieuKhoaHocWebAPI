using QuanLyDuLieuKhoaHoc.DAL.Helper;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial class CongTacDAL : ICongTacDAL
    {
        private IDatabaseHelper _dbHelper;
        public CongTacDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<CongTacModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "congtac_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CongTacModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CongTacModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "congtac_getID",
                     "@ID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CongTacModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(CongTacModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "congtac_create",
                "@Id_GiangVien", model.Id_GiangVien,
                "@ViTri", model.ViTri,
                "@CoQuan", model.CoQuan,
                "@Diachi", model.DiaChi,
                "@ThoiGianBD", model.ThoiGianBD,
                "@ThoiGianKT", model.ThoiGianKT
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
        public bool Delete(int id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "congtac_delete",
                "@ID", id);
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
        public bool Update(CongTacModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "congtac_update",
                "@Id", model.Id,
                "@Id_GiangVien", model.Id_GiangVien,
                "@ViTri", model.ViTri,
                "@CoQuan", model.CoQuan,
                "@Diachi", model.DiaChi,
                "@ThoiGianBD", model.ThoiGianBD,
                "@ThoiGianKT", model.ThoiGianKT);
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

        public List<CongTacModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "congtac_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                     "@ten", ten,
                     "@idGV", idGV);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<CongTacModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CongTacModel> GetGV(string id)
        {
            string msgError = "";
            try
            {

                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "congtac_getAll_ID_giangvien",
                     "@ID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CongTacModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public CongTacModel GetDatabyGV(string id)
        {
            string msgError = "";
            try
            {

                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "congtac_getAll_ID_giangvien",
                     "@ID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<CongTacModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
