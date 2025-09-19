using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практическая_работа_1
{
    public class Fleet
    {
        private List<Garage> garages;
        public Fleet()
        {
            garages = new List<Garage>();
        }
        public void AddGarage(Garage garage)
        {
            garages.Add(garage);
            Console.WriteLine($"Добавлен {garage}");
        }
        public void RemoveGarage(Garage garage)
        {
            if (garages.Remove(garage))
            {
                Console.WriteLine($"Удален {garage}");
            }
        }
        public IEnumerable<Vehicle> FindVehicles(string searchTerm)
        {
            return garages.SelectMany(g => g.GetVehicles())
                          .Where(v => v.Brand.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                      v.Model.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
        }
        public void ShowFleet()
        {
            Console.WriteLine("Автопарк:");
            foreach (var garage in garages)
            {
                Console.WriteLine(garage);
                foreach (var vehicle in garage.GetVehicles())
                {
                    Console.WriteLine("   " + vehicle);
                }
            }
        }
    }
}