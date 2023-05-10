using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QLSV1
{
    internal class SinhVien
    {
        public string MaSV { get; set; }
        public string TenSV { get; set; }
        public string gioitinh { get; set; }
        public int tuoi { get; set; }
        public string Diachi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public DateTime NgayThangNamsinh { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
        public string Nganh { get; set; }
    }
}
