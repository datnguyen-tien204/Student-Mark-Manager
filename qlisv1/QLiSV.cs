using QLSV1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Globalization;
using qlisv1;
using Azure.Identity;
using AsciiChart.Sharp;
using System.Reflection.Metadata.Ecma335;
using System.ComponentModel.Design;

namespace QLSV1
{
    internal class QLiSV
    {
        private List<SinhVien> danhSachSV = new List<SinhVien>();
        private List<Diem> danhSachDiem = new List<Diem>();
        private List<MonHoc> danhSachMonHoc = new List<MonHoc>();
        private List<khoa> danhSachKhoa = new List<khoa>();
        private List<giaovien> danhsachgiaovien = new List<giaovien>();
        private List<nganh> danhsachnganh = new List<nganh>();
        private List<TK_MK> danhsachtk_mk = new List<TK_MK>();
        private List<TK_MK> danhsachtk_mk2 = new List<TK_MK>();

        private static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public void DOCTATCATUTEP()
        {
            //Doc tu tep sinh vien
            Console.Clear();
            danhSachSV.Clear();
            string tenfile = "sinhvien.txt";


            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
            if (!File.Exists(tenfile))
            {
                Console.WriteLine($"Khong tim thay file {tenfile}");
                Thread.Sleep(2000);
                return;
            }
            using (var fs = new FileStream(tenfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamReader streamReader = new StreamReader(fs);

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    switch (data[0])
                    {
                        case "SinhVien":
                            SinhVien sv = new SinhVien()
                            {
                                MaSV = data[1],
                                TenSV = data[2],
                                gioitinh = data[3],
                                tuoi = int.Parse(data[4]),
                                Diachi = data[5],
                                Lop = data[6],
                                Khoa = data[7],
                                Nganh = data[8],
                                SDT = data[9],
                                Email = data[10],
                                NgayThangNamsinh = DateTime.Parse(data[11])
                            };
                            danhSachSV.Add(sv);
                            break;
                    }
                }

            }
            Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach sinh vien thanh cong");
            Thread.Sleep(2000);

            //Doc tu tep mon hoc
            Console.Clear();
            danhSachMonHoc.Clear();
            string tenfile2 = "dsmonhoc.txt";


            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
            if (!File.Exists(tenfile2))
            {
                Console.WriteLine($"Khong tim thay file {tenfile2}");
                Thread.Sleep(2000);
                return;
            }
            using (var fs = new FileStream(tenfile2, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamReader streamReader = new StreamReader(fs);

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    switch (data[0])
                    {
                        case "MonHoc":
                            MonHoc mh = new MonHoc()
                            {
                                MaMH = data[1],
                                TenMH = data[2],
                                Sotinchi = int.Parse(data[3]),
                                Hocky = data[4],
                                Nienkhoa = data[5],
                                magv = data[6],
                                makhoa = data[7]
                            };
                            danhSachMonHoc.Add(mh);
                            break;
                    }

                }
                Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach mon hoc thanh cong");
                Thread.Sleep(2000);
            }

            //Doc tu tep diem

            Console.Clear();
            danhSachDiem.Clear();
            string tenfile3 = "danhsachdiem.txt";


            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
            if (!File.Exists(tenfile3))
            {
                Console.WriteLine($"Khong tim thay file {tenfile3}");
                Thread.Sleep(2000);
                return;
            }
            using (var fs = new FileStream(tenfile3, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamReader streamReader = new StreamReader(fs);

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    switch (data[0])
                    {
                        case "Diem":
                            Diem diem = new Diem()
                            {
                                MaSV = data[1],
                                TenSV = data[2],
                                MaMH = data[3],
                                TenMH = data[4],
                                DiemCC = float.Parse(data[5]),
                                DiemKT = float.Parse(data[6]),
                                DiemTH = float.Parse(data[7]),
                                DiemTB = float.Parse(data[8]),
                                DGHS = data[9]
                            };
                            danhSachDiem.Add(diem);
                            break;
                    }
                }
            }
            Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach diem thanh cong");
            Thread.Sleep(1000);

            //Doc tu tep giao vien

            Console.Clear();
            danhsachgiaovien.Clear();
            string tenfile4 = "danhsachgiaovien.txt";


            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
            if (!File.Exists(tenfile4))
            {
                Console.WriteLine($"Khong tim thay file {tenfile4}");
                Thread.Sleep(2000);
                return;
            }
            using (var fs = new FileStream(tenfile4, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamReader streamReader = new StreamReader(fs);

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    switch (data[0])
                    {
                        case "GiaoVien":
                            giaovien gv = new giaovien()
                            {
                                magv = data[1],
                                tengv = data[2],
                                makhoa = data[3],
                                tenkhoa = data[4],
                                cocnlopkhong = bool.Parse(data[5]),
                                malopchunhiem = data[6],
                                sodienthoai = data[7],
                                email = data[8],
                                diachi = data[9]
                            };
                            danhsachgiaovien.Add(gv);
                            break;
                    }
                }

            }
            Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach giao vien thanh cong");
            Thread.Sleep(1000);

            //Doc tu tep khoa
            Console.Clear();
            danhSachKhoa.Clear();
            string tenfile6 = "danhsachkhoa.txt";


            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
            if (!File.Exists(tenfile6))
            {
                Console.WriteLine($"Khong tim thay file {tenfile6}");
                Thread.Sleep(1000);
                return;
            }
            using (var fs = new FileStream(tenfile6, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamReader streamReader = new StreamReader(fs);

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    switch (data[0])
                    {
                        case "Khoa":
                            khoa khoa = new khoa()
                            {
                                makhoa = data[1],
                                tenkhoa = data[2],
                                soluongbm = int.Parse(data[3]),
                                soluonggv = int.Parse(data[4]),
                                soluongsv = int.Parse(data[5]),
                                soluongmh = int.Parse(data[6]),
                                soluongnganh = int.Parse(data[7]),
                                soluonglop = int.Parse(data[8])
                            };
                            danhSachKhoa.Add(khoa);
                            break;
                    }
                }

            }
            Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach khoa thanh cong");
            Thread.Sleep(1000);

            //Doc tu tep nganh

            Console.Clear();
            danhsachnganh.Clear();
            string tenfile7 = "danh_sach_nganh.txt";


            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
            if (!File.Exists(tenfile7))
            {
                Console.WriteLine($"Khong tim thay file {tenfile7}");
                Thread.Sleep(1000);
                return;
            }
            using (var fs = new FileStream(tenfile7, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamReader streamReader = new StreamReader(fs);

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    switch (data[0])
                    {
                        case "Nganh":
                            nganh ng = new nganh();
                            {
                                ng.manganh = data[1];
                                ng.tennganh = data[2];
                            };
                            danhsachnganh.Add(ng);
                            break;
                    }
                }
            }
            Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach nganh thanh cong");
            Thread.Sleep(2000);

        }
        public void SINHVIEN()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.WindowLeft = Console.WindowTop = 0;
            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║      READ LIST UNIVERSITY STUDENTS  ▼       ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                ADD STUDENTS         ▼       ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              DELETE STUDENTS        ▼       ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                EDIT STUDENTS        ▼       ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SAVE LIST STUDENTS     ▼       ║  
                                                             ╚═════════════════════════════════════════════╝" };


            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        return;
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\t\t\t\t\t\t F1");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(".READ FROM FILES");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\t\t\t\t\t\t F2");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(".READ FROM SQL SERVERS");
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\t\t\t\t\t\t F3");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(".EXIT");
                        if (Console.ReadKey(true).Key == ConsoleKey.F1)
                        {

                            Console.Clear();
                            danhSachSV.Clear();
                            string tenfile = "sinhvien.txt";


                            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                            if (!File.Exists(tenfile))
                            {
                                Console.WriteLine($"Khong tim thay file {tenfile}");
                                Thread.Sleep(2000);
                                return;
                            }
                            using (var fs = new FileStream(tenfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            {
                                StreamReader streamReader = new StreamReader(fs);

                                string line;
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    string[] data = line.Split(',');

                                    switch (data[0])
                                    {
                                        case "SinhVien":
                                            SinhVien sv = new SinhVien()
                                            {
                                                MaSV = data[1],
                                                TenSV = data[2],
                                                gioitinh = data[3],
                                                tuoi = int.Parse(data[4]),
                                                Diachi = data[5],
                                                Lop = data[6],
                                                Khoa = data[7],
                                                Nganh = data[8],
                                                SDT = data[9],
                                                Email = data[10],
                                                NgayThangNamsinh = DateTime.Parse(data[11])
                                            };
                                            danhSachSV.Add(sv);
                                            break;
                                    }
                                }

                            }
                            Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach thanh cong");
                            Thread.Sleep(3000);
                        }
                        else if (Console.ReadKey(true).Key == ConsoleKey.F2)
                        {
                            Console.Clear();
                            string connectionString = @"Data Source=NGUYENTIENDAT\MSSQLSERVER01;Initial Catalog=DIEMDOANCK1;Integrated Security=True";
                            string query = "SELECT * FROM SinhVien";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                SqlCommand command = new SqlCommand(query, connection);
                                connection.Open();
                                Console.WriteLine("[!] Mo ket noi den SQL Server thanh cong");
                                Thread.Sleep(3000);

                                SqlDataReader reader = command.ExecuteReader();

                                while (reader.Read())
                                {
                                    SinhVien sv = new SinhVien();
                                    sv.MaSV = reader["MaSV"].ToString();
                                    sv.TenSV = reader["TenSV"].ToString();
                                    sv.gioitinh = reader["Gioitinh"].ToString();
                                    sv.Diachi = reader["Diachi"].ToString();
                                    sv.Lop = reader["Lop"].ToString();
                                    sv.Khoa = reader["Khoa"].ToString();
                                    sv.Nganh = reader["Nganh"].ToString();
                                    sv.tuoi = Convert.ToInt32(reader["Tuoi"]);
                                    sv.SDT = reader["SDT"].ToString();
                                    sv.Email = reader["Email"].ToString();
                                    sv.NgayThangNamsinh = Convert.ToDateTime(reader["ngaythangnamsinh"]);

                                    danhSachSV.Add(sv);
                                }
                                reader.Close();
                                Console.WriteLine("[!] Doc du lieu tu SQL Server thanh cong");
                                Thread.Sleep(3000);
                            }
                        }

