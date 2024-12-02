using System;

namespace Adapter
{
    // Система яку будемо адаптовувати
    class Helic
    {
        public void FlyStraight()
        {
            Console.WriteLine("Вертоліт летить прямо.");
        }

        public void ChangeDirection(string direction)
        {
            Console.WriteLine($"Вертоліт змінює напрямок на {direction}.");
        }
    }

    interface IVehicle
    {
        void DriveForward();
        void Turn(string direction);
    }

    // Клас для автомобіля
    class Car : IVehicle
    {
        public void DriveForward()
        {
            Console.WriteLine("Вантажівка рухається вперед.");
        }

        public void Turn(string direction)
        {
            Console.WriteLine($"Вантажівка повертає {direction}.");
        }
    }

    // Адаптер
    class HelicAdapter : IVehicle
    {
        private Helic _helic;

        public HelicAdapter(Helic helic)
        {
            _helic = helic;
        }

        // Перетворюємо політ на рух
        public void DriveForward()
        {
            _helic.FlyStraight();
        }

        // Перетворюємо зміну напрямку на поворот
        public void Turn(string direction)
        {
            _helic.ChangeDirection(direction);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Робота з автомобілем
            IVehicle car = new Car();
            car.DriveForward();
            car.Turn("ліворуч");

            // Робота з дроном через адаптер
            Helic helic = new Helic();
            IVehicle adaptedHelic = new HelicAdapter(helic);
            adaptedHelic.DriveForward();
            adaptedHelic.Turn("праворуч");

            Console.ReadKey();
        }
    }
}