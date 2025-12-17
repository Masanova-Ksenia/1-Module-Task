using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork_40
{
    public interface IMediator
    {
        void Register(IModule module);
        void Notify(string sender, string eventName, object data);
    }
}
