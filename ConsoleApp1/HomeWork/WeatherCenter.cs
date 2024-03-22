using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.HomeWork
{
    public class WeatherCenter
    {
        public Action<int> WeatherChanged;
        public Action<int> TemperatureChanged;
        public Action<int> PreashureChanged;

        public WeatherCenter()
        {
            Task.Run(CheckWeatherAsync);
            Task.Run(Checktemperatureasync);
            Task.Run(CheckPreasureAsync);
        }
       
        public async Task CheckWeatherAsync()
        {
            while (true)
            {
                var random = new Random();
                var windSpeed = random.Next(0, 41);
                WeatherChanged.Invoke(windSpeed);
                await Task.Delay(10000);
            }
        }

        public async Task Checktemperatureasync()
        {
           
            while (true)
            {
                var random = new Random();
                int temp = random.Next(-25, 55);
                TemperatureChanged.Invoke(temp);
                await Task.Delay(10000);
            }
        }

        public async Task CheckPreasureAsync()
        {
            
            while (true)
            {
                var random = new Random();
                int preashure = random.Next(680, 800);
                PreashureChanged.Invoke(preashure);
                await Task.Delay(10000);
            }
        }
    }

}
