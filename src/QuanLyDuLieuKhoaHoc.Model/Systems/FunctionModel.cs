using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLyDuLieuKhoaHoc.Model
{
    public class FunctionModel
    {
        public string Id { get; set; }

        public string Ten { get; set; }

        public string Icon  { get; set; }

        public string Url { get; set; }

        public int Stt { get; set; }

        public string IdCha { get; set; }
        public List<FunctionModel> DSCon { get; set; }
        public bool? TrangThai { get; set; }
    }
}
