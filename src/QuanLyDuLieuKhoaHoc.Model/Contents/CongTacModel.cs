using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.Model
{
    public class CongTacModel
    {
        public int Id { get; set; }
        public string Id_GiangVien { get; set; }
        public string TenGV { get; set; }
        public string ViTri { get; set; }
        public string CoQuan { get; set; }
        public string DiaChi { get; set; }
        public DateTime ThoiGianBD { get; set; }
        public DateTime? ThoiGianKT { get; set; }
    }
}
