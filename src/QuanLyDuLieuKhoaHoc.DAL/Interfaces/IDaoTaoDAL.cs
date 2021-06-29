using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface IDaoTaoDAL
    {
        List<DaoTaoModel> GetData_GV(string id);
        bool Create(DaoTaoModel model);
        bool Update(DaoTaoModel model);
        bool Delete(string id);
        DaoTaoModel GetDatabyID(string id);
        List<DaoTaoModel> GetGV(string id);
        List<DaoTaoModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV);

        //Ngoại ngữ
        List<NgoaiNguModel> Get_NgoaiNgu_GV(string id);
    }
}
