using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface IDeTaiDAL
    {
        List<DeTaiModel> GetData();
        DeTaiModel GetDatabyID(int id);
        List<DeTaiModel> GetDatabyGV(int id);
        bool Create(DeTaiModel model);
        bool Create_GV(DeTaiModel model);
        bool Update(DeTaiModel model);
        bool Delete(string id);
        List<DeTaiModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV);
        List<DeTaiModel> DTGV_ViTri(string id, string vitri);
        List<DeTaiModel> TK_Nam(int nam, bool trangthai);
    }
}
