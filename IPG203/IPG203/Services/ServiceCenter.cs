using System;
using System.Collections.Generic;
using System.Text;
using IPG203.Models;
using System.Collections.Generic;

namespace IPG203.Services
{
    public class ServiceCenter
    {
        private List<Device> devices = new List<Device>();

        
        // إضافة جهاز للمركز
        public void AddDevice(Device device)
        {
            devices.Add(device);
            device.StatusChanged += OnStatusChanged;
        }

        // عرض جميع الأجهزة
        public void DisplayDevices()
        {
            foreach (Device device in devices)
            {
                device.Display();
                Console.WriteLine("--------------------");
            }
        }

        // حساب تكاليف جميع الأجهزة
        public void CalculateCosts()
        {
            foreach (Device device in devices)
            {
                Console.WriteLine(
                    $"{device.Name}: {device.CalcCost()}"
                );
            }
        }
        // متابعة تغيير حالة الجهاز
        private void OnStatusChanged(string serial, string status)
        {
            Console.WriteLine(
                $"Device {serial} status changed to: {status}"
            );
        }
        // البحث عن جهاز باستخدام الرقم التسلسلي
        public Device FindDevice(string serial)
        {
            foreach (Device device in devices)
            {
                if (device.Serial == serial)
                    return device;
            }

            return null;
        }
        // عرض الأجهزة المكتملة
        public void DisplayCompletedDevices()
        {
            foreach (Device device in devices)
            {
                if (device.Status == "Completed")
                {
                    device.Display();
                    Console.WriteLine("--------------------");
                }
            }
        }
    }
}