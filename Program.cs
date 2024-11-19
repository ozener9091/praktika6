using System;
using System.Collections.Generic;
using MobileDevicesClass;
using ListsClass;

namespace MobileDevices
{

    public class Program
    {

        public static void Main()
        {
            var devices = new List<IPrintable>();
            int choice;
            bool done = false;
            while (!done)
            {
                Console.WriteLine("1. Добавить\n" +
                                  "2. Вывести на экран\n" +
                                  "3. Выйти\n" +
                                  "Выбор: ");

                choice = EnterNumber.Int();

                switch (choice)
                {
                    case 1:
                        Lists.CreateAndAddDevice(devices);
                        break;
                    case 2:
                        Lists.PrintDevices(devices);
                        break;
                    case 3:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        break;
                }
            }
        }
    }
}
