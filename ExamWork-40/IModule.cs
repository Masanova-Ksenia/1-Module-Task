using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork_40
{
    public interface IModule
    {
        string Name { get; }
        void HandleEvent(string eventName, object data);
    }
}
