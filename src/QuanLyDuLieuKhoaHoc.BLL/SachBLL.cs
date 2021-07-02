using QuanLyDuLieuKhoaHoc.DAL;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial class SachBLL : ISachBLL
    {
        private ISachDAL _res;
        public SachBLL(ISachDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<SachModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(SachModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SachModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public SachModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<SachModel> GetDatabyGV(int id)
        {
            return _res.GetDatabyGV(id);
        }

        public List<SachModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV)
        {
            return _res.Search(pageIndex, pageSize, out total, ten, idGV);
        }

        public List<SachModel> SGV_ViTri(string id, string loai)
        {
            return _res.SGV_ViTri(id, loai);
        }
        public int GetTong()
        {
            var lay_tt = _res.GetData().ToList();
            var sl = lay_tt.Count;
            return sl;
        }
    }
}
