using QLSV1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.ComponentModel;
using System.Net.Mail;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace qlisv1
{
    internal class Login
    {
        public string username;
        public string password;
        public string magvlogin;
        public string masvlogin;
        public string matkhaugv;
        public string matkhauhs;
        public string usernamecheck;
        public string[] tk_mk_list_arr;
        public Role role;
        public List<Login> loginlist { get; } = new List<Login>();

        public void Show()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.WindowLeft = Console.WindowTop = 0;
            Console.Clear();
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo;
            int selectedIndex = 0;
            Console.WriteLine();
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            string[] options = {
    "\t\t\t\t\t\t║                                 EXIT \t\t\t\t           ║",
    "\n\t\t\t\t\t\t║                               STUDENTS   \t\t\t           ║",
    "\n\t\t\t\t\t\t║                               TEACHERS\t\t\t           ║",
    "\n\t\t\t\t\t\t║                                ADMIN\t\t\t                   ║"
};


            while (true)
            {
                Console.Clear();
                string logo = (@" 
                                           ____ _   _    _    ____  ____  ___ ____  _____   _____ _        _    ___ _   _    _    
                                          / ___| | | |  / \  |  _ \|  _ \|_ _/ ___|| ____| | ____| |      / \  |_ _| \ | |  / \   
                                         | |   | |_| | / _ \ | |_) | |_) || |\___ \|  _|   |  _| | |     / _ \  | ||  \| | / _ \  
                                         | |___|  _  |/ ___ \|  _ <|  _ < | | ___) | |___  | |___| |___ / ___ \ | || |\  |/ ___ \ 
                                          \____|_| |_/_/   \_\_| \_\_| \_\___|____/|_____| |_____|_____/_/   \_\___|_| \_/_/   \_\
  

");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(logo);
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t\t\t\t\t║                     \t CHOOSE YOUR ROLE TO LOGIN\t\t           ║");

                Console.WriteLine();
                Console.WriteLine();
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
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════════════╝");

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
                        Environment.Exit(0);
                    }
                    else if (selectedIndex == 1)
                    {
                        role = Role.Student;

                    }
                    else if (selectedIndex == 2)
                    {
                        role = Role.Teacher;
                    }

                    else if (selectedIndex == 3)
                    {
                        role = Role.Admin;
                    }
                    break;
                }
            }
   
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t\t║                     \t       LOGIN MENU\t                           ║");
            Console.WriteLine("\t\t\t\t\t\t║                                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t║                                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t║                                                                          ║");
            Console.Write("\t\t\t\t\t\t║    >>>Username:                                                          ║");     
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t║                                                                          ║");
            Console.Write("\t\t\t\t\t\t║    >>>Password:                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t║                                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t║                                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t\t\t  [!] ");
            Console.ForegroundColor= ConsoleColor.Red;
            Console.Write("F");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("orget Password?");
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\t\t\t\t\t\t\t\t  [!] ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("E");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("sc");
            //An F de quen mat khau
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
            {
                return;
            }
            else if (key == ConsoleKey.F)
            {
                ForgotPassword();
                return;
            }


            Console.SetCursorPosition(68, 8);
            username = Console.ReadLine();
            Console.SetCursorPosition(68, 10);
            string password2 = "";
            while (true)
            {
                ConsoleKeyInfo key2 = Console.ReadKey(true);
                if (key2.Key == ConsoleKey.Enter)
                {
                    break;
                }
                password2 += key2.KeyChar;
                Console.Write("*");
            }
            Console.WriteLine();
            password = password2;

            string tenTep2 = "tamgv.txt";
            string fileContent = username;
            File.WriteAllText(tenTep2, fileContent);
            
        }

        public bool Authenticate()
        {
            loginlist.Clear();
            string filepath = "danhsachtaikhoanmatkhausv.txt";
            string filepath2 = "danhsachtaikhoanmatkhaugv.txt";
            while (true)
            {
                switch (role)
                {

                    case (Role.Student):
                        string[] lines = System.IO.File.ReadAllLines(filepath);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string[] field = lines[i].Split(",");
                            if (field[0].Equals(username) && field[1].Equals(password))
                            {
                                return true;

                            }
                        }
                        return false;

                    case Role.Teacher:
                        string[] lines2 = System.IO.File.ReadAllLines(filepath2);
                        for (int i = 0; i < lines2.Length; i++)
                        {
                            string[] field2 = lines2[i].Split(",");
                            if (field2[0].Equals(username) && field2[1].Equals(password))
                            {
                                return true;
                            }
                        }
                        return false;

                    case (Role.Admin):
                        if (username == "admin" && password == "123")
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                }
            }
        }
        public void ForgotPassword()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t╔══════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t\t║                     \t      FORGOT PASSWORD\t                           ║");
            Console.WriteLine("\t\t\t\t\t\t║                                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t║                                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t║                                                                          ║");
            Console.Write("\t\t\t\t\t\t║    >>>Username:                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t║                                                                          ║");
            Console.Write("\t\t\t\t\t\t║    >>>Code Authentication:                                               ║");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t║                                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t║                                                                          ║");
            Console.WriteLine("\t\t\t\t\t\t╚══════════════════════════════════════════════════════════════════════════╝");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(68, 11);
            string username = Console.ReadLine();

            switch (role)
            {
                case (Role.Student):
                    // Đọc dữ liệu từ file danh sách tài khoản sinh viên
                    string[] lines = System.IO.File.ReadAllLines("danhsachtaikhoanmatkhausv.txt");
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] field = lines[i].Split(",");
                        if (field[0].Equals(username))
                        {
                            string emailguive = field[2];
                            Random random = new Random();

                            string code = "";
                            for (int i2 = 0; i2 < 10; i2++)
                            {
                                // Tạo giá trị ngẫu nhiên từ 65 đến 90 (tương ứng với mã ASCII từ A đến Z)
                                int randomValue = random.Next(65, 91);

                                // Chuyển đổi giá trị ngẫu nhiên thành ký tự
                                char randomChar = Convert.ToChar(randomValue);

                                // Thêm ký tự vào cuối chuỗi mã
                                code += randomChar;
                            }
                            string s = code;
                            using (MailMessage mail = new MailMessage())
                            {
                                mail.From = new MailAddress("nguyendat130504@gmail.com");
                                mail.To.Add(emailguive);
                                mail.Subject = "MA XAC THUC CHO TAI KHOAN SINH VIEN";
                                mail.Body = $"<>MA XAC THUC CHO TAI KHOAN SINH VIEN LA: {s}</h1>";
                                mail.IsBodyHtml = true;


                                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                                {
                                    smtp.Credentials = new NetworkCredential("nguyendat130504@gmail.com", "njfeqjaqnwchvesf");
                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\t\t     [!] A confirmation code has been sent to your mail");

                            Console.ForegroundColor = ConsoleColor.Green;
                            
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\t\t\t\t\t\t      F3.");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Open Email in Default Browser");
                            Console.ForegroundColor = ConsoleColor.Green;

                            var key2 = Console.ReadKey(true).Key;

                            if (key2 == ConsoleKey.F3)
                            {
                                OpenBrowser();
                            }
                            Console.SetCursorPosition(80, 13);
                            string code2 = Console.ReadLine();
                            if (code2 == s)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\tMat khau cua ban la: " + field[1]);
                                Console.ForegroundColor = ConsoleColor.Green;
                                return;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\n\t\t\t\t\t\t\t\tMa xac thuc khong dung");
                                Console.ForegroundColor = ConsoleColor.Green;
                                return;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\n[!] Khong tim thay tai khoan hop le");
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                  
                    }
                    break;

                case Role.Teacher:
                    // Đọc dữ liệu từ file danh sách tài khoản giáo viên
                    string[] lines2 = System.IO.File.ReadAllLines("danhsachtaikhoanmatkhaugv.txt");
                    for (int i = 0; i < lines2.Length; i++)
                    {
                        string[] field2 = lines2[i].Split(",");
                        if (field2[0].Equals(username))
                        {
                            Random random = new Random();
                            string emailguive2 = field2[2];

                            string code = "";
                            for (int i2 = 0; i2 < 10; i2++)
                            {
                                // Tạo giá trị ngẫu nhiên từ 65 đến 90 (tương ứng với mã ASCII từ A đến Z)
                                int randomValue = random.Next(65, 91);

                                // Chuyển đổi giá trị ngẫu nhiên thành ký tự
                                char randomChar = Convert.ToChar(randomValue);

                                // Thêm ký tự vào cuối chuỗi mã
                                code += randomChar;
                            }
                            string s = code;
                            
                            using (MailMessage mail = new MailMessage())
                            {
                                
                                mail.From = new MailAddress("nguyendat130504@gmail.com");
                                mail.To.Add(emailguive2);
                                mail.Subject = "MA XAC THUC CHO TAI KHOAN GIAO VIEN";
                                mail.Body = $"</h1>MA XAC THUC CHO TAI KHOAN GIAO VIEN LA: {s}</h1>";
                                mail.IsBodyHtml = true;


                                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                                {
                                    smtp.Credentials = new NetworkCredential("nguyendat130504@gmail.com", "njfeqjaqnwchvesf");
                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                }
                            }
   
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\t\t     [!] A confirmation code has been sent to your mail");

                            Console.ForegroundColor = ConsoleColor.Green;


                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\t\t\t\t\t\t      F3.");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Open Email in Default Browser");
                            Console.ForegroundColor = ConsoleColor.Green;

                            var key2 = Console.ReadKey(true).Key;

                            if (key2 == ConsoleKey.F3)
                            {
                                OpenBrowser();
                            }
                            Console.SetCursorPosition(80, 13);

                            string code2 = Console.ReadLine();
                            if (code2 == s)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t\t\t\t\t\t\n[!] Mat khau cua ban la: " + field2[1]);
                                Console.ForegroundColor = ConsoleColor.Green;
                                return;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t\t\t\t\t\t\n[!] Ma xac thuc khong dung");
                                Console.ForegroundColor = ConsoleColor.Green;
                                return;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\n[!] Khong tim thay tai khoan hop le");
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    }
                    break;

                case Role.Admin:
                    string[] lines3 = System.IO.File.ReadAllLines("danhsachtaikhoanmatkhauadmin.txt");
                    for (int i = 0; i < lines3.Length; i++)
                    {
                        string[] field3 = lines3[i].Split(",");
                        if (field3[0].Equals(username))
                        {
                            Random random = new Random();

                            string code = "";
                            for (int i2 = 0; i2 < 10; i2++)
                            {
                                // Tạo giá trị ngẫu nhiên từ 65 đến 90 (tương ứng với mã ASCII từ A đến Z)
                                int randomValue = random.Next(65, 91);

                                // Chuyển đổi giá trị ngẫu nhiên thành ký tự
                                char randomChar = Convert.ToChar(randomValue);

                                // Thêm ký tự vào cuối chuỗi mã
                                code += randomChar;
                            }
                            string s = code;

                            using (MailMessage mail = new MailMessage())
                            {

                                mail.From = new MailAddress("nguyendat130504@gmail.com");
                                mail.To.Add("nguyendatdtqn@gmail.com");
                                mail.Subject = "MA XAC THUC CHO TAI KHOAN GIAO VIEN";
                                mail.Body = $"</h1>MA XAC THUC CHO TAI KHOAN GIAO VIEN LA: {s}</h1>";
                                mail.IsBodyHtml = true;


                                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                                {
                                    smtp.Credentials = new NetworkCredential("nguyendat130504@gmail.com", "njfeqjaqnwchvesf");
                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                }
                            }

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\t\t     [!] A confirmation code has been sent to your mail");

                            Console.ForegroundColor = ConsoleColor.Green;


                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\t\t\t\t\t\t      F3.");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Open Email in Default Browser");
                            Console.ForegroundColor = ConsoleColor.Green;

                            var key2 = Console.ReadKey(true).Key;

                            if (key2 == ConsoleKey.F3)
                            {
                                OpenBrowser();
                            }
                            Console.SetCursorPosition(80, 13);
                            string code2 = Console.ReadLine();
                            if (code2 == s)
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.ForegroundColor= ConsoleColor.Red;
                                Console.WriteLine("\t\t\t\t\t\t\t\n[!] Mat khau cua ban la: " + field3[1]);
                                Console.ForegroundColor=ConsoleColor.Green;
                                return;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\t\t\t\t\t\t\t\n[!] Ma xac thuc khong dung");
                                Console.ForegroundColor = ConsoleColor.Green;
                                return;
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\n[!] Khong tim thay tai khoan hop le");
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    }
                    break;
            }
        }
        public void OpenBrowser()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c start https://www.gmail.com/",
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process process = new Process
            {
                StartInfo = startInfo
            };
            process.Start();
        }

    }
    public enum Role
    {
        Admin,
        Teacher,
        Student
    }
}

