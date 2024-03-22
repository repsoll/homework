using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.HomeWork
{
    public class Weather
    {
        public async Task RunAsync()
        {
            WeatherCenter weatherCenter = new WeatherCenter();

            weatherCenter.WeatherChanged += WeatherChanged;
            weatherCenter.TemperatureChanged += TemperatureChanged;
            weatherCenter.PreashureChanged += PreashureChanged;

            void WeatherChanged(int windSpeed)
            {
                Console.WriteLine($"Wind speed is {windSpeed} m/s");
            }
            void TemperatureChanged(int temp)
            {
                Console.WriteLine($"Temperature Changed {temp}");
            }
            void PreashureChanged(int preashure)
            {
                Console.WriteLine($"Preashure Changed {preashure} ");
            }

            await Task.Delay(-1);
        }
    }
}
