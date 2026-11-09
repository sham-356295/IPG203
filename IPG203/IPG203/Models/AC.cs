using System;
using System.Collections.Generic;
using System.Text;

namespace IPG203.Models
{
    public class AC : Device
    {
        public AC(string serial, string name)
            : base(serial, name)
        {
        }

        // حساب تكلفة الإصلاح
        public override double CalcCost()
        {
            Cost = 250;
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
