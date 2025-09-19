using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_1
{
    public class Garage
    {
        public string Name { get; }
        private List<Vehicle> vehicles;
        public Garage(string name)
        {
            Name = name;
            vehicles = new List<Vehicle>();
        }
        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            Console.WriteLine($"В гараж '{Name}' добавлено: {vehicle}");
        }
        public void RemoveVehicle(Vehicle vehicle)
        {
            if (vehicles.Remove(vehicle))
            {
                Console.WriteLine($"Из гаража '{Name}' удалено: {vehicle}");
            }
            else
            {
                Console.WriteLine($"Транспорт {vehicle} не найден в гараже '{Name}'.");
            }
        }
        public IEnumerable<Vehicle> GetVehicles() => vehicles;
        public override string ToString()
        {
            return $"Гараж '{Name}' | Транспортных средств: {vehicles.Count}";
        }
    }
}