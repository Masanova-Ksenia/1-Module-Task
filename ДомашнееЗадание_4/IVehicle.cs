using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_4
{
    public interface IVehicle
    {
        void Drive();
        void Refuel();
    }
    public class Car : IVehicle
    {
        public string Brand { get; }
        public string Model { get; }
        public string FuelType { get; }
        public Car(string brand, string model, string fuelType)
        {
            Brand = brand;
            Model = model;
            FuelType = fuelType;
        }
        public void Drive()
        {
            Console.WriteLine($"Автомобиль {Brand} {Model} едет.");
        }
        public void Refuel()
        {
            Console.WriteLine($"Автомобиль {Brand} {Model} заправляется топливом: {FuelType}.");
        }
    }
    public class Motorcycle : IVehicle
    {
        public string Type { get; }
        public int EngineVolume { get; }
        public Motorcycle(string type, int engineVolume)
        {
            Type = type;
            EngineVolume = engineVolume;
        }
        public void Drive()
        {
            Console.WriteLine($"Мотоцикл ({Type}, {EngineVolume} куб.см) едет.");
        }
        public void Refuel()
        {
            Console.WriteLine($"Мотоцикл ({Type}) заправляется бензином.");
        }
    }
    public class Truck : IVehicle
    {
        public double Capacity { get; }
        public int Axles { get; }
        public Truck(double capacity, int axles)
        {
            Capacity = capacity;
            Axles = axles;
        }
        public void Drive()
        {
            Console.WriteLine($"Грузовик с грузоподъемностью {Capacity} тонн и {Axles} осями едет.");
        }
        public void Refuel()
        {
            Console.WriteLine("Грузовик заправляется дизельным топливом.");
        }
    }
    public class Bus : IVehicle
    {
        public int Seats { get; }
        public string Route { get; }
        public Bus(int seats, string route)
        {
            Seats = seats;
            Route = route;
        }
        public void Drive()
        {
            Console.WriteLine($"Автобус на маршруте {Route} с кол-вом мест ({Seats}) едет.");
        }
        public void Refuel()
        {
            Console.WriteLine("Автобус заправляется газом или дизелем.");
        }
    }
}
