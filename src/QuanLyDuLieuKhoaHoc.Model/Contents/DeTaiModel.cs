using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.Model
{
    public class DeTaiModel
    {
        public int Id { get; set; }

        public string Id_GiangVien { get; set; }

        public string TenGV { get; set; }

        public string ViTri { get; set; }

        public string TenDT { get; set; }

        public string LoaiDT { get; set; }

        public int MaSo { get; set; }

        public DateTime ThoiGianBD { get; set; }

        public DateTime? ThoiGianKT { get; set; }

        public bool Status { get; set; }

        public string CapQuanLy { get; set; }

        public string CoQuanQuanLy { get; set; }

        public string ThanhTich { get; set; }
    }
}
