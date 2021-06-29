using QuanLyDuLieuKhoaHoc.DAL;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial class DaoTaoBLL : IDaoTaoBLL
    {
        private IDaoTaoDAL _res;
        public DaoTaoBLL(IDaoTaoDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<DaoTaoModel> GetData_GV(string id)
        {
            return _res.GetData_GV(id);
        }
        public DaoTaoModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(DaoTaoModel model)
        {
            return _res.Create(model);
        }
        public bool Update(DaoTaoModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<DaoTaoModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV)
        {
            return _res.Search(pageIndex, pageSize, out total, ten, idGV);
        }
        public List<DaoTaoModel> GetGV(string id)
        {
            return _res.GetGV(id);
        }

        //Ngoại ngữ
        public List<NgoaiNguModel> Get_NgoaiNgu_GV(string id)
        {
            return _res.Get_NgoaiNgu_GV(id);
        }
    }
}
