using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW2
{
    //định nghĩa các thuộc tính của cá nhân
    class Person
    {
        private string ten;
        private string dchi;
        private double luong;
        //hàm tạo lớp person
        public Person(string ten, string dchi, double luong)
        {
            this.ten = ten;
            this.dchi = dchi;
            this.luong = luong;
        }
        //getter và setter
        public string Name { get => ten; set => ten = value; }
        public string Address { get => dchi; set => dchi = value; }
        public double Salary { get => luong; set => luong = value; }

        //thong tin hien thi
        public override string ToString()
        {
            return $"Name: {ten}\nAddress: {dchi}\nSalary: {luong}";
        }
    }
}

