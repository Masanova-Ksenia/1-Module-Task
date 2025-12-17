using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWork_40
{
    public class EventMediator : IMediator
    {
        private readonly Dictionary<string, IModule> _modules = new();
        private readonly Dictionary<string, List<string>> _scenarios;
        public EventMediator(Dictionary<string, List<string>> scenarios)
        {
            _scenarios = scenarios;
        }
        public void Register(IModule module)
        {
            _modules[module.Name] = module;
        }
        public void Notify(string sender, string eventName, object data)
        {
            string key = $"{sender}.{eventName}";
            if (!_scenarios.ContainsKey(key))
                return;
            foreach (var targetModule in _scenarios[key])
            {
                if (_modules.ContainsKey(targetModule))
                {
                    _modules[targetModule].HandleEvent(eventName, data);
                }
            }
        }
    }
}
