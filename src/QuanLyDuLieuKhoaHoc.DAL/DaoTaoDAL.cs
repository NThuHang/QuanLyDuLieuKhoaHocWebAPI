using QuanLyDuLieuKhoaHoc.DAL.Helper;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial class DaoTaoDAL : IDaoTaoDAL
    {
        private IDatabaseHelper _dbHelper;
        public DaoTaoDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Lấy quá trình đào tạo theo ID giảng viên
        public List<DaoTaoModel> GetData_GV(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "daotao_getAll_ID_giangvien",
                     "@ID_GV", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DaoTaoModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DaoTaoModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "daotao_getID",
                     "@ID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DaoTaoModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(DaoTaoModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "daotao_create",
                "@Id_GiangVien", model.Id_GiangVien,
                "@BacDT", model.BacDT,
                "@NoiDT", model.NoiDT,
                "@ChuyenMon", model.ChuyenMon,
                "@NamTotNghiep", model.NamTotNghiep);
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "daotao_delete",
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
        public bool Update(DaoTaoModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "daotao_update",
                "@Id", model.Id,
                "@Id_GiangVien", model.Id_GiangVien,
                "@BacDT", model.BacDT,
                "@NoiDT", model.NoiDT,
                "@ChuyenMon", model.ChuyenMon,
                "@NamTotNghiep", model.NamTotNghiep);
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
        public List<DaoTaoModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "daotao_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                     "@ten", ten,
                     "@idGV", idGV);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DaoTaoModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DaoTaoModel> GetGV(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "daotao_getAll_ID_giangvien",
                     "@ID_GV", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DaoTaoModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Ngoại ngữ
        public List<NgoaiNguModel> Get_NgoaiNgu_GV(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "ngoaingu_getby_giangvien",
                     "@Id", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NgoaiNguModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
