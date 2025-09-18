using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Employee clerk1 = new Employee("Quang");

            Item candy = new Item("Kẹo", 1.35, 0.25);
            Item milk = new Item("Sữa", 3.50, 0.0);
            Item bread = new Item("Bánh mì", 2.20, 0.10);

            Console.WriteLine("[DEMO]");
            Console.WriteLine("\nHóa đơn thông thường");
            GroceryBill bill1 = new GroceryBill(clerk1);
            bill1.Add(candy);
            bill1.Add(milk);
            bill1.Add(bread);
            bill1.PrintReceipt();

            Console.WriteLine("\nHóa đơn cho khách hàng thân thiết");
            DiscountBill bill2 = new DiscountBill(clerk1, true);
            bill2.Add(candy);
            bill2.Add(milk);
            bill2.Add(bread);
            bill2.PrintReceipt();

            Console.WriteLine("\n[DEMO PHẦN MỞ RỘNG]");
            Console.WriteLine("\nHóa đơn với dòng hóa đơn");
            Employee clerk2 = new Employee("Toàn");
            Item apple = new Item("Táo", 0.5, 0.1);
            Item orange = new Item("Cam", 0.7, 0.0);

            GroceryBillV2 bill3 = new GroceryBillV2(clerk2);
            bill3.Add(new BillLine(apple, 10));
            bill3.Add(new BillLine(orange, 5));
            bill3.PrintReceipt();
            Console.ReadKey(); 
        }
    }
}