                        else if (Console.ReadKey(true).Key == ConsoleKey.F3)
                        {

                            Console.WriteLine("Thoat chuong trinh");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nhap sai. Vui long nhap lai");
                        }
                    }
                    else if (selectedIndex == 2)
                    {

                        Console.Clear();
                        Console.WriteLine("Nhap thong tin sinh vien moi");

                        Console.Write("+------------+");
                        Console.Write("+------------+");
                        Console.WriteLine("+------------+");

                        Console.Write("| Ma khoa     |");
                        Console.Write("| Ma nganh   |");
                        Console.WriteLine("| Ma Sinh Vien|");

                        Console.Write("+------------+");
                        Console.Write("+------------+");
                        Console.WriteLine("+------------+");

                        for (int i = 0; i < danhSachKhoa.Count || i < danhsachnganh.Count || i < danhSachSV.Count; i++)
                        {
                            string makhoa = i < danhSachKhoa.Count ? danhSachKhoa[i].makhoa : "";
                            string manganh = i < danhsachnganh.Count ? danhsachnganh[i].manganh : "";
                            string MaSV = i < danhSachSV.Count ? danhSachSV[i].MaSV : "";

                            Console.Write($"| {makhoa,-11}|");
                            Console.Write($"| {manganh,-11}|");
                            Console.WriteLine($"| {MaSV,-11}|");
                        }

                        Console.Write("+------------+");
                        Console.Write("+------------+");
                        Console.WriteLine("+------------+");



                        Console.Write(">>>Hay nhap so sinh vien can them: ");
                        int a = int.Parse(Console.ReadLine());
                        for (int i = 0; i < a; i++)
                        {
                            SinhVien sinhvien = new SinhVien();
                            Console.WriteLine(">>>Hay nhap thong tin cho sinh vien thu {0}", i + 1);

                            //Ma sinh vien
                            Console.Write(">>>Ma sinh vien: ");
                            string MaSV = Console.ReadLine();
                            while (MaSV.Length == 0)
                            {
                                Console.WriteLine("Ma sinh vien khong duoc de trong. Vui long nhap lai.");
                                Console.Write("Ma sinh vien: ");
                                MaSV = Console.ReadLine();
                            }

                            // Kiem tra xem ma sach da ton tai hay chua
                            while (KiemTraTonTaiSinhVien(MaSV))
                            {
                                Console.WriteLine($"Ma sinh vien {MaSV} da ton tai. Vui long nhap lai.");
                                Console.Write("Ma sinh vien: ");
                                MaSV = Console.ReadLine();
                            }

                            // Hàm kiểm tra sự tồn tại của một sinh viên trong danh sách
                            bool KiemTraTonTaiSinhVien(string maSV)
                            {
                                return danhSachSV.Any(sv => sv.MaSV == maSV);
                            }
                            sinhvien.MaSV = MaSV;

                            ///Ten sinh vien
                            Console.Write(">>>Ten sinh vien: ");
                            string TenSV = Console.ReadLine();
                            while (TenSV.Length == 0)
                            {
                                Console.WriteLine("Ten sinh vien khong duoc de trong. Vui long nhap lai.");
                                Console.Write("Ten sinh vien: ");
                                TenSV = Console.ReadLine();
                            }
                            sinhvien.TenSV = TenSV;

                            //Gioi tinh
                            Console.Write(">>>Gioi tinh (nam/nu): ");
                            string gioitinh = Console.ReadLine().ToLower();

                            while (true)
                            {
                                if (string.IsNullOrEmpty(gioitinh))
                                {
                                    Console.WriteLine("Gioi tinh khong duoc rong. Vui long nhap lai.");
                                    Console.Write(">>>Tuoi: ");
                                    gioitinh = Console.ReadLine();
                                }
                                else if (gioitinh != "nam" && gioitinh != "nu")
                                {
                                    Console.WriteLine("Gioi tinh chi co the la 'nam' hoac 'nu'. Vui long nhap lai.");
                                    Console.Write(">>>Gioi tinh (nam/nu): ");
                                    gioitinh = Console.ReadLine().ToLower();
                                }
                                else
                                {
                                    sinhvien.gioitinh = gioitinh;
                                    break;
                                }
                            }

                            Console.Write(">>>Dia chi: ");
                            string Diachi = Console.ReadLine();
                            while (Diachi.Length == 0)
                            {
                                Console.WriteLine("Dia chi khong duoc de trong. Vui long nhap lai.");
                                Console.Write("Dia chi: ");
                                Diachi = Console.ReadLine();
                            }
                            sinhvien.Diachi = Diachi;

                            Console.Write(">>>SDT: ");
                            string SDT = Console.ReadLine();

                            while (true)
                            {
                                if (string.IsNullOrEmpty(SDT))
                                {
                                    Console.WriteLine("So dien thoai khong duoc de trong.Vui long nhap lai!");
                                    Console.Write("SDT: ");
                                    SDT = Console.ReadLine();
                                }
                                else if (!IsNumeric(SDT) || !SDT.StartsWith("0"))
                                {
                                    Console.WriteLine("So dien thoai phai la mot chuoi so va bat dau bang so 0");
                                    Console.Write("SDT: ");
                                    SDT = Console.ReadLine();
                                }
                                else if (SDT.Length != 10)
                                {
                                    Console.WriteLine("So dien thoai phai co 10 chu so");
                                    Console.Write("SDT: ");
                                    SDT = Console.ReadLine();
                                }
                                else
                                {
                                    sinhvien.SDT = SDT;
                                    break;
                                }
                            }


                            Console.Write(">>>Email: ");
                            string email = Console.ReadLine();
                            while (true)
                            {
                                if (string.IsNullOrEmpty(email))
                                {
                                    Console.WriteLine("Email khong duoc de trong. Vui long nhap lai");
                                    Console.Write("Email: ");
                                    email = Console.ReadLine();
                                }
                                else if (!email.Contains("@") || !email.Contains("."))
                                {
                                    Console.WriteLine("Email khong hop le. Vui long nhap lai");
                                    Console.Write("Email: ");
                                    email = Console.ReadLine();
                                }
                                else
                                {
                                    sinhvien.Email = email;
                                    break;
                                }
                            }

                            Console.Write(">>>Lop: ");
                            string Lop = Console.ReadLine();
                            while (true)
                            {
                                if (string.IsNullOrEmpty(Lop))
                                {
                                    Console.WriteLine("Lop khong duoc de trong. Vui long nhap lai.");
                                    Console.Write("Lop: ");
                                    sinhvien.Lop = Console.ReadLine();
                                }
                                else
                                {
                                    sinhvien.Lop = Lop;
                                    break;
                                }
                            }
                            DateTime NgayThangNamSinh;
                            while (true)
                            {
                                Console.Write(">>>Ngay/thang/nam sinh: ");
                                if (DateTime.TryParse(Console.ReadLine(), out NgayThangNamSinh) && NgayThangNamSinh >= DateTime.MinValue && NgayThangNamSinh <= DateTime.MaxValue)
                                {
                                    if (NgayThangNamSinh.Year < 1900 || NgayThangNamSinh.Year > DateTime.Now.Year)
                                    {
                                        Console.WriteLine("Nam sinh khong hop le. Vui long nhap lai.");
                                    }
                                    else if (NgayThangNamSinh.Day > 31 || NgayThangNamSinh.Month > 12)
                                    {
                                        Console.WriteLine("Ngay khong vuot qua 31! Thang khong vuot qua 12! Vui long nhap lai.");
                                    }
                                    else
                                    {
                                        sinhvien.NgayThangNamsinh = NgayThangNamSinh.Date;
                                        sinhvien.tuoi = DateTime.Now.Year - NgayThangNamSinh.Year;
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ngay sinh khong hop le. Vui long nhap lai.");
                                }
                            }

                            //Khoa

                            while (true)
                            {
                                Console.Write(">>>Ma khoa: ");
                                string Khoa = Console.ReadLine();
                                khoa khoa = danhSachKhoa.FirstOrDefault(s => s.makhoa == Khoa);

                                if (string.IsNullOrEmpty(Khoa))
                                {
                                    Console.WriteLine("Khoa khong duoc de trong. Vui long nhap lai.");
                                }
                                else if (khoa == null)
                                {
                                    Console.WriteLine($"Khong tim thay khoa voi ten {Khoa}");
                                    Console.WriteLine("Hay nhap lai ma khoa");
                                }
                                if (khoa!=null)
                                {
                                    sinhvien.Khoa = Khoa;
                                    break;
                                }
                            }


                            //Nganh
                            while (true)
                            {
                                Console.Write(">>>Ma nganh: ");
                                string nganhnhap = Console.ReadLine();
                                nganh nganh1 = danhsachnganh.FirstOrDefault(s => s.manganh == nganhnhap);
                                if (nganh1 == null)
                                {
                                    Console.WriteLine($"Khong tim thay nganh voi ten {nganhnhap}");
                                    Console.WriteLine("Hay nhap lai ten nganh");
                                }
                                if (string.IsNullOrEmpty(nganhnhap))
                                {
                                    Console.WriteLine("Nganh khong duoc de trong. Vui long nhap lai.");

                                }
                                if (nganh1!=null)
                                {
                                    sinhvien.Nganh = nganhnhap;
                                    break;
                                }
                            }

                            danhSachSV.Add(sinhvien);

                            Console.WriteLine("Sinh vien moi thu {0} da duoc them vao danh sach.", i + 1);
                            Console.WriteLine();
                            Console.WriteLine("Bam mot phim bat ki de tiep tuc!");
                            Console.ReadKey();
                        }
                    }
                    else if (selectedIndex == 3)
                    {
                        while (true)
                        {
                            Console.SetWindowSize(200, 40);
                            Console.Clear();

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap ma sinh vien can xoa:                        ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");
                            Console.WriteLine("|Ma Sinh Vien| Ho ten           | Gioi tinh    | Dia chi             | Khoa    | Nganh     | Tuoi     | SDT        | Email                   | Ngay/thang/nam sinh    |");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");

                            foreach (SinhVien sv in danhSachSV)
                            {

                                Console.WriteLine($"| {sv.MaSV,-11}| {sv.TenSV,-17}| {sv.gioitinh,-13}| {sv.Diachi,-20}| {sv.Khoa,-7} |{sv.Nganh,-11}|{sv.tuoi,-9} | {sv.SDT,-11}|{sv.Email,-18}      | {sv.NgayThangNamsinh.Date,-20}  |");
                            }
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");
                            Console.SetCursorPosition(85, 3);
                            string MaSV = Console.ReadLine();

                            // Kiem tra xem ma sinh vien co ton tai hay khong
                            SinhVien sinhVien = danhSachSV.FirstOrDefault(sv => sv.MaSV == MaSV);
                            if (sinhVien == null)
                            {
                                Console.WriteLine($"Khong tim thay sinh vien voi ma so {MaSV}");
                                return;
                            }

                            // Xoa sinh vien khoi danh sach
                            danhSachSV.Remove(sinhVien);

                            // Xoa diem cua sinh vien khoi danh sach
                            danhSachDiem.RemoveAll(diem => diem.MaSV == MaSV);
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");
                            Console.WriteLine("|Ma Sinh Vien| Ho ten           | Gioi tinh    | Dia chi             | Khoa    | Nganh     | Tuoi     | SDT        | Email                   | Ngay/thang/nam sinh    |");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");
                            foreach (SinhVien sv in danhSachSV)
                            {

                                Console.WriteLine($"| {sv.MaSV,-11}| {sv.TenSV,-17}| {sv.gioitinh,-13}| {sv.Diachi,-20}| {sv.Khoa,-7} |{sv.Nganh,-11}|{sv.tuoi,-9} | {sv.SDT,-11}|{sv.Email,-18}  | {sv.NgayThangNamsinh.Date,-20}  |");
                            }
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");
                            Console.WriteLine($"Sinh vien {sinhVien.TenSV} da duoc xoa khoi danh sach.");
                            Console.WriteLine();
                            //An esc  de thoat
                            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                            {
                                Console.SetWindowSize(158, 34);
                                break;
                            }
                        }
                        Console.SetWindowSize(158, 34);
                    }
                    else if (selectedIndex == 4)
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.SetWindowSize(200, 40);
                            Console.Clear();

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap ma sinh vien can sua:                        ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");
                            Console.WriteLine("|Ma Sinh Vien| Ho ten           | Gioi tinh    | Dia chi             | Khoa    | Nganh     | Tuoi     | SDT        | Email                   | Ngay/thang/nam sinh    |");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");

                            foreach (SinhVien sv in danhSachSV)
                            {

                                Console.WriteLine($"| {sv.MaSV,-11}| {sv.TenSV,-17}| {sv.gioitinh,-13}| {sv.Diachi,-20}| {sv.Khoa,-7} |{sv.Nganh,-11}|{sv.tuoi,-9} | {sv.SDT,-11}|{sv.Email,-18}      | {sv.NgayThangNamsinh.Date,-20}  |");
                            }
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");
                            Console.SetCursorPosition(85, 3);
                            string MaSV = Console.ReadLine();

                            SinhVien sv2 = danhSachSV.Find(s => s.MaSV.Equals(MaSV, StringComparison.OrdinalIgnoreCase));

                            if (sv2 != null)
                            {

                                Console.SetWindowSize(200, 40);
                                Console.Clear();

                                Console.WriteLine();
                                Console.WriteLine();
                                Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║        THONG TIN SINH VIEN CAN SUA                ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");
                                Console.WriteLine("|Ma Sinh Vien| Ho ten           | Gioi tinh    | Dia chi             | Khoa    | Nganh     | Tuoi     | SDT        | Email                   | Ngay/thang/nam sinh    |");
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");

                                {

                                    Console.WriteLine($"| {sv2.MaSV,-11}| {sv2.TenSV,-17}| {sv2.gioitinh,-13}| {sv2.Diachi,-20}| {sv2.Khoa,-7} |{sv2.Nganh,-11}|{sv2.tuoi,-9} | {sv2.SDT,-11}|{sv2.Email,-18}      | {sv2.NgayThangNamsinh.Date,-20}  |");
                                }
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");

                                Console.WriteLine("Nhap thong tin sinh vien moi:");

                                Console.Write("Nhap ma sinh vien: ");
                                string MaSV2 = Console.ReadLine();

                                while (MaSV2.Length == 0)
                                {
                                    Console.WriteLine("Ma sinh vien khong duoc de trong. Vui long nhap lai.");
                                    Console.Write("Ma sinh vien: ");
                                    MaSV2 = Console.ReadLine();
                                }
                                sv2.MaSV = MaSV2;

                                ///Ten sinh vien
                                Console.Write(">>>Ten sinh vien: ");
                                string TenSV = Console.ReadLine();
                                while (TenSV.Length == 0)
                                {
                                    Console.WriteLine("Ten sinh vien khong duoc de trong. Vui long nhap lai.");
                                    Console.Write("Ten sinh vien: ");
                                    TenSV = Console.ReadLine();
                                }
                                sv2.TenSV = TenSV;

                                //Gioi tinh
                                Console.Write(">>>Gioi tinh (nam/nu): ");
                                string gioitinh = Console.ReadLine().ToLower();

                                while (true)
                                {
                                    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
                                    {
                                        break;
                                    }
                                    if (string.IsNullOrEmpty(gioitinh))
                                    {
                                        Console.WriteLine("Gioi tinh khong duoc rong. Vui long nhap lai.");
                                        Console.Write(">>>Tuoi: ");
                                        gioitinh = Console.ReadLine();
                                    }
                                    else if (gioitinh != "nam" && gioitinh != "nu")
                                    {
                                        Console.WriteLine("Gioi tinh chi co the la 'nam' hoac 'nu'. Vui long nhap lai.");
                                        Console.Write(">>>Gioi tinh (nam/nu): ");
                                        gioitinh = Console.ReadLine().ToLower();
                                    }
                                    else
                                    {
                                        sv2.gioitinh = gioitinh;
                                        break;
                                    }
                                }

                                Console.Write(">>>Dia chi: ");
                                string Diachi = Console.ReadLine();
                                while (Diachi.Length == 0)
                                {
                                    Console.WriteLine("Dia chi khong duoc de trong. Vui long nhap lai.");
                                    Console.Write("Dia chi: ");
                                    Diachi = Console.ReadLine();
                                }
                                sv2.Diachi = Diachi;

                                Console.Write(">>>SDT: ");
                                string SDT = Console.ReadLine();

                                while (true)
                                {
                                    if (string.IsNullOrEmpty(SDT))
                                    {
                                        Console.WriteLine("So dien thoai khong duoc de trong.Vui long nhap lai!");
                                        Console.Write("SDT: ");
                                        SDT = Console.ReadLine();
                                    }
                                    else if (!IsNumeric(SDT) || !SDT.StartsWith("0"))
                                    {
                                        Console.WriteLine("So dien thoai phai la mot chuoi so va bat dau bang so 0");
                                        Console.Write("SDT: ");
                                        SDT = Console.ReadLine();
                                    }
                                    else if (SDT.Length != 10)
                                    {
                                        Console.WriteLine("So dien thoai phai co 10 chu so");
                                        Console.Write("SDT: ");
                                        SDT = Console.ReadLine();
                                    }
                                    else
                                    {
                                        sv2.SDT = SDT;
                                        break;
                                    }
                                }


                                Console.Write(">>>Email: ");
                                string email = Console.ReadLine();
                                while (true)
                                {
                                    if (string.IsNullOrEmpty(email))
                                    {
                                        Console.WriteLine("Email khong duoc de trong. Vui long nhap lai");
                                        Console.Write("Email: ");
                                        email = Console.ReadLine();
                                    }
                                    else if (!email.Contains("@") || !email.Contains("."))
                                    {
                                        Console.WriteLine("Email khong hop le. Vui long nhap lai");
                                        Console.Write("Email: ");
                                        email = Console.ReadLine();
                                    }
                                    else
                                    {
                                        sv2.Email = email;
                                        break;
                                    }
                                }


                                Console.Write(">>>Lop: ");
                                string Lop = Console.ReadLine();
                                while (true)
                                {
                                    if (string.IsNullOrEmpty(Lop))
                                    {
                                        Console.WriteLine("Lop khong duoc de trong. Vui long nhap lai.");
                                        Console.Write("Lop: ");
                                        sv2.Lop = Console.ReadLine();
                                    }
                                    else
                                    {
                                        sv2.Lop = Lop;
                                        break;
                                    }
                                }

                                Console.Write("Ngay/thang/nam sinh: ");
                                DateTime NgayThangNamSinh;
                                while (true)
                                {
                                    string input = Console.ReadLine();
                                    if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out NgayThangNamSinh))
                                    {
                                        if (NgayThangNamSinh.Year < 1900 || NgayThangNamSinh.Year > DateTime.Now.Year)
                                        {
                                            Console.WriteLine("Nam sinh khong hop le. Vui long nhap lai.");
                                        }
                                        else if (NgayThangNamSinh.Day >= 31 || NgayThangNamSinh.Month >= 12)
                                        {
                                            Console.WriteLine("Ngay khong vuot qua 30!Thang khong vuot qua 12!.Vui long nhap lai.");
                                        }
                                        else
                                        {
                                            sv2.NgayThangNamsinh = NgayThangNamSinh.Date;
                                            sv2.tuoi = DateTime.Now.Year - NgayThangNamSinh.Year;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ngay sinh khong hop le. Vui long nhap lai (dd/MM/yyyy).");
                                    }
                                }


                                while (true)
                                {
                                    Console.Write(">>>Khoa: ");
                                    string Khoa = Console.ReadLine();
                                    khoa khoa = danhSachKhoa.FirstOrDefault(s => s.tenkhoa == Khoa);
                                    if (khoa == null)
                                    {
                                        Console.WriteLine($"Khong tim thay ten khoa voi ma {Khoa}");
                                        Console.WriteLine("Hay nhap lai ten khoa");
                                    }
                                    if (string.IsNullOrEmpty(Khoa))
                                    {
                                        Console.WriteLine("Khoa khong duoc de trong. Vui long nhap lai.");
                                    }
                                    if (khoa!=null)
                                    {
                                        sv2.Khoa = Khoa;
                                        break;
                                    }
                                }


                                while (true)
                                {
                                    Console.Write(">>>Nganh: ");
                                    string nganhnhap = Console.ReadLine();
                                    nganh nganh1 = danhsachnganh.FirstOrDefault(s => s.tennganh == nganhnhap);
                                    if (nganh1 == null)
                                    {
                                        Console.WriteLine($"Khong tim thay nganh voi ten {nganhnhap}");
                                        Console.WriteLine("Hay nhap lai ten nganh");
                                    }
                                    if (string.IsNullOrEmpty(nganhnhap))
                                    {
                                        Console.WriteLine("Nganh khong duoc de trong. Vui long nhap lai.");

                                    }
                                    if (nganh1!=null)
                                    {
                                        sv2.Nganh = nganhnhap;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay sinh vien can sua.");
                            }
                            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                            {
                                Console.SetWindowSize(158, 34);
                                break;
                            }
                        }

                    }
                    else if (selectedIndex == 5)
                    {
                        Console.Clear();
                        string tenTep2 = "sinhvien.txt";

                        try
                        {
                            using (StreamWriter writer = new StreamWriter(tenTep2))
                            {
                                foreach (SinhVien sinhvien in danhSachSV)
                                {
                                    writer.WriteLine($"SinhVien,{sinhvien.MaSV},{sinhvien.TenSV},{sinhvien.gioitinh},{sinhvien.tuoi},{sinhvien.Diachi},{sinhvien.Lop},{sinhvien.Khoa},{sinhvien.Nganh},{sinhvien.SDT},{sinhvien.Email},{sinhvien.NgayThangNamsinh}");
                                }
                            }

                            Console.WriteLine($"Da ghi danh sach sach sinh vien vao tep {tenTep2} thanh cong.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Loi khi ghi danh sach sinh vien vao tep: {ex.Message}");
                        }
                        Thread.Sleep(3000);
                    }
                }
            }
        }
        public void QUANLIMONHOC()
        {

            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║               READ LIST SUBJECTS      ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                ADD SUBJECTS           ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              DELETE SUBJECTS          ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                EDIT SUBJECTS          ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SAVE LIST SUBJECT        ▼     ║  
                                                             ╚═════════════════════════════════════════════╝" };

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        break;
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(">>>1. Doc danh sach tu tep");
                        Console.WriteLine(">>>2. Doc danh sach tu SQL Server");
                        Console.WriteLine(">>>0. Thoat chuong trinh");
                        Console.Write(">>>>Nhap lua chon cua ban: ");
                        int chon = int.Parse(Console.ReadLine());
                        if (chon == 1)
                        {
                            Console.Clear();
                            danhSachMonHoc.Clear();
                            string tenfile = "dsmonhoc.txt";


                            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                            if (!File.Exists(tenfile))
                            {
                                Console.WriteLine($"Khong tim thay file {tenfile}");
                                Thread.Sleep(2000);
                                return;
                            }
                            using (var fs = new FileStream(tenfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            {
                                StreamReader streamReader = new StreamReader(fs);

                                string line;
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    string[] data = line.Split(',');

                                    switch (data[0])
                                    {
                                        case "MonHoc":
                                            MonHoc mh = new MonHoc()
                                            {
                                                MaMH = data[1],
                                                TenMH = data[2],
                                                Sotinchi = int.Parse(data[3]),
                                                Hocky = data[4],
                                                Nienkhoa = data[5],
                                                magv = data[6],
                                                makhoa = data[7]
                                            };
                                            danhSachMonHoc.Add(mh);
                                            break;
                                    }

                                }
                                Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach thanh cong");
                                Thread.Sleep(3000);
                            }
                        }
                        else if (chon == 2)
                        {
                            Console.Clear();
                            string connectionString = @"Data Source=NGUYENTIENDAT\MSSQLSERVER01;Initial Catalog=DIEMDOANCK1;Integrated Security=True";
                            string query2 = "SELECT * FROM MonHoc";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                SqlCommand command2 = new SqlCommand(query2, connection);
                                connection.Open();
                                Console.WriteLine("[!] Mo ket noi den SQL Server thanh cong");
                                SqlDataReader sqlDataReaderreader2 = command2.ExecuteReader();
                                while (sqlDataReaderreader2.Read())
                                {
                                    MonHoc mh = new MonHoc();
                                    mh.MaMH = sqlDataReaderreader2["MaMH"].ToString();
                                    mh.TenMH = sqlDataReaderreader2["TenMH"].ToString();
                                    mh.Sotinchi = Convert.ToInt32(sqlDataReaderreader2["SoTinChi"]);
                                    mh.Hocky = sqlDataReaderreader2["Hocky"].ToString();
                                    mh.Nienkhoa = sqlDataReaderreader2["Nienkhoa"].ToString();
                                    mh.magv = sqlDataReaderreader2["magv"].ToString();
                                    mh.makhoa = sqlDataReaderreader2["makhoa"].ToString();
                                    danhSachMonHoc.Add(mh);
                                }
                                sqlDataReaderreader2.Close();
                                Console.WriteLine("[!] Doc du lieu tu SQL Server thanh cong");
                                Thread.Sleep(3000);
                            }
                        }

                        else if (chon == 0)
                        {
                            Console.WriteLine("Thoat chuong trinh");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nhap sai. Vui long nhap lai");
                        }
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Nhap thong tin mon hoc moi");


                        Console.Write("+------------+");
                        Console.Write("+------------+");
                        Console.WriteLine("+------------+");

                        Console.Write("| Ma khoa    |");
                        Console.Write("| Ma mon hoc |");
                        Console.WriteLine("|Ma giao vien|");

                        Console.Write("+------------+");
                        Console.Write("+------------+");
                        Console.WriteLine("+------------+");

                        for (int i = 0; i < danhSachKhoa.Count || i < danhSachMonHoc.Count || i < danhsachgiaovien.Count; i++)
                        {
                            string makhoa = i < danhSachKhoa.Count ? danhSachKhoa[i].makhoa : "";
                            string mamh = i < danhSachMonHoc.Count ? danhSachMonHoc[i].MaMH : "";
                            string magv = i < danhsachgiaovien.Count ? danhsachgiaovien[i].magv : "";

                            Console.Write($"| {makhoa,-11}|");
                            Console.Write($"| {mamh,-11}|");
                            Console.WriteLine($"| {magv,-11}|");
                        }

                        Console.Write("+------------+");
                        Console.Write("+------------+");
                        Console.WriteLine("+------------+");



                        Console.Write("Hay nhap so mon hoc ban can them: ");
                        int somonhoc = int.Parse(Console.ReadLine());

                        for (int i = 0; i < somonhoc; i++)
                        {
                            MonHoc monhoc = new MonHoc();
                            Console.WriteLine("Hay nhap thong tin cho mon hoc thu {0}", i + 1);
                            Console.Write(">>>Ma mon hoc: ");
                            string MaMH = Console.ReadLine();

                            // Kiem tra xem ma mon hoc da ton tai hay chua

                            while (KiemTraTonTaiMonHoc(MaMH))
                            {
                                Console.WriteLine($"Ma mon hoc {MaMH} da ton tai. Vui long nhap lai.");
                                Console.Write("Ma mon hoc: ");
                                MaMH = Console.ReadLine();
                            }

                            // Hàm kiểm tra sự tồn tại của một môn học trong danh sách
                            bool KiemTraTonTaiMonHoc(string maMH)
                            {
                                return danhSachMonHoc.Any(mh => mh.MaMH == maMH);
                            }
                            monhoc.MaMH = MaMH;

                            Console.Write("Ten mon hoc: ");
                            string TenMH = Console.ReadLine();
                            while (true)
                            {
                                if (string.IsNullOrEmpty(TenMH))
                                {
                                    Console.WriteLine("Ten mon hoc khong duoc de trong. Vui long nhap lai.");
                                    Console.Write("Ten mon hoc: ");
                                    TenMH = Console.ReadLine();
                                }
                                else
                                {
                                    monhoc.TenMH = TenMH;
                                    break;
                                }
                            }

                            Console.Write("So tin chi: ");
                            string sotinchinhap = Console.ReadLine();

                            while (true)
                            {
                                if (string.IsNullOrEmpty(sotinchinhap))
                                {
                                    Console.WriteLine("So tin chi khong duoc rong. Vui long nhap lai.");
                                    Console.Write(">>>So tin chi: ");
                                    sotinchinhap = Console.ReadLine();
                                }
                                else if (!int.TryParse(sotinchinhap, out int sotinchi) || sotinchi < 1)
                                {
                                    Console.WriteLine("So tin chi phai la mot so duong. Vui long nhap lai.");
                                    Console.Write(">>>So tin chi: ");
                                    sotinchinhap = Console.ReadLine();
                                }
                                else
                                {
                                    monhoc.Sotinchi = sotinchi;
                                    break;
                                }
                            }

                            Console.Write("Hoc ky: ");
                            string Hocky = Console.ReadLine();
                            while (true)
                            {
                                if (string.IsNullOrEmpty(Hocky))
                                {
                                    Console.WriteLine("Hoc ky khong duoc de trong. Vui long nhap lai.");
                                    Console.Write("Hoc ky: ");
                                    Hocky = Console.ReadLine();
                                }
                                else
                                {
                                    monhoc.Hocky = Hocky;
                                    break;
                                }
                            }

                            Console.Write("Nien khoa: ");
                            string Nienkhoa = Console.ReadLine();
                            while (true)
                            {
                                if (string.IsNullOrEmpty(Nienkhoa))
                                {
                                    Console.WriteLine("Nien khoa khong duoc de trong. Vui long nhap lai.");
                                    Console.Write("Nien khoa: ");
                                    Nienkhoa = Console.ReadLine();
                                }
                                else
                                {
                                    monhoc.Nienkhoa = Nienkhoa;
                                    break;
                                }
                            }

                            //giao vien

                            Console.Write(">>>Ma giao vien: ");
                            string magvnhap = Console.ReadLine();
                            while (true)
                            {
                                giaovien gv = danhsachgiaovien.FirstOrDefault(s => s.magv == magvnhap);
                                if (gv == null)
                                {
                                    Console.WriteLine($"Khong tim thay giao vien voi ma {magvnhap}");
                                    Console.Write("Hay nhap lai ma giao vien: ");
                                    magvnhap = Console.ReadLine();
                                }
                                else if (string.IsNullOrEmpty(magvnhap))
                                {
                                    Console.WriteLine("Ma giao vien khong duoc de trong. Vui long nhap lai.");
                                }
                                if (gv!=null)
                                {
                                    monhoc.magv = magvnhap;
                                    break;
                                }
                            }
                            // Ma khoa
                            while (true)
                            {
                                Console.Write(">>>Ma khoa: ");
                                string magkhoanhap = Console.ReadLine();
                                khoa kh = danhSachKhoa.FirstOrDefault(s => s.makhoa == magkhoanhap);
                                if (kh == null)
                                {
                                    Console.WriteLine($"Khong tim thay khoa voi ma {magkhoanhap}");
                                    Console.WriteLine("Hay nhap lai ma khoa");
                                }
                                if (string.IsNullOrEmpty(magkhoanhap))
                                {
                                    Console.WriteLine("Khoa khong duoc de trong. Vui long nhap lai.");

                                }
                                if(kh!=null)
                                {
                                    monhoc.makhoa = magkhoanhap;
                                    break;
                                }
                            }
                            danhSachMonHoc.Add(monhoc);

                            Console.WriteLine("Mon hoc moi thu {0} da duoc them vao danh sach.", i + 1);
                            Console.WriteLine();
                            Console.WriteLine("Bam mot phim bat ki de tiep tuc!");
                            Console.ReadKey();
                        }

                    }
                    else if (selectedIndex == 3)
                    {
                        while (true)
                        {
                            Console.SetWindowSize(200, 40);
                            Console.Clear();

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap ma mon hoc can xoa:                          ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");
                            Console.WriteLine("|Ma mon hoc  | Ten mon hoc      |So tin chi    | Nien khoa           | MaGV    | Ma Khoa   | Hoc ki   |");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");

                            foreach (MonHoc mh in danhSachMonHoc)
                            {

                                Console.WriteLine($"| {mh.MaMH,-11}| {mh.TenMH,-17}| {mh.Sotinchi,-13}| {mh.Nienkhoa,-20}| {mh.magv,-7} |{mh.makhoa,-11}|{mh.Hocky,-9} |");
                            }
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");
                            Console.SetCursorPosition(85, 3);
                            string mamh = Console.ReadLine();

                            // Kiem tra xem ma sinh vien co ton tai hay khong
                            MonHoc monhoccheck = danhSachMonHoc.FirstOrDefault(mh2 => mh2.MaMH == mamh);
                            if (monhoccheck == null)
                            {
                                Console.WriteLine($"Khong tim thay mon hoc voi ma so {mamh}");
                                return;
                            }

                            // Xoa sinh vien khoi danh sach
                            danhSachMonHoc.Remove(monhoccheck);

                            // Xoa diem cua sinh vien khoi danh sach

                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");
                            Console.WriteLine("|Ma mon hoc  | Ten mon hoc      |So tin chi    | Nien khoa           | MaGV    | Ma Khoa   | Hoc ki   |");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");

                            foreach (MonHoc mh in danhSachMonHoc)
                            {

                                Console.WriteLine($"| {mh.MaMH,-11}| {mh.TenMH,-17}| {mh.Sotinchi,-13}| {mh.Nienkhoa,-20}| {mh.magv,-7} |{mh.makhoa,-11}|{mh.Hocky,-9} |");
                            }
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");
                            Console.WriteLine($"Mon hoc {monhoccheck.TenMH} da duoc xoa khoi danh sach.");
                            Console.WriteLine();
                            //An esc  de thoat
                            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                            {
                                Console.SetWindowSize(158, 34);
                                break;
                            }
                        }
                        Console.SetWindowSize(158, 34);
                    }
                    else if (selectedIndex == 4)
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.SetWindowSize(200, 40);
                            Console.Clear();

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap ma mon hoc can sua:                          ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");
                            Console.WriteLine("|Ma mon hoc  | Ten mon hoc      |So tin chi    | Nien khoa           | MaGV    | Ma Khoa   | Hoc ki   |");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");

                            foreach (MonHoc mh in danhSachMonHoc)
                            {

                                Console.WriteLine($"| {mh.MaMH,-11}| {mh.TenMH,-17}| {mh.Sotinchi,-13}| {mh.Nienkhoa,-20}| {mh.magv,-7} |{mh.makhoa,-11}|{mh.Hocky,-9} |");
                            }
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");
                            Console.SetCursorPosition(85, 3);
                            string mamh = Console.ReadLine();

                            MonHoc mhcheck = danhSachMonHoc.Find(s => s.MaMH.Equals(mamh, StringComparison.OrdinalIgnoreCase));

                            if (mhcheck != null)
                            {

                                Console.SetWindowSize(200, 40);
                                Console.Clear();

                                Console.WriteLine();
                                Console.WriteLine();
                                Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║        THONG TIN SINH MON HOC CAN SUA             ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");
                                Console.WriteLine("|Ma mon hoc  | Ten mon hoc      |So tin chi    | Nien khoa           | MaGV    | Ma Khoa   | Hoc ki   |");
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+");
                                {

                                    Console.WriteLine($"| {mhcheck.MaMH,-11}| {mhcheck.TenMH,-17}| {mhcheck.Sotinchi,-13}| {mhcheck.Nienkhoa,-20}| {mhcheck.magv,-7} |{mhcheck.makhoa,-11}|{mhcheck.Hocky,-9} |");
                                }
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+-------------------------+------------------------+");

                                Console.WriteLine("Nhap thong tin mon hoc moi:");

                                Console.Write(">>>Ma mon hoc: ");
                                string MaMH = Console.ReadLine();

                                // Kiem tra xem ma mon hoc da ton tai hay chua
                                mhcheck.MaMH = MaMH;

                                // Hàm kiểm tra sự tồn tại của một môn học trong danh sách

                                Console.Write("Ten mon hoc: ");
                                string TenMH = Console.ReadLine();
                                while (true)
                                {
                                    if (string.IsNullOrEmpty(TenMH))
                                    {
                                        Console.WriteLine("Ten mon hoc khong duoc de trong. Vui long nhap lai.");
                                        Console.Write("Ten mon hoc: ");
                                        TenMH = Console.ReadLine();
                                    }
                                    else
                                    {
                                        mhcheck.TenMH = TenMH;
                                        break;
                                    }
                                }

                                Console.Write("So tin chi: ");
                                string sotinchinhap = Console.ReadLine();

                                while (true)
                                {
                                    if (string.IsNullOrEmpty(sotinchinhap))
                                    {
                                        Console.WriteLine("So tin chi khong duoc rong. Vui long nhap lai.");
                                        Console.Write(">>>So tin chi: ");
                                        sotinchinhap = Console.ReadLine();
                                    }
                                    else if (!int.TryParse(sotinchinhap, out int sotinchi) || sotinchi < 1)
                                    {
                                        Console.WriteLine("So tin chi phai la mot so duong. Vui long nhap lai.");
                                        Console.Write(">>>So tin chi: ");
                                        sotinchinhap = Console.ReadLine();
                                    }
                                    else
                                    {
                                        mhcheck.Sotinchi = sotinchi;
                                        break;
                                    }
                                }

                                Console.Write("Hoc ky: ");
                                string Hocky = Console.ReadLine();
                                while (true)
                                {
                                    if (string.IsNullOrEmpty(Hocky))
                                    {
                                        Console.WriteLine("Hoc ky khong duoc de trong. Vui long nhap lai.");
                                        Console.Write("Hoc ky: ");
                                        Hocky = Console.ReadLine();
                                    }
                                    else
                                    {
                                        mhcheck.Hocky = Hocky;
                                        break;
                                    }
                                }

                                Console.Write("Nien khoa: ");
                                string Nienkhoa = Console.ReadLine();
                                while (true)
                                {
                                    if (string.IsNullOrEmpty(Nienkhoa))
                                    {
                                        Console.WriteLine("Nien khoa khong duoc de trong. Vui long nhap lai.");
                                        Console.Write("Nien khoa: ");
                                        Nienkhoa = Console.ReadLine();
                                    }
                                    else
                                    {
                                        mhcheck.Nienkhoa = Nienkhoa;
                                        break;
                                    }
                                }
                                while (true)
                                {
                                    Console.Write(">>>Ma giao vien: ");
                                    string magvnhap = Console.ReadLine();
                                    giaovien gv = danhsachgiaovien.FirstOrDefault(s => s.magv == magvnhap);
                                    if (gv == null)
                                    {
                                        Console.WriteLine($"Khong tim thay giao vien voi ma {magvnhap}");
                                        Console.WriteLine("Hay nhap lai ma khoa");
                                    }
                                    if (string.IsNullOrEmpty(magvnhap))
                                    {
                                        Console.WriteLine("Giao vien khong duoc de trong. Vui long nhap lai.");

                                    }
                                    if (gv!=null)
                                    {
                                        mhcheck.magv = magvnhap;
                                        break;
                                    }
                                }
                                // Ma khoa
                                while (true)
                                {
                                    Console.Write(">>>Ma khoa: ");
                                    string magkhoanhap = Console.ReadLine();
                                    khoa kh = danhSachKhoa.FirstOrDefault(s => s.makhoa == magkhoanhap);
                                    if (kh == null)
                                    {
                                        Console.WriteLine($"Khong tim thay khoa voi ma {magkhoanhap}");
                                        Console.WriteLine("Hay nhap lai ma khoa");
                                    }
                                    if (string.IsNullOrEmpty(magkhoanhap))
                                    {
                                        Console.WriteLine("Khoa khong duoc de trong. Vui long nhap lai.");

                                    }
                                    if (kh!=null)
                                    {
                                        mhcheck.makhoa = magkhoanhap;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay mon hoc can sua.");
                            }
                            Console.WriteLine("0.Thoat");
                            Console.WriteLine("1.Thu lai");
                            Console.Write("Nhap lua chon: ");
                            int choose = int.Parse(Console.ReadLine());
                            if (choose == 0)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else if (selectedIndex == 5)
                    {
                        Console.Clear();
                        string tenTep2 = "dsmonhoc.txt";

                        try
                        {
                            using (StreamWriter writer = new StreamWriter(tenTep2))
                            {
                                foreach (MonHoc mh in danhSachMonHoc)
                                {
                                    writer.WriteLine($"MonHoc,{mh.MaMH},{mh.TenMH},{mh.Sotinchi},{mh.Hocky},{mh.Nienkhoa},{mh.magv},{mh.makhoa}");
                                }
                            }

                            Console.WriteLine($"Da ghi danh sach sach monhoc vao tep {tenTep2} thanh cong.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Loi khi ghi danh sach sinh vien vao tep: {ex.Message}");
                        }
                        Console.WriteLine("[!] An mot phim bat ki de tiep tuc");
                        Console.ReadKey();

                    }
                }
            }
        }
        public void QUANLIDIEM()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║               READ LIST MARKS         ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                  ADD MARKS            ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                DELETE MARKS           ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                  EDIT MARKS           ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║               SAVE LIST MARKS         ▼     ║  
                                                             ╚═════════════════════════════════════════════╝" };
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        break;
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(">>>1. Doc danh sach tu tep");
                        Console.WriteLine(">>>2. Doc danh sach tu SQL Server");
                        Console.WriteLine(">>>0. Thoat chuong trinh");
                        Console.Write(">>>>Nhap lua chon cua ban: ");
                        int chon = int.Parse(Console.ReadLine());
                        if (chon == 1)
                        {
                            Console.Clear();
                            danhSachDiem.Clear();
                            string tenfile = "danhsachdiem.txt";


                            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                            if (!File.Exists(tenfile))
                            {
                                Console.WriteLine($"Khong tim thay file {tenfile}");
                                Thread.Sleep(2000);
                                return;
                            }
                            using (var fs = new FileStream(tenfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            {
                                StreamReader streamReader = new StreamReader(fs);

                                string line;
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    string[] data = line.Split(',');

                                    switch (data[0])
                                    {
                                        case "Diem":
                                            Diem diem = new Diem()
                                            {
                                                MaSV = data[1],
                                                TenSV = data[2],
                                                MaMH = data[3],
                                                TenMH = data[4],
                                                DiemCC = float.Parse(data[5]),
                                                DiemKT = float.Parse(data[6]),
                                                DiemTH = float.Parse(data[7]),
                                                DiemTB = float.Parse(data[8]),
                                                DGHS = data[9]
                                            };
                                            danhSachDiem.Add(diem);
                                            break;
                                    }
                                }
                            }
                            Console.WriteLine("Doc thong tin tu tep va ghi vao danh diem thanh cong");
                            Thread.Sleep(3000);
                        }
                        else if (chon == 2)
                        {
                            Console.Clear();
                            string connectionString = @"Data Source=NGUYENTIENDAT\MSSQLSERVER01;Initial Catalog=DIEMDOANCK1;Integrated Security=True";
                            string query3 = "SELECT * FROM Diem";

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                SqlCommand command3 = new SqlCommand(query3, connection);
                                connection.Open();
                                Console.WriteLine("[!] Mo ket noi den SQL Server thanh cong");
                                Thread.Sleep(3000);

                                SqlDataReader sqlDataReaderreader3 = command3.ExecuteReader();
                                while (sqlDataReaderreader3.Read())
                                {
                                    Diem diem = new Diem();
                                    diem.MaSV = sqlDataReaderreader3["MaSV"].ToString();
                                    diem.TenSV = sqlDataReaderreader3["TenSV"].ToString();
                                    diem.MaMH = sqlDataReaderreader3["MaMH"].ToString();
                                    diem.TenMH = sqlDataReaderreader3["TenMH"].ToString();
                                    diem.DiemCC = Convert.ToInt32(sqlDataReaderreader3["DiemCC"]);
                                    diem.DiemKT = Convert.ToInt32(sqlDataReaderreader3["DiemKT"]);
                                    diem.DiemTH= Convert.ToInt32(sqlDataReaderreader3["DiemTH"]);
                                    diem.DiemTB = Convert.ToInt32(sqlDataReaderreader3["DiemTB"]);
                                    diem.DGHS = sqlDataReaderreader3["DGHS"].ToString();

                                    danhSachDiem.Add(diem);
                                }

                                sqlDataReaderreader3.Close();
                                Console.WriteLine("[!] Doc du lieu tu SQL Server thanh cong");
                                Thread.Sleep(3000);
                            }
                        }

                        else if (chon == 0)
                        {
                            Console.WriteLine("Thoat chuong trinh");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Nhap sai. Vui long nhap lai");
                        }
                    }

                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Nhap thong tin diem moi");
                        Console.Write("+------------+");
                        Console.WriteLine("+------------+");
                        

                        Console.Write("| Ma SV      |");
                        Console.WriteLine("| Ma mon hoc |");
                       

                        Console.Write("+------------+");
                        Console.WriteLine("+------------+");

                        for (int i = 0; i < danhSachSV.Count || i < danhSachMonHoc.Count; i++)
                        {
                            string masv = i < danhSachSV.Count ? danhSachSV[i].MaSV : "";
                            string mamh = i < danhSachMonHoc.Count ? danhSachMonHoc[i].MaMH : "";

                            Console.Write($"| {masv,-11}|");
                            Console.WriteLine($"| {mamh,-11}|");
                        }

                        Console.Write("+------------+");
                        Console.WriteLine("+------------+");
                       

                        Console.Write("Nhap so sinh vien can them diem: ");
                        int themsinhvien = int.Parse(Console.ReadLine());
                        for (int i = 0; i < themsinhvien; i++)
                        {
                            Diem diem = new Diem();
                            // Nhap ma sinh vien
                            Console.Write(">>>Ma sinh vien: ");
                            string masvnhap = Console.ReadLine();
                            while (true)
                            {
                                SinhVien sinhVien1 = danhSachSV.FirstOrDefault(sv => sv.MaSV == masvnhap);
                                if (sinhVien1 == null)
                                {
                                    Console.WriteLine($"Khong tim thay sinh vien voi ma {masvnhap}");
                                    Console.Write("Hay nhap lai ma sinh vien: ");
                                    masvnhap = Console.ReadLine();
                                }
                                else if (string.IsNullOrEmpty(masvnhap))
                                {
                                    Console.WriteLine("Ma sinh vien khong duoc de trong. Vui long nhap lai.");
                                }
                                if (sinhVien1 != null)
                                {
                                    diem.MaSV = masvnhap;
                                    diem.TenSV = sinhVien1.TenSV;
                                    break;
                                }
                            }

                            Console.Write(">>>Ma mon hoc: ");
                            string mamhnhap = Console.ReadLine();
                            while (true)
                            {
                                MonHoc mh = danhSachMonHoc.FirstOrDefault(mh1 => mh1.MaMH == mamhnhap);
                                if (mh == null)
                                {
                                    Console.WriteLine($"Khong tim thay mon hoc voi ma {mamhnhap}");
                                    Console.Write("Hay nhap lai ma mon hoc: ");
                                    mamhnhap = Console.ReadLine();
                                }
                                else if (string.IsNullOrEmpty(masvnhap))
                                {
                                    Console.WriteLine("Ma mon hoc khong duoc de trong. Vui long nhap lai.");
                                }
                                if (mh != null)
                                {
                                    diem.MaMH = mh.MaMH;
                                    diem.TenMH=mh.TenMH;
                                    break;
                                }
                            }                 

                            // Nhap thong tin diem

                            Console.Write("Diem chuyen can: ");
                            string diemCCnhap = Console.ReadLine();

                            while (true)
                            {
                                if (string.IsNullOrEmpty(diemCCnhap))
                                {
                                    Console.WriteLine("Diem chuyen can khong duoc rong. Vui long nhap lai.");
                                    Console.Write(">>>Diem chuyen can: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else if (!float.TryParse(diemCCnhap, out float diemCC) || diemCC < 1 || diemCC > 10)
                                {
                                    Console.WriteLine("Diem chuyen can phai nam trong khoang tu 1 den 10. Vui long nhap lai.");
                                    Console.Write(">>>Diem chuyen can: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else
                                {
                                    diem.DiemCC = diemCC;
                                    break;
                                }
                            }


                            Console.Write("Diem kiem tra: ");
                            string diemKTnhap = Console.ReadLine();

                            while (true)
                            {
                                if (string.IsNullOrEmpty(diemKTnhap))
                                {
                                    Console.WriteLine("Diem kiem tra khong duoc rong. Vui long nhap lai.");
                                    Console.Write(">>>Diem kiem tra: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else if (!float.TryParse(diemKTnhap, out float diemKT) || diemKT < 1 || diemKT > 10)
                                {
                                    Console.WriteLine("Diem kiem tra phai nam trong khoang tu 1 den 10. Vui long nhap lai.");
                                    Console.Write(">>>Diem kiem tra: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else
                                {
                                    diem.DiemKT = diemKT;
                                    break;
                                }
                            }

                            Console.Write("Diem thuc hanh: ");
                            string diemTHnhap = Console.ReadLine();

                            while (true)
                            {
                                if (string.IsNullOrEmpty(diemTHnhap))
                                {
                                    Console.WriteLine("Diem thuc hanh khong duoc rong. Vui long nhap lai.");
                                    Console.Write(">>>Diem thuc hanh: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else if (!float.TryParse(diemTHnhap, out float diemTH) || diemTH < 1 || diemTH > 10)
                                {
                                    Console.WriteLine("Diem thuc hanh phai nam trong khoang tu 1 den 10. Vui long nhap lai.");
                                    Console.Write(">>>Diem thuc hanh: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else
                                {
                                    diem.DiemTH = diemTH;
                                    break;
                                }
                            }

                            diem.DiemTB = (diem.DiemCC + diem.DiemKT + diem.DiemTH) / 3;
                            if (diem.DiemTB > 0 && diem.DiemTB < 5)
                            {
                                diem.DGHS = "Hoc lai";
                            }
                            else if (diem.DiemTB >= 5 && diem.DiemTB < 8)
                            {
                                diem.DGHS = "Hoc sinh kha";
                            }
                            else if (diem.DiemTB >= 8 && diem.DiemTB < 9)
                            {
                                diem.DGHS = "Hoc sinh gioi";
                            }
                            else if (diem.DiemTB >= 9 && diem.DiemTB <= 10)
                            {
                                diem.DGHS = "Hoc sinh xuat sac";
                            }
                            // Them diem vao danh sach
                            danhSachDiem.Add(diem);

                            Console.WriteLine($"Diem cua sinh vien {diem.TenSV} voi ma so {diem.MaSV} da duoc them vao danh sach.");
                            Console.WriteLine();
                            Console.WriteLine("Bam mot phim bat ki de tiep tuc!");
                            Console.ReadKey();
                        }
                    }
                    else if (selectedIndex == 3)
                    {
                        Console.Clear();
                        Console.Write(">>>Nhap ma sinh vien can xoa diem: ");
                        string masv = Console.ReadLine();

                        // Kiem tra xem ma sinh vien co ton tai hay khong
                        Diem diem = danhSachDiem.FirstOrDefault(diem => diem.MaSV == masv);
                        if (diem == null)
                        {
                            Console.WriteLine($"Khong tim thay sinh vien voi ma so {masv}");
                            return;
                        }

                        // Xoa mon hoc khoi danh sach
                        danhSachDiem.Remove(diem);
                        Console.WriteLine($"Mon hoc {diem.TenSV} da duoc xoa khoi danh sach.");
                        Console.WriteLine();
                        Console.WriteLine("Bam mot phim bat ki de tro ve man hinh chinh!");
                        Console.ReadKey();
                    }
                    else if (selectedIndex == 4)
                    {
                        Console.Write("Nhap ma sinh vien can sua diem: ");
                        string maSV = Console.ReadLine();

                        Diem diem = danhSachDiem.Find(s => s.MaSV.Equals(maSV, StringComparison.OrdinalIgnoreCase));

                        if (diem != null)
                        {
                            Console.WriteLine("Thong tin diem can sua:");
                            Console.WriteLine($"Ma sinh vien: {diem.MaSV}");
                            Console.WriteLine($"Ten sinh vien: {diem.TenSV}");
                            Console.WriteLine($"Ma mon hoc: {diem.MaMH}");
                            Console.WriteLine($"Ten mon hoc: {diem.TenMH}");
                            Console.WriteLine($"Diem CC: {diem.DiemCC}");
                            Console.WriteLine($"Diem KT: {diem.DiemKT}");
                            Console.WriteLine($"Diem TH: {diem.DiemTH}");

                            Console.WriteLine("Nhap thong tin diem moi:");

                            Console.Write("Diem chuyen can: ");
                            string diemCCnhap = Console.ReadLine();

                            while (true)
                            {
                                if (string.IsNullOrEmpty(diemCCnhap))
                                {
                                    Console.WriteLine("Diem chuyen can khong duoc rong. Vui long nhap lai.");
                                    Console.Write(">>>Diem chuyen can: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else if (!float.TryParse(diemCCnhap, out float diemCC) || diemCC < 1 || diemCC > 10)
                                {
                                    Console.WriteLine("Diem chuyen can phai nam trong khoang tu 1 den 10. Vui long nhap lai.");
                                    Console.Write(">>>Diem chuyen can: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else
                                {
                                    diem.DiemCC = diemCC;
                                    break;
                                }
                            }


                            Console.Write("Diem kiem tra: ");
                            string diemKTnhap = Console.ReadLine();

                            while (true)
                            {
                                if (string.IsNullOrEmpty(diemKTnhap))
                                {
                                    Console.WriteLine("Diem kiem tra khong duoc rong. Vui long nhap lai.");
                                    Console.Write(">>>Diem kiem tra: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else if (!float.TryParse(diemKTnhap, out float diemKT) || diemKT < 1 || diemKT > 10)
                                {
                                    Console.WriteLine("Diem kiem tra phai nam trong khoang tu 1 den 10. Vui long nhap lai.");
                                    Console.Write(">>>Diem kiem tra: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else
                                {
                                    diem.DiemKT = diemKT;
                                    break;
                                }
                            }

                            Console.Write("Diem thuc hanh: ");
                            string diemTHnhap = Console.ReadLine();

                            while (true)
                            {
                                if (string.IsNullOrEmpty(diemTHnhap))
                                {
                                    Console.WriteLine("Diem thuc hanh khong duoc rong. Vui long nhap lai.");
                                    Console.Write(">>>Diem thuc hanh: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else if (!float.TryParse(diemTHnhap, out float diemTH) || diemTH < 1 || diemTH > 10)
                                {
                                    Console.WriteLine("Diem thuc hanh phai nam trong khoang tu 1 den 10. Vui long nhap lai.");
                                    Console.Write(">>>Diem thuc hanh: ");
                                    diemCCnhap = Console.ReadLine();
                                }
                                else
                                {
                                    diem.DiemTH = diemTH;
                                    break;
                                }
                            }

                            diem.DiemTB = (diem.DiemCC + diem.DiemKT + diem.DiemTH) / 3;
                            if (diem.DiemTB > 0 && diem.DiemTB < 5)
                            {
                                diem.DGHS = "Hoc lai";
                            }
                            else if (diem.DiemTB >= 5 && diem.DiemTB < 8)
                            {
                                diem.DGHS = "Hoc sinh kha";
                            }
                            else if (diem.DiemTB >= 8 && diem.DiemTB < 9)
                            {
                                diem.DGHS = "Hoc sinh gioi";
                            }
                            else if (diem.DiemTB >= 9 && diem.DiemTB <= 10)
                            {
                                diem.DGHS = "Hoc sinh xuat sac";
                            }
                            Console.WriteLine();
                            Console.WriteLine("Sua thong tin diem thanh cong.");
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay sinh vien can sua.");
                        }
                        Console.WriteLine("0.Thoat");
                        Console.WriteLine("1.Thu lai");
                        Console.Write("Nhap lua chon: ");
                        int choose = int.Parse(Console.ReadLine());
                        if (choose == 0)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    else if (selectedIndex == 5)
                    {
                        Console.Clear();
                        string tenTep2 = "danhsachdiem.txt";

                        try
                        {
                            using (StreamWriter writer = new StreamWriter(tenTep2))
                            {
                                foreach (Diem diem in danhSachDiem)
                                {

                                    //writer.WriteLine($"MonHoc,{diem.MaSV},{diem.TenSV},{diem.MaMH},{diem.TenMH},{diem.DiemCC},{diem.DiemKT},{diem.DiemTH},{diem.DiemTB}");
                                    writer.WriteLine($"Diem,{diem.MaSV},{diem.TenSV},{diem.MaMH},{diem.TenMH},{diem.DiemCC},{diem.DiemKT},{diem.DiemTH},{diem.DiemTB},{diem.DGHS}");
                                }
                            }

                            Console.WriteLine($"Da ghi danh sach sach diem vao tep {tenTep2} thanh cong.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Loi khi ghi danh sach sinh vien vao tep: {ex.Message}");
                        }
                    }
                    break;
                }
            }
        }
        public void HienthiDS_Thongke()
        {
            Console.Clear();
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║               SHOW LIST STUDENTS            ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SHOW LIST SUBJECTS             ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║               SHOW LIST MARKS               ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║        SHOW LIST SATISFIES THE CONDITIONS   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║               EVALUATE STUDENTS             ║  
                                                             ╚═════════════════════════════════════════════╝" };

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        break;
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("Danh sach cac sinh vien:");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+---------------------+------------------------+");
                            Console.WriteLine("|Ma Sinh Vien| Ho ten           | Gioi tinh    | Dia chi             | Khoa    | Nganh     | Tuoi     | SDT        | Email               | Ngay/thang/nam sinh    |");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+---------------------+------------------------+");

                            foreach (SinhVien sv in danhSachSV)
                            {

                                Console.WriteLine($"| {sv.MaSV,-11}| {sv.TenSV,-17}| {sv.gioitinh,-13}| {sv.Diachi,-20}| {sv.Khoa,-7} |{sv.Nganh,-11}|{sv.tuoi,-9} | {sv.SDT,-11}|{sv.Email,-18}  | {sv.NgayThangNamsinh.Date,-20}  |");
                            }

                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+---------------------+------------------------+");
                            Console.WriteLine("0.Thoat");
                            Console.WriteLine("1.Thu lai");
                            Console.Write("Nhap lua chon: ");
                            int choose = int.Parse(Console.ReadLine());
                            if (choose == 0)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Danh sach cac mon hoc:");

                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+");
                            Console.WriteLine("|Ma mon hoc  | Ten mon hoc      |So tin chi    | Hoc ki              |Nien khoa|");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+");
                            foreach (MonHoc mh in danhSachMonHoc)
                            {
                                Console.WriteLine($"| {mh.MaMH,-11}| {mh.TenMH,-17}| {mh.Sotinchi,-13}| {mh.Hocky,-20}| {mh.Nienkhoa,-7} |");
                            }
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+");
                            Console.WriteLine("0.Thoat");
                            Console.WriteLine("1.Thu lai");
                            Console.Write("Nhap lua chon: ");
                            int choose = int.Parse(Console.ReadLine());
                            if (choose == 0)
                            {
                                Console.Clear();
                                break;
                            }

                        }
                    }
                    else if (selectedIndex == 3)
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("Danh sach diem cua cach sinh vien:");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+--------------------+");
                            Console.WriteLine("|Ma Sinh Vien| Ho ten           | Ma Mon Hoc   | Ten Mon Hoc         |Diem CC  |Diem KT    |Diem TH   |Diem TB     |  DGHS              |");
                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+--------------------+");

                            foreach (Diem diem in danhSachDiem)
                            {
                                Console.WriteLine($"| {diem.MaSV,-11}| {diem.TenSV,-17}| {diem.MaMH,-13}| {diem.TenMH,-20}| {diem.DiemCC,-7} |{diem.DiemKT,-11}|{diem.DiemTH,-9} | {diem.DiemTB,-11}|{diem.DGHS,-17}   |");
                            }

                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+--------------------+");
                            Console.WriteLine("0.Thoat");
                            Console.WriteLine("1.Thu lai");
                            Console.Write("Nhap lua chon: ");
                            int choose = int.Parse(Console.ReadLine());
                            if (choose == 0)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else if (selectedIndex == 4)
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine(">>>1.Hien thi hoc sinh hoc lai");
                            Console.WriteLine(">>>2.Hien thi hoc sinh kha");
                            Console.WriteLine(">>>3.Hien thi hoc sinh gioi");
                            Console.WriteLine(">>>4.Hien thi hoc sinh xuat sac");
                            Console.WriteLine(">>>0.Thoat");
                            Console.Write(">>>>Hay nhap lua chon: ");
                            int choose = int.Parse(Console.ReadLine());
                            if (choose == 1)
                            {
                                string diemSV5 = "Hoc lai";
                                List<Diem> diemtimkiem = danhSachDiem.FindAll(s => s.DGHS.Equals(diemSV5, StringComparison.OrdinalIgnoreCase));

                                if (diemtimkiem.Count > 0)
                                {
                                    foreach (Diem diem in diemtimkiem)
                                    {
                                        Console.WriteLine($"Ma sinh vien: {diem.MaSV},-Diem CC: {diem.DiemCC}, Diem KT: {diem.DiemKT}, DiemTH: {diem.DiemTH}, Diem TB: {diem.DiemTB}");
                                    }
                                }
                            }
                            else if (choose == 2)
                            {
                                string diemSV5 = "Hoc sinh kha";
                                List<Diem> diemtimkiem = danhSachDiem.FindAll(s => s.DGHS.Equals(diemSV5, StringComparison.OrdinalIgnoreCase));

                                if (diemtimkiem.Count > 0)
                                {
                                    foreach (Diem diem in diemtimkiem)
                                    {
                                        Console.WriteLine($"Ma sinh vien: {diem.MaSV},-Diem CC: {diem.DiemCC}, Diem KT: {diem.DiemKT}, DiemTH: {diem.DiemTH}, Diem TB: {diem.DiemTB}");
                                    }
                                }
                            }
                            else if (choose == 3)
                            {
                                string diemSV5 = "Hoc sinh gioi";
                                List<Diem> diemtimkiem = danhSachDiem.FindAll(s => s.DGHS.Equals(diemSV5, StringComparison.OrdinalIgnoreCase));

                                if (diemtimkiem.Count > 0)
                                {
                                    foreach (Diem diem in diemtimkiem)
                                    {
                                        Console.WriteLine($"Ma sinh vien: {diem.MaSV},-Diem CC: {diem.DiemCC}, Diem KT: {diem.DiemKT}, DiemTH: {diem.DiemTH}, Diem TB: {diem.DiemTB}");
                                    }
                                }
                            }
                            else if (choose == 4)
                            {

                                string diemSV5 = "Hoc sinh xuat sac";
                                List<Diem> diemtimkiem = danhSachDiem.FindAll(s => s.DGHS.Equals(diemSV5, StringComparison.OrdinalIgnoreCase));

                                if (diemtimkiem.Count > 0)
                                {
                                    foreach (Diem diem in diemtimkiem)
                                    {
                                        Console.WriteLine($"Ma sinh vien: {diem.MaSV},-Diem CC: {diem.DiemCC}, Diem KT: {diem.DiemKT}, DiemTH: {diem.DiemTH}, Diem TB: {diem.DiemTB}");
                                    }
                                }
                            }
                            else if (choose == 0)
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Lua chon khong co san");
                            }
                        }
                    }
                    else if (selectedIndex == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Thong tin danh gia hoc sinh: ");
                        foreach (Diem diem in danhSachDiem)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine($"\t\t\t\tMa sinh vien: {diem.MaSV}");
                            Console.WriteLine($"\t\t\t\tTen sinh vien: {diem.TenSV}");
                            Console.WriteLine($"\t\t\t\tDiem TB cua sinh vien: {diem.DiemTB}");
                            Console.WriteLine($"\t\t\t\tSinh vien thuoc loai: {diem.DGHS}");
                        }
                        Console.WriteLine("An mot phim bat ki de tiep tuc!");
                        Console.ReadKey();
                    }
                    break;
                }
            }
        }
        public void TruyVanDuLieu()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║             FIND STUDENTS WITH CODE         ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║            FIND STUDENTS WITH MARK          ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║   SHOW THE LIST OF STUDENT AVERAGE DECIDES  ║  
                                                             ╚═════════════════════════════════════════════╝" };

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        break;
                    }
                    if (selectedIndex == 1)
                    {
                        Console.Clear();
                        while (true)
                        {

                            Console.Write("Nhap ma sinh vien can tim: ");
                            string masinhvien3 = Console.ReadLine();

                            List<SinhVien> ketQuaTimKiem = danhSachSV.FindAll(s => s.MaSV.Equals(masinhvien3, StringComparison.OrdinalIgnoreCase));
                            List<Diem> diemtimkiem = danhSachDiem.FindAll(s => s.MaSV.Equals(masinhvien3, StringComparison.OrdinalIgnoreCase));

                            if (ketQuaTimKiem.Count > 0)
                            {
                                Console.WriteLine("Ket qua tim kiem:");
                                foreach (SinhVien sinhvien in ketQuaTimKiem)
                                {
                                    Console.WriteLine($"-MaSinhVien: {sinhvien.MaSV},Ten sinh vien: {sinhvien.TenSV},Gioi tinh: {sinhvien.gioitinh},Tuoi: {sinhvien.tuoi},Lop: ({sinhvien.Lop}), Khoa: {sinhvien.Khoa} , Nganh: {sinhvien.Nganh},Tuoi: {sinhvien.tuoi},So DT: {sinhvien.SDT},Email: {sinhvien.Email},Thang/Ngay/Nam sinh: {sinhvien.NgayThangNamsinh.Date}");
                                }
                                foreach (Diem diem in diemtimkiem)
                                {
                                    Console.WriteLine($"-Ma mon hoc: {diem.MaMH}, Diem CC: {diem.DiemCC}, Diem KT: {diem.DiemKT}, DiemTH: {diem.DiemTH}, Diem TB: {diem.DiemTB}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Khong tim thay sinh vien co ma sinh vien {masinhvien3} trong danh sach.");
                            }
                            Console.WriteLine("0.Thoat");
                            Console.WriteLine("1.Thu lai");
                            Console.Write("Nhap lua chon: ");
                            int choose = int.Parse(Console.ReadLine());
                            if (choose == 0)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.Write("Nhap ten sinh vien can tim: ");
                            string tenSV4 = Console.ReadLine();

                            List<SinhVien> ketQuaTimKiem = danhSachSV.FindAll(student => student.TenSV.Contains(tenSV4));
                            List<Diem> diemtimkiem = danhSachDiem.FindAll(s => s.TenSV.Equals(tenSV4, StringComparison.OrdinalIgnoreCase));

                            if (ketQuaTimKiem.Count > 0)
                            {
                                Console.WriteLine("Ket qua tim kiem:");
                                foreach (SinhVien sinhvien in ketQuaTimKiem)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine($"-Ten sinh vien: {sinhvien.TenSV},Ma sinh vien: {sinhvien.MaSV},Tuoi: {sinhvien.tuoi},Gioi tinh: {sinhvien.gioitinh}, Nganh theo hoc: {sinhvien.Nganh}, Lop: {sinhvien.Lop}, Khoa: {sinhvien.Khoa}, Nganh: {sinhvien.Nganh},Tuoi: {sinhvien.tuoi},So DT: {sinhvien.SDT},Email: {sinhvien.Email},Thang/Ngay/Nam sinh: {sinhvien.NgayThangNamsinh.Date}");
                                }
                                foreach (Diem diem in diemtimkiem)
                                {
                                    Console.WriteLine($"Ma mon hoc: {diem.MaMH},-Diem CC: {diem.DiemCC}, Diem KT: {diem.DiemKT}, DiemTH: {diem.DiemTH}, Diem TB: {diem.DiemTB}");
                                    Console.WriteLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Khong tim thay sach co ten {tenSV4} trong danh sach.");
                            }
                            Console.WriteLine("0.Thoat");
                            Console.WriteLine("1.Thu lai");
                            Console.Write("Nhap lua chon: ");
                            int choose = int.Parse(Console.ReadLine());
                            if (choose == 0)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else if (selectedIndex == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Danh sach diem theo thu tu giam dan");
                        Console.WriteLine("Danh sach diem");
                        Console.WriteLine("+------------+------------------+---------+-----------+----------+------------+--------------------+");
                        Console.WriteLine("|Ma Sinh Vien| Ho ten           |Diem CC  |Diem KT    |Diem TH   |Diem TB     |  DGHS              |");
                        Console.WriteLine("+------------+------------------+---------+-----------+----------+------------+--------------------+");

                        var diem = danhSachDiem.OrderByDescending(d => d.DiemTB);

                        foreach (var item in diem)
                        {
                            Console.WriteLine($"| {item.MaSV,-11}| {item.TenSV,-17}| {item.DiemCC,-7} |{item.DiemKT,-11}|{item.DiemTH,-9} | {item.DiemTB,-11}|{item.DGHS,-17}   |");
                        }
                        Console.WriteLine("+------------+------------------+---------+-----------+----------+------------+--------------------+");
                        Console.WriteLine();
                        Console.WriteLine("Bam mot phim bat ky de tro ve menu chinh.");
                        Console.ReadKey();
                    }
                    break;
                }
            }
        }
        public void DONGBODULIEULENSQLSERVER()
        {
            Console.Clear();
            string strCon = @"Data Source=NGUYENTIENDAT\MSSQLSERVER01;Initial Catalog=DIEMDOANCK1;Integrated Security=True";
            Console.WriteLine(">>>Dang ket noi den SQL Server");
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                try
                {
                    //Mở kết nối thành công
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open(); //Đóng thì mởƯ
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("[!]Tinh trang: Mo ket noi den SQL Server thanh cong");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Thread.Sleep(3000);
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor=ConsoleColor.Red;
                    Console.WriteLine("[!]Tinh trang: Mo ket noi den SQL Server that bai");
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor=ConsoleColor.Green;
                }
                Console.CursorVisible = false;
                ConsoleKeyInfo keyInfo;
                int selectedIndex = 0;
                string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║        SYNC STUDENTS UNIVERSITY LIST  ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║             SYNC SUBJECTS LIST        ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SYNC MARKS LIST          ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║         SYNC TEACHERS UNIVERSITY LIST ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SYNC FACULTIES LIST      ▼     ║  
                                                             ╚═════════════════════════════════════════════╝",
                @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SYNC DEPARTMENTS LIST    ▼     ║  
                                                             ╚═════════════════════════════════════════════╝"};

                while (true)
                {
                    Console.Clear();
                    for (int i = 0; i < options.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                    }

                    keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        selectedIndex--;
                        if (selectedIndex < 0)
                        {
                            selectedIndex = options.Length - 1;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        selectedIndex++;
                        if (selectedIndex == options.Length)
                        {
                            selectedIndex = 0;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        if (selectedIndex == 0)
                        {
                            break;
                        }
                        if (selectedIndex == 1)
                        {
                            SqlCommand command = new SqlCommand("INSERT INTO SinhVien (MaSV,TenSV,Gioitinh,Tuoi,Diachi,SDT,Email,NgayThangNamsinh,Lop,Khoa,Nganh) VALUES (@MaSV, @TenSV, @Gioitinh, @Tuoi,@Diachi,@SDT,@Email,@NgayThangNamsinh,@Lop,@Khoa,@Nganh)", connection);

                            //Thiết lập các thuộc tính cho đối tượng Command
                            command.CommandType = CommandType.Text;

                            foreach (SinhVien sv in danhSachSV)
                            {

                                command.Parameters.Clear(); //Xóa các tham số trước khi thêm mới giá trị vào
                                SqlParameter maSachParam = new SqlParameter("@MaSV", SqlDbType.NVarChar);
                                maSachParam.Value = sv.MaSV ?? (object)DBNull.Value;
                                command.Parameters.Add(maSachParam);


                                SqlParameter ten = new SqlParameter("@TenSV", sv.TenSV);
                                command.Parameters.Add(ten);

                                SqlParameter gioitinh = new SqlParameter("@Gioitinh", sv.gioitinh);
                                command.Parameters.Add(gioitinh);

                                SqlParameter tuoi = new SqlParameter("@Tuoi", sv.tuoi);
                                command.Parameters.Add(tuoi);

                                SqlParameter diachi = new SqlParameter("@Diachi", sv.Diachi);
                                command.Parameters.Add(diachi);

                                SqlParameter sdt = new SqlParameter("@SDT", sv.SDT);
                                command.Parameters.Add(sdt);

                                SqlParameter email = new SqlParameter("@Email", sv.Email);
                                command.Parameters.Add(email);

                                SqlParameter ngaythangnamsinh = new SqlParameter("@NgayThangNamsinh", sv.NgayThangNamsinh);
                                command.Parameters.Add(ngaythangnamsinh);

                                SqlParameter lop = new SqlParameter("@Lop", sv.Lop);
                                command.Parameters.Add(lop);

                                SqlParameter khoa = new SqlParameter("@Khoa", sv.Khoa);
                                command.Parameters.Add(khoa);

                                SqlParameter nganh = new SqlParameter("@Nganh", sv.Nganh);
                                command.Parameters.Add(nganh);


                                command.ExecuteNonQuery();
                            }

                            Console.WriteLine($"Dong bo {danhSachSV.Count} sinh vien thanh cong.");
                            Thread.Sleep(5000);
                        }
                        else if (selectedIndex == 2)
                        {
                            SqlCommand command = new SqlCommand("INSERT INTO MonHoc (MaMH, TenMH, SoTinChi, Hocky,NienKhoa,magv,makhoa) VALUES (@MaMH, @TenMH, @SoTinChi, @Hocky,@NienKhoa,@magv,@makhoa)", connection);

                            //Thiết lập các thuộc tính cho đối tượng Command
                            command.CommandType = CommandType.Text;

                            foreach (MonHoc mh in danhSachMonHoc)
                            {

                                command.Parameters.Clear(); //Xóa các tham số trước khi thêm mới giá trị vào
                                SqlParameter maMHParam = new SqlParameter("@MaMH", SqlDbType.NVarChar);
                                maMHParam.Value = mh.MaMH ?? (object)DBNull.Value;
                                command.Parameters.Add(maMHParam);


                                SqlParameter ten = new SqlParameter("@TenMH", mh.TenMH);
                                command.Parameters.Add(ten);

                                SqlParameter stc = new SqlParameter("@SoTinChi", mh.Sotinchi);
                                command.Parameters.Add(stc);

                                SqlParameter hocki = new SqlParameter("@Hocky", mh.Hocky);
                                command.Parameters.Add(hocki);

                                SqlParameter nienkhoa = new SqlParameter("@NienKhoa", mh.Nienkhoa);
                                command.Parameters.Add(nienkhoa);

                                SqlParameter magv = new SqlParameter("@magv", mh.magv);
                                command.Parameters.Add(magv);

                                SqlParameter makhoa = new SqlParameter("@makhoa", mh.makhoa);
                                command.Parameters.Add(makhoa);

                                command.ExecuteNonQuery();
                            }

                            Console.WriteLine($"Dong bo {danhSachMonHoc.Count} mon hoc thanh cong.");
                            Thread.Sleep(5000);
                        }
                        else if (selectedIndex == 3)
                        {
                            SqlCommand command = new SqlCommand("INSERT INTO Diem (MaSV,TenSV,MaMH,TenMH,DiemCC,DiemKT,DiemTH,DiemTB,DGHS) VALUES (@MaSV,@TenSV,@MaMH,@TenMH,@DiemCC,@DiemKT,@DiemTH,@DiemTB,@DGHS)", connection);

                            //Thiết lập các thuộc tính cho đối tượng Command
                            command.CommandType = CommandType.Text;

                            foreach (Diem diem in danhSachDiem)
                            {

                                command.Parameters.Clear(); //Xóa các tham số trước khi thêm mới giá trị vào
                                SqlParameter maSVParam = new SqlParameter("@MaSV", SqlDbType.NVarChar);
                                maSVParam.Value = diem.MaSV ?? (object)DBNull.Value;
                                command.Parameters.Add(maSVParam);


                                SqlParameter ten = new SqlParameter("@TenSV", diem.TenSV);
                                command.Parameters.Add(ten);

                                SqlParameter mamh = new SqlParameter("@MaMH", diem.MaMH);
                                command.Parameters.Add(mamh);

                                SqlParameter tenmh = new SqlParameter("@TenMH", diem.TenMH);
                                command.Parameters.Add(tenmh);

                                SqlParameter diemcc = new SqlParameter("@DiemCC", diem.DiemCC);
                                command.Parameters.Add(diemcc);

                                SqlParameter diemkt = new SqlParameter("@DiemKT", diem.DiemKT);
                                command.Parameters.Add(diemkt);

                                SqlParameter diemth = new SqlParameter("@DiemTH", diem.DiemTH);
                                command.Parameters.Add(diemth);

                                SqlParameter diemtb = new SqlParameter("@DiemTB", diem.DiemTB);
                                command.Parameters.Add(diemtb);

                                SqlParameter dghs = new SqlParameter("@DGHS", diem.DGHS);
                                command.Parameters.Add(dghs);

                                command.ExecuteNonQuery();
                            }

                            Console.WriteLine($"Dong bo {danhSachDiem.Count} diem thanh cong.");
                            Thread.Sleep(4000);
                        }
                        else if (selectedIndex == 4)
                        {
                            SqlCommand command = new SqlCommand("INSERT INTO GiaoVien (magv,tengv, makhoa, tenkhoa,cocnlopkhong,malopchunhiem,sodienthoai,email,diachi) VALUES (@magv,@tengv,@makhoa,@tenkhoa,@cocnlopkhong,@malopchunhiem,@sodienthoai,@email,@diachi)", connection);

                            //Thiết lập các thuộc tính cho đối tượng Command
                            command.CommandType = CommandType.Text;

                            foreach (giaovien gv in danhsachgiaovien)
                            {

                                command.Parameters.Clear(); //Xóa các tham số trước khi thêm mới giá trị vào
                                SqlParameter magvParam = new SqlParameter("@magv", SqlDbType.NVarChar);
                                magvParam.Value = gv.magv ?? (object)DBNull.Value;
                                command.Parameters.Add(magvParam);


                                SqlParameter ten = new SqlParameter("@tengv", gv.tengv);
                                command.Parameters.Add(ten);

                                SqlParameter stc = new SqlParameter("@makhoa", gv.makhoa);
                                command.Parameters.Add(stc);

                                SqlParameter hocki = new SqlParameter("@tenkhoa", gv.tenkhoa);
                                command.Parameters.Add(hocki);


                                SqlParameter makhoa = new SqlParameter("@cocnlopkhong", gv.cocnlopkhong);
                                command.Parameters.Add(makhoa);

                                SqlParameter makhoa1 = new SqlParameter("@malopchunhiem", gv.malopchunhiem);
                                command.Parameters.Add(makhoa1);

                                SqlParameter makhoa2 = new SqlParameter("@sodienthoai", gv.sodienthoai);
                                command.Parameters.Add(makhoa2);

                                SqlParameter makhoa3 = new SqlParameter("@email", gv.email);
                                command.Parameters.Add(makhoa3);

                                SqlParameter makhoa4 = new SqlParameter("@diachi", gv.diachi);
                                command.Parameters.Add(makhoa4);

                                command.ExecuteNonQuery();
                            }

                            Console.WriteLine($"Dong bo {danhsachgiaovien.Count} giao vien thanh cong.");
                            Thread.Sleep(5000);
                            break;
                        }
                        else if (selectedIndex == 5)
                        {
                            SqlCommand command = new SqlCommand("INSERT INTO Khoa (makhoa,tenkhoa, soluongbm, soluonggv,soluongsv,soluongmh,soluongnganh,soluonglop) VALUES (@makhoa,@tenkhoa, @soluongbm, @soluonggv,@soluongsv,@soluongmh,@soluongnganh,@soluonglop)", connection);

                            //Thiết lập các thuộc tính cho đối tượng Command
                            command.CommandType = CommandType.Text;

                            foreach (khoa kh in danhSachKhoa)
                            {

                                command.Parameters.Clear(); //Xóa các tham số trước khi thêm mới giá trị vào
                                SqlParameter makhoaParam = new SqlParameter("@makhoa", SqlDbType.NVarChar);
                                makhoaParam.Value = kh.makhoa ?? (object)DBNull.Value;
                                command.Parameters.Add(makhoaParam);


                                SqlParameter ten = new SqlParameter("@tenkhoa", kh.tenkhoa);
                                command.Parameters.Add(ten);

                                SqlParameter stc = new SqlParameter("@soluongbm", kh.soluongbm);
                                command.Parameters.Add(stc);

                                SqlParameter hocki = new SqlParameter("@soluonggv", kh.soluonggv);
                                command.Parameters.Add(hocki);

                                SqlParameter nienkhoa = new SqlParameter("@soluongsv", kh.soluongsv);
                                command.Parameters.Add(nienkhoa);

                                SqlParameter magv = new SqlParameter("@soluongmh", kh.soluongmh);
                                command.Parameters.Add(magv);

                                SqlParameter makhoa = new SqlParameter("@soluongnganh", kh.soluongnganh);
                                command.Parameters.Add(makhoa);

                                SqlParameter makhoa1 = new SqlParameter("@soluonglop", kh.soluonglop);
                                command.Parameters.Add(makhoa1);

                                command.ExecuteNonQuery();
                            }

                            Console.WriteLine($"Dong bo {danhsachgiaovien.Count} khoa thanh cong.");
                            Thread.Sleep(5000);
                        }
                        else if (selectedIndex == 6)
                        {
                            SqlCommand command = new SqlCommand("INSERT INTO Nganh (manganh,tennganh) VALUES (@manganh,@tennganh)", connection);

                            //Thiết lập các thuộc tính cho đối tượng Command
                            command.CommandType = CommandType.Text;

                            foreach (nganh ng in danhsachnganh)
                            {

                                command.Parameters.Clear(); //Xóa các tham số trước khi thêm mới giá trị vào
                                SqlParameter manganhParam = new SqlParameter("@manganh", SqlDbType.NVarChar);
                                manganhParam.Value = ng.manganh ?? (object)DBNull.Value;
                                command.Parameters.Add(manganhParam);


                                SqlParameter ten = new SqlParameter("@tennganh", ng.tennganh);
                                command.Parameters.Add(ten);

                                command.ExecuteNonQuery();
                            }

                            Console.WriteLine($"Dong bo {danhsachnganh.Count} nganh thanh cong.");
                            Thread.Sleep(5000);
                        }
                    }
                }
            }
        }
        public void QUANLIKHOA()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                MANAGE TEACHERS              ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║               MANAGE FACULTIES              ║  
                                                             ╚═════════════════════════════════════════════╝" };

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        return;
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.CursorVisible = false;
                        ConsoleKeyInfo keyInfo1;
                        int selectedIndex2 = 0;
                        string[] option = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║       READ LIST UNIVERSITY TEACHERS     ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                ADD TEACHERS             ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              DELETE TEACHERS            ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                EDIT TEACHERS            ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SAVE LIST TEACHERS         ▼   ║  
                                                             ╚═════════════════════════════════════════════╝" };

                        while (true)
                        {
                            Console.Clear();
                            for (int b = 0; b < option.Length; b++)
                            {
                                if (b == selectedIndex2)
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                Console.Write(option[b].PadRight(Console.WindowWidth - option.Length));
                            }

                            keyInfo1 = Console.ReadKey(true);

                            if (keyInfo1.Key == ConsoleKey.UpArrow)
                            {
                                selectedIndex2--;
                                if (selectedIndex2 < 0)
                                {
                                    selectedIndex2 = option.Length - 1;
                                }
                            }
                            else if (keyInfo1.Key == ConsoleKey.DownArrow)
                            {
                                selectedIndex2++;
                                if (selectedIndex2 == option.Length)
                                {
                                    selectedIndex2 = 0;
                                }
                            }


                            else if (keyInfo1.Key == ConsoleKey.Enter)
                            {
                                if (selectedIndex2 == 0)
                                {
                                    return;
                                }
                                else if (selectedIndex2 == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine(">>>1. Doc danh sach tu tep");
                                    Console.WriteLine(">>>2. Doc danh sach tu SQL Server");
                                    Console.WriteLine(">>>0. Thoat chuong trinh");
                                    Console.Write(">>>>Nhap lua chon cua ban: ");
                                    int chon = int.Parse(Console.ReadLine());
                                    if (chon == 1)
                                    {
                                        Console.Clear();
                                        danhsachgiaovien.Clear();
                                        string tenfile = "danhsachgiaovien.txt";


                                        // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                                        if (!File.Exists(tenfile))
                                        {
                                            Console.WriteLine($"Khong tim thay file {tenfile}");
                                            Thread.Sleep(2000);
                                            return;
                                        }
                                        using (var fs = new FileStream(tenfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                        {
                                            StreamReader streamReader = new StreamReader(fs);

                                            string line;
                                            while ((line = streamReader.ReadLine()) != null)
                                            {
                                                string[] data = line.Split(',');

                                                switch (data[0])
                                                {
                                                    case "GiaoVien":
                                                        giaovien gv = new giaovien()
                                                        {
                                                            magv = data[1],
                                                            tengv = data[2],
                                                            makhoa = data[3],
                                                            tenkhoa = data[4],
                                                            cocnlopkhong = bool.Parse(data[5]),
                                                            malopchunhiem = data[6],
                                                            sodienthoai = data[7],
                                                            email = data[8],
                                                            diachi = data[9]
                                                        };
                                                        danhsachgiaovien.Add(gv);
                                                        break;
                                                }
                                            }

                                        }
                                        Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach thanh cong");
                                        Thread.Sleep(3000);
                                    }
                                    else if (chon == 2)
                                    {
                                        Console.Clear();
                                        string connectionString = @"Data Source=NGUYENTIENDAT\MSSQLSERVER01;Initial Catalog=DIEMDOANCK1;Integrated Security=True";
                                        string query2 = "SELECT * FROM GiaoVien";

                                        using (SqlConnection connection = new SqlConnection(connectionString))
                                        {
                                            SqlCommand command2 = new SqlCommand(query2, connection);
                                            connection.Open();
                                            Console.WriteLine("[!] Mo ket noi den SQL Server thanh cong");
                                            SqlDataReader sqlDataReaderreader2 = command2.ExecuteReader();
                                            while (sqlDataReaderreader2.Read())
                                            {
                                                giaovien gv = new giaovien();
                                                gv.magv = sqlDataReaderreader2["MaGV"].ToString();
                                                gv.tengv = sqlDataReaderreader2["TenGV"].ToString();
                                                gv.makhoa = sqlDataReaderreader2["MaKhoa"].ToString();
                                                gv.tenkhoa = sqlDataReaderreader2["Tenkhoa"].ToString();
                                                gv.tenbm = sqlDataReaderreader2["Tenbm"].ToString();
                                                gv.cocnlopkhong = bool.Parse(sqlDataReaderreader2["CoCNLopKhong"].ToString());
                                                gv.malopchunhiem = sqlDataReaderreader2["MaLopChuNhiem"].ToString();
                                                gv.sodienthoai = sqlDataReaderreader2["SoDienThoai"].ToString();
                                                gv.email = sqlDataReaderreader2["Email"].ToString();
                                                gv.diachi = sqlDataReaderreader2["DiaChi"].ToString();

                                                danhsachgiaovien.Add(gv);
                                            }
                                            sqlDataReaderreader2.Close();
                                            Console.WriteLine("[!] Doc du lieu tu SQL Server thanh cong");
                                            Thread.Sleep(3000);

                                        }
                                    }
                                    else if (chon == 0)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Lua chon khong hop le");
                                        Thread.Sleep(2000);
                                    }
                                }
                                else if (selectedIndex2 == 2)
                                {
                                    Console.Clear();

                                    Console.Write("+------------+");
                                    
                                    Console.WriteLine("+------------+");

                                    Console.Write("|Ma giao vien|");
                                    Console.WriteLine("| Ma khoa    |");
                                   

                                    Console.Write("+------------+");
                                    Console.WriteLine("+------------+");

                                    for (int i = 0; i < danhsachgiaovien.Count || i < danhSachKhoa.Count; i++)
                                    {
                                        string makhoa = i < danhsachgiaovien.Count ? danhsachgiaovien[i].magv : "";
                                        string manganh = i < danhSachKhoa.Count ? danhSachKhoa[i].makhoa : "";
                                        

                                        Console.Write($"| {makhoa,-11}|");
                                        Console.WriteLine($"| {manganh,-11}|");
                                        
                                    }

                                    Console.Write("+------------+");
                                    Console.WriteLine("+------------+");
                                    Console.WriteLine("Nhap thong tin giao vien moi");

                                    Console.Write("Hay nhap so giao vien ban can them: ");
                                    int somonhoc = int.Parse(Console.ReadLine());

                                    for (int i = 0; i < somonhoc; i++)
                                    {
                                        giaovien gv = new giaovien();
                                        Console.WriteLine("Hay nhap thong tin cho giao vien thu {0}", i + 1);
                                        Console.Write(">>>Ma giao vien: ");
                                        string Magv = Console.ReadLine();

                                        // Kiem tra xem ma mon hoc da ton tai hay chua

                                        while (KiemTraTonTaiMonHoc(Magv))
                                        {
                                            Console.WriteLine($"Ma giao vien {Magv} da ton tai. Vui long nhap lai.");
                                            Console.Write("Ma mon hoc: ");
                                            Magv = Console.ReadLine();
                                        }

                                        // Hàm kiểm tra sự tồn tại của một giáo viên trong danh sách
                                        bool KiemTraTonTaiMonHoc(string magv)
                                        {
                                            return danhsachgiaovien.Any(gv => gv.magv == magv);
                                        }
                                        gv.magv = Magv;

                                        Console.Write("Ten giao vien: ");
                                        string tengv = Console.ReadLine();
                                        while (true)
                                        {
                                            if (string.IsNullOrEmpty(tengv))
                                            {
                                                Console.WriteLine("Ten giao vien khong duoc de trong. Vui long nhap lai.");
                                                Console.Write("Ten giao vien: ");
                                                tengv = Console.ReadLine();
                                            }
                                            else
                                            {
                                                gv.tengv = tengv;
                                                break;
                                            }
                                        }
                                        //Ma khoa
                                        while (true)
                                        {
                                            Console.Write("Ma khoa: ");
                                            string makhoa = Console.ReadLine();

                                            //Tim mon hoc trong danh sach
                                            khoa kh = danhSachKhoa.FirstOrDefault(kh => kh.makhoa == makhoa);
                                            if (kh == null)
                                            {
                                                Console.WriteLine($"Khong tim thay ma khoa voi ma {kh}");
                                                return;
                                            }
                                            else if(string.IsNullOrEmpty(makhoa))
                                            {
                                                Console.WriteLine("Ma khoa khong duoc tr");
                                            }    
                                            else
                                            {
                                                gv.makhoa = makhoa;
                                                gv.tenkhoa = kh.tenkhoa;
                                                break;
                                            }
                                        }


                                        while (true)
                                        {
                                            Console.Write("Co chu nhiem lop khong (Y/N): ");
                                            string cocnlopkhong = Console.ReadLine();
                                            if (cocnlopkhong == "Y" || cocnlopkhong == "y")
                                            {
                                                gv.cocnlopkhong = true;
                                                {
                                                    Console.Write("Ma lop chu nhiem: ");
                                                    string malopchunhiem = Console.ReadLine();
                                                    while (true)
                                                    {
                                                        if (string.IsNullOrEmpty(malopchunhiem))
                                                        {
                                                            Console.WriteLine("Ma lop chu nhiem khong duoc de trong. Vui long nhap lai.");
                                                            Console.Write("Ma lop chu nhiem: ");
                                                            malopchunhiem = Console.ReadLine();
                                                        }
                                                        else
                                                        {
                                                            gv.malopchunhiem = malopchunhiem;
                                                            break;
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                            else if (cocnlopkhong == "N" || cocnlopkhong == "n")
                                            {
                                                gv.cocnlopkhong = false;
                                                gv.malopchunhiem = "null";
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                                            }
                                        }
                                        //So dien thoai

                                        Console.Write(">>>SDT: ");
                                        string SDT = Console.ReadLine();

                                        while (true)
                                        {
                                            if (string.IsNullOrEmpty(SDT))
                                            {
                                                Console.WriteLine("So dien thoai khong duoc de trong.Vui long nhap lai!");
                                                Console.Write("SDT: ");
                                                SDT = Console.ReadLine();
                                            }
                                            else if (!IsNumeric(SDT) || !SDT.StartsWith("0"))
                                            {
                                                Console.WriteLine("So dien thoai phai la mot chuoi so va bat dau bang so 0");
                                                Console.Write("SDT: ");
                                                SDT = Console.ReadLine();
                                            }
                                            else if (SDT.Length != 10)
                                            {
                                                Console.WriteLine("So dien thoai phai co 10 chu so");
                                                Console.Write("SDT: ");
                                                SDT = Console.ReadLine();
                                            }
                                            else
                                            {
                                                gv.sodienthoai = SDT;
                                                break;
                                            }
                                        }

                                        //Email
                                        Console.Write(">>>Email: ");
                                        string email = Console.ReadLine();
                                        while (true)
                                        {
                                            if (string.IsNullOrEmpty(email))
                                            {
                                                Console.WriteLine("Email khong duoc de trong. Vui long nhap lai");
                                                Console.Write("Email: ");
                                                email = Console.ReadLine();
                                            }
                                            else if (!email.Contains("@") || !email.Contains("."))
                                            {
                                                Console.WriteLine("Email khong hop le. Vui long nhap lai");
                                                Console.Write("Email: ");
                                                email = Console.ReadLine();
                                            }
                                            else
                                            {
                                                gv.email = email;
                                                break;
                                            }
                                        }
                                        //Dia chi
                                        Console.Write("Dia chi: ");
                                        string diachi = Console.ReadLine();
                                        while (true)
                                        {
                                            if (string.IsNullOrEmpty(diachi))
                                            {
                                                Console.WriteLine("Dia chi khong duoc de trong. Vui long nhap lai.");
                                                Console.Write("Dia chi: ");
                                                diachi = Console.ReadLine();
                                            }
                                            else
                                            {
                                                gv.diachi = diachi;
                                                break;
                                            }
                                        }

                                        danhsachgiaovien.Add(gv);

                                        Console.WriteLine("Giao vien moi thu {0} da duoc them vao danh sach.", i + 1);
                                        Console.WriteLine();
                                        Console.WriteLine("Bam mot phim bat ki de tiep tuc!");
                                        Console.ReadKey();
                                    }
                                }
                                else if (selectedIndex2 == 3)
                                {
                                    while (true)
                                    {
                                        Console.SetWindowSize(200, 40);
                                        Console.Clear();

                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap ma giao vien can xoa:                        ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                        Console.WriteLine("|Ma giao vien| Ho ten           | Ma khoa      | Ten khoa            |Ma bo mon|Ten bo mon | SDT      | Email                   | Co chu nhiem lop khong | Ma lop chu nhiem       |");
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");

                                        foreach (giaovien gv in danhsachgiaovien)
                                        {

                                            Console.WriteLine($"| {gv.magv,-11}| {gv.tengv,-17}| {gv.makhoa,-13}| {gv.tenkhoa,-20}| {gv.mabm,-7} |{gv.tenbm,-11}|{gv.sodienthoai,-9} |{gv.email,-18}      | {gv.cocnlopkhong,-20}  | {gv.malopchunhiem,-20}  |");
                                        }
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                        Console.SetCursorPosition(85, 3);
                                        string magv = Console.ReadLine();

                                        // Kiem tra xem ma sinh vien co ton tai hay khong
                                        giaovien gv2 = danhsachgiaovien.FirstOrDefault(s => s.magv == magv);
                                        if (gv2 == null)
                                        {
                                            Console.WriteLine($"Khong tim thay sinh vien voi ma so {magv}");
                                            return;
                                        }

                                        // Xoa sinh vien khoi danh sach
                                        danhsachgiaovien.Remove(gv2);

                                        // Xoa diem cua sinh vien khoi danh sach
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                        Console.WriteLine("|Ma giao vien| Ho ten           | Ma khoa      | Ten khoa            |Ma bo mon|Ten bo mon | SDT      | Email                   | Co chu nhiem lop khong | Ma lop chu nhiem       |");
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                        foreach (giaovien gv in danhsachgiaovien)
                                        {

                                            Console.WriteLine($"| {gv.magv,-11}| {gv.tengv,-17}| {gv.makhoa,-13}| {gv.tenkhoa,-20}| {gv.mabm,-7} |{gv.tenbm,-11}|{gv.sodienthoai,-9} |{gv.email,-18}      | {gv.cocnlopkhong,-20}  | {gv.malopchunhiem,-20}  |");
                                        }
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                        Console.WriteLine($"Giao vien {gv2.tengv} da duoc xoa khoi danh sach.");
                                        Console.WriteLine();
                                        //An esc  de thoat
                                        if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                                        {
                                            Console.SetWindowSize(158, 34);
                                            break;
                                        }
                                    }
                                    Console.SetWindowSize(158, 34);
                                }
                                else if (selectedIndex2 == 4)
                                {
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.SetWindowSize(200, 40);
                                        Console.Clear();

                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap ma giao vien can sua:                        ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine();
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                        Console.WriteLine("|Ma giao vien| Ho ten           | Ma khoa      | Ten khoa            |Ma bo mon|Ten bo mon | SDT      | Email                   | Co chu nhiem lop khong | Ma lop chu nhiem       |");
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                        foreach (giaovien gv in danhsachgiaovien)
                                        {

                                            Console.WriteLine($"| {gv.magv,-11}| {gv.tengv,-17}| {gv.makhoa,-13}| {gv.tenkhoa,-20}| {gv.mabm,-7} |{gv.tenbm,-11}|{gv.sodienthoai,-9} |{gv.email,-18}      | {gv.cocnlopkhong,-20}  | {gv.malopchunhiem,-20}  |");
                                        }
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                        Console.SetCursorPosition(85, 3);
                                        string magvsua = Console.ReadLine();

                                        giaovien gvcheck = danhsachgiaovien.Find(s => s.magv.Equals(magvsua, StringComparison.OrdinalIgnoreCase));

                                        if (gvcheck != null)
                                        {

                                            Console.SetWindowSize(200, 40);
                                            Console.Clear();

                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║        THONG TIN GIAO VIEN CAN SUA                ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                            Console.WriteLine("|Ma giao vien| Ho ten           | Ma khoa      | Ten khoa            |Ma bo mon|Ten bo mon | SDT      | Email                   | Co chu nhiem lop khong | Ma lop chu nhiem       |");
                                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");
                                            {

                                                Console.WriteLine($"| {gvcheck.magv,-11}| {gvcheck.tengv,-17}| {gvcheck.makhoa,-13}| {gvcheck.tenkhoa,-20}| {gvcheck.mabm,-7} |{gvcheck.tenbm,-11}|{gvcheck.sodienthoai,-9} |{gvcheck.email,-18}      | {gvcheck.cocnlopkhong,-20}  | {gvcheck.malopchunhiem,-20}  |");
                                            }
                                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+-------------------------+------------------------+------------------------+");

                                            Console.WriteLine("Nhap thong tin giao vien moi");
                                            Console.Clear();
                                            Console.Write("Ma giao vien: ");
                                            string magv2 = Console.ReadLine();
                                            while (true)
                                            {
                                                if (magv2.Length == 0)
                                                {
                                                    Console.WriteLine("Ma giao vien khong duoc de trong. Vui long nhap lai!");
                                                    Console.Write("Ma giao vien: ");
                                                    magv2 = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    gvcheck.magv = magv2;
                                                    break;
                                                }
                                            }
                                            //Nhap ten giao vien
                                            Console.Write("Ten cua giao vien: ");
                                            gvcheck.tengv = Console.ReadLine();

                                            //Nhap ma khoa
                                            while (true)
                                            {
                                                Console.Write("Ma khoa: ");
                                                string makhoa = Console.ReadLine();

                                                //Tim mon hoc trong danh sach
                                                khoa kh = danhSachKhoa.FirstOrDefault(kh => kh.makhoa == makhoa);
                                                if (kh == null)
                                                {
                                                    Console.WriteLine($"Khong tim thay ma khoa voi ma {kh}");
                                                    return;
                                                }
                                                else if (string.IsNullOrEmpty(makhoa))
                                                {
                                                    Console.WriteLine("Ma khoa khong duoc tr");
                                                }
                                                else
                                                {
                                                    gvcheck.makhoa = makhoa;
                                                    gvcheck.tenkhoa = kh.tenkhoa;
                                                    break;
                                                }
                                            }


                                            //Ma bo mon
                                            while (true)
                                            {
                                                Console.Write("Co chu nhiem lop khong (Y/N): ");
                                                string cocnlopkhong = Console.ReadLine();
                                                if (cocnlopkhong == "Y" || cocnlopkhong == "y")
                                                {
                                                    gvcheck.cocnlopkhong = true;
                                                    {
                                                        Console.Write("Ma lop chu nhiem: ");
                                                        string malopchunhiem = Console.ReadLine();
                                                        while (true)
                                                        {
                                                            if (string.IsNullOrEmpty(malopchunhiem))
                                                            {
                                                                Console.WriteLine("Ma lop chu nhiem khong duoc de trong. Vui long nhap lai.");
                                                                Console.Write("Ma lop chu nhiem: ");
                                                                malopchunhiem = Console.ReadLine();
                                                            }
                                                            else
                                                            {
                                                                gvcheck.malopchunhiem = malopchunhiem;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                                else if (cocnlopkhong == "N" || cocnlopkhong == "n")
                                                {
                                                    gvcheck.cocnlopkhong = false;
                                                    gvcheck.malopchunhiem = "null";
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                                                }
                                            }
                                            //So dien thoai

                                            Console.Write(">>>SDT: ");
                                            string SDT = Console.ReadLine();
                                            gvcheck.sodienthoai = Console.ReadLine();

                                            //Email
                                            Console.Write(">>>Email: ");
                                            string email = Console.ReadLine();
                                            while (true)
                                            {
                                                if (string.IsNullOrEmpty(email))
                                                {
                                                    Console.WriteLine("Email khong duoc de trong. Vui long nhap lai");
                                                    Console.Write("Email: ");
                                                    email = Console.ReadLine();
                                                }
                                                else if (!email.Contains("@") || !email.Contains("."))
                                                {
                                                    Console.WriteLine("Email khong hop le. Vui long nhap lai");
                                                    Console.Write("Email: ");
                                                    email = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    gvcheck.email = email;
                                                    break;
                                                }
                                            }
                                            //Dia chi
                                            Console.Write("Dia chi: ");
                                            string diachi = Console.ReadLine();
                                            while (true)
                                            {
                                                if (string.IsNullOrEmpty(diachi))
                                                {
                                                    Console.WriteLine("Dia chi khong duoc de trong. Vui long nhap lai.");
                                                    Console.Write("Dia chi: ");
                                                    diachi = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    gvcheck.diachi = diachi;
                                                    break;
                                                }
                                            }

                                            danhsachgiaovien.Add(gvcheck);

                                            Console.WriteLine($"Giao vien co ma {gvcheck.magv} da duoc sua.");
                                            Console.WriteLine();
                                            Console.WriteLine("Bam mot phim bat ki de tiep tuc!");
                                            Console.ReadKey();
                                        }
                                    }
                                }
                                else if (selectedIndex2 == 5)
                                {
                                    Console.Clear();
                                    string tenTep2 = "danhsachgiaovien.txt";

                                    try
                                    {
                                        using (StreamWriter writer = new StreamWriter(tenTep2))
                                        {
                                            foreach (giaovien gv in danhsachgiaovien)
                                            {
                                                writer.WriteLine($"GiaoVien,{gv.magv},{gv.tengv},{gv.makhoa},{gv.tenkhoa},{gv.cocnlopkhong},{gv.malopchunhiem},{gv.sodienthoai},{gv.email},{gv.diachi}");
                                            }
                                        }

                                        Console.WriteLine($"Da ghi danh sach sach giao vien vao tep {tenTep2} thanh cong.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Loi khi ghi danh sach giao vien vao tep: {ex.Message}");
                                    }
                                    Console.WriteLine("[!] An mot phim bat ki de tiep tuc");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.CursorVisible = false;
                        ConsoleKeyInfo keyInfo3;
                        int selectedIndex3 = 0;
                        string[] options2 = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║      READ LIST UNIVERSITY FACULTIES   ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                ADD FACULTIES          ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              DELETE FACULTIES         ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                EDIT FACULTIES         ▼     ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SAVE LIST FACULTIES      ▼     ║  
                                                             ╚═════════════════════════════════════════════╝" };

                        while (true)
                        {
                            Console.Clear();
                            for (int i = 0; i < options2.Length; i++)
                            {
                                if (i == selectedIndex3)
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                Console.Write(options2[i].PadRight(Console.WindowWidth - options2.Length));
                            }

                            keyInfo3 = Console.ReadKey(true);

                            if (keyInfo3.Key == ConsoleKey.UpArrow)
                            {
                                selectedIndex3--;
                                if (selectedIndex3 < 0)
                                {
                                    selectedIndex3 = options2.Length - 1;
                                }
                            }
                            else if (keyInfo3.Key == ConsoleKey.DownArrow)
                            {
                                selectedIndex3++;
                                if (selectedIndex3 == options2.Length)
                                {
                                    selectedIndex3 = 0;
                                }
                            }
                            else if (keyInfo3.Key == ConsoleKey.Enter)
                            {
                                if (selectedIndex3 == 0)
                                {
                                    return;
                                }
                                else if (selectedIndex3 == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine(">>>1. Doc danh sach tu tep");
                                    Console.WriteLine(">>>2. Doc danh sach tu SQL Server");
                                    Console.WriteLine(">>>0. Thoat chuong trinh");
                                    Console.Write(">>>>Nhap lua chon cua ban: ");
                                    int chon = int.Parse(Console.ReadLine());
                                    if (chon == 1)
                                    {
                                        Console.Clear();
                                        danhSachSV.Clear();
                                        string tenfile = "danhsachkhoa.txt";


                                        // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                                        if (!File.Exists(tenfile))
                                        {
                                            Console.WriteLine($"Khong tim thay file {tenfile}");
                                            Thread.Sleep(2000);
                                            return;
                                        }
                                        using (var fs = new FileStream(tenfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                        {
                                            StreamReader streamReader = new StreamReader(fs);

                                            string line;
                                            while ((line = streamReader.ReadLine()) != null)
                                            {
                                                string[] data = line.Split(',');

                                                switch (data[0])
                                                {
                                                    case "Khoa":
                                                        khoa khoa = new khoa()
                                                        {
                                                            makhoa = data[1],
                                                            tenkhoa = data[2],
                                                            soluongbm = int.Parse(data[3]),
                                                            soluonggv = int.Parse(data[4]),
                                                            soluongsv = int.Parse(data[5]),
                                                            soluongmh = int.Parse(data[6]),
                                                            soluongnganh = int.Parse(data[7]),
                                                            manganh = data[8],
                                                            soluonglop = int.Parse(data[9])
                                                        };
                                                        danhSachKhoa.Add(khoa);
                                                        break;
                                                }
                                            }

                                        }
                                        Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach thanh cong");
                                        Thread.Sleep(3000);
                                    }
                                    else if (chon == 2)
                                    {
                                        Console.Clear();
                                        string connectionString = @"Data Source=NGUYENTIENDAT\MSSQLSERVER01;Initial Catalog=DIEMDOANCK1;Integrated Security=True";
                                        string query2 = "SELECT * FROM Khoa";

                                        using (SqlConnection connection = new SqlConnection(connectionString))
                                        {
                                            SqlCommand command2 = new SqlCommand(query2, connection);
                                            connection.Open();
                                            Console.WriteLine("[!] Ket noi den SQL Server thanh cong");
                                            SqlDataReader sqlDataReaderreader2 = command2.ExecuteReader();
                                            while (sqlDataReaderreader2.Read())
                                            {
                                                khoa khoa = new khoa();
                                                khoa.makhoa = sqlDataReaderreader2["MaKhoa"].ToString();
                                                khoa.tenkhoa = sqlDataReaderreader2["TenKhoa"].ToString();
                                                khoa.soluongbm = Convert.ToInt32(sqlDataReaderreader2["Soluongbm"]);
                                                khoa.soluonggv = Convert.ToInt32(sqlDataReaderreader2["Soluonggv"]);
                                                khoa.soluongsv = Convert.ToInt32(sqlDataReaderreader2["Soluongsv"]);
                                                khoa.soluongmh = Convert.ToInt32(sqlDataReaderreader2["Soluongmh"]);
                                                khoa.soluongnganh = Convert.ToInt32(sqlDataReaderreader2["Soluongnganh"]);
                                                khoa.soluonglop = Convert.ToInt32(sqlDataReaderreader2["Soluonglop"]);
                                                danhSachKhoa.Add(khoa);
                                            }
                                            sqlDataReaderreader2.Close();
                                            Console.WriteLine("[!] Doc du lieu tu SQL Server thanh cong");
                                            Thread.Sleep(3000);
                                        }
                                    }
                                    else if (chon == 0)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Lua chon khong hop le");
                                        Thread.Sleep(2000);
                                    }
                                }
                                else if (selectedIndex3 == 2)
                                {
                                    Console.Clear();
                                    Console.Clear();
                                    Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                                    Console.WriteLine("|Ma khoa     | Ten khoa         |So luong bm   |So luong giao vien   |so luong sinh vien   | So luong mon hoc    |So luong nganh       | So luong lop            |");
                                    Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");

                                    foreach (khoa kh in danhSachKhoa)
                                    {

                                        Console.WriteLine($"| {kh.makhoa,-11}| {kh.tenkhoa,-17}| {kh.soluongbm,-13}| {kh.soluonggv,-20}| {kh.soluongsv,-20}| {kh.soluongmh,-20}|{kh.soluongnganh,-20} | {kh.soluonglop,-20}|");
                                    }
                                    Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                                    Console.WriteLine("Nhap thong tin khoa moi");

                                    Console.Write("Hay nhap so khoa ban can them: ");
                                    int songanh = int.Parse(Console.ReadLine());

                                    for (int i = 0; i < songanh; i++)
                                    {
                                        khoa khoa = new khoa();
                                        Console.WriteLine("Hay nhap thong tin cho khoa thu {0}", i + 1);
                                        Console.Write(">>>Ma khoa: ");
                                        string makhoa = Console.ReadLine();

                                        // Kiem tra xem ma mon hoc da ton tai hay chua

                                        while (KiemTraTonTaiMonHoc(makhoa))
                                        {
                                            Console.WriteLine($"Ma khoa {makhoa} da ton tai. Vui long nhap lai.");
                                            Console.Write("Ma khoa: ");
                                            makhoa = Console.ReadLine();
                                        }

                                        // Hàm kiểm tra sự tồn tại của một giáo viên trong danh sách
                                        bool KiemTraTonTaiMonHoc(string makhoa)
                                        {
                                            return danhSachKhoa.Any(s => s.makhoa == makhoa);
                                        }
                                        khoa.makhoa = makhoa;

                                        Console.Write("Ten khoa: ");
                                        string tenkhoa = Console.ReadLine();
                                        while (true)
                                        {
                                            if (string.IsNullOrEmpty(tenkhoa))
                                            {
                                                Console.WriteLine("Ten khoa khong duoc de trong. Vui long nhap lai.");
                                                Console.Write("Ten khoa: ");
                                                tenkhoa = Console.ReadLine();
                                            }
                                            else
                                            {
                                                khoa.tenkhoa = tenkhoa;
                                                break;
                                            }
                                        }
                                        //So luong bo mon
                                        Console.Write("So luong bo mon: ");
                                        int soluongbomon = int.Parse(Console.ReadLine());
                                        while (true)
                                        {
                                            if (soluongbomon <= 0)
                                            {
                                                Console.WriteLine("So luong bo mon khong duoc nho hon hoac bang 0");
                                                Console.Write("So luong bo mon: ");
                                                soluongbomon = int.Parse(Console.ReadLine());
                                            }
                                            else
                                            {
                                                khoa.soluongbm = soluongbomon;
                                                break;
                                            }
                                        }
                                        //So luong giao vien
                                        Console.Write("So luong giao vien: ");
                                        int soluonggiaovien = int.Parse(Console.ReadLine());
                                        while (true)
                                        {
                                            if (soluonggiaovien <= 0)
                                            {
                                                Console.WriteLine("So luong giao vien khong duoc nho hon hoac bang 0");
                                                Console.Write("So luong giao vien: ");
                                                soluonggiaovien = int.Parse(Console.ReadLine());
                                            }
                                            else
                                            {
                                                khoa.soluonggv = soluonggiaovien;
                                                break;
                                            }

                                        }
                                        //So luong sinh vien
                                        Console.Write("So luong sinh vien: ");
                                        int soluongsinhvien = int.Parse(Console.ReadLine());
                                        while (true)
                                        {
                                            if (soluongsinhvien <= 0)
                                            {
                                                Console.WriteLine("So luong sinh vien khong duoc nho hon hoac bang 0");
                                                Console.Write("So luong sinh vien: ");
                                                soluongsinhvien = int.Parse(Console.ReadLine());
                                            }
                                            else
                                            {
                                                khoa.soluongsv = soluongsinhvien;
                                                break;
                                            }

                                        }
                                        //So luong mon hoc
                                        Console.Write("So luong mon hoc: ");
                                        int soluongmh = int.Parse(Console.ReadLine());
                                        while (true)
                                        {
                                            if (soluongmh <= 0)
                                            {
                                                Console.WriteLine("So luong mon hoc khong duoc nho hon hoac bang 0");
                                                Console.Write("So luong mon hoc: ");
                                                soluongmh = int.Parse(Console.ReadLine());
                                            }
                                            else
                                            {
                                                khoa.soluongmh = soluongmh;
                                                break;
                                            }

                                        }
                                        //So luong nganh
                                        Console.Write("So luong nganh: ");
                                        int soluongnganh = int.Parse(Console.ReadLine());
                                        while (true)
                                        {
                                            if (soluongnganh <= 0)
                                            {
                                                Console.WriteLine("So luong nganh khong duoc nho hon hoac bang 0");
                                                Console.Write("So luong nganh: ");
                                                soluongnganh = int.Parse(Console.ReadLine());
                                            }
                                            else
                                            {
                                                khoa.soluongnganh = soluongnganh;
                                                {
                                                    for (int a = 0; a < soluongnganh; a++)
                                                    {
                                                        nganh nganh = new nganh();
                                                        Console.Write("Ma nganh: ");
                                                        string manganh = Console.ReadLine();
                                                        Console.Write("Ten nganh: ");
                                                        string tennganh = Console.ReadLine();
                                                        while (true)
                                                        {
                                                            if (string.IsNullOrEmpty(manganh))
                                                            {
                                                                Console.WriteLine("Ma nganh khong duoc de trong. Vui long nhap lai.");
                                                                Console.Write("Ma nganh: ");
                                                                manganh = Console.ReadLine();
                                                            }
                                                            else if (string.IsNullOrEmpty(tennganh))
                                                            {
                                                                Console.WriteLine("Ten nganh khong duoc de trong. Vui long nhap lai.");
                                                                Console.Write("Te nganh: ");
                                                                tennganh = Console.ReadLine();
                                                            }   
                                                            else
                                                            {
                                                                nganh.manganh = manganh;
                                                                nganh.tennganh = tennganh;
                                                                danhsachnganh.Add(nganh);
                                                                break;//Su dụng list liên kết
                                                            }
                                                            
                                                        }
                                                    }
                                                }
                                                break;
                                            }

                                        }
                                        //So luong lop
                                        Console.Write("So luong lop: ");
                                        int soluonglop = int.Parse(Console.ReadLine());
                                        while (true)
                                        {
                                            if (soluonglop <= 0)
                                            {
                                                Console.WriteLine("So luong lop khong duoc nho hon hoac bang 0");
                                                Console.Write("So luong lop: ");
                                                soluonglop = int.Parse(Console.ReadLine());
                                            }
                                            else
                                            {
                                                khoa.soluonglop = soluonglop;
                                                break;
                                            }

                                        }

                                        danhSachKhoa.Add(khoa);

                                        Console.WriteLine("Khoa moi thu {0} da duoc them vao danh sach.", i + 1);
                                        Console.WriteLine();
                                        Console.WriteLine("Bam mot phim bat ki de tiep tuc!");
                                        Console.ReadKey();
                                    }
                                }
                                else if (selectedIndex3 == 3)
                                {
                                    while (true)
                                    {
                                        Console.SetWindowSize(200, 40);
                                        Console.Clear();

                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap ma khoa can xoa:                             ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                                        Console.WriteLine("|Ma khoa     | Ten khoa         |So luong bm   |So luong giao vien   |so luong sinh vien   | So luong mon hoc    |So luong nganh       | So luong lop            |");
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");

                                        foreach (khoa kh in danhSachKhoa)
                                        {

                                            Console.WriteLine($"| {kh.makhoa,-11}| {kh.tenkhoa,-17}| {kh.soluongbm,-13}| {kh.soluonggv,-20}| {kh.soluongsv,-20}| {kh.soluongmh,-20}|{kh.soluongnganh,-20} | {kh.soluonglop,-20}|");
                                        }
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                                        Console.SetCursorPosition(85, 3);
                                        string makhoa = Console.ReadLine();

                                        // Kiem tra xem ma sinh vien co ton tai hay khong
                                        khoa kh2 = danhSachKhoa.FirstOrDefault(s => s.makhoa == makhoa);
                                        if (kh2 == null)
                                        {
                                            Console.WriteLine($"Khong tim thay khoa voi ma so {makhoa}");
                                            return;
                                        }

                                        // Xoa sinh vien khoi danh sach
                                        danhSachKhoa.Remove(kh2);

                                        // Xoa diem cua sinh vien khoi danh sach
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                                        Console.WriteLine("|Ma khoa     | Ten khoa         |So luong bm   |So luong giao vien   |so luong sinh vien   | So luong mon hoc    |So luong nganh       | So luong lop            |");
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");

                                        foreach (khoa kh in danhSachKhoa)
                                        {

                                            Console.WriteLine($"| {kh.makhoa,-11}| {kh.tenkhoa,-17}| {kh.soluongbm,-13}| {kh.soluonggv,-20}| {kh.soluongsv,-20}| {kh.soluongmh,-20}|{kh.soluongnganh,-20} | {kh.soluonglop,-20}|");
                                        }
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                                        Console.WriteLine($"Khoa {kh2.tenkhoa} da duoc xoa khoi danh sach.");
                                        Console.WriteLine();
                                        //An esc  de thoat
                                        if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                                        {
                                            Console.SetWindowSize(158, 34);
                                            break;
                                        }
                                    }
                                  
   
                                }
                                else if (selectedIndex3 == 4)
                                {
                                    Console.Clear();

                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.SetWindowSize(200, 40);
                                        Console.Clear();

                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap ma khoa can sua:                               ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine();
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                                        Console.WriteLine("|Ma khoa     | Ten khoa         |So luong bm   |So luong giao vien   |so luong sinh vien   | So luong mon hoc    |So luong nganh       | So luong lop            |");
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");

                                        foreach (khoa kh in danhSachKhoa)
                                        {

                                            Console.WriteLine($"| {kh.makhoa,-11}| {kh.tenkhoa,-17}| {kh.soluongbm,-13}| {kh.soluonggv,-20}| {kh.soluongsv,-20}| {kh.soluongmh,-20}|{kh.soluongnganh,-20} | {kh.soluonglop,-20}|");
                                        }
                                        Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                  
                                        Console.SetCursorPosition(85, 3);
                                        string makhoasu = Console.ReadLine();

                                        khoa khoacheck = danhSachKhoa.Find(s => s.makhoa.Equals(makhoasu, StringComparison.OrdinalIgnoreCase));

                                        if (khoacheck != null)
                                        {

                                            Console.SetWindowSize(200, 40);
                                            Console.Clear();

                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║        THONG TIN GIAO VIEN CAN SUA                ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                                            Console.WriteLine("|Ma khoa     | Ten khoa         |So luong bm   |So luong giao vien   |so luong sinh vien   | So luong mon hoc    |So luong nganh       | So luong lop            |");
                                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");
                                            {

                                                Console.WriteLine($"| {khoacheck.makhoa,-11}| {khoacheck.tenkhoa,-17}| {khoacheck.soluongbm,-13}| {khoacheck.soluonggv,-20}| {khoacheck.soluongsv,-20}| {khoacheck.soluongmh,-20}|{khoacheck.soluongnganh,-20} | {khoacheck.soluonglop,-20}|");
                                            }
                                            Console.WriteLine("+------------+------------------+--------------+---------------------+---------------------+---------------------+---------------------+-------------------------+");

                                            Console.WriteLine("Nhap thong tin khoa moi moi:");

                                            Console.Write("Ma khoa: ");
                                            string makhoa2 = Console.ReadLine();
                                            while (true)
                                            {
                                                if (makhoa2.Length == 0)
                                                {
                                                    Console.WriteLine("Ma khoa khong duoc de trong. Vui long nhap lai!");
                                                    Console.Write("Ma khoa: ");
                                                    makhoa2 = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    khoacheck.makhoa = makhoa2;
                                                    break;
                                                }
                                            }
                                            //Nhap ten khoa can sua
                                            Console.Write("Ten khoa: ");
                                            string tenkhoa2 = Console.ReadLine();
                                            while (true)
                                            {
                                                if (tenkhoa2.Length == 0)
                                                {
                                                    Console.WriteLine("Ten khoa khong duoc de trong. Vui long nhap lai!");
                                                    Console.Write("Ten khoa: ");
                                                    tenkhoa2 = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    khoacheck.tenkhoa = tenkhoa2;
                                                    break;
                                                }
                                            }
                                            //So luong bo mon
                                            Console.Write("So luong bo mon: ");
                                            int soluongbm2 = int.Parse(Console.ReadLine());
                                            while (true)
                                            {
                                                if (soluongbm2 <= 0)
                                                {
                                                    Console.WriteLine("So luong bo mon khong duoc nho hon hoac bang 0");
                                                    Console.Write("So luong bo mon: ");
                                                    soluongbm2 = int.Parse(Console.ReadLine());
                                                }
                                                else
                                                {
                                                    khoacheck.soluongbm = soluongbm2;
                                                    break;
                                                }

                                            }
                                            //So luong giao vien
                                            Console.Write("So luong giao vien: ");
                                            int soluonggv2 = int.Parse(Console.ReadLine());
                                            while (true)
                                            {
                                                if (soluonggv2 <= 0)
                                                {
                                                    Console.WriteLine("So luong giao vien khong duoc nho hon hoac bang 0");
                                                    Console.Write("So luong giao vien: ");
                                                    soluonggv2 = int.Parse(Console.ReadLine());
                                                }
                                                else
                                                {
                                                    khoacheck.soluonggv = soluonggv2;
                                                    break;
                                                }

                                            }
                                            //So luong sinh vien
                                            Console.Write("So luong sinh vien: ");
                                            int soluongsv2 = int.Parse(Console.ReadLine());
                                            while (true)
                                            {
                                                if (soluongsv2 <= 0)
                                                {
                                                    Console.WriteLine("So luong sinh vien khong duoc nho hon hoac bang 0");
                                                    Console.Write("So luong sinh vien: ");
                                                    soluongsv2 = int.Parse(Console.ReadLine());
                                                }
                                                else
                                                {
                                                    khoacheck.soluongsv = soluongsv2;
                                                    break;
                                                }

                                            }
                                            //So luong mon hoc
                                            Console.Write("So luong mon hoc: ");
                                            int soluongmh2 = int.Parse(Console.ReadLine());
                                            while (true)
                                            {
                                                if (soluongmh2 <= 0)
                                                {
                                                    Console.WriteLine("So luong mon hoc khong duoc nho hon hoac bang 0");
                                                    Console.Write("So luong mon hoc: ");
                                                    soluongmh2 = int.Parse(Console.ReadLine());
                                                }
                                                else
                                                {
                                                    khoacheck.soluongmh = soluongmh2;
                                                    break;
                                                }

                                            }
                                            //So luong nganh
                                            Console.Write("So luong nganh: ");
                                            int soluongnganh2 = int.Parse(Console.ReadLine());
                                            while (true)
                                            {
                                                if (soluongnganh2 <= 0)
                                                {
                                                    Console.WriteLine("So luong nganh khong duoc nho hon hoac bang 0");
                                                    Console.Write("So luong nganh: ");
                                                    soluongnganh2 = int.Parse(Console.ReadLine());
                                                }
                                                else
                                                {
                                                    khoacheck.soluongnganh = soluongnganh2;
                                                    break;
                                                }

                                            }
                                            //So luong lop
                                            Console.Write("So luong lop: ");
                                            int soluonglop2 = int.Parse(Console.ReadLine());
                                            while (true)
                                            {
                                                if (soluonglop2 <= 0)
                                                {
                                                    Console.WriteLine("So luong lop khong duoc nho hon hoac bang 0");
                                                    Console.Write("So luong lop: ");
                                                    soluonglop2 = int.Parse(Console.ReadLine());
                                                }
                                                else
                                                {
                                                    khoacheck.soluonglop = soluonglop2;
                                                    break;
                                                }

                                            }
                                            danhSachKhoa.Add(khoacheck);

                                            Console.WriteLine($"Khoa co ma {khoacheck.makhoa} da duoc sua.");
                                            Console.WriteLine();
                                            Console.WriteLine("Bam mot phim bat ki de tiep tuc!");
                                            Console.ReadKey();

                                        }
                                    }
                                }
                                else if (selectedIndex3 == 5)
                                {
                                    Console.Clear();
                                    string tenTep2 = "danhsachkhoa.txt";
                                    string tenTep3 = "danh_sach_nganh.txt";

                                    try
                                    {
                                        using (StreamWriter writer2 = new StreamWriter(tenTep2))
                                        {
                                            foreach (khoa kh in danhSachKhoa)
                                            {
                                                writer2.WriteLine($"Khoa,{kh.makhoa},{kh.tenkhoa},{kh.soluongbm},{kh.soluonggv},{kh.soluongsv},{kh.soluongmh},{kh.soluongnganh},{kh.soluonglop}");
     
                                            }
                                        }

                                        

                                        Console.WriteLine($"Da ghi danh sach khoa vao tep {tenTep2} thanh cong.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Loi khi ghi danh sach khoa vao tep: {ex.Message}");
                                    }

                                    try
                                    {
                                        using (StreamWriter writer3 = new StreamWriter(tenTep3))
                                        {
                                            foreach (nganh ng in danhsachnganh)
                                            {
                                                writer3.WriteLine($"Nganh,{ng.manganh},{ng.tennganh}");
                                            }
                                        }

                                        Console.WriteLine($"Da ghi danh sach nganh vao tep {tenTep2} thanh cong.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Loi khi ghi danh sach nganh vao tep: {ex.Message}");
                                    }
                                    Console.WriteLine("[!] An mot phim bat ki de tiep tuc");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }   
                }
            }
        }
        public void THONGKEDL()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║          STUDENT GRADE STATEMENT            ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║     DRAWING STUDENT's AVERAGE GRADE CHART   ║  
                                                             ╚═════════════════════════════════════════════╝" };

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        break;
                    }
                    else if (selectedIndex == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("SAP XEP DANH SACH SINH VIEN THEO DIEM TRUNG BINH");
                        Console.WriteLine();
                        Console.Clear();
                        Console.WriteLine("Danh sach diem theo thu tu giam dan");
                        Console.WriteLine("Danh sach diem");
                        Console.WriteLine("+------------+------------------+---------+-----------+----------+------------+--------------------+");
                        Console.WriteLine("|Ma Sinh Vien| Ho ten           |Diem CC  |Diem KT    |Diem TH   |Diem TB     |  DGHS              |");
                        Console.WriteLine("+------------+------------------+---------+-----------+----------+------------+--------------------+");

                        var diem = danhSachDiem.OrderByDescending(d => d.DiemTB);

                        foreach (var item in diem)
                        {
                            Console.WriteLine($"| {item.MaSV,-11}| {item.TenSV,-17}| {item.DiemCC,-7} |{item.DiemKT,-11}|{item.DiemTH,-9} | {item.DiemTB,-11}|{item.DGHS,-17}   |");
                        }
                        Console.WriteLine("+------------+------------------+---------+-----------+----------+------------+--------------------+");
                        Console.WriteLine();
                        Console.WriteLine("Bam mot phim bat ky de tro ve menu chinh.");
                        Console.ReadKey();
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.Clear();
                        List<double> scores = new List<double>();
                        List<double> scores2 = new List<double>();
                        List<double> scores3 = new List<double>();
                        List<double> scores4 = new List<double>();


                        foreach (Diem diem in danhSachDiem)
                        {
                            scores.Add(diem.DiemTB);
                            scores2.Add(diem.DiemCC);
                            scores3.Add(diem.DiemKT);
                            scores4.Add(diem.DiemTH);
                        }
                        // Khởi tạo một danh sách chứa điểm số
                        // Khởi tạo một Dictionary để đếm số lần xuất hiện của mỗi điểm
                        Dictionary<double, int> scoreCounts = new Dictionary<double, int>();
                        foreach (double score in scores)
                        {
                            if (!scoreCounts.ContainsKey(score))
                            {
                                scoreCounts.Add(score, 1);
                            }
                            else
                            {
                                scoreCounts[score]++;
                            }
                        }
                        //DiemCC
                        Dictionary<double, int> scoreCounts2 = new Dictionary<double, int>();
                        foreach (double score in scores2)
                        {
                            if (!scoreCounts2.ContainsKey(score))
                            {
                                scoreCounts2.Add(score, 1);
                            }
                            else
                            {
                                scoreCounts2[score]++;
                            }
                        }
                        //DiemKT
                        Dictionary<double, int> scoreCounts3 = new Dictionary<double, int>();
                        foreach (double score2 in scores3)
                        {
                            if (!scoreCounts3.ContainsKey(score2))
                            {
                                scoreCounts3.Add(score2, 1);
                            }
                            else
                            {
                                scoreCounts3[score2]++;
                            }
                        }
                        //DiemTH
                        Dictionary<double, int> scoreCounts4 = new Dictionary<double, int>();
                        foreach (double score3 in scores4)
                        {
                            if (!scoreCounts4.ContainsKey(score3))
                            {
                                scoreCounts4.Add(score3, 1);
                            }
                            else
                            {
                                scoreCounts4[score3]++;
                            }
                        }
                        // Vẽ biểu đồ
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t\t\t\t\tAvegrage Score");
                        Console.WriteLine("\t\t\t\t\t\t\t------------------------");
                        Console.ForegroundColor=ConsoleColor.White;
                        foreach (KeyValuePair<double, int> pair in scoreCounts)
                        {
                            double score = pair.Key;
                            int count = pair.Value;
                            double ratio = (double)count / scores.Count * 100;
                            Console.Write($"{score,4:F1} | ");
                            for (int i = 0; i < ratio; i++)
                            {
                                Console.Write("█");
                            }
                            Console.WriteLine($" {ratio:F1}% ({count} diem)");
                        }
                        Console.WriteLine();
                        //Diem CC
                        Console.WriteLine("\t\t\t\t\t\t\tCC Score");
                        Console.WriteLine("\t\t\t\t\t\t\t------------------------");
                        Console.ForegroundColor = ConsoleColor.Red;
                        foreach (KeyValuePair<double, int> pair in scoreCounts2)
                        {
                            double score = pair.Key;
                            int count = pair.Value;
                            double ratio = (double)count / scores.Count * 100;
                            Console.Write($"{score,4:F1} | ");
                            for (int i = 0; i < ratio; i++)
                            {
                                Console.Write("█");
                            }
                            Console.WriteLine($" {ratio:F1}% ({count} diem)");
                        }
                        Console.WriteLine();
                        //DiemKT
                        Console.WriteLine("\t\t\t\t\t\t\tTest Score");
                        Console.WriteLine("\t\t\t\t\t\t\t------------------------");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        foreach (KeyValuePair<double, int> pair in scoreCounts3)
                        {
                            double score = pair.Key;
                            int count = pair.Value;
                            double ratio = (double)count / scores.Count * 100;
                            Console.Write($"{score,4:F1} | ");
                            for (int i = 0; i < ratio; i++)
                            {
                                Console.Write("█");
                            }
                            Console.WriteLine($" {ratio:F1}% ({count} diem)");
                        }
                        Console.WriteLine();
                        //DiemTH
                        Console.WriteLine("\t\t\t\t\t\t\tPractice Score");
                        Console.WriteLine("\t\t\t\t\t\t\t------------------------");
                        Console.ForegroundColor= ConsoleColor.Yellow;
                        foreach (KeyValuePair<double, int> pair in scoreCounts4)
                        {
                            double score = pair.Key;
                            int count = pair.Value;
                            double ratio = (double)count / scores.Count * 100;
                            Console.Write($"{score,4:F1} | ");
                            for (int i = 0; i < ratio; i++)
                            {
                                Console.Write("█");
                            }
                            Console.WriteLine($" {ratio:F1}% ({count} diem)");
                        }
                        Console.ForegroundColor=ConsoleColor.Green;
                        Console.WriteLine("[!] An mot phim bat ki de tiep tuc");
                        Console.ReadKey();
                    }

                }
            }
        }
        public void XEMDIEM_XEMTHONGTINSINHVIEN()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                 SHOW YOUR MARK              ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║            SHOW YOUR INFORMATION            ║  
                                                             ╚═════════════════════════════════════════════╝",
            @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║               CHANGE PASSWORD               ║  
                                                             ╚═════════════════════════════════════════════╝"};

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        break;
                    }
                    else if (selectedIndex == 1)
                    {


                        Login login = new Login();
                        Console.WriteLine(login.username);
                        Console.Clear();
                        while (true)
                        {
                            Console.Clear();
                            danhSachDiem.Clear();
                            string tenfile = "danhsachdiem.txt";


                            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                            if (!File.Exists(tenfile))
                            {
                                Console.WriteLine($"Khong tim thay file {tenfile}");
                                Thread.Sleep(2000);
                                return;
                            }
                            using (var fs = new FileStream(tenfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            {
                                StreamReader streamReader = new StreamReader(fs);

                                string line;
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    string[] data = line.Split(',');

                                    switch (data[0])
                                    {
                                        case "Diem":
                                            Diem diem = new Diem()
                                            {
                                                MaSV = data[1],
                                                TenSV = data[2],
                                                MaMH = data[3],
                                                TenMH = data[4],
                                                DiemCC = float.Parse(data[5]),
                                                DiemKT = float.Parse(data[6]),
                                                DiemTH = float.Parse(data[7]),
                                                DiemTB = float.Parse(data[8]),
                                                DGHS = data[9]
                                            };
                                            danhSachDiem.Add(diem);
                                            break;
                                    }
                                }
                            }

                            Console.Clear();
                            danhSachSV.Clear();
                            string tenfile2 = "sinhvien.txt";


                            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                            if (!File.Exists(tenfile))
                            {
                                Console.WriteLine($"Khong tim thay file {tenfile}");
                                Thread.Sleep(2000);
                                return;
                            }
                            using (var fs = new FileStream(tenfile2, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            {
                                StreamReader streamReader = new StreamReader(fs);

                                string line;
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    string[] data = line.Split(',');

                                    switch (data[0])
                                    {
                                        case "SinhVien":
                                            SinhVien sv = new SinhVien()
                                            {
                                                MaSV = data[1],
                                                TenSV = data[2],
                                                gioitinh = data[3],
                                                tuoi = int.Parse(data[4]),
                                                Diachi = data[5],
                                                Lop = data[6],
                                                Khoa = data[7],
                                                Nganh = data[8],
                                                SDT = data[9],
                                                Email = data[10],
                                                NgayThangNamsinh = DateTime.Parse(data[11])
                                            };
                                            danhSachSV.Add(sv);
                                            break;
                                    }
                                }
                            }

                            string tenTep = "tamgv.txt";
                            string[] mangDuLieu = File.ReadAllLines(tenTep);


                            //Console.Write("Nhap ma sinh vien can tim: ");

                            string masinhvien3 = mangDuLieu[0];

                            List<SinhVien> ketQuaTimKiem = danhSachSV.FindAll(s => s.MaSV.Equals(masinhvien3, StringComparison.OrdinalIgnoreCase));
                            List<Diem> diemtimkiem = danhSachDiem.FindAll(s => s.MaSV.Equals(masinhvien3, StringComparison.OrdinalIgnoreCase));

                            if (ketQuaTimKiem.Count > 0)
                            {
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+----------------+");
                                Console.WriteLine("|Ma Sinh Vien| Ho ten           | Ma mon hoc   | Diem CC             |Diem KT  |Diem TH    |Diem TB   |Danh gia hs     |");
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+----------------+");

                                foreach (SinhVien sinhvien in ketQuaTimKiem)
                                {
                                    foreach (Diem diem in diemtimkiem)
                                    {
                                        Console.WriteLine($"| {sinhvien.MaSV,-11}| {sinhvien.TenSV,-17}| {diem.MaMH,-13}| {diem.DiemCC,-20}| {diem.DiemKT,-7} |{diem.DiemTH,-11}|{diem.DiemTB,-9} | {diem.DGHS,-11}  |");
                                    }
                                }
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+----------------+");
                            }
                            else
                            {
                                Console.WriteLine($"Khong tim thay sinh vien co ma sinh vien {masinhvien3} trong danh sach.");
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\t\t\t\t\t\t\t\t  [!] ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("E");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("xit");
                            Console.ForegroundColor = ConsoleColor.Green;
                            //An F de quen mat khau
                            if (Console.ReadKey(true).Key == ConsoleKey.E)
                            {
                                break;
                            }
                        }
                    }
                    else if (selectedIndex == 2)
                    {
                        while (true)
                        {
                            Console.Clear();
                            danhSachSV.Clear();
                            string tenfile2 = "sinhvien.txt";


                            // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                            if (!File.Exists(tenfile2))
                            {
                                Console.WriteLine($"Khong tim thay file {tenfile2}");
                                Thread.Sleep(2000);
                                return;
                            }
                            using (var fs = new FileStream(tenfile2, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            {
                                StreamReader streamReader = new StreamReader(fs);

                                string line;
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    string[] data = line.Split(',');

                                    switch (data[0])
                                    {
                                        case "SinhVien":
                                            SinhVien sv = new SinhVien()
                                            {
                                                MaSV = data[1],
                                                TenSV = data[2],
                                                gioitinh = data[3],
                                                tuoi = int.Parse(data[4]),
                                                Diachi = data[5],
                                                Lop = data[6],
                                                Khoa = data[7],
                                                Nganh = data[8],
                                                SDT = data[9],
                                                Email = data[10],
                                                NgayThangNamsinh = DateTime.Parse(data[11])
                                            };
                                            danhSachSV.Add(sv);
                                            break;
                                    }
                                }
                            }


                            string tenTep = "tamgv.txt";
                            string[] mangDuLieu = File.ReadAllLines(tenTep);


                            //Console.Write("Nhap ma sinh vien can tim: ");

                            string masinhvien34 = mangDuLieu[0];

                            List<SinhVien> svkqtk = danhSachSV.FindAll(s => s.MaSV.Equals(masinhvien34, StringComparison.OrdinalIgnoreCase));

                            if (svkqtk.Count > 0)
                            {
                                Console.WriteLine("Danh sach cac sinh vien:");
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+---------------------+------------------------+");
                                Console.WriteLine("|Ma Sinh Vien| Ho ten           | Gioi tinh    | Dia chi             | Khoa    | Nganh     | Tuoi     | SDT        | Email               | Ngay/thang/nam sinh    |");
                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+---------------------+------------------------+");
                                foreach (SinhVien sv in svkqtk)
                                {

                                    Console.WriteLine($"| {sv.MaSV,-11}| {sv.TenSV,-17}| {sv.gioitinh,-13}| {sv.Diachi,-20}| {sv.Khoa,-7} |{sv.Nganh,-11}|{sv.tuoi,-9} | {sv.SDT,-11}|{sv.Email,-18} | {sv.NgayThangNamsinh.Date,-20}   |");
                                }

                                Console.WriteLine("+------------+------------------+--------------+---------------------+---------+-----------+----------+------------+---------------------+------------------------+");

                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\t\t\t\t\t\t\t\t  [!] ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("E");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("xit");
                            Console.ForegroundColor = ConsoleColor.Green;
                            //An F de quen mat khau
                            if (Console.ReadKey(true).Key == ConsoleKey.E)
                            {
                                break;
                            }
                        }
                    }
                    else if (selectedIndex == 3)
                    {
                        while(true)
                        {     
                        Console.Clear();
                        string tenTep = "tamgv.txt";
                        string[] mangDuLieu = File.ReadAllLines(tenTep);


                        
                        string username = mangDuLieu[0];

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("\t\t\t\t\t\tNhap mat khau hien tai: ");
                        string password = Console.ReadLine();

                        string filepath = "danhsachtaikhoanmatkhausv.txt";


                        // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                        if (!File.Exists(filepath))
                        {
                            Console.WriteLine($"Khong tim thay file {filepath}");
                            Thread.Sleep(2000);
                            return;
                        }
                        using (var fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            StreamReader streamReader = new StreamReader(fs);

                            string line;
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                string[] data = line.Split(',');

                                TK_MK taikhoan_mk_sv = new TK_MK();
                                {
                                    taikhoan_mk_sv.taikhoanhs = data[0];
                                    taikhoan_mk_sv.matkhauhs = data[1];
                                };
                                danhsachtk_mk2.Add(taikhoan_mk_sv);
                            }
                        }

                        string[] lines = System.IO.File.ReadAllLines(filepath);
                            for (int i = 0; i < lines.Length; i++)
                            {
                                string[] field = lines[i].Split(",");
                                if (field[0].Equals(username))
                                {
                                    if (field[1].Equals(password))
                                    {
                                        Console.Write("\t\t\t\t\t\tNhap mat khau moi: ");
                                        string newPassword = Console.ReadLine();
                                        Console.Write("\t\t\t\t\t\tXac nhan mat khau moi: ");
                                        string confirmPassword = Console.ReadLine();
                                        if (newPassword != confirmPassword)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("\t\t\t\t\t\tMat khau xac nhan khong trung khop");
                                            break;
                                        }
                                        else
                                        {

                                            TK_MK taikhoanmkcheck = danhsachtk_mk2.Find(s => s.taikhoanhs.Equals(username, StringComparison.OrdinalIgnoreCase));
                                            if (taikhoanmkcheck != null)
                                            {

                                                taikhoanmkcheck.matkhauhs = newPassword;
                                            }
                                            string tenTep2 = "danhsachtaikhoanmatkhausv.txt";

                                            try
                                            {
                                                using (StreamWriter writer = new StreamWriter(tenTep2))
                                                {
                                                    foreach (TK_MK taikhoan_matkhausave in danhsachtk_mk2)
                                                    {
                                                        writer.WriteLine($"{taikhoan_matkhausave.taikhoanhs},{taikhoan_matkhausave.matkhauhs}");
                                                    }
                                                }
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\t\t\t\t\t\t[!]Doi mat khau cua ban thanh cong !");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                            }
                                            catch (Exception ex)
                                            {
                                                Console.WriteLine($"Loi khi ghi mat khau vao tep: {ex.Message}");
                                            }
                                            Console.ReadLine();
                                            break;

                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine();
                                        Console.WriteLine("\t\t\t\t\t\t[!] Sai mat khau cu");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                    }
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("\t\t\t\t\t\t\t\t  [!] Enter: Nhap lai");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\t\t\t\t\t\t\t\t  [!] ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("E");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("xit");
                            Console.ForegroundColor = ConsoleColor.Green;
                            //An F de quen mat khau
                            if (Console.ReadKey(true).Key == ConsoleKey.E)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        public void QUANLITAIKHOANMK()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║      MANAGE TEACHERS USERNAME-PASSWORD      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║      MANAGE STUDENTS USERNAME-PASSWORD      ║  
                                                             ╚═════════════════════════════════════════════╝" };

            while (true)
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.Write(options[i].PadRight(Console.WindowWidth - options.Length));
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (selectedIndex == 0)
                    {
                        break;
                    }
                    else if (selectedIndex == 1)
                    {

                        Console.CursorVisible = false;
                        ConsoleKeyInfo keyInfo1;
                        int selectedIndex2 = 0;
                        string[] option = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║         READ LIST USERNAME-PASSWORD     ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║           ADD USERNAME-PASSWORD         ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║          DELETE USERNAME-PASSWORD       ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║           EDIT USERNAME-PASSWORD        ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║         SAVE LIST USERNAME-PASSWORD     ▼   ║  
                                                             ╚═════════════════════════════════════════════╝" };

                        while (true)
                        {
                            Console.Clear();
                            for (int b = 0; b < option.Length; b++)
                            {
                                if (b == selectedIndex2)
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                Console.Write(option[b].PadRight(Console.WindowWidth - option.Length));
                            }

                            keyInfo1 = Console.ReadKey(true);

                            if (keyInfo1.Key == ConsoleKey.UpArrow)
                            {
                                selectedIndex2--;
                                if (selectedIndex2 < 0)
                                {
                                    selectedIndex2 = option.Length - 1;
                                }
                            }
                            else if (keyInfo1.Key == ConsoleKey.DownArrow)
                            {
                                selectedIndex2++;
                                if (selectedIndex2 == option.Length)
                                {
                                    selectedIndex2 = 0;
                                }
                            }
                            else if (keyInfo1.Key == ConsoleKey.Enter)
                            {
                                if (selectedIndex2 == 0)
                                {
                                    return;
                                }
                                else if (selectedIndex2 == 1)
                                {

                                    Console.Clear();
                                    Console.WriteLine(">>>1. Doc danh sach tai khoan-mat khau tu tep");
                                    Console.WriteLine(">>>2. Doc danh sach tai khoan-mat khau tu SQL Server");
                                    Console.WriteLine(">>>0. Thoat chuong trinh");
                                    Console.Write(">>>>Nhap lua chon cua ban: ");
                                    int chon = int.Parse(Console.ReadLine());
                                    if (chon == 1)
                                    {
                                        Console.Clear();
                                        danhsachtk_mk.Clear();
                                        string tenfile = "danhsachtaikhoanmatkhaugv.txt";


                                        // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                                        if (!File.Exists(tenfile))
                                        {
                                            Console.WriteLine($"Khong tim thay file {tenfile}");
                                            Thread.Sleep(2000);
                                            return;
                                        }
                                        using (var fs = new FileStream(tenfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                        {
                                            StreamReader streamReader = new StreamReader(fs);

                                            string line;
                                            while ((line = streamReader.ReadLine()) != null)
                                            {
                                                string[] data = line.Split(',');

                                                TK_MK taikhoan_matkhau = new TK_MK();
                                                {
                                                    taikhoan_matkhau.taikhoangv = data[0];
                                                    taikhoan_matkhau.matkhaugv = data[1];
                                                    taikhoan_matkhau.emailgv= data[2];
                                                }
                                                danhsachtk_mk.Add(taikhoan_matkhau);

                                            }
                                        }
                                        Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach thanh cong");
                                        Thread.Sleep(3000);

                                        Console.Clear();
                                        danhsachgiaovien.Clear();
                                        string tenfile4 = "danhsachgiaovien.txt";


                                        // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                                        if (!File.Exists(tenfile4))
                                        {
                                            Console.WriteLine($"Khong tim thay file {tenfile4}");
                                            Thread.Sleep(2000);
                                            return;
                                        }
                                        using (var fs = new FileStream(tenfile4, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                        {
                                            StreamReader streamReader2 = new StreamReader(fs);

                                            string line;
                                            while ((line = streamReader2.ReadLine()) != null)
                                            {
                                                string[] data = line.Split(',');

                                                switch (data[0])
                                                {
                                                    case "GiaoVien":
                                                        giaovien gv = new giaovien()
                                                        {
                                                            magv = data[1],
                                                            tengv = data[2],
                                                            makhoa = data[3],
                                                            tenkhoa = data[4],
                                                            mabm = data[5],
                                                            tenbm = data[6],
                                                            cocnlopkhong = bool.Parse(data[7]),
                                                            malopchunhiem = data[8],
                                                            sodienthoai = data[9],
                                                            email = data[10],
                                                            diachi = data[11]
                                                        };
                                                        danhsachgiaovien.Add(gv);
                                                        break;
                                                }
                                            }

                                        }
                                        Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach giao vien thanh cong");
                                        Thread.Sleep(2000);

                                    }
                                    else if (chon == 2)
                                    {
                                        Console.Clear();
                                        string connectionString = @"Data Source=NGUYENTIENDAT\MSSQLSERVER01;Initial Catalog=DIEMDOANCK1;Integrated Security=True";
                                        string query2 = "SELECT * FROM TaiKhoan_MK";

                                        using (SqlConnection connection = new SqlConnection(connectionString))
                                        {
                                            SqlCommand command2 = new SqlCommand(query2, connection);
                                            //connection.Open();
                                            SqlDataReader sqlDataReaderreader2 = command2.ExecuteReader();
                                            while (sqlDataReaderreader2.Read())
                                            {
                                                TK_MK taikhoan_mk = new TK_MK();
                                                taikhoan_mk.taikhoangv = sqlDataReaderreader2["tkgv"].ToString();
                                                taikhoan_mk.matkhaugv = sqlDataReaderreader2["mkgv"].ToString();
                                                danhsachtk_mk.Add(taikhoan_mk);
                                            }
                                            sqlDataReaderreader2.Close();
                                            Console.WriteLine("[!] Doc du lieu tu SQL Server thanh cong");
                                            Thread.Sleep(3000);
                                        }
                                    }
                                    else if (chon == 0)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Lua chon khong hop le");
                                        Thread.Sleep(2000);
                                    }

                                }
                                else if (selectedIndex2 == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Nhap thong tin tai khoan mat khau moi");

                                    Console.Write("Hay nhap tai khoan-mat khau giao vien ban can them: ");
                                    int sotk = int.Parse(Console.ReadLine());

                                    for (int i = 0; i < sotk; i++)
                                    {
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine("+------------+------------------+");
                                        Console.WriteLine("|Ma giao vien| Ho ten           |");
                                        Console.WriteLine("+------------+------------------+");
                                        foreach (giaovien gv in danhsachgiaovien)
                                        {

                                            Console.WriteLine($"| {gv.magv,-11}| {gv.tengv,-17}|");
                                        }
                                        Console.WriteLine("+------------+------------------+");

                                        TK_MK taikhoan_matkhau = new TK_MK();
                                        Console.WriteLine("Hay nhap thong tin tai khoan-mat khau cho giao vien thu {0}", i + 1);
                                        Console.Write(">>>Ma giao vien: ");
                                        string Magv = Console.ReadLine();

                                        bool tonTai = danhsachgiaovien.Any(gv => gv.magv == Magv);
                                        if (tonTai)
                                        {
                                            taikhoan_matkhau.taikhoangv = Magv;
                                            //Nhap mat khau cho tai khoan do
                                            Console.Write("Mat khau cua giao vien: ");
                                            string mkgv = Console.ReadLine();
                                            while (true)
                                            {
                                                if (string.IsNullOrEmpty(mkgv))
                                                {
                                                    Console.WriteLine("Mat khau cua giao vien khong duoc de trong. Vui long nhap lai.");
                                                    Console.Write("Mat khau cua giao vien: ");
                                                    mkgv = Console.ReadLine();
                                                }
                                                else if (mkgv.Length < 6)
                                                {
                                                    Console.WriteLine("Mat khau cua giao vien phai co it nhat 6 ky tu. Vui long nhap lai.");
                                                    Console.Write("Mat khau cua giao vien: ");
                                                    mkgv = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    taikhoan_matkhau.matkhaugv = mkgv;
                                                    break;
                                                }
                                            }
                                            Console.Write(">>>Email dang nhap sinh vien: ");
                                            string email = Console.ReadLine();
                                            email = "nguyendatdtqn@gmail.com";
                                            taikhoan_matkhau.emailgv = email;

                                        }
                                        else
                                        {
                                            Console.WriteLine($"Ma giao vien {Magv} khong ton tai trong danh sach giao vien.");
                                            
                                        }

                                        danhsachtk_mk.Add(taikhoan_matkhau);
                                        Console.WriteLine($"[!] Da them {danhsachtk_mk.Count} tai khoan giao vien.");
                                        Console.WriteLine("[!] An mot phim bat ki de tiep tuc");
                                        Console.ReadLine();
                                    }

                                }
                                else if (selectedIndex2 == 3)
                                {
                                    Console.SetWindowSize(200, 40);
                                    Console.Clear();

                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap ma giao vien can xoa:                        ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("+------------+------------------+");
                                    Console.WriteLine("|Tai khoan   | Mat khau         |");
                                    Console.WriteLine("+------------+------------------+");

                                    foreach (TK_MK tkmk in danhsachtk_mk)
                                    {

                                        Console.WriteLine($"| {tkmk.taikhoangv,-11}| {tkmk.matkhaugv,-17}|");
                                    }
                                    Console.WriteLine("+------------+------------------+");
                                    Console.SetCursorPosition(85, 3);
                                    string tkgv = Console.ReadLine();

                                    // Kiem tra xem ma giao vien co ton tai hay khong
                                    TK_MK tkmk2 = danhsachtk_mk.FirstOrDefault(s => s.taikhoangv == tkgv);
                                    if (tkmk2 == null)
                                    {
                                        Console.WriteLine($"Khong tim thay giao vien voi ma so {tkmk2}");
                                        return;
                                    }

                                    // Xoa tai khoan giao vien khoi danh sach
                                    danhsachtk_mk.Remove(tkmk2);

                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine("+------------+------------------+");
                                    Console.WriteLine("|Tai khoan   | Mat khau         |");
                                    Console.WriteLine("+------------+------------------+");
                                    foreach (TK_MK tkmk in danhsachtk_mk)
                                    {

                                        Console.WriteLine($"| {tkmk.taikhoangv,-11}| {tkmk.matkhaugv,-17}|");
                                    }
                                    Console.WriteLine("+------------+------------------+");
                                    Console.WriteLine();
                                    //An esc  de thoat
                                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                                    {
                                        break;
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Bam mot phim bat ki de tro ve man hinh chinh!");
                                    Console.ReadKey();
                                }

                                else if (selectedIndex2 == 4)
                                {
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.SetWindowSize(200, 40);
                                        Console.Clear();

                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap tai khoan giao vien can sua:                 ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("+------------+------------------+------------------+");
                                        Console.WriteLine("|Tai khoan   |Mat khau          |  Email           |");
                                        Console.WriteLine("+------------+------------------+------------------+");

                                        foreach (TK_MK taikhoan_matkhau in danhsachtk_mk)
                                        {

                                            Console.WriteLine($"| {taikhoan_matkhau.taikhoangv,-11}| {taikhoan_matkhau.matkhaugv,-17}| {taikhoan_matkhau.emailgv,-17}|");
                                        }
                                        Console.WriteLine("+------------+------------------+------------------+");
                                        Console.SetCursorPosition(85, 3);
                                        string tk_mk = Console.ReadLine();

                                        TK_MK taikhoan_matkhaucheck = danhsachtk_mk.Find(s => s.taikhoangv.Equals(tk_mk, StringComparison.OrdinalIgnoreCase));

                                        if (taikhoan_matkhaucheck != null)
                                        {

                                            Console.SetWindowSize(200, 40);
                                            Console.Clear();

                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║      THONG TIN TAI KHOAN MAT KHAU CAN SUA         ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("+------------+------------------+------------------+");
                                            Console.WriteLine("|Tai khoan   |Mat khau          |  Email           |");
                                            Console.WriteLine("+------------+------------------+------------------+");

                                            {

                                                Console.WriteLine($"| {taikhoan_matkhaucheck.taikhoangv,-11}| {taikhoan_matkhaucheck.matkhaugv,-17}| {taikhoan_matkhaucheck.emailgv,-17}|");
                                            }
                                            Console.WriteLine("+------------+------------------+------------------+");



                                            Console.WriteLine("Nhap thong tin mat khau cho giao vien");

                                            Console.Write("Mat khau cua giao vien: ");
                                            string mkgv = Console.ReadLine();
                                            while (true)
                                            {
                                                if (string.IsNullOrEmpty(mkgv))
                                                {
                                                    Console.WriteLine("Mat khau cua giao vien khong duoc de trong. Vui long nhap lai.");
                                                    Console.Write("Mat khau cua giao vien: ");
                                                    mkgv = Console.ReadLine();
                                                }
                                                else if (mkgv.Length < 6)
                                                {
                                                    Console.WriteLine("Mat khau cua giao vien phai co it nhat 6 ky tu. Vui long nhap lai.");
                                                    Console.Write("Mat khau cua giao vien: ");
                                                    mkgv = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    taikhoan_matkhaucheck.matkhaugv = mkgv;
                                                    break;
                                                }
                                                
                                            }
                                            Console.Write(">>>Email dang nhap: ");
                                            string email = Console.ReadLine();
                                            while (true)
                                            {
                                                if (string.IsNullOrEmpty(email))
                                                {
                                                    Console.WriteLine("Email khong duoc de trong. Vui long nhap lai");
                                                    Console.Write("Email: ");
                                                    email = Console.ReadLine();
                                                }
                                                else if (!email.Contains("@") || !email.Contains("."))
                                                {
                                                    Console.WriteLine("Email khong hop le. Vui long nhap lai");
                                                    Console.Write("Email: ");
                                                    email = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    taikhoan_matkhaucheck.emailgv = email;
                                                    break;
                                                }
                                            }
                                            danhsachtk_mk.Add(taikhoan_matkhaucheck);

                                            Console.WriteLine($"Giao vien co ma {taikhoan_matkhaucheck.taikhoangv} da duoc sua mat khau.");
                                            Console.WriteLine();
                                            Console.WriteLine("Bam mot phim bat ki de tiep tuc!");
                                            Console.ReadKey();
                                            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (selectedIndex2 == 5)
                                {
                                    Console.Clear();
                                    string tenTep2 = "danhsachtaikhoanmatkhaugv.txt";

                                    try
                                    {
                                        using (StreamWriter writer = new StreamWriter(tenTep2))
                                        {
                                            foreach (TK_MK taikhoan_matkhau in danhsachtk_mk)
                                            {
                                                writer.WriteLine($"{taikhoan_matkhau.taikhoangv},{taikhoan_matkhau.matkhaugv},{taikhoan_matkhau.emailgv}");
                                            }
                                        }

                                        Console.WriteLine($"Da ghi danh sach sach tai khoan-mat khau giao vien vao tep {tenTep2} thanh cong.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Loi khi ghi danh sach giao vien vao tep: {ex.Message}");
                                    }
                                    Console.WriteLine("[!] Nhan phim bam phim bat ki");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                    else if (selectedIndex == 2)
                    {
                        Console.CursorVisible = false;
                        ConsoleKeyInfo keyInfo1;
                        int selectedIndex2 = 0;
                        string[] option = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║        READ LISTS USERNAME-PASSWORD     ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║           ADD USERNAME-PASSWORD         ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║          DELETE USERNAME-PASSWORD       ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║           EDIT USERNAME-PASSWORD        ▼   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║          SAVE LIST USERNAME-PASSWORD    ▼   ║  
                                                             ╚═════════════════════════════════════════════╝" };

                        while (true)
                        {
                            Console.Clear();
                            for (int b = 0; b < option.Length; b++)
                            {
                                if (b == selectedIndex2)
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                                Console.Write(option[b].PadRight(Console.WindowWidth - option.Length));
                            }

                            keyInfo1 = Console.ReadKey(true);

                            if (keyInfo1.Key == ConsoleKey.UpArrow)
                            {
                                selectedIndex2--;
                                if (selectedIndex2 < 0)
                                {
                                    selectedIndex2 = option.Length - 1;
                                }
                            }
                            else if (keyInfo1.Key == ConsoleKey.DownArrow)
                            {
                                selectedIndex2++;
                                if (selectedIndex2 == option.Length)
                                {
                                    selectedIndex2 = 0;
                                }
                            }

                            else if (keyInfo1.Key == ConsoleKey.Enter)
                            {
                                if (selectedIndex2 == 0)
                                {
                                    return;
                                }
                                else if (selectedIndex2 == 1)
                                {

                                    Console.Clear();
                                    Console.WriteLine(">>>1. Doc danh sach tai khoan-mat khau tu tep");
                                    Console.WriteLine(">>>2. Doc danh sach tai khoan-mat khau tu SQL Server");
                                    Console.WriteLine(">>>0. Thoat chuong trinh");
                                    Console.Write(">>>>Nhap lua chon cua ban: ");
                                    int chon = int.Parse(Console.ReadLine());
                                    if (chon == 1)
                                    {
                                        Console.Clear();
                                        danhsachtk_mk2.Clear();
                                        string tenfile = "danhsachtaikhoanmatkhausv.txt";


                                        // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                                        if (!File.Exists(tenfile))
                                        {
                                            Console.WriteLine($"Khong tim thay file {tenfile}");
                                            Thread.Sleep(2000);
                                            return;
                                        }
                                        using (var fs = new FileStream(tenfile, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                        {
                                            StreamReader streamReader = new StreamReader(fs);

                                            string line;
                                            while ((line = streamReader.ReadLine()) != null)
                                            {
                                                string[] data = line.Split(',');

                                                TK_MK taikhoan_matkhau = new TK_MK();
                                                {
                                                    taikhoan_matkhau.taikhoanhs = data[0];
                                                    taikhoan_matkhau.matkhauhs = data[1];
                                                    taikhoan_matkhau.emailhs = data[2];

                                                }
                                                danhsachtk_mk2.Add(taikhoan_matkhau);
                                                break;
                                            }

                                        }

                                        Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach thanh cong");
                                        Thread.Sleep(3000);
                                        Console.Clear();
                                        danhSachSV.Clear();
                                        string tenfile2 = "sinhvien.txt";


                                        // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                                        if (!File.Exists(tenfile))
                                        {
                                            Console.WriteLine($"Khong tim thay file {tenfile2}");
                                            Thread.Sleep(2000);
                                            return;
                                        }
                                        using (var fs = new FileStream(tenfile2, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                                        {
                                            StreamReader streamReader = new StreamReader(fs);

                                            string line;
                                            while ((line = streamReader.ReadLine()) != null)
                                            {
                                                string[] data = line.Split(',');

                                                switch (data[0])
                                                {
                                                    case "SinhVien":
                                                        SinhVien sv = new SinhVien()
                                                        {
                                                            MaSV = data[1],
                                                            TenSV = data[2],
                                                            gioitinh = data[3],
                                                            tuoi = int.Parse(data[4]),
                                                            Diachi = data[5],
                                                            Lop = data[6],
                                                            Khoa = data[7],
                                                            Nganh = data[8],
                                                            SDT = data[9],
                                                            Email = data[10],
                                                            NgayThangNamsinh = DateTime.Parse(data[11])
                                                        };
                                                        danhSachSV.Add(sv);
                                                        break;
                                                }
                                            }

                                        }
                                        Console.WriteLine("Doc thong tin tu tep va ghi vao danh sach sinh vien thanh cong");
                                        Thread.Sleep(2000);
                                    }
                                    else if (chon == 2)
                                    {
                                        Console.Clear();
                                        string connectionString = @"Data Source=NGUYENTIENDAT\MSSQLSERVER01;Initial Catalog=DIEMDOANCK1;Integrated Security=True";
                                        string query2 = "SELECT * FROM TaiKhoan_MK";

                                        using (SqlConnection connection = new SqlConnection(connectionString))
                                        {
                                            SqlCommand command2 = new SqlCommand(query2, connection);
                                            //connection.Open();
                                            SqlDataReader sqlDataReaderreader2 = command2.ExecuteReader();
                                            while (sqlDataReaderreader2.Read())
                                            {
                                                TK_MK taikhoan_mk = new TK_MK();
                                                taikhoan_mk.taikhoanhs = sqlDataReaderreader2["tkhs"].ToString();
                                                taikhoan_mk.matkhauhs = sqlDataReaderreader2["mkhs"].ToString();
                                                taikhoan_mk.emailhs = sqlDataReaderreader2["emailhs"].ToString();
                                                danhsachtk_mk2.Add(taikhoan_mk);
                                            }
                                            sqlDataReaderreader2.Close();
                                            Console.WriteLine("[!] Doc du lieu tu SQL Server thanh cong");
                                            Thread.Sleep(3000);
                                        }
                                    }
                                    else if (chon == 0)
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Lua chon khong hop le");
                                        Thread.Sleep(2000);
                                    }

                                }
                                else if (selectedIndex2 == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Nhap thong tin tai khoan mat khau moi");

                                    Console.Write("Hay nhap tai khoan-mat khau sinh vien ban can them: ");
                                    int somonhoc = int.Parse(Console.ReadLine());

                                    for (int i = 0; i < somonhoc; i++)
                                    {
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine("+------------+------------------+");
                                        Console.WriteLine("|Ma sinh vien| Ho ten           |");
                                        Console.WriteLine("+------------+------------------+");
                                        foreach (SinhVien sv in danhSachSV)
                                        {

                                            Console.WriteLine($"| {sv.MaSV,-11}| {sv.TenSV,-17}|");
                                        }
                                        Console.WriteLine("+------------+------------------+");

                                        TK_MK taikhoan_matkhau2 = new TK_MK();
                                        Console.WriteLine("Hay nhap thong tin tai khoan-mat khau cho sinh vien thu {0}", i + 1);
                                        Console.Write(">>>Ma sinh vien: ");
                                        string masv = Console.ReadLine();

                                        bool tonTai = danhSachSV.Any(sv => sv.MaSV == masv);
                                        if (tonTai)
                                        {
                                            taikhoan_matkhau2.taikhoanhs = masv;
                                            //Nhap mat khau cho tai khoan do
                                            Console.Write("Mat khau cua sinh vien: ");
                                            string mkgv = Console.ReadLine();
                                            while (true)
                                            {
                                                if (string.IsNullOrEmpty(mkgv))
                                                {
                                                    Console.WriteLine("Mat khau cua sinh vien khong duoc de trong. Vui long nhap lai.");
                                                    Console.Write("Mat khau cua sinh vien: ");
                                                    mkgv = Console.ReadLine();
                                                }
                                                else if (mkgv.Length < 6)
                                                {
                                                    Console.WriteLine("Mat khau cua giao vien phai co it nhat 6 ky tu. Vui long nhap lai.");
                                                    Console.Write("Mat khau cua sinh vien: ");
                                                    mkgv = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    taikhoan_matkhau2.matkhauhs = mkgv;
                                                    break;
                                                }
                                            }
                                            Console.Write(">>>Email dang nhap sinh vien: ");
                                            string email = Console.ReadLine();
                                            email = "nguyendatdtqn@gmail.com";
                                            taikhoan_matkhau2.emailhs = email;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Ma sinh vien {masv} khong ton tai trong danh sach sinh vien.");
                                            
                                        }
                                        danhsachtk_mk2.Add(taikhoan_matkhau2);
                                        Console.WriteLine($"[!] Da them tai khoan voi {masv} thanh cong");
                                        Console.WriteLine("[!] An mot phim bat ki de tiep tuc");
                                        Console.ReadLine();
                                    }
                                }
                                else if (selectedIndex2 == 3)
                                {
                                    Console.SetWindowSize(200, 40);
                                    Console.Clear();

                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap tai khoan can xoa:                           ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.WriteLine("+------------+------------------+------------------+");
                                    Console.WriteLine("|Tai khoan   | Mat khau         | Email            |");
                                    Console.WriteLine("+------------+------------------+------------------+");

                                    foreach (TK_MK tkmk in danhsachtk_mk2)
                                    {

                                        Console.WriteLine($"| {tkmk.taikhoanhs,-11}| {tkmk.matkhauhs,-17}| {tkmk.emailhs,-17}|");
                                    }
                                    Console.WriteLine("+------------+------------------+------------------+");
                                    Console.SetCursorPosition(85, 3);
                                    string tkhs = Console.ReadLine();

                                    // Kiem tra xem ma giao vien co ton tai hay khong
                                    TK_MK tkmk2 = danhsachtk_mk2.FirstOrDefault(s => s.taikhoanhs == tkhs);
                                    if (tkmk2 == null)
                                    {
                                        Console.WriteLine($"Khong tim thay sinh vien voi ma so {tkmk2}");
                                        return;
                                    }

                                    // Xoa tai khoan giao vien khoi danh sach
                                    danhsachtk_mk2.Remove(tkmk2);

                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine("+------------+------------------+------------------+");
                                    Console.WriteLine("|Tai khoan   | Mat khau         | Email            |");
                                    Console.WriteLine("+------------+------------------+------------------+");
                                    foreach (TK_MK tkmk in danhsachtk_mk2)
                                    {

                                        Console.WriteLine($"| {tkmk.taikhoanhs,-11}| {tkmk.matkhauhs,-17}| {tkmk.emailhs,-17}|");
                                    }
                                    Console.WriteLine("+------------+------------------+------------------+");
                                    Console.WriteLine();
                                    //An esc  de thoat
                                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                                    {
                                        break;
                                    }

                                    Console.WriteLine();
                                    Console.WriteLine("Bam mot phim bat ki de tro ve man hinh chinh!");
                                    Console.ReadKey();
                                }
                                else if (selectedIndex2 == 4)
                                {
                                    Console.Clear();
                                    while (true)
                                    {
                                        Console.SetWindowSize(200, 40);
                                        Console.Clear();

                                        Console.WriteLine();
                                        Console.WriteLine();
                                        Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║ Nhap tai khoan sinh vien can sua:                 ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("+------------+------------------+------------------+");
                                        Console.WriteLine("|Tai khoan   |Mat khau          | Email            |");
                                        Console.WriteLine("+------------+------------------+------------------+");

                                        foreach (TK_MK taikhoan_matkhau in danhsachtk_mk2)
                                        {

                                            Console.WriteLine($"| {taikhoan_matkhau.taikhoanhs,-11}| {taikhoan_matkhau.matkhauhs,-17}| {taikhoan_matkhau.emailhs,-17}");
                                        }
                                        Console.WriteLine("+------------+------------------+------------------+");
                                        Console.SetCursorPosition(85, 3);
                                        string tk_mk = Console.ReadLine();

                                        TK_MK taikhoan_matkhaucheck = danhsachtk_mk2.Find(s => s.taikhoanhs.Equals(tk_mk, StringComparison.OrdinalIgnoreCase));

                                        if (taikhoan_matkhaucheck != null)
                                        {

                                            Console.SetWindowSize(200, 40);
                                            Console.Clear();

                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.Write(@"                                                      ╔═══════════════════════════════════════════════════╗      
                                                      ║      THONG TIN TAI KHOAN MAT KHAU CAN SUA         ║                                                              
                                                      ╚═══════════════════════════════════════════════════╝                                                           ");
                                            Console.WriteLine();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\t\t\t\t\t\t[!]An phim ESC de thoat");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("+------------+------------------+------------------+");
                                            Console.WriteLine("|Tai khoan   |Mat khau          | Email            |");
                                            Console.WriteLine("+------------+------------------+------------------+");
                                            {

                                                Console.WriteLine($"| {taikhoan_matkhaucheck.taikhoanhs,-11}| {taikhoan_matkhaucheck.matkhauhs,-17}| {taikhoan_matkhaucheck.emailhs,-17}|");
                                            }
                                            Console.WriteLine("+------------+------------------+------------------+");



                                            Console.WriteLine("Nhap thong tin mat khau cho sinh vien");

                                            Console.Write("Mat khau cua sinh vien: ");
                                            string mkhs = Console.ReadLine();
                                            while (true)
                                            {
                                                if (string.IsNullOrEmpty(mkhs))
                                                {
                                                    Console.WriteLine("Mat khau cua giao vien khong duoc de trong. Vui long nhap lai.");
                                                    Console.Write("Mat khau cua giao vien: ");
                                                    mkhs = Console.ReadLine();
                                                }
                                                else if (mkhs.Length < 6)
                                                {
                                                    Console.WriteLine("Mat khau cua giao vien phai co it nhat 6 ky tu. Vui long nhap lai.");
                                                    Console.Write("Mat khau cua giao vien: ");
                                                    mkhs = Console.ReadLine();
                                                }
                                                else
                                                {
                                                    taikhoan_matkhaucheck.matkhauhs = mkhs;
                                                    break;
                                                }
                                            }


                                            danhsachtk_mk2.Add(taikhoan_matkhaucheck);

                                            Console.WriteLine($"Sinh vien co ma {taikhoan_matkhaucheck.taikhoanhs} da duoc sua mat khau.");
                                            Console.WriteLine();
                                            Console.WriteLine("Bam mot phim bat ki de tiep tuc!");
                                            Console.ReadKey();
                                            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (selectedIndex2 == 5)
                                {
                                    Console.Clear();
                                    string tenTep2 = "danhsachtaikhoanmatkhausv.txt";

                                    try
                                    {
                                        using (StreamWriter writer = new StreamWriter(tenTep2))
                                        {
                                            foreach (TK_MK taikhoan_matkhau in danhsachtk_mk2)
                                            {
                                                writer.WriteLine($"{taikhoan_matkhau.taikhoanhs},{taikhoan_matkhau.matkhauhs},{taikhoan_matkhau.emailhs}");
                                            }
                                        }

                                        Console.WriteLine($"Da ghi danh sach sach tai khoan-mat khau sinh vien vao tep {tenTep2} thanh cong.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Loi khi ghi danh sach sinh vien vao tep: {ex.Message}");
                                    }
                                    Console.WriteLine("[!] An mot phim bat ki de tiep tuc");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                }
            }
        }
        public void DOITK_MK_GV()
        {
            while (true)
            {
                Console.Clear();
                string tenTep = "tamgv.txt";
                string[] mangDuLieu = File.ReadAllLines(tenTep);



                string username = mangDuLieu[0];

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("\t\t\t\t\t\tNhap mat khau hien tai: ");
                string password = Console.ReadLine();

                string filepath = "danhsachtaikhoanmatkhaugv.txt";


                // Kiểm tra đường dẫn tệp tin có tồn tại hay không
                if (!File.Exists(filepath))
                {
                    Console.WriteLine($"Khong tim thay file {filepath}");
                    Thread.Sleep(2000);
                    return;
                }
                using (var fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    StreamReader streamReader = new StreamReader(fs);

                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');

                        TK_MK taikhoan_mk_sv = new TK_MK();
                        {
                            taikhoan_mk_sv.taikhoangv = data[0];
                            taikhoan_mk_sv.matkhaugv = data[1];
                        };
                        danhsachtk_mk.Add(taikhoan_mk_sv);
                    }
                }

                string[] lines = System.IO.File.ReadAllLines(filepath);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] field = lines[i].Split(",");
                    if (field[0].Equals(username))
                    {
                        if (field[1].Equals(password))
                        {
                            Console.Write("\t\t\t\t\t\tNhap mat khau moi: ");
                            string newPassword = Console.ReadLine();
                            Console.Write("\t\t\t\t\t\tXac nhan mat khau moi: ");
                            string confirmPassword = Console.ReadLine();
                            if (newPassword != confirmPassword)
                            {
                                Console.WriteLine("\t\t\t\t\t\tMat khau xac nhan khong trung khop");
                                return;
                            }
                            else
                            {

                                TK_MK taikhoanmkcheck = danhsachtk_mk.Find(s => s.taikhoangv.Equals(username, StringComparison.OrdinalIgnoreCase));
                                if (taikhoanmkcheck != null)
                                {

                                    taikhoanmkcheck.matkhauhs = newPassword;
                                }
                                string tenTep2 = "danhsachtaikhoanmatkhausv.txt";

                                try
                                {
                                    using (StreamWriter writer = new StreamWriter(tenTep2))
                                    {
                                        foreach (TK_MK taikhoan_matkhausave in danhsachtk_mk)
                                        {
                                            writer.WriteLine($"{taikhoan_matkhausave.taikhoangv},{taikhoan_matkhausave.matkhaugv}");
                                        }
                                    }
                                    Console.WriteLine($"Doi mat khau cua ban thanh cong !");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Loi khi ghi danh sach sinh vien vao tep: {ex.Message}");
                                }
                                Console.WriteLine("An mot phim bat ki de tiep tuc");
                                Console.ReadLine();
                                break;

                            }
                        }
                        else
                        {
                            Console.WriteLine("Sai mat khau cu");
                            break;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\t\t\t\t\t\t\t\t  [!] ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("E");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("xit");
                Console.ForegroundColor = ConsoleColor.Green;
                //An F de quen mat khau
                if (Console.ReadKey(true).Key == ConsoleKey.E)
                {
                    break;
                }
            }
        }
    }
}
