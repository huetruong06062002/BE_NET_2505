using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_NET_2505
{
    public class Bai24
    {

        public enum HocLuc
        {
            XuatSac,
            Gioi,
            Kha,
            TrungBinh,
            Yeu
        }

        public class SinhVien
        {
            public string ID { get; set; }
            public string Ten { get; set; }
            public int Tuoi { get; set; }
            public double DiemHK1 { get; set; }
            public double DiemHK2 { get; set; }
            public HocLuc HocLuc
            {
                get
                {
                    double diemTB = (DiemHK1 + DiemHK2) / 2;
                    if (diemTB >= 9) return HocLuc.XuatSac;
                    if (diemTB >= 8) return HocLuc.Gioi;
                    if (diemTB >= 6.5) return HocLuc.Kha;
                    if (diemTB >= 5) return HocLuc.TrungBinh;
                    return HocLuc.Yeu;
                }
            }
        }

        public class MenuSinhVien
        {
            static List<SinhVien> sinhViens = new List<SinhVien>();

            public void CallMenu()
            {
                Console.Write("Nhap so luong sinh vien: ");
                int soLuongSinhVien = int.Parse(Console.ReadLine());

                for (int i = 0; i < soLuongSinhVien; i++)
                {
                    ThemSinhVien();
                }

                while (true)
                {
                    Console.WriteLine("1. Them sinh vien");
                    Console.WriteLine("2. Xem thong tin sinh vien");
                    Console.WriteLine("3. Xoa sinh vien");
                    Console.WriteLine("4. Thoat");
                    Console.Write("Lua chon: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            ThemSinhVien();
                            break;
                        case 2:
                            XemThongTinSinhVien();
                            break;
                        case 3:
                            XoaSinhVien();
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                    }
                }
            }

            static void ThemSinhVien()
            {
                SinhVien sv = new SinhVien();

                Console.Write("Nhap ID: ");
                sv.ID = Console.ReadLine();

                Console.Write("Nhap ten: ");
                sv.Ten = Console.ReadLine();

                Console.Write("Nhap tuoi: ");
                sv.Tuoi = int.Parse(Console.ReadLine());

                Console.Write("Nhap diem HK1: ");
                sv.DiemHK1 = double.Parse(Console.ReadLine());

                Console.Write("Nhap diem HK2: ");
                sv.DiemHK2 = double.Parse(Console.ReadLine());

                sinhViens.Add(sv);
            }

            static void XemThongTinSinhVien()
            {
                foreach (var sv in sinhViens)
                {
                    Console.WriteLine($"ID: {sv.ID}");
                    Console.WriteLine($"Ten: {sv.Ten}");
                    Console.WriteLine($"Tuoi: {sv.Tuoi}");
                    Console.WriteLine($"Diem HK1: {sv.DiemHK1}");
                    Console.WriteLine($"Diem HK2: {sv.DiemHK2}");
                    Console.WriteLine($"Hoc luc: {sv.HocLuc}");
                    Console.WriteLine();
                }
            }

            static void XoaSinhVien()
            {
                Console.Write("Nhap ID sinh vien can xoa: ");
                string id = Console.ReadLine();

                SinhVien svToRemove = sinhViens.Find(sv => sv.ID == id);
                if (svToRemove != null)
                {
                    sinhViens.Remove(svToRemove);
                    Console.WriteLine("Xoa thanh cong.");
                }
                else
                {
                    Console.WriteLine("Khong tim thay sinh vien.");
                }
            }

        }
    }
}

