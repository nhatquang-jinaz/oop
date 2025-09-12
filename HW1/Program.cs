using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            string hoten, masv, lop, username, gmail;
            hoten = "Nguyễn Lưu Nhật Quang";
            masv = "12424060";
            lop = "12424TN";
            username = "nhatquang-jinaz";
            gmail = "nhatquang10messi@gmail.com";
            Console.WriteLine("Họ tên\t Mã sinh viên\t Mã lớp\t Tên tài khoản git\t Gmail");
            Console.WriteLine($"{hoten}\t {masv}\t {lop}\t {username}\t {gmail}");
            Console.ReadKey();
        }
    }
}
