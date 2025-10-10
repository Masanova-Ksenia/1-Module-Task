using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛабораторнаяРабота_5._3
{
    public interface IPrototype
    {
        IPrototype Clone();
    }
    public class Section : IPrototype
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Section(string title, string text)
        {
            Title = title;
            Text = text;
        }
        public IPrototype Clone()
        {
            return new Section(Title, Text);
        }
    }
    public class Image : IPrototype
    {
        public string Url { get; set; }

        public Image(string url)
        {
            Url = url;
        }
        public IPrototype Clone()
        {
            return new Image(Url);
        }
    }
    public class Table : IPrototype
    {
        public string[,] Data { get; set; }
        public Table(string[,] data)
        {
            Data = (string[,])data.Clone();
        }

        public IPrototype Clone()
        {
            return new Table(Data);
        }
    }
    public class Document : IPrototype
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Section> Sections { get; set; } = new List<Section>();
        public List<Image> Images { get; set; } = new List<Image>();
        public List<Table> Tables { get; set; } = new List<Table>();
        public Document(string title, string content)
        {
            Title = title;
            Content = content;
        }
        public void AddSection(Section section)
        {
            Sections.Add(section);
        }
        public void AddImage(Image image)
        {
            Images.Add(image);
        }
        public void AddTable(Table table)
        {
            Tables.Add(table);
        }
        public IPrototype Clone()
        {
            Document clone = new Document(Title, Content);
            foreach (var section in Sections)
                clone.AddSection((Section)section.Clone());
            foreach (var image in Images)
                clone.AddImage((Image)image.Clone());
            foreach (var table in Tables)
                clone.AddTable((Table)table.Clone());
            return clone;
        }
        public void SaveToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Title: " + Title);
                writer.WriteLine("Content: " + Content);
                foreach (var section in Sections)
                    writer.WriteLine("Section: " + section.Title + " - " + section.Text);
                foreach (var image in Images)
                    writer.WriteLine("Image: " + image.Url);
                foreach (var table in Tables)
                {
                    writer.WriteLine("Table:");
                    for (int i = 0; i < table.Data.GetLength(0); i++)
                    {
                        for (int j = 0; j < table.Data.GetLength(1); j++)
                            writer.Write(table.Data[i, j] + "\t");
                        writer.WriteLine();
                    }
                }
            }
        }
        public static Document LoadFromFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            Document doc = new Document(lines[0].Replace("Title: ", ""), lines[1].Replace("Content: ", ""));
            return doc;
        }
    }
}
