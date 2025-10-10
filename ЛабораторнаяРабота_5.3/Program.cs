using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_5._3
{
    public class Program
    {
        public static void Main()
        {
            Document doc1 = new Document("Original", "Main content");
            doc1.AddSection(new Section("Intro", "Welcome"));
            doc1.AddImage(new Image("image1.png"));
            doc1.AddTable(new Table(new string[,] { { "A", "B" }, { "1", "2" } }));

            DocumentManager manager = new DocumentManager();
            Document doc2 = manager.CreateDocument(doc1);
            doc2.Title = "Clone";
            doc2.AddSection(new Section("Extra", "Additional content"));

            doc1.SaveToFile("doc1.txt");
            doc2.SaveToFile("doc2.txt");

            Document loaded = Document.LoadFromFile("doc1.txt");

            Console.WriteLine("Original: " + doc1.Title);
            Console.WriteLine("Clone: " + doc2.Title);
            Console.WriteLine("Loaded: " + loaded.Title);
        }
    }
}
