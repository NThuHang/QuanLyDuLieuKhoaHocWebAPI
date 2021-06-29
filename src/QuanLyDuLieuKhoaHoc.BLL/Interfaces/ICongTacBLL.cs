using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial interface ICongTacBLL
    {
        List<CongTacModel> GetData();
        bool Create(CongTacModel model);
        bool Update(CongTacModel model);
        bool Delete(int id);
        CongTacModel GetDatabyID(string id);
        CongTacModel GetDatabyGV(string id);
        List<CongTacModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV);
        List<CongTacModel> GetGV(string id);
    }
}
