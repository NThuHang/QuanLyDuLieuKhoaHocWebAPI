using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface ITapChiDAL
    {
        List<TapChiModel> GetData();
        TapChiModel GetDatabyID(string id);
        List<TapChiModel> GetbyIDLoai(string id);
        bool Create(TapChiModel model);
        bool Update(TapChiModel model);
        bool Delete(string id);
        List<TapChiModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
