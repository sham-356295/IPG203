using System;
using System.Collections.Generic;
using System.Text;
using IPG203.Interfaces;

namespace IPG203.Models
{
    // تعريف Delegate لتغيير حالة الجهاز
    public delegate void StatusChangedHandler(string serial, string status);
    public abstract class Device : IDevice
    {
        private string serial;
        private string name;
        private string status;
        private double cost;
        // حدث عند تغيير حالة الجهاز
        public event StatusChangedHandler StatusChanged;
        public string Serial
        {
            get { return serial; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Status
        {
            get { return status; }
            protected set
            {
                if (status == "Completed")
                    CompletedCount--;

                status = value;

                if (status == "Completed")
                    CompletedCount++;

                StatusChanged?.Invoke(Serial, status);
            }
        }

        public double Cost
        {
            get { return cost; }
            protected set { cost = value; }
        }

        protected Device(string serial, string name)
        {
            this.serial = serial;
            this.name = name;
            status = "Pending";
            cost = 0;
        }

        public abstract double CalcCost();

        public abstract void Start();

        public abstract void Complete();

        public void Display()
        {
            Console.WriteLine($"Serial: {Serial}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Cost: {Cost}");
        }
        // عدد الأجهزة المكتملة
        public static int CompletedCount { get; private set; }
    }
}
