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
        bool Create_GV(DeTaiModel model);
        bool Update(DeTaiModel model);
        bool Delete(string id);
        DeTaiModel GetDatabyID(int id);
        List<DeTaiModel> GetDatabyGV(int id);
        List<DeTaiModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV);
        List<DeTaiModel> DTGV_ViTri(string id, string vitri);
        int GetTong();
        List<DeTaiModel> TK_Nam(int nam, bool trangthai);
    }
}
