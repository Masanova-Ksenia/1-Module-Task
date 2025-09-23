using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДомашнееЗадание_4
{
    public abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle();
    }
    public class CarFactory : VehicleFactory
    {
        private readonly string _brand;
        private readonly string _model;
        private readonly string _fuelType;
        public CarFactory(string brand, string model, string fuelType)
        {
            _brand = brand;
            _model = model;
            _fuelType = fuelType;
        }
        public override IVehicle CreateVehicle()
        {
            return new Car(_brand, _model, _fuelType);
        }
    }
    public class MotorcycleFactory : VehicleFactory
    {
        private readonly string _type;
        private readonly int _engineVolume;
        public MotorcycleFactory(string type, int engineVolume)
        {
            _type = type;
            _engineVolume = engineVolume;
        }
        public override IVehicle CreateVehicle()
        {
            return new Motorcycle(_type, _engineVolume);
        }
    }
    public class TruckFactory : VehicleFactory
    {
        private readonly double _capacity;
        private readonly int _axles;
        public TruckFactory(double capacity, int axles)
        {
            _capacity = capacity;
            _axles = axles;
        }
        public override IVehicle CreateVehicle()
        {
            return new Truck(_capacity, _axles);
        }
    }
    public class BusFactory : VehicleFactory
    {
        private readonly int _seats;
        private readonly string _route;
        public BusFactory(int seats, string route)
        {
            _seats = seats;
            _route = route;
        }
        public override IVehicle CreateVehicle()
        {
            return new Bus(_seats, _route);
        }
    }
}
