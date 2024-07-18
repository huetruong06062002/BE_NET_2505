using System;
using System.Collections.Generic;
using System.Linq;


namespace BE_NET_2505
{
    using System;
    using System.Collections.Generic;

    abstract class NhanVien
    {
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public string LoaiNhanVien { get; set; }

        public NhanVien(string ten, int tuoi, string loaiNhanVien)
        {
            Ten = ten;
            Tuoi = tuoi;
            LoaiNhanVien = loaiNhanVien;
        }

        public abstract double TinhLuong();
    }

    class NhanVienToanThoiGian : NhanVien
    {
        public double LuongCoBan { get; set; }

        public NhanVienToanThoiGian(string ten, int tuoi, double luongCoBan)
            : base(ten, tuoi, "Toàn thời gian")
        {
            LuongCoBan = luongCoBan;
        }

        public override double TinhLuong()
        {
            return LuongCoBan;
        }
    }

    class NhanVienBanThoiGian : NhanVien
    {
        public double LuongGio { get; set; }
        public int SoGioLam { get; set; }

        public NhanVienBanThoiGian(string ten, int tuoi, double luongGio, int soGioLam)
            : base(ten, tuoi, "Bán thời gian")
        {
            LuongGio = luongGio;
            SoGioLam = soGioLam;
        }

        public override double TinhLuong()
        {
            return LuongGio * SoGioLam;
        }
    }

    class NhanVienThucTap : NhanVien
    {
        public double TroCap { get; set; }

        public NhanVienThucTap(string ten, int tuoi, double troCap)
            : base(ten, tuoi, "Thực tập")
        {
            TroCap = troCap;
        }

        public override double TinhLuong()
        {
            return TroCap;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();

            Console.Write("Nhập số lượng nhân viên: ");
            int soLuongNhanVien = int.Parse(Console.ReadLine());

            for (int i = 0; i < soLuongNhanVien; i++)
            {
                Console.WriteLine($"Nhập thông tin cho nhân viên thứ {i + 1}:");
                Console.Write("Tên: ");
                string ten = Console.ReadLine();
                Console.Write("Tuổi: ");
                int tuoi = int.Parse(Console.ReadLine());

                Console.Write("Loại nhân viên (1 - Toàn thời gian, 2 - Bán thời gian, 3 - Thực tập): ");
                int loaiNhanVien = int.Parse(Console.ReadLine());

                if (loaiNhanVien == 1)
                {
                    Console.Write("Lương cơ bản: ");
                    double luongCoBan = double.Parse(Console.ReadLine());
                    danhSachNhanVien.Add(new NhanVienToanThoiGian(ten, tuoi, luongCoBan));
                }
                else if (loaiNhanVien == 2)
                {
                    Console.Write("Lương giờ: ");
                    double luongGio = double.Parse(Console.ReadLine());
                    Console.Write("Số giờ làm: ");
                    int soGioLam = int.Parse(Console.ReadLine());
                    danhSachNhanVien.Add(new NhanVienBanThoiGian(ten, tuoi, luongGio, soGioLam));
                }
                else if (loaiNhanVien == 3)
                {
                    Console.Write("Trợ cấp: ");
                    double troCap = double.Parse(Console.ReadLine());
                    danhSachNhanVien.Add(new NhanVienThucTap(ten, tuoi, troCap));
                }
            }

            Console.WriteLine("Danh sách nhân viên và lương tương ứng:");
            foreach (var nv in danhSachNhanVien)
            {
                Console.WriteLine($"Tên: {nv.Ten}, Tuổi: {nv.Tuoi}, Loại: {nv.LoaiNhanVien}, Lương: {nv.TinhLuong()}");
            }
        }
    }

}
