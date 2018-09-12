using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();
            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            CurrentHumidityDisplay currentDisplay2 = new CurrentHumidityDisplay(weatherData);
            CurrentPressureDisplay currentDisplay3 = new CurrentPressureDisplay(weatherData);
            weatherData.setMeasurements(20, 60, 30);
            weatherData.setMeasurements(23, 55, 20);
            weatherData.setMeasurements(25, 50, 25);
            weatherData.setMeasurements(22, 52, 30);
            weatherData.setMeasurements(20, 70, 40);
            Console.ReadLine();
        }
    }
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObserver();

    }
    public interface IObserver
    {
        void update(float temp, float humidity, float pressure);
    }
    interface IdisplayElement
    {
        void display();
    }
    public class WeatherData : ISubject
    {
        private List<IObserver> observerList = new List<IObserver>();
        private float temperature;
        private float humidity;
        private float pressure;
        public void RegisterObserver(IObserver observer)
        {
            observerList.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            observerList.Remove(observer);
        }
        public void NotifyObserver()
        {
            foreach (IObserver observer in observerList)
            {
                observer.update(temperature, humidity, pressure);
            }
        }

        void getTemperature()
        {

        }
        void getHumidty()
        {

        }
        void meassurementsChanged()
        {
            NotifyObserver();
        }
        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            meassurementsChanged();
        }
    }
    public class CurrentConditionsDisplay : IObserver,IdisplayElement
    {
        private float temperature;
        private ISubject weatherData;
        public CurrentConditionsDisplay (ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;

            display();
        }
        public void display()
        {
            Console.WriteLine("Current conditions: " + temperature + "F degrees");
        }
    }
    public class CurrentHumidityDisplay: IObserver, IdisplayElement
    {
        private float humidity;
        private ISubject weatherData;
        public CurrentHumidityDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public void update(float temp, float humidity, float pressure)
        {

            this.humidity = humidity;
            display();

        }
        public void display()
        {
            Console.WriteLine("Current humidity: " + humidity);
        }
    }
    public class CurrentPressureDisplay : IObserver, IdisplayElement
    {
        private float pressure;
        private ISubject weatherData;
        public CurrentPressureDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        public void update(float temperature, float humidity, float pressure)
        {
            this.pressure = pressure;
            display();
        }
        public void display()
        {
            Console.WriteLine("Current pressure: " + pressure+"Pa");
        }
    }
}
