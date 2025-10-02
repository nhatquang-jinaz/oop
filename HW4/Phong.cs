using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Phong
    {
        public int SoNgayThue { get; set; }
        public double DonGia { get; set; }

        public Phong(int soNgay, double donGia)
        {
            SoNgayThue = soNgay;
            DonGia = donGia;
        }

        public virtual double TinhTien()
        {
            return SoNgayThue * DonGia;
        }

        public virtual void HienThi()
        {
            Console.WriteLine($"Số ngày thuê: {SoNgayThue}, Đơn giá: {DonGia}");
        }
    }

    class PhongA : Phong
    {
        public double TienDichVu { get; set; }

        public PhongA(int soNgay, double tienDichVu) : base(soNgay, 80)
        {
            TienDichVu = tienDichVu;
        }

        public override double TinhTien()
        {
            double tong = SoNgayThue * DonGia + TienDichVu;
            if (SoNgayThue >= 5) tong *= 0.9;  // giảm 10%
            return tong;
        }

        public override void HienThi()
        {
            Console.WriteLine($"Phòng A - {SoNgayThue} ngày, DV: {TienDichVu}, Tổng: {TinhTien()} USD");
        }
    }

    class PhongB : Phong
    {
        public PhongB(int soNgay) : base(soNgay, 60) { }

        public override double TinhTien()
        {
            double tong = SoNgayThue * DonGia;
            if (SoNgayThue >= 5) tong *= 0.9;  // giảm 10%
            return tong;
        }

        public override void HienThi()
        {
            Console.WriteLine($"Phòng B - {SoNgayThue} ngày, Tổng: {TinhTien()} USD");
        }
    }

    class PhongC : Phong
    {
        public PhongC(int soNgay) : base(soNgay, 40) { }

        public override void HienThi()
        {
            Console.WriteLine($"Phòng C - {SoNgayThue} ngày, Tổng: {TinhTien()} USD");
        }
    }

}
