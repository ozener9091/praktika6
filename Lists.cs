using MobileDevicesClass;
using System;
using System.Collections.Generic;

namespace ListsClass
{
    public static class EnterNumber
    {
        static private int intNum;
        static private double doubleNum;
        public static int Int()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out intNum)) return intNum;
                else Console.Write("Ошибка ввода! Введите еще раз: ");
            }
        }
        public static double Double()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out doubleNum)) return doubleNum;
                else Console.Write("Ошибка ввода! Введите еще раз: ");
            }
        }
    }
    public class Lists
    {
        public static void CreateAndAddDevice(List<IPrintable> devices)
        {
            int choice, year, cameraSize, ramSize, batteryCapacity;
            double price, screenSize;
            string model, manufacturer, screenResolution, screenType, supportedFormats;
            IPrintable currentDevice;

            Console.WriteLine("Выберите тип девайса:\n" +
                              "1. MobileDevice\n" +
                              "2. Smartphone\n" +
                              "3. EBookReader\n" +
                              "Выбор: ");

            choice = EnterNumber.Int();

            Console.Write("Введите модель: ");
            model = Console.ReadLine();
            Console.Write("Введите производителя: ");
            manufacturer = Console.ReadLine();
            Console.Write("Введите цену: ");
            price = EnterNumber.Double();
            Console.Write("Введите год: ");
            year = EnterNumber.Int();

            try
            {
                switch (choice)
                {
                    case 1:
                        currentDevice = new MobileDevice(model, manufacturer, price, year);
                        devices.Add(currentDevice);
                        break;
                    case 2:
                        Console.Write("Введите размер экрана: ");
                        screenSize = EnterNumber.Double();
                        Console.Write("Введите разрешение экрана: ");
                        screenResolution = Console.ReadLine();
                        Console.Write("Введите разрешение камеры: ");
                        cameraSize = EnterNumber.Int();
                        Console.Write("Введите объём памяти: ");
                        ramSize = EnterNumber.Int();

                        currentDevice = new Smartphone(model, manufacturer, price, year, screenSize, screenResolution, cameraSize, ramSize);
                        devices.Add(currentDevice);
                        break;
                    case 3:
                        Console.Write("Введите размер экрана: ");
                        screenSize = EnterNumber.Double();
                        Console.Write("Введите тип экрана: ");
                        screenType = Console.ReadLine();
                        Console.Write("Введите поддерживающиеся форматы: ");
                        supportedFormats = Console.ReadLine();
                        Console.Write("Введите ёмкость аккумулятора: ");
                        batteryCapacity = EnterNumber.Int();

                        currentDevice = new EBookReader(model, manufacturer, price, year, screenSize, screenType, supportedFormats, batteryCapacity);
                        devices.Add(currentDevice);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        break;
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }

        public static void PrintDevices(List<IPrintable> devices)
        {
            foreach (var device in devices)
            {
                device.PrintInfo();
                Console.WriteLine("------------------------");
            }
        }
    }
}
