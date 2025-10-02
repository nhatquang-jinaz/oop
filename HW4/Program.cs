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

            List<Phong> danhSach = new List<Phong>();

            Console.Write("Nhập số lượng phòng khách thuê: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Phòng {i + 1} ---");
                Console.Write("Loại phòng (A/B/C): ");
                string loai = Console.ReadLine().ToUpper();

                Console.Write("Số ngày thuê: ");
                int soNgay = int.Parse(Console.ReadLine());

                if (loai == "A")
                {
                    Console.Write("Tiền dịch vụ: ");
                    double dv = double.Parse(Console.ReadLine());
                    danhSach.Add(new PhongA(soNgay, dv));
                }
                else if (loai == "B")
                {
                    danhSach.Add(new PhongB(soNgay));
                }
                else
                {
                    danhSach.Add(new PhongC(soNgay));
                }
            }

            Console.WriteLine("\n=== DANH SÁCH HÓA ĐƠN ===");
            foreach (var p in danhSach)
            {
                p.HienThi();
            }
        }
    
    }
}
