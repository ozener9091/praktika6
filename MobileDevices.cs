using System;

namespace MobileDevicesClass
{
    public enum TypeOfDevices
    {
        MobileDevice,
        Smartphone,
        EBookReader
    }
    public interface IPrintable
    {
        void PrintInfo();
    }
    public class MobileDevice : IPrintable
    {
        protected TypeOfDevices TYPE_OF_DEVICE = TypeOfDevices.MobileDevice;
        private string _model;
        private string _manufacturer;
        private double _price;
        private int _year;

        //Конструктор
        public MobileDevice(string model, string manufacturer, double price, int year)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Year = year;

        }

        //Метод вывода в консоль информации
        public void PrintInfo()
        {
            Console.WriteLine(
                $"Тип устройства: {TYPE_OF_DEVICE}\n" +
                $"Модель: {Model}\n" +
                $"Производитель: {Manufacturer}\n" +
                $"Цена: {Price} Руб\n" +
                $"Год: {Year}");
        }

        //Свойства
        public string Model
        {
            get { return _model; }
            set
            {
                if (string.IsNullOrEmpty(value)) { throw new NullReferenceException("Название модели не может быть пустым."); }
                _model = value;
            }
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if (string.IsNullOrEmpty(value)) { throw new ArgumentException("Название модели не может быть пустым."); }
                _manufacturer = value;
            }
        }

        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0) { throw new ArgumentException("Цена не может быть отрицательной."); }
                _price = value;
            }
        }

        public int Year
        {
            get { return _year; }
            set
            {
                int currentYear = 2024;
                if (value < 1980 || value > currentYear) { throw new ArgumentException($"Год должен быть между 1980 и {currentYear}."); }
                _year = value;
            }
        }

    }

    public class Smartphone : MobileDevice, IPrintable
    {
        private double _screenSize;
        private string _screenResolution;
        private int _cameraSize;
        private int _ramSize;

        //Конструктор
        public Smartphone(string model, string manufacturer, double price, int year,
            double screenSize, string screenResolution, int cameraSize, int ramSize) : base(model, manufacturer, price, year)
        {
            TYPE_OF_DEVICE = TypeOfDevices.Smartphone;
            ScreenSize = screenSize;
            ScreenResolution = screenResolution;
            CameraSize = cameraSize;
            RamSize = ramSize;
        }

        //Метод вывода в консоль информации
        public new void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine(
                $"Размер экрана: {ScreenSize} дюймах\n" +
                $"Разрешение экрана: {ScreenResolution}\n" +
                $"Камера: {CameraSize} МП\n" +
                $"Память: {RamSize} ГБ");

        }

        // Свойства
        public double ScreenSize
        {
            get { return _screenSize; }
            set
            {
                if (value <= 0) { throw new NullReferenceException("Размер экрана должен быть положительным."); }
                _screenSize = value;
            }
        }

        public string ScreenResolution
        {
            get { return _screenResolution; }
            set
            {
                if (string.IsNullOrEmpty(value)) { throw new NullReferenceException("Разрешение экрана не может быть пустым."); }
                _screenResolution = value;
            }
        }

        public int CameraSize
        {
            get { return _cameraSize; }
            set
            {
                if (value <= 0) { throw new NullReferenceException("Разрешение камеры должно быть положительным."); }
                _cameraSize = value;
            }
        }

        public int RamSize
        {
            get { return _ramSize; }
            set
            {
                if (value <= 0) { throw new NullReferenceException("Память должна быть положительной."); }
                _ramSize = value;
            }
        }
    }

    public class EBookReader : MobileDevice, IPrintable
    {
        private double _screenSize;
        private string _screenType;
        private string _supportedFormats;
        private int _batteryCapacity;


        public EBookReader(string model, string manufacturer, double price, int year,
            double screenSize, string screenType, string supportedFormats, int batteryCapacity)
            : base(model, manufacturer, price, year)
        {
            TYPE_OF_DEVICE = TypeOfDevices.EBookReader;
            ScreenSize = screenSize;
            ScreenType = screenType;
            SupportedFormats = supportedFormats;
            BatteryCapacity = batteryCapacity;
        }

        public new void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine(
                $"Размер экрана: {ScreenSize} дюймов\n" +
                $"Тип экрана: {ScreenType} \n" +
                $"Поддерживающиеся форматы: {SupportedFormats}\n" +
                $"Ёмкость аккумулятора: {BatteryCapacity} mAh");
        }


        //Свойства
        public double ScreenSize
        {
            get { return _screenSize; }
            set
            {
                if (value <= 0) { throw new NullReferenceException("Размер экрана должен быть положительным."); }
                _screenSize = value;
            }
        }
        public string ScreenType
        {
            get { return _screenType; }
            set
            {
                if (string.IsNullOrEmpty(value)) { throw new NullReferenceException("Тип экрана не может быть пустым."); }
                _screenType = value;
            }
        }
        public string SupportedFormats
        {
            get { return _supportedFormats; }
            set
            {
                if (string.IsNullOrEmpty(value)) { throw new NullReferenceException("Поддерживаемые форматы не могут быть пустыми."); }
                _supportedFormats = value;
            }
        }
        public int BatteryCapacity
        {
            get { return _batteryCapacity; }
            set
            {
                if (value <= 0) { throw new NullReferenceException("Ёмкость аккумулятора должна быть положительной."); }
                _batteryCapacity = value;
            }
        }

    }
}
