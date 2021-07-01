using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial interface IBaoChiBLL
    {
        List<BaoChiModel> GetData();

        List<BaoChiModel> GetDataGV(string id);
        bool Create(BaoChiModel model);
        bool Update(BaoChiModel model);
        bool Delete(string id);
        BaoChiModel GetDatabyID(string id);
        List<BaoChiModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV);
        int GetTong();
    }
}
