using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface IBoMonDAL
    {
        List<BoMonModel> GetData();
        BoMonModel GetDatabyID(string id);
        bool Create(BoMonModel model);
        bool Update(BoMonModel model);
        bool Delete(string id);
        List<BoMonModel> Search(int pageIndex, int pageSize, out long total, string ten);
        List<BoMonModel> GetBoMon_idKhoa(string id);
    }
}
