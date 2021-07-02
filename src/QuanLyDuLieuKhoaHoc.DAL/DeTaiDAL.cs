using QuanLyDuLieuKhoaHoc.DAL.Helper;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial class DeTaiDAL : IDeTaiDAL
    {
        private IDatabaseHelper _dbHelper;
        public DeTaiDAL(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<DeTaiModel> GetData()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "detai_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DeTaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DeTaiModel GetTopCuoi()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "detai_getAll");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DeTaiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DeTaiModel GetDatabyID(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "detai_getID",
                     "@ID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DeTaiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DeTaiModel> GetDatabyGV(int id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "detai_getGV",
                     "@ID", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DeTaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SoHuuDTModel GetDatabyVT(int idDT, string idGV)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "detai_getVTri",
                     "@Id_DeTai", idDT,
                     "@Id_GiangVien", idGV);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SoHuuDTModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Create(DeTaiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "detai_create",
                "@LoaiDT", model.LoaiDT,
                "@TenDT", model.TenDT,
                "@MaSo", model.MaSo,
                "@CapQuanLy", model.CapQuanLy,
                "@CoQuanQuanLy", model.CoQuanQuanLy,
                "@ThoiGianBD", model.ThoiGianBD,
                "@ThoiGianKT", model.ThoiGianKT,
                "@ThanhTich", model.ThanhTich,
                "@Status", model.Status
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
        public bool CreateGV(SoHuuDTModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "detai_giangvien_create",
                 "@Id_DeTai", model.Id_DeTai,
                "@Id_GiangVien", model.Id_GiangVien,
                "@ViTri", model.ViTri
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
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "detai_delete",
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
        public bool DeleteGV(int idDT, string idGV)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "detai_gv_delete",
                "@Id_DeTai", idDT,
                "@Id_GiangVien", idGV);
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
        public bool Update(DeTaiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "detai_update",
                "@Id", model.Id,
                "@LoaiDT", model.LoaiDT,
                "@TenDT", model.TenDT,
                "@MaSo", model.MaSo,
                "@CapQuanLy", model.CapQuanLy,
                "@CoQuanQuanLy", model.CoQuanQuanLy,
                "@ThoiGianBD", model.ThoiGianBD,
                "@ThoiGianKT", model.ThoiGianKT,
                "@ThanhTich", model.ThanhTich);
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

        public bool UpdateGV(SoHuuDTModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "detai_giangvien_update",
                "@Id_DeTai", model.Id_DeTai,
                "@Id_GiangVien", model.Id_GiangVien,
                "@ViTri", model.ViTri);
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

        public List<DeTaiModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "detai_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten", ten,
                    "@idGV", idGV);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DeTaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DeTaiModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "detai_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten", ten);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<DeTaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DeTaiModel> DTGV_ViTri(string id, string vitri)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "lay_dlkh_gv",
                    "@Id", id,
                    "@vitri", vitri);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DeTaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DeTaiModel> TK_Nam(int nam, bool trangthai)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "detai_TK_Nam",
                    "@tg", nam, "@tt", trangthai);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<DeTaiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }

}
