using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.Model
{
    public class BaoChiModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string TenGV { get; set; }

        public int Id_TapChi { get; set; }

        public int TenHN { get; set; }

        public string TenBB { get; set; }

        public string KhuVuc { get; set; }

        public string TenTC { get; set; }

        public string LoaiTC { get; set; }

        public int Vol { get; set; }

        public int TrangBD { get; set; }

        public int TrangKT { get; set; }
    }
}
