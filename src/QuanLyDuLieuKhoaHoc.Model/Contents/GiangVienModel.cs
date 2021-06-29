using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.Model
{
    public class GiangVienModel
    {
        public string Id { get; set; }

        public string Id_BoMon { get; set; }

        public string UserId { get; set; }

        public string TenBM { get; set; }

        public string TenGV { get; set; }

        public string HinhAnh { get; set; }

        public string GioiTinh { get; set; }

        public DateTime NgaySinh { get; set; }

        public string Sdt { get; set; }

        public string Email { get; set; }

        public string NoiSinh { get; set; }

        public string DiaChi { get; set; }

        public string TinHoc { get; set; }

        public string ChucVu { get; set; }

        public string ChucDanh { get; set; }

        public int? SoLuong_DeTai { get; set; }

        public int? SoLuong_Sach { get; set; }

        public int? SoLuong_BaiBao { get; set; }

        public int? SoLuong_HoiNghi { get; set; }
    }
}
