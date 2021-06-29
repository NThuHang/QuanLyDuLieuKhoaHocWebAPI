using QuanLyDuLieuKhoaHoc.DAL;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial class KhoaDaoTaoBLL : IKhoaDaoTaoBLL
    {
        private IKhoaDaoTaoDAL _res;
        public KhoaDaoTaoBLL(IKhoaDaoTaoDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<KhoaDaoTaoModel> GetData_GV(string id)
        {
            return _res.GetData_GV(id);
        }
        public KhoaDaoTaoModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(KhoaDaoTaoModel model)
        {
            return _res.Create(model);
        }
        public bool Update(KhoaDaoTaoModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<KhoaDaoTaoModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
        public List<KhoaDaoTaoModel> GetGV(string id)
        {
            return _res.GetGV(id);
        }
    }
}
