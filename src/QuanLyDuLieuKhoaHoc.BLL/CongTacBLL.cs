using QuanLyDuLieuKhoaHoc.DAL;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial class CongTacBLL : ICongTacBLL
    {
        private ICongTacDAL _res;
        public CongTacBLL(ICongTacDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<CongTacModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(CongTacModel model)
        {
            return _res.Create(model);
        }
        public bool Update(CongTacModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public CongTacModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public CongTacModel GetDatabyGV(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<CongTacModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV)
        {
            return _res.Search(pageIndex, pageSize, out total, ten, idGV);
        }
        public List<CongTacModel> GetGV(string id)
        {
            return _res.GetGV(id);
        }

    }
}
