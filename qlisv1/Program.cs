using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;
using System;
using QLSV1;
using qlisv1;
using System.ComponentModel;

class Program
{

    static QLiSV quanlysinhvien = new QLiSV();

    static void Main(string[] args)
    {
        Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        Console.WindowLeft = Console.WindowTop = 0;
        while (true)
        {
            Login login = new Login();
            int maxAttempt = 3;
            int attempt = 0;
            while (true)
            {
                login.Show();
                bool authenticated = login.Authenticate();
                if (authenticated == true)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\n\n\n\t\t\t\t\t\t\t\t[!] Login successfully");
                    Console.ForegroundColor= ConsoleColor.Green;
                    Thread.Sleep(2000);
                    break;
                }             
                else
                {
                    attempt++;
                    if (attempt < maxAttempt)
                    {
                        if (attempt == 1)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("\t\t\t\t\t\t[!] Sai ten dang nhap hoac mat khau.Vui long thu lai");
                            Console.ReadKey();
                        }
                        else if (attempt == 2)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\t\t\t\t\t\t[!] Sai ten dang nhap hoac mat khau.Vui long thu lai");
                            Console.WriteLine($"\t\t\t\t\t\t[!]Ban da quen mat khau ?");
                            Console.Write("\t\t\t\t\t\t[!]Ban co muon dat lai mat khau? [Y] or [N]: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            while (true) 
                            {
                                string check = Console.ReadLine();
                                if (check=="N" || check=="n")
                                {
                                    break;
                                }
                                else if(check=="Y"||check=="y")
                                {
                                    login.ForgotPassword();
                                }
                                else
                                {
                                    Console.WriteLine("Lua chon sai");
                                    Console.Write("Nhap lai lua chon: ");
                                } 
                                    
                            }
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.ReadKey();
                        }

                    }
                    else if (attempt == maxAttempt)
                    {
                        Console.WriteLine($"Ban da nhap sai qua {attempt} lan. Tai khoan da bi vo hieu hoa. Hay lien he quan tri vien de khoi phuc");
                        Console.ReadKey();
                        return;
                    }
                    
                }
                
            }
            switch (login.role)
                {
                    case (Role.Admin):
                        {
                            Console.CursorVisible = false;
                            ConsoleKeyInfo keyInfo;
                            int selectedIndex = 0;
                            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝" , @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              STUDENTS MANAGER     ▼         ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SUBJECTS MANAGER     ▼         ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              MARKS MANAGER        ▼         ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                   SHOW LIST                 ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                  QUERY DATA                 ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║             SYNC DATA TO SQL SERVER         ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                FACULTIES MANAGER            ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              STATITICS DATA-GRAPH           ║  
                                                             ╚═════════════════════════════════════════════╝",
                        @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║       USERNAMES-PASSWORDS MANAGER           ║  
                                                             ╚═════════════════════════════════════════════╝",
                         @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║     READ ALL FILE FROM FILE EXPLORER        ║  
                                                             ╚═════════════════════════════════════════════╝"};

                            while (true)
                            {
                            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                            Console.WindowLeft = Console.WindowTop = 0;
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
                                    if (selectedIndex == 1)
                                    {
                                        quanlysinhvien.SINHVIEN();
                                    }
                                    else if (selectedIndex == 2)
                                    {
                                        quanlysinhvien.QUANLIMONHOC();
                                    }
                                    else if (selectedIndex == 3)
                                    {
                                        quanlysinhvien.QUANLIDIEM();
                                    }
                                    else if (selectedIndex == 4)
                                    {
                                        quanlysinhvien.HienthiDS_Thongke();
                                    }
                                    else if (selectedIndex == 5)
                                    {
                                        quanlysinhvien.TruyVanDuLieu();
                                    }
                                    else if (selectedIndex == 6)
                                    {
                                        quanlysinhvien.DONGBODULIEULENSQLSERVER();
                                    }
                                    else if (selectedIndex == 7)
                                    {
                                        quanlysinhvien.QUANLIKHOA();
                                    }
                                    else if (selectedIndex == 8)
                                    {
                                        quanlysinhvien.THONGKEDL();
                                    }
                                    else if (selectedIndex == 9)
                                    {
                                        quanlysinhvien.QUANLITAIKHOANMK();
                                    }
                                    else if(selectedIndex==10)
                                    {
                                        quanlysinhvien.DOCTATCATUTEP();
                                    }
                                }
                            }
                        }
                    case (Role.Student):
                        {
                           quanlysinhvien.XEMDIEM_XEMTHONGTINSINHVIEN();
                            return;
                        }
                    case (Role.Teacher):
                        {
                            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                            Console.WindowLeft = Console.WindowTop = 0;
                            Console.CursorVisible = false;
                            ConsoleKeyInfo keyInfo;
                            int selectedIndex = 0;
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("\n\n");
                            string[] options = { @"                                                             ╔═════════════════════════════════════════════╗ 
                                                             ║                   EXIT                      ║  
                                                             ╚═════════════════════════════════════════════╝" , @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              STUDENTS MANAGER      ▼        ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              SUBJECTS MANAGER      ▼        ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║              MARKS MANAGER         ▼        ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                 SHOW LIST                   ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║                  QUERY DATA                 ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║            SYNC DATA TO SQL SERVER          ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║            STATITICS DATA-GRAPH             ║  
                                                             ╚═════════════════════════════════════════════╝", @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║            CHANGE YOUR PASSWORD             ║  
                                                             ╚═════════════════════════════════════════════╝",
                         @"                                                                                                                                                                      ╔═════════════════════════════════════════════╗ 
                                                             ║      READ ALL FILE FROM FILE EXPLORER       ║  
                                                             ╚═════════════════════════════════════════════╝"};

                            while (true)
                            {
                            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
                            Console.WindowLeft = Console.WindowTop = 0;
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
                                    if (selectedIndex == 1)
                                    {
                                        quanlysinhvien.SINHVIEN();
                                    }
                                    else if (selectedIndex == 2)
                                    {
                                        quanlysinhvien.QUANLIMONHOC();
                                    }
                                    else if (selectedIndex == 3)
                                    {
                                        quanlysinhvien.QUANLIDIEM();
                                    }
                                    else if (selectedIndex == 4)
                                    {
                                        quanlysinhvien.HienthiDS_Thongke();
                                    }
                                    else if (selectedIndex == 5)
                                    {
                                        quanlysinhvien.TruyVanDuLieu();
                                    }
                                    else if (selectedIndex == 6)
                                    {
                                        quanlysinhvien.DONGBODULIEULENSQLSERVER();
                                    }
                                    else if (selectedIndex == 7)
                                    {
                                        quanlysinhvien.THONGKEDL();
                                    }
                                    else if (selectedIndex==8)
                                    {
                                    quanlysinhvien.DOITK_MK_GV();
                                    }    
                                    else if(selectedIndex==9)
                                    {
                                        quanlysinhvien.DOCTATCATUTEP();
                                    }
                                }
                            }
                        }
                }
            }
        }
    }
