using QuanLyDuLieuKhoaHoc.DAL;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial class HoiNghiBLL : IHoiNghiBLL
    {
        private IHoiNghiDAL _res;
        public HoiNghiBLL(IHoiNghiDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<HoiNghiModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(HoiNghiModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HoiNghiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public HoiNghiModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<HoiNghiModel> Search(int pageIndex, int pageSize, out long total, string ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ten);
        }
        public int GetTong()
        {
            var lay_tt = _res.GetData().ToList();
            var sl = lay_tt.Count;
            return sl;
        }
    }

}
