using System;
using System.Collections.Generic;
using System.Text;

namespace IPG203.Models
{
    public class Washer : Device
    {
        public Washer(string serial, string name)
            : base(serial, name)
        {
        }

        // حساب تكلفة الإصلاح
        public override double CalcCost()
        {
            Cost = 200;
            return Cost;
        }

        // بدء الصيانة
        public override void Start()
        {
            Status = "In Progress";
        }

        // إنهاء الصيانة
        public override void Complete()
        {
            Status = "Completed";
        }
    }
}