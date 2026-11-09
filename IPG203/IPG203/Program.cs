
using IPG203.Models;
using IPG203.Services;
using IPG203.Utilities;

namespace IPG203
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCenter center = new ServiceCenter();

            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine(" Home Appliance Maintenance");
                Console.WriteLine("================================");
                Console.WriteLine("1. Add New Device");
                Console.WriteLine("2. View All Devices");
                Console.WriteLine("3. Start Maintenance");
                Console.WriteLine("4. Complete Maintenance");
                Console.WriteLine("5. Calculate Repair Costs");
                Console.WriteLine("6. View Completed Devices");
                Console.WriteLine("0. Exit");
                Console.WriteLine("================================");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDevice(center);
                        break;

                    case "2":
                        center.DisplayDevices();
                        break;

                    case "3":
                        ChangeMaintenanceStatus(center, false);
                        break;

                    case "4":
                        ChangeMaintenanceStatus(center, true);
                        break;

                    case "5":
                        center.CalculateCosts();
                        break;

                    case "6":
                        center.DisplayCompletedDevices();
                        Console.WriteLine(
                            $"Completed Devices: {Device.CompletedCount}"
                        );
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        // إضافة جهاز جديد
        static void AddDevice(ServiceCenter center)
        {
            Console.WriteLine("\nSelect Device Type:");
            Console.WriteLine("1. Refrigerator");
            Console.WriteLine("2. Washing Machine");
            Console.WriteLine("3. Air Conditioner");
            Console.Write("Choice: ");

            string type = Console.ReadLine();

            Console.Write("Serial Number: ");
            string serial = Console.ReadLine();

            Console.Write("Device Name: ");
            string name = Console.ReadLine();

            if (!DeviceValidator.IsValidSerial(serial) ||
                !DeviceValidator.IsValidName(name))
            {
                Console.WriteLine("Invalid device information!");
                return;
            }

            Device device = null;

            switch (type)
            {
                case "1":
                    device = new Fridge(serial, name);
                    break;

                case "2":
                    device = new Washer(serial, name);
                    break;

                case "3":
                    device = new AC(serial, name);
                    break;

                default:
                    Console.WriteLine("Invalid device type!");
                    return;
            }

            center.AddDevice(device);

            Console.WriteLine("Device added successfully!");
        }

        // تغيير حالة الصيانة
        static void ChangeMaintenanceStatus(
            ServiceCenter center,
            bool complete)
        {
            Console.Write("Enter Device Serial Number: ");
            string serial = Console.ReadLine();

            Device device = center.FindDevice(serial);

            if (device == null)
            {
                Console.WriteLine("Device not found!");
                return;
            }

            if (complete)
                device.Complete();
            else
                device.Start();
        }
    }
}
