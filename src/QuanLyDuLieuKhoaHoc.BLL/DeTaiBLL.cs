using QuanLyDuLieuKhoaHoc.DAL;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial class DeTaiBLL : IDeTaiBLL
    {
        private IDeTaiDAL _res;
        public DeTaiBLL(IDeTaiDAL ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public List<DeTaiModel> GetData()
        {
            return _res.GetData();
        }
        public bool Create(DeTaiModel model)
        {
            return _res.Create(model);
        }
        public bool CreateGV(SoHuuDTModel model)
        {
            return _res.CreateGV(model);
        }
        public bool Update(DeTaiModel model)
        {
            return _res.Update(model);
        }
        public bool UpdateGV(SoHuuDTModel model)
        {
            return _res.UpdateGV(model);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }

        public bool DeleteGV(int idDT, string idGV)
        {
            return _res.DeleteGV(idDT,idGV);
        }

        public DeTaiModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }

        public SoHuuDTModel GetDatabyVT(int idDT, string idGV)
        {
            return _res.GetDatabyVT(idDT,idGV);
        }


        public List<DeTaiModel> GetDatabyGV(int id)
        {
            return _res.GetDatabyGV(id);
        }

        public List<DeTaiModel> Search(int pageIndex, int pageSize, out long total, string ten, string idGV)
        {
            return _res.Search(pageIndex, pageSize, out total, ten, idGV);
        }
        public List<DeTaiModel> DTGV_ViTri(string id, string vitri)
        {
            return _res.DTGV_ViTri(id, vitri);
        }
        public int GetTong()
        {
            var lay_tt = _res.GetData().ToList();
            var sl = lay_tt.Count;
            return sl;
        }
        public List<DeTaiModel> TK_Nam(int nam, bool trangthai)
        {
            return _res.TK_Nam(nam, trangthai);
        }
    }
}
