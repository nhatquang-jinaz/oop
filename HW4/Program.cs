using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    internal class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            List<ThueXe> ds = new List<ThueXe>();

            Console.Write("Nhập số lượng người thuê: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Người thuê {i + 1} ---");
                Console.Write("Họ tên: ");
                string ten = Console.ReadLine();

                Console.Write("Số giờ thuê: ");
                int gio = int.Parse(Console.ReadLine());

                Console.Write("Loại xe (1. Xe du lịch, 2. Xe tải): ");
                int loai = int.Parse(Console.ReadLine());

                if (loai == 1)
                    ds.Add(new XeDuLich(ten, gio));
                else
                    ds.Add(new XeTai(ten, gio));
            }

            Console.WriteLine("\nDanh sách thuê xe:");
            Console.WriteLine("Họ tên\tSố giờ\tThành tiền");
            foreach (var xe in ds)
            {
                Console.WriteLine($"{xe.HoTen}\t{xe.SoGio}\t{xe.TinhTien()}");
            }
        }
    }
}
