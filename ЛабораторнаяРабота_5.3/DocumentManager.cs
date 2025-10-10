using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_5._3
{
    public class DocumentManager
    {
        public Document CreateDocument(IPrototype prototype)
        {
            return (Document)prototype.Clone();
        }
    }
}
