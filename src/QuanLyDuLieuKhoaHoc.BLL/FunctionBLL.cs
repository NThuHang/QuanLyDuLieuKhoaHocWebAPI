using QuanLyDuLieuKhoaHoc.DAL;
using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial class FunctionBLL : IFunctionBLL
    {
        private IFunctionDAL _res;
        public FunctionBLL(IFunctionDAL FunctionRes)
        {
            _res = FunctionRes;
        }
        public List<FunctionModel> GetData(string quyen)
        {
            var lay_menu = _res.GetData(quyen);
            var ds_cha = lay_menu.Where(ds => ds.IdCha == null).OrderBy(s => s.Stt).ToList();
            foreach (var item in ds_cha)
            {
                item.DSCon = GetFunctionCon(lay_menu, item);
            }
            return ds_cha;
        }
        public List<FunctionModel> GetFunctionCon(List<FunctionModel> lstAll, FunctionModel node)
        {
            var ds_con = lstAll.Where(ds => ds.IdCha == node.Id).ToList();
            if (ds_con.Count == 0)
                return null;
            for (int i = 0; i < ds_con.Count; i++)
            {
                var con = GetFunctionCon(lstAll, ds_con[i]);
                ds_con[i].DSCon = con;
            }
            return ds_con.OrderBy(s => s.Stt).ToList();
        }
    }
}
