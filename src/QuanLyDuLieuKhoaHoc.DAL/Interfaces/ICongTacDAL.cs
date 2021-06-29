using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface ICongTacDAL
    {
        List<CongTacModel> GetData();
        CongTacModel GetDatabyID(string id);
        CongTacModel GetDatabyGV(string id);
        bool Create(CongTacModel model);
        bool Update(CongTacModel model);
        bool Delete(int id);
        List<CongTacModel> GetGV(string id);
        List<CongTacModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV);
    }
}
