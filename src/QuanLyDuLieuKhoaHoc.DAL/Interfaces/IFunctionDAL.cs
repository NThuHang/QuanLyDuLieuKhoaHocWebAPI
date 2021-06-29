using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.DAL
{
    public partial interface IFunctionDAL
    {
        List<FunctionModel> GetData(string quyen);
    }
}

