using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface IGiangVienDAL
    {
        List<GiangVienModel> GetData();
        GiangVienModel GetDatabyID(string id);
        GiangVienModel Get_ThongTin_TK(string id);
        bool Create(GiangVienModel model);
        bool Update(GiangVienModel model);
        bool Delete(string id);
        List<GiangVienModel> Search(int pageIndex, int pageSize, out long total, string hoten);
        List<GiangVienModel> GetGV_DT();
        List<GiangVienModel> GetGV_Sach();
        List<GiangVienModel> GetGV_BBao();
    }
}
