using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._1
{
    public abstract class ReportDecorator : IReport
    {
        protected IReport _report;
        public ReportDecorator(IReport report)
        {
            _report = report;
        }
        public virtual string Generate()
        {
            return _report.Generate();
        }
    }
    public class DateFilterDecorator : ReportDecorator
    {
        private DateTime _startDate;
        private DateTime _endDate;
        public DateFilterDecorator(IReport report, DateTime startDate, DateTime endDate) : base(report)
        {
            _startDate = startDate;
            _endDate = endDate;
        }
        public override string Generate()
        {
            string baseReport = base.Generate();
            var sb = new StringBuilder();
            sb.AppendLine($"[Фильтр по датам: {_startDate:dd.MM.yyyy} - {_endDate:dd.MM.yyyy}]");
            sb.AppendLine();
            if (_report is SalesReport salesReport)
            {
                var filteredSales = salesReport.GetSales()
                    .Where(s => s.Date >= _startDate && s.Date <= _endDate)
                    .ToList();

                sb.AppendLine("Отфильтрованный отчет по продажам");
                sb.AppendLine();
                foreach (var sale in filteredSales)
                {
                    sb.AppendLine(sale.ToString());
                }
                sb.AppendLine();
                sb.AppendLine($"Количество продаж в периоде: {filteredSales.Count}");
                sb.AppendLine($"Общая сумма: {filteredSales.Sum(s => s.Amount)}");
            }
            else if (_report is UserReport userReport)
            {
                var filteredUsers = userReport.GetUsers()
                    .Where(u => u.RegistrationDate >= _startDate && u.RegistrationDate <= _endDate)
                    .ToList();

                sb.AppendLine("Отфильтрованный отчет по пользователям");
                sb.AppendLine();
                foreach (var user in filteredUsers)
                {
                    sb.AppendLine(user.ToString());
                }
                sb.AppendLine();
                sb.AppendLine($"Пользователей зарегистрировано в периоде: {filteredUsers.Count}");
            }
            else
            {
                sb.Append(baseReport);
            }

            return sb.ToString();
        }
    }
    public class SortingDecorator : ReportDecorator
    {
        public enum SortCriteria
        {
            ByDate,
            ByAmount,
            ByName
        }
        private SortCriteria _criteria;
        public SortingDecorator(IReport report, SortCriteria criteria)
            : base(report)
        {
            _criteria = criteria;
        }
        public override string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[Сортировка: {GetCriteriaName()}]");
            sb.AppendLine();
            if (_report is SalesReport salesReport)
            {
                var sortedSales = _criteria switch
                {
                    SortCriteria.ByDate => salesReport.GetSales().OrderBy(s => s.Date).ToList(),
                    SortCriteria.ByAmount => salesReport.GetSales().OrderByDescending(s => s.Amount).ToList(),
                    _ => salesReport.GetSales()
                };
                sb.AppendLine("Отсортированный отчет по продажам");
                sb.AppendLine();
                foreach (var sale in sortedSales)
                {
                    sb.AppendLine(sale.ToString());
                }
                sb.AppendLine();
                sb.AppendLine($"Общее количество продаж: {sortedSales.Count}");
                sb.AppendLine($"Общая сумма: {sortedSales.Sum(s => s.Amount)}");
            }
            else if (_report is UserReport userReport)
            {
                var sortedUsers = _criteria switch
                {
                    SortCriteria.ByDate => userReport.GetUsers().OrderBy(u => u.RegistrationDate).ToList(),
                    SortCriteria.ByName => userReport.GetUsers().OrderBy(u => u.Name).ToList(),
                    _ => userReport.GetUsers()
                };

                sb.AppendLine("Отсортированный отчет по пользователям");
                sb.AppendLine();
                foreach (var user in sortedUsers)
                {
                    sb.AppendLine(user.ToString());
                }
                sb.AppendLine();
                sb.AppendLine($"Общее количество пользователей: {sortedUsers.Count}");
            }
            else
            {
                sb.Append(base.Generate());
            }

            return sb.ToString();
        }
        private string GetCriteriaName()
        {
            return _criteria switch
            {
                SortCriteria.ByDate => "По дате",
                SortCriteria.ByAmount => "По сумме",
                SortCriteria.ByName => "По имени",
                _ => "Без сортировки"
            };
        }
    }
    public class CsvExportDecorator : ReportDecorator
    {
        public CsvExportDecorator(IReport report) : base(report) { }
        public override string Generate()
        {
            string baseReport = _report.Generate();
            return baseReport + "\n\nОтчёт экспортирован в формате CSV.";
        }
    }
    public class PdfExportDecorator : ReportDecorator
    {
        public PdfExportDecorator(IReport report) : base(report) { }
        public override string Generate()
        {
            string baseReport = _report.Generate();
            return baseReport + "\n\nОтчёт экспортирован в формате PDF.";
        }
    }
    public class AmountFilterDecorator : ReportDecorator
    {
        private decimal _minAmount;
        private decimal _maxAmount;
        public AmountFilterDecorator(IReport report, decimal minAmount, decimal maxAmount)
            : base(report)
        {
            _minAmount = minAmount;
            _maxAmount = maxAmount;
        }
        public override string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[Фильтр по сумме: {_minAmount} - {_maxAmount}]");
            sb.AppendLine();
            if (_report is SalesReport salesReport)
            {
                var filteredSales = salesReport.GetSales()
                    .Where(s => s.Amount >= _minAmount && s.Amount <= _maxAmount)
                    .ToList();

                sb.AppendLine("Отчет по продажам, отфильтрованный по сумме");
                sb.AppendLine();
                foreach (var sale in filteredSales)
                {
                    sb.AppendLine(sale.ToString());
                }
                sb.AppendLine();
                sb.AppendLine($"Количество продаж: {filteredSales.Count}");
                sb.AppendLine($"Общая сумма: {filteredSales.Sum(s => s.Amount)}");
            }
            else
            {
                sb.Append(base.Generate());
            }
            return sb.ToString();
        }
    }
    public class StatusFilterDecorator : ReportDecorator
    {
        private string _status;
        public StatusFilterDecorator(IReport report, string status)
            : base(report)
        {
            _status = status;
        }
        public override string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[Фильтр по статусу: {_status}]");
            sb.AppendLine();
            if (_report is UserReport userReport)
            {
                var filteredUsers = userReport.GetUsers()
                    .Where(u => u.Status.Equals(_status, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                sb.AppendLine("Отчет по пользователям, отфильтрованный по статусу");
                sb.AppendLine();
                foreach (var user in filteredUsers)
                {
                    sb.AppendLine(user.ToString());
                }
                sb.AppendLine();
                sb.AppendLine($"Пользователей со статусом '{_status}': {filteredUsers.Count}");
            }
            else
            {
                sb.Append(base.Generate());
            }
            return sb.ToString();
        }
    }
}
