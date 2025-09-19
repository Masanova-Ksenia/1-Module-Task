using System;
using System.Collections.Generic;
using System.Linq;

namespace Практическая_работа_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Toyota", "Camry", 2020, 4, "Автомат");
            Car car2 = new Car("BMW", "X5", 2022, 5, "Механика");
            Motorcycle moto1 = new Motorcycle("Yamaha", "R1", 2019, "Спортбайк", false);
            Motorcycle moto2 = new Motorcycle("Honda", "Gold Wing", 2021, "Туристический", true);

            Garage garage1 = new Garage("Гараж №1");
            Garage garage2 = new Garage("Гараж №2");

            garage1.AddVehicle(car1);
            garage1.AddVehicle(moto1);

            garage2.AddVehicle(car2);
            garage2.AddVehicle(moto2);

            Fleet fleet = new Fleet();
            fleet.AddGarage(garage1);
            fleet.AddGarage(garage2);

            fleet.ShowFleet();

            garage1.RemoveVehicle(car1);
            fleet.RemoveGarage(garage2);

            fleet.ShowFleet();
        }
    }
}
