using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface IDeTaiDAL
    {
        List<DeTaiModel> GetData();
        DeTaiModel GetTopCuoi();
        DeTaiModel GetDatabyID(int id);
        List<DeTaiModel> GetDatabyGV(int id);
        SoHuuDTModel GetDatabyVT(int idDT, string idGV);
        bool Create(DeTaiModel model);
        bool CreateGV(SoHuuDTModel model);
        bool Update(DeTaiModel model);
        bool UpdateGV(SoHuuDTModel model);
        bool Delete(int id);
        bool DeleteGV(int idDT, string idGV);
        List<DeTaiModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV);
        List<DeTaiModel> Search(int pageIndex, int pageSize, out long total, string ten);
        List<DeTaiModel> DTGV_ViTri(string id, string vitri);
        List<DeTaiModel> TK_Nam(int nam, bool trangthai);
    }
}
