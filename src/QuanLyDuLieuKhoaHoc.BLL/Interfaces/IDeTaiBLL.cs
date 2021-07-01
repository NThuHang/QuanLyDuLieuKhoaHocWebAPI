using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial interface IDeTaiBLL
    {
        List<DeTaiModel> GetData();
        bool Create(DeTaiModel model);
        bool CreateGV(SoHuuDTModel model);
        bool Update(DeTaiModel model);
        bool UpdateGV(SoHuuDTModel model);
        bool Delete(int id);
        bool DeleteGV(int idDT, string idGV);
        DeTaiModel GetDatabyID(int id);
        List<DeTaiModel> GetDatabyGV(int id);
        SoHuuDTModel GetDatabyVT(int idDT, string idGV);
        List<DeTaiModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV);
        List<DeTaiModel> DTGV_ViTri(string id, string vitri);
        int GetTong();
        List<DeTaiModel> TK_Nam(int nam, bool trangthai);
    }
}
