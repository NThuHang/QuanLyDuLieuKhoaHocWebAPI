using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial interface IHoiNghiBLL
    {
        List<HoiNghiModel> GetData();
        bool Create(HoiNghiModel model);
        bool Update(HoiNghiModel model);
        bool Delete(string id);
        HoiNghiModel GetDatabyID(string id);
        List<HoiNghiModel> Search(int pageIndex, int pageSize, out long total, string ten);
        int GetTong();
    }
}

