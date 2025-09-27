using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПрактическаяРабота_4
{
    public abstract class DocumentCreator
    {
        public abstract Document CreateDocument();
    }
    public class ReportCreator : DocumentCreator
    {
        public override Document CreateDocument() => new Report();
    }
    public class ResumeCreator : DocumentCreator
    {
        public override Document CreateDocument() => new Resume();
    }
    public class LetterCreator : DocumentCreator
    {
        public override Document CreateDocument() => new Letter();
    }
    public class InvoiceCreator : DocumentCreator
    {
        public override Document CreateDocument() => new Invoice();
    }
}
