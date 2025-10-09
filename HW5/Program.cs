using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace motor
{
    public interface IMotor
    {
        void inputInfor();
        void displayInfor();
        void changeInfor();
    }

    public class Motor : IMotor
    {
        public string Code { get; set; }    // Mã xe
        public string Name { get; set; }    // Tên loại xe
        public double Capacity { get; set; } // Dung tích xi lanh
        public int Num { get; set; }         // Kiểu truyền (mấy số)

        public Motor() { }

        public Motor(string code, string name, double capacity, int num)
        {
            Code = code;
            Name = name;
            Capacity = capacity;
            Num = num;
        }

        public virtual void inputInfor()
        {
            try
            {
                Console.Write("Nhập mã xe: ");
                Code = Console.ReadLine();
                Console.Write("Nhập tên loại xe: ");
                Name = Console.ReadLine();
                Console.Write("Nhập dung tích xi lanh (vd 150.0): ");
                Capacity = double.Parse(Console.ReadLine());
                Console.Write("Nhập kiểu truyền (số): ");
                Num = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nhập: " + ex.Message);
            }
        }

        public virtual void displayInfor()
        {
            Console.WriteLine($"Code: {Code}, Name: {Name}, Capacity: {Capacity}, Num: {Num}");
        }

        public virtual void changeInfor()
        {
            Console.WriteLine("Thay đổi thông tin cho xe (để trống giữ nguyên):");
            Console.Write("Mã xe mới: ");
            var s = Console.ReadLine();
            if (!string.IsNullOrEmpty(s)) Code = s;
            Console.Write("Tên mới: ");
            s = Console.ReadLine();
            if (!string.IsNullOrEmpty(s)) Name = s;
            Console.Write("Dung tích mới (để trống giữ nguyên): ");
            s = Console.ReadLine();
            if (!string.IsNullOrEmpty(s) && double.TryParse(s, out double d)) Capacity = d;
            Console.Write("Kiểu truyền mới (để trống giữ nguyên): ");
            s = Console.ReadLine();
            if (!string.IsNullOrEmpty(s) && int.TryParse(s, out int n)) Num = n;
        }
    }
}

namespace motor.yamaha
{
    using motor;

    public class Jupiter : Motor
    {
        public int Warranty { get; set; } // thời gian bảo hành (tháng, ví dụ)

        public Jupiter() : base() { }

        public Jupiter(string code, string name, double capacity, int num, int warranty)
            : base(code, name, capacity, num)
        {
            Warranty = warranty;
        }

        public override void inputInfor()
        {
            base.inputInfor();
            try
            {
                Console.Write("Nhập thời gian bảo hành (tháng) cho Jupiter: ");
                Warranty = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nhập warranty: " + ex.Message);
            }
            // đảm bảo tên là Jupiter nếu muốn
            if (string.IsNullOrEmpty(Name)) Name = "Jupiter";
        }

        public override void displayInfor()
        {
            Console.WriteLine($"[Jupiter] Code: {Code}, Name: {Name}, Capacity: {Capacity}, Num: {Num}, Warranty: {Warranty}");
        }

        public override void changeInfor()
        {
            base.changeInfor();
            Console.Write("Warranty mới (để trống giữ nguyên): ");
            var s = Console.ReadLine();
            if (!string.IsNullOrEmpty(s) && int.TryParse(s, out int w)) Warranty = w;
        }
    }

    public class Serius : Motor
    {
        public int Warranty { get; set; }

        public Serius() : base() { }

        public Serius(string code, string name, double capacity, int num, int warranty)
            : base(code, name, capacity, num)
        {
            Warranty = warranty;
        }

        public override void inputInfor()
        {
            base.inputInfor();
            try
            {
                Console.Write("Nhập thời gian bảo hành (tháng) cho Serius: ");
                Warranty = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nhập warranty: " + ex.Message);
            }
            if (string.IsNullOrEmpty(Name)) Name = "Serius";
        }

        public override void displayInfor()
        {
            Console.WriteLine($"[Serius] Code: {Code}, Name: {Name}, Capacity: {Capacity}, Num: {Num}, Warranty: {Warranty}");
        }

        public override void changeInfor()
        {
            base.changeInfor();
            Console.Write("Warranty mới (để trống giữ nguyên): ");
            var s = Console.ReadLine();
            if (!string.IsNullOrEmpty(s) && int.TryParse(s, out int w)) Warranty = w;
        }
    }

