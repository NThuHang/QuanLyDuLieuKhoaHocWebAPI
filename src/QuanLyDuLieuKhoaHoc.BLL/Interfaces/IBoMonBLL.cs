﻿using QuanLyDuLieuKhoaHoc.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.BLL
{
    public partial interface IBoMonBLL
    {
        List<BoMonModel> GetData();
        bool Create(BoMonModel model);
        bool Update(BoMonModel model);
        bool Delete(string id);
        BoMonModel GetDatabyID(string id);
        List<BoMonModel> Search(int pageIndex, int pageSize, out long total, string ten);
        List<BoMonModel> GetKhoa(string id);
    }
}
