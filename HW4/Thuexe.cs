using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class ThueXe
    {
        public string HoTen { get; set; }
        public int SoGio { get; set; }

        public ThueXe(string hoTen, int soGio)
        {
            HoTen = hoTen;
            SoGio = soGio;
        }

        public virtual int TinhTien()
        {
            return 0;
        }
    }

    class XeDuLich : ThueXe
    {
        public XeDuLich(string hoTen, int soGio) : base(hoTen, soGio) { }

        public override int TinhTien()
        {
            if (SoGio <= 1) return 250000;
            return 250000 + (SoGio - 1) * 70000;
        }
    }

    class XeTai : ThueXe
    {
        public XeTai(string hoTen, int soGio) : base(hoTen, soGio) { }

        public override int TinhTien()
        {
            if (SoGio <= 1) return 220000;
            return 220000 + (SoGio - 1) * 85000;
        }
    }

}
