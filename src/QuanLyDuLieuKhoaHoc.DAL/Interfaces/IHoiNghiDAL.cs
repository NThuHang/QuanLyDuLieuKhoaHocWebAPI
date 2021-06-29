using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface IHoiNghiDAL
    {
        List<HoiNghiModel> GetData();
        HoiNghiModel GetDatabyID(string id);
        bool Create(HoiNghiModel model);
        bool Update(HoiNghiModel model);
        bool Delete(string id);
        List<HoiNghiModel> Search(int pageIndex, int pageSize, out long total, string ten);
    }
}
