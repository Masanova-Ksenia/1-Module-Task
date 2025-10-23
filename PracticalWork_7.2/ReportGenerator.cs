using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._2
{
    public abstract class ReportGenerator
    {
        protected readonly List<string> StepsLog = new List<string>();

        public void GenerateReport()
        {
            StepsLog.Clear();
            Logger.Log($"Начата генерация отчёта: {GetType().Name}");
            try
            {
                CollectData();
                AnalyzeData();
                FormatReport();
                Export();

                if (CustomerWantsSave())
                {
                    Save();
                }
                else if (CustomerWantsSendByEmail())
                {
                    SendByEmail();
                }
                else
                {
                    Logger.Log("Пользователь выбрал ни сохранять, ни отправлять — завершение без сохранения.");
                }

                Logger.Log($"Генерация отчёта {GetType().Name} завершена успешно.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Ошибка при генерации отчёта {GetType().Name}: {ex.Message}");
            }
            finally
            {
                foreach (var s in StepsLog) Logger.Log(s);
            }
        }

        protected virtual void CollectData()
        {
            StepsLog.Add("Сбор данных: выполнен");
        }

        protected virtual void AnalyzeData()
        {
            StepsLog.Add("Анализ данных: выполнен");
        }

        protected abstract void FormatReport();
        protected abstract void Export();
        protected abstract void Save();

        protected virtual bool CustomerWantsSave()
        {
            Console.Write("Сохранить отчёт на диск? (y/n): ");
            string input = Console.ReadLine()?.Trim().ToLower();
            while (input != "y" && input != "n")
            {
                Console.Write("Некорректный ввод. Введите 'y' или 'n': ");
                input = Console.ReadLine()?.Trim().ToLower();
            }
            return input == "y";
        }

        protected virtual bool CustomerWantsSendByEmail()
        {
            Console.Write("Отправить отчёт по электронной почте? (y/n): ");
            string input = Console.ReadLine()?.Trim().ToLower();
            while (input != "y" && input != "n")
            {
                Console.Write("Некорректный ввод. Введите 'y' или 'n': ");
                input = Console.ReadLine()?.Trim().ToLower();
            }
            return input == "y";
        }

        protected virtual void SendByEmail()
        {
            Console.Write("Введите адрес электронной почты для отправки: ");
            string email = Console.ReadLine()?.Trim();
            while (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                Console.Write("Некорректный адрес. Введите корректный e-mail: ");
                email = Console.ReadLine()?.Trim();
            }
            Logger.Log($"Отправка отчёта на {email} (симуляция)");
            StepsLog.Add($"Отправлено на {email}");
        }
    }
    public class PdfReport : ReportGenerator
    {
        private string content;
        private string filePath = "report.pdf";

        protected override void FormatReport()
        {
            content = $"PDF Report\nСгенерировано: {DateTime.Now}";
            StepsLog.Add("Форматирование PDF: выполнено");
        }

        protected override void Export()
        {
            try
            {
                File.WriteAllText(filePath, content, Encoding.UTF8);
                StepsLog.Add($"Экспорт PDF в {filePath}: выполнен");
            }
            catch (Exception ex)
            {
                throw new IOException($"Не удалось экспортировать PDF: {ex.Message}");
            }
        }

        protected override void Save()
        {
            Logger.Log($"Сохранён PDF в {Path.GetFullPath(filePath)}");
            StepsLog.Add($"Сохранение PDF: {filePath}");
        }
    }
    public class ExcelReport : ReportGenerator
    {
        private string[,] table;
        private string filePath = "report.xlsx";

        protected override void CollectData()
        {
            base.CollectData();
            table = new string[3, 2]
            {
            { "Показатель", "Значение" },
            { "Продажи", "1000" },
            { "Расходы", "400" }
            };
            StepsLog.Add("Сбор данных для Excel: выполнен");
        }

        protected override void FormatReport()
        {
            StepsLog.Add("Форматирование Excel: выполнено");
        }

        protected override void Export()
        {
            try
            {
                var sb = new StringBuilder();
                for (int r = 0; r < table.GetLength(0); r++)
                {
                    for (int c = 0; c < table.GetLength(1); c++)
                    {
                        sb.Append(table[r, c]);
                        if (c < table.GetLength(1) - 1) sb.Append("\t");
                    }
                    sb.AppendLine();
                }
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                StepsLog.Add($"Экспорт Excel (симуляция) в {filePath}: выполнен");
            }
            catch (Exception ex)
            {
                throw new IOException($"Не удалось экспортировать Excel: {ex.Message}");
            }
        }

        protected override void Save()
        {
            Logger.Log($"Excel файл сохранён: {Path.GetFullPath(filePath)}");
            StepsLog.Add($"Сохранение Excel: {filePath}");
        }

        protected override void SendByEmail()
        {
            Console.Write("Введите адрес для отправки Excel: ");
            string email = Console.ReadLine()?.Trim();
            while (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                Console.Write("Некорректный адрес. Введите корректный e-mail: ");
                email = Console.ReadLine()?.Trim();
            }
            Logger.Log($"Отправка Excel-файла на {email} (симуляция)");
            StepsLog.Add($"Excel отправлен на {email}");
        }
    }
    public class HtmlReport : ReportGenerator
    {
        private string html;
        private string filePath = "report.html";

        protected override void FormatReport()
        {
            html = $"<html><head><meta charset='utf-8'><title>Отчёт</title></head><body><h1>Отчёт</h1><p>Сгенерировано: {DateTime.Now}</p></body></html>";
            StepsLog.Add("Форматирование HTML: выполнено");
        }

        protected override void Export()
        {
            try
            {
                File.WriteAllText(filePath, html, Encoding.UTF8);
                StepsLog.Add($"Экспорт HTML в {filePath}: выполнен");
            }
            catch (Exception ex)
            {
                throw new IOException($"Не удалось экспортировать HTML: {ex.Message}");
            }
        }

        protected override void Save()
        {
            Logger.Log($"HTML сохранён: {Path.GetFullPath(filePath)}");
            StepsLog.Add($"Сохранение HTML: {filePath}");
        }
    }
    public class CsvReport : ReportGenerator
    {
        private string csv;
        private string filePath = "report.csv";

        protected override void CollectData()
        {
            base.CollectData();
            StepsLog.Add("Сбор данных для CSV: выполнен");
        }

        protected override void FormatReport()
        {
            var rows = new List<string>
        {
            "Показатель;Значение",
            "Продажи;1000",
            "Расходы;400"
        };
            csv = string.Join(Environment.NewLine, rows);
            StepsLog.Add("Форматирование CSV: выполнено");
        }

        protected override void Export()
        {
            try
            {
                File.WriteAllText(filePath, csv, Encoding.UTF8);
                StepsLog.Add($"Экспорт CSV в {filePath}: выполнен");
            }
            catch (Exception ex)
            {
                throw new IOException($"Не удалось экспортировать CSV: {ex.Message}");
            }
        }

        protected override void Save()
        {
            Logger.Log($"CSV сохранён: {Path.GetFullPath(filePath)}");
            StepsLog.Add($"Сохранение CSV: {filePath}");
        }
    }
}