    public class Yamaha
    {
        private List<Motor> motors = new List<Motor>();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Input");
                Console.WriteLine("2. Display");
                Console.WriteLine("3. Sort (theo thời gian bảo hành)");
                Console.WriteLine("4. Search (tìm xe có tên là 'Serius')");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn (1-5): ");
                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        InputMin3Each();
                        break;
                    case "2":
                        DisplayAll();
                        break;
                    case "3":
                        SortByWarranty();
                        break;
                    case "4":
                        SearchSerius();
                        break;
                    case "5":
                        Console.WriteLine("Kết thúc chương trình.");
                        return;
                    default:
                        Console.WriteLine("Chọn không hợp lệ. Thử lại.");
                        break;
                }
            }
        }

        // Yêu cầu: Nhập tối thiểu 3 Jupiter và 3 Serius khi gọi chức năng 1.
        private void InputMin3Each()
        {
            Console.WriteLine("Nhập tối thiểu 3 Jupiter và 3 Serius.");
            int jCount = 0, sCount = 0;

            while (jCount < 3)
            {
                Console.WriteLine($"\nNhập Jupiter thứ {jCount + 1}:");
                var j = new Jupiter();
                j.inputInfor();
                if (string.IsNullOrEmpty(j.Name)) j.Name = "Jupiter";
                motors.Add(j);
                jCount++;
            }

            while (sCount < 3)
            {
                Console.WriteLine($"\nNhập Serius thứ {sCount + 1}:");
                var sr = new Serius();
                sr.inputInfor();
                if (string.IsNullOrEmpty(sr.Name)) sr.Name = "Serius";
                motors.Add(sr);
                sCount++;
            }

            // Sau đó cho phép nhập thêm nếu muốn
            Console.Write("Bạn có muốn nhập thêm xe khác (y/n)? ");
            var more = Console.ReadLine();
            while (more != null && more.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Chọn loại (1=Jupiter, 2=Serius, 3=Motor thường): ");
                var t = Console.ReadLine();
                if (t == "1")
                {
                    var j = new Jupiter();
                    j.inputInfor();
                    motors.Add(j);
                }
                else if (t == "2")
                {
                    var sr = new Serius();
                    sr.inputInfor();
                    motors.Add(sr);
                }
                else
                {
                    var m = new Motor();
                    m.inputInfor();
                    motors.Add(m);
                }
                Console.Write("Tiếp tục nhập thêm? (y/n): ");
                more = Console.ReadLine();
            }
        }

        private void DisplayAll()
        {
            if (motors.Count == 0)
            {
                Console.WriteLine("Chưa có dữ liệu. Hãy chọn Input (1) trước.");
                return;
            }

            Console.WriteLine("\n-- Hiển thị thông tin tất cả xe --");
            foreach (var m in motors)
            {
                m.displayInfor();
            }
        }

        // Sắp xếp theo warranty (xe không có warranty coi là 0)
        private void SortByWarranty()
        {
            if (motors.Count == 0)
            {
                Console.WriteLine("Chưa có dữ liệu. Hãy chọn Input (1) trước.");
                return;
            }

            Console.WriteLine("\nHiển thị trước khi sắp xếp:");
            DisplayAll();

            // Tạo một key selector: nếu là Jupiter hoặc Serius lấy thuộc tính Warranty, ngược lại 0
            var sorted = motors.OrderBy(m =>
            {
                if (m is Jupiter j) return j.Warranty;
                if (m is Serius s) return s.Warranty;
                return 0;
            }).ToList();

            motors = sorted;
            Console.WriteLine("\nHiển thị sau khi sắp xếp tăng dần theo warranty:");
            DisplayAll();
        }

        private void SearchSerius()
        {
            if (motors.Count == 0)
            {
                Console.WriteLine("Chưa có dữ liệu. Hãy chọn Input (1) trước.");
                return;
            }

            Console.WriteLine("\nHiển thị trước khi tìm kiếm:");
            DisplayAll();

            var results = motors.Where(m =>
                // tìm theo kiểu là Serius hoặc tên chứa "Serius"
                m is Serius || (!string.IsNullOrEmpty(m.Name) && m.Name.Equals("Serius", StringComparison.OrdinalIgnoreCase))
            ).ToList();

            Console.WriteLine($"\nTìm thấy {results.Count} chiếc có tên/kiểu là Serius:");
            foreach (var r in results)
            {
                r.displayInfor();
            }

            Console.WriteLine("\nHiển thị sau khi (không thay đổi danh sách chính) - nếu muốn sắp xếp kết quả theo warranty:");
            var sortedResults = results.OrderBy(r => (r is Serius sr) ? sr.Warranty : 0).ToList();
            foreach (var r in sortedResults)
            {
                r.displayInfor();
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        var app = new motor.yamaha.Yamaha();
        app.Run();
        Console.ReadKey();
    }
}
