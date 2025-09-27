using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_4
{
    public abstract class Document
    {
        public abstract void Open();
    }
    public class Report : Document
    {
        public override void Open()
        {
            Console.WriteLine("Открыт отчет");
        }
    }
    public class Resume : Document
    {
        public override void Open()
        {
            Console.WriteLine("Открыто резюме");
        }
    }
    public class Letter : Document
    {
        public override void Open()
        {
            Console.WriteLine("Открыто письмо");
        }
    }
    public class Invoice : Document
    {
        public override void Open()
        {
            Console.WriteLine("Открыт счет");
        }
    }
}
