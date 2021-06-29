using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.Model
{
    public class HoiNghiModel
    {
        public int Id { get; set; }
        public string TenHN { get; set; }
        public string LoaiHN { get; set; }
        public string KhuVuc { get; set; }
        public int TrangBD { get; set; }
        public int TrangKT { get; set; }
        public string HinhThuc { get; set; }
        public DateTime ThoiGian { get; set; }
        public string DiaDiem { get; set; }
    }
}
