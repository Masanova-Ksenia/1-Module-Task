using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_6._2
{
    public interface IObserver
    {
        void Update(decimal usdToKztRate);
    }
}
