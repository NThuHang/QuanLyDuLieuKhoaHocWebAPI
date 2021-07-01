using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface ISachDAL
    {
        List<SachModel> GetData();
        SachModel GetDatabyID(string id);
        List<SachModel> GetDatabyGV(int id);
        bool Create(SachModel model);
        bool Update(SachModel model);
        bool Delete(string id);
        List<SachModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV);
    }
}
