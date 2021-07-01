using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.Model
{
    public class SachModel
    {
        public int Id { get; set; }

        public string Id_GiangVien { get; set; }

        public string TenSach { get; set; }

        public string LoaiSach { get; set; }

        public string TenGV { get; set; }

        public string ViTri { get; set; }

        public string NoiXB { get; set; }

        public int NamXB { get; set; }

        public int ISBN { get; set; }
    }
}
