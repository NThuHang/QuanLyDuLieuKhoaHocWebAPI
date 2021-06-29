using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLyDuLieuKhoaHoc.DAL;
using QuanLyDuLieuKhoaHoc.Model;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial class GiangVienBLL : IGiangVienBLL
    {
        private IGiangVienDAL _res;
        public GiangVienBLL(IGiangVienDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<GiangVienModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(GiangVienModel model)
        {
            return _res.Create(model);
        }
        public bool Update(GiangVienModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }

        public GiangVienModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public List<GiangVienModel> Search(int pageIndex, int pageSize, out long total, string hoten)
        {
            return _res.Search(pageIndex, pageSize, out total, hoten);
        }
        public GiangVienModel Get_ThongTin_TK(string id)
        {
            return _res.Get_ThongTin_TK(id);
        }

        public int GetTong()
        {
            var lay_tt = _res.GetData().ToList();
            var sl = lay_tt.Count;
            return sl;
        }

        public List<GiangVienModel> GetGV_DeTai()
        {
            return _res.GetGV_DT();
        }
        public List<GiangVienModel> GetGV_Sach()
        {
            return _res.GetGV_Sach();
        }
        public List<GiangVienModel> GetGV_BBao()
        {
            return _res.GetGV_BBao();
        }

    }
}

