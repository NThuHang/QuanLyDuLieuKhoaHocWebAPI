using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial interface IKhoaDaoTaoBLL
    {
        List<KhoaDaoTaoModel> GetData_GV(string id);
        bool Create(KhoaDaoTaoModel model);
        bool Update(KhoaDaoTaoModel model);
        bool Delete(string id);
        KhoaDaoTaoModel GetDatabyID(string id);
        List<KhoaDaoTaoModel> GetGV(string id);
        List<KhoaDaoTaoModel> Search(int pageIndex, int pageSize, out long total, string ten);

    }
}
