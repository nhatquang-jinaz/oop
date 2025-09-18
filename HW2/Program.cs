using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW2
{
    class Program
    {
        //nhập dữ liệu về người nào đó
        public static Person InputPersonInfo()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập tên: ");
            string ten = Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            string dchi = Console.ReadLine();
            double luong = 0;
            while (true)
            {
                Console.Write("Nhập lương: ");
                string input = Console.ReadLine();
                //xử lý ngoại lệ
                try
                {
                    luong = double.Parse(input);
                    if (luong <= 0)
                    {
                        Console.WriteLine("Lương phải lớn hơn 0!");
                    }
                    else
                    {
                        break;
                    }
                }
                //xử lý trong trường hợp người dùng nhập sai kiểu dữ liệu (không phải là số)
                catch
                {
                    Console.WriteLine("Bạn nhập sai kiểu dữ liệu. Vui lòng nhập số.");
                }
            }
            return new Person(ten, dchi, luong);

        }

        //hiển thị thông tin
        public static void DisplayPersonInfo(Person p)
        {
            Console.WriteLine("Thông tin:");
            Console.WriteLine(p.ToString());
            Console.WriteLine();
        }

        //sắp xếp theo lương
        public static void SortBySalary(Person[] persons)
        {
            for (int i = 0; i < persons.Length - 1; i++)
            {
                for (int j = 0; j < persons.Length - i - 1; j++)
                {
                    if (persons[j].Salary > persons[j + 1].Salary) //so sánh lương của người bên trái với người đứng cạnh bên phải, nếu lương cao hon thì đổi chỗ
                    {
                        Person temp = persons[j];
                        persons[j] = persons[j + 1];
                        persons[j + 1] = temp;
                    }
                }
            }
        }

        //chương trình chính
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Person[] persons = new Person[3];//tạo 1 mảng để lưu dữ liệu 3 người
            //nhập thông tin của 3 người
            for(int i = 0; i < 3; i++) {
                Console.WriteLine($"\nNhập thông tin của người thứ {i + 1}");
                persons[i] = InputPersonInfo();
            }

            //hiển thị thông tin
            foreach (Person p in persons) {
                DisplayPersonInfo(p);
            }

            //sắp xếp theo lương
            SortBySalary(persons);
            Console.WriteLine("\nSau khi đã sắp xếp theo lương: ");
            foreach (Person p in persons)
            {
                DisplayPersonInfo(p);
            }
            Console.ReadKey();
        }

    }
}
