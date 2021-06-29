﻿using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial interface ISachBLL
    {
        List<SachModel> GetData();
        bool Create(SachModel model);
        bool Update(SachModel model);
        bool Delete(string id);
        SachModel GetDatabyID(string id);
        List<SachModel> Search(int pageIndex, int pageSize, out long total, string ten);
        int GetTong();
    }
}
