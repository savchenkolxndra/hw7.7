using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CarFacade carFacade = new CarFacade();

            // Запускаємо автомобіль
            Console.WriteLine("Запуск автомобіля:");
            carFacade.StartCar();

            // Зупиняємо автомобіль
            Console.WriteLine("\nЗупинка автомобіля:");
            carFacade.StopCar();

            Console.ReadKey();
        }
    }


    // Підсистема: Мотор
    class Engine
    {
        public void Start()
        {
            Console.WriteLine("Двигун увімкнено.");
        }

        public void Stop()
        {
            Console.WriteLine("Двигун вимкнено.");
        }
    }

    // Підсистема: Гальма
    class Brakes
    {
        public void Apply()
        {
            Console.WriteLine("Машина гальмує.");
        }
    }


    class GlassCleaner
    {
        public void SetOption(int option)
        {
            Console.WriteLine($"Очиснику скла встановлено {option} режим.");
        }
    }

    // Підсистема: Музика
    class Music
    {
        public void PlayMusic(string music)
        {
            Console.WriteLine($"Увімкнено музику: {music}");
        }

        public void StopMusic()
        {
            Console.WriteLine("Музика вимкнена.");
        }
    }

    // "Facade" 
    class CarFacade
    {
        private Engine engine;
        private Brakes brakes;
        private GlassCleaner cleaner;
        private Music music;

        public CarFacade()
        {
            engine = new Engine();
            brakes = new Brakes();
            cleaner = new GlassCleaner();
            music = new Music();
        }

        // Запуск автомобіля
        public void StartCar()
        {
            engine.Start();
            cleaner.SetOption(2);
            music.PlayMusic("радіо");
            Console.WriteLine("Автомобіль їде ");
        }

        // Зупинка автомобіля
        public void StopCar()
        {
            music.StopMusic();
            brakes.Apply();
            engine.Stop();
            Console.WriteLine("Автомобіль не їде ");
        }
    }

}