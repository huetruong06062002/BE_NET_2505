using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_NET_2505
{
    public class PhanSo
    {
        public int TuSo { get; set; }
        public int MauSo { get; set; }

        public PhanSo(int tuSo, int mauSo)
        {
            if (mauSo == 0)
            {
                throw new ArgumentException("Mau so phai khac 0");
            }
            TuSo = tuSo;
            MauSo = mauSo;
            RutGon();
        }

        public void RutGon()
        {
            int gcd = GCD(TuSo, MauSo);
            TuSo /= gcd;
            MauSo /= gcd;
            if (MauSo < 0)
            {
                TuSo = -TuSo;
                MauSo = -MauSo;
            }
        }

        private int GCD(int a, int b)
        {
            if (b == 0) return a;
            return GCD(b, a % b);
        }

        public static PhanSo operator +(PhanSo p1, PhanSo p2)
        {
            int tuSo = p1.TuSo * p2.MauSo + p2.TuSo * p1.MauSo;
            int mauSo = p1.MauSo * p2.MauSo;
            return new PhanSo(tuSo, mauSo);
        }

        public static PhanSo operator -(PhanSo p1, PhanSo p2)
        {
            int tuSo = p1.TuSo * p2.MauSo - p2.TuSo * p1.MauSo;
            int mauSo = p1.MauSo * p2.MauSo;
            return new PhanSo(tuSo, mauSo);
        }

        public static PhanSo operator *(PhanSo p1, PhanSo p2)
        {
            int tuSo = p1.TuSo * p2.TuSo;
            int mauSo = p1.MauSo * p2.MauSo;
            return new PhanSo(tuSo, mauSo);
        }

        public static PhanSo operator /(PhanSo p1, PhanSo p2)
        {
            if (p2.TuSo == 0)
            {
                throw new DivideByZeroException("Khong the chia cho 0");
            }
            int tuSo = p1.TuSo * p2.MauSo;
            int mauSo = p1.MauSo * p2.TuSo;
            return new PhanSo(tuSo, mauSo);
        }

        public override string ToString()
        {
            return $"{TuSo}/{MauSo}";
        }
    }

    public class NhapPhanSo
    {
        public static PhanSo NhapPhanSoTuNguoiDung()
        {
            Console.Write("Nhap tu so: ");
            int tuSo = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau so: ");
            int mauSo = int.Parse(Console.ReadLine());
            return new PhanSo(tuSo, mauSo);
        }

        public  void Menu()
        {
            try
            {
                Console.WriteLine("Nhap phan so thu nhat:");
                PhanSo p1 = NhapPhanSo.NhapPhanSoTuNguoiDung();

                Console.WriteLine("Nhap phan so thu hai:");
                PhanSo p2 = NhapPhanSo.NhapPhanSoTuNguoiDung();

                while (true)
                {
                    Console.WriteLine("\nChon phep toan:");
                    Console.WriteLine("1. Cong hai phan so");
                    Console.WriteLine("2. Tru hai phan so");
                    Console.WriteLine("3. Nhan hai phan so");
                    Console.WriteLine("4. Chia hai phan so");
                    Console.WriteLine("5. Thoat");
                    Console.Write("Lua chon: ");
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 5) break;

                    PhanSo ketQua = null;

                    switch (choice)
                    {
                        case 1:
                            ketQua = p1 + p2;
                            Console.WriteLine($"Ket qua: {ketQua}");
                            break;
                        case 2:
                            ketQua = p1 - p2;
                            Console.WriteLine($"Ket qua: {ketQua}");
                            break;
                        case 3:
                            ketQua = p1 * p2;
                            Console.WriteLine($"Ket qua: {ketQua}");
                            break;
                        case 4:
                            try
                            {
                                ketQua = p1 / p2;
                                Console.WriteLine($"Ket qua: {ketQua}");
                            }
                            catch (DivideByZeroException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        default:
                            Console.WriteLine("Lua chon khong hop le!");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }
    }
}
