using System;

namespace ПрактическаяРабота_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип документа: 1-отчёт, 2-резюме, 3-письмо, 4-счёт");
            string number = Console.ReadLine();
            DocumentCreator creator = null;
            switch (number)
            {
                case "1": 
                    creator = new ReportCreator();break;
                case "2":
                    creator = new ResumeCreator(); break;
                case "3":
                    creator = new LetterCreator(); break;
                case "4":
                    creator = new InvoiceCreator(); break;
                default:
                    creator = null; break;
            };
            if (creator != null)
            {
                Document doc = creator.CreateDocument();
                doc.Open();
            }
            else
            {
                Console.WriteLine("Неизвестный тип документа!");
            }
        }
    }
}