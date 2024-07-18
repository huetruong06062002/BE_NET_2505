


namespace BE_NET_2505
{
    abstract class SanPham
    {
        public string TenSanPham { get; set; }
        public double GiaNhap { get; set; }

        public SanPham(string tenSanPham, double giaNhap)
        {
            TenSanPham = tenSanPham;
            GiaNhap = giaNhap;
        }

        public abstract double TinhGiaBan();
    }

    class DienThoai : SanPham
    {
        public DienThoai(string tenSanPham, double giaNhap)
            : base(tenSanPham, giaNhap) { }

        public override double TinhGiaBan()
        {
            return GiaNhap * 1.2;
        }
    }

    class Laptop : SanPham
    {
        public Laptop(string tenSanPham, double giaNhap)
            : base(tenSanPham, giaNhap) { }

        public override double TinhGiaBan()
        {
            return GiaNhap * 1.3;
        }
    }

    class Sach : SanPham
    {
        public Sach(string tenSanPham, double giaNhap)
            : base(tenSanPham, giaNhap) { }

        public override double TinhGiaBan()
        {
            return GiaNhap * 1.1;
        }
    }

    class Bai2_Buoi7
    {
        static void Main(string[] args)
        {
            List<SanPham> danhSachSanPham = new List<SanPham>();

            while (true)
            {
                Console.WriteLine("Nhập loại sản phẩm (1: Điện thoại, 2: Laptop, 3: Sách, 0: Thoát): ");
                int loai = int.Parse(Console.ReadLine());

                if (loai == 0) break;

                Console.WriteLine("Nhập tên sản phẩm: ");
                string ten = Console.ReadLine();
                Console.WriteLine("Nhập giá nhập: ");
                double giaNhap = double.Parse(Console.ReadLine());

                switch (loai)
                {
                    case 1:
                        danhSachSanPham.Add(new DienThoai(ten, giaNhap));
                        break;
                    case 2:
                        danhSachSanPham.Add(new Laptop(ten, giaNhap));
                        break;
                    case 3:
                        danhSachSanPham.Add(new Sach(ten, giaNhap));
                        break;
                }
            }

            foreach (var sp in danhSachSanPham)
            {
                Console.WriteLine($"Gia ban cua {sp.TenSanPham} la: {sp.TinhGiaBan()}");
            }
        }
    }
}