using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial interface IFunctionBLL
    {
        List<FunctionModel> GetData(string id);
    }
}
