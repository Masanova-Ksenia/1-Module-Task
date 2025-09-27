using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_4
{
    public abstract class TransportFactory
    {
        public abstract ITransport CreateTransport(string Model, int Speed);
    }
    public class CarFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Car { Model = model, Speed = speed };
        }
    }
    public class MotorcycleFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Motorcycle { Model = model, Speed = speed };
        }
    }
    public class PlaneFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Plane { Model = model, Speed = speed };
        }
    }
    public class BicycleFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Bicycle { Model = model, Speed = speed };
        }
    }
}
