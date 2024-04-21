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

            weatherCenter.TemperatureChanged += temp => { Console.WriteLine($"Temperature: {temp}"); }; 
            weatherCenter.PreashureChanged += preashure => { Console.WriteLine($"Preashure: {preashure}"); }; 
            weatherCenter.WeatherChanged += windSpeed => { Console.WriteLine($"Wind speed is {windSpeed} m/s"); }; 

            await Task.Delay(-1);
        }
    }
}
