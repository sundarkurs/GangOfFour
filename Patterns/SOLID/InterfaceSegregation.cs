using System;
using static System.Console;

namespace Patterns.SOLID
{

    public class Document
    {
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Printer : IPrinter
    {
        public void Print(Document d)
        {
            Console.WriteLine("Print..");
        }
    }

    public class Scanner : IScanner
    {
        public void Scan(Document d)
        {
            Console.WriteLine("Scan..");
        }
    }

    // One way of implementing multiple functionalities
    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            Console.WriteLine("Print..");
        }

        public void Scan(Document d)
        {
            Console.WriteLine("Scan..");
        }
    }

    // Another way of doing it
    public interface IMultiFunctionDevice : IPrinter, IScanner //
    {

    }
    
    public struct MultiFunctionMachine : IMultiFunctionDevice
    {
        // compose this out of several modules
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            if (printer == null)
            {
                throw new ArgumentNullException(paramName: nameof(printer));
            }
            if (scanner == null)
            {
                throw new ArgumentNullException(paramName: nameof(scanner));
            }
            this.printer = printer;
            this.scanner = scanner;
        }

        // Decorator
        public void Print(Document d)
        {
            printer.Print(d);
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
        }
    }

    public class InterfaceSegregation
    {
        static void Run()
        {
            IPrinter printer = new Printer();
            IScanner scanner = new Scanner();
            var doc = new Document();

            IMultiFunctionDevice multiFunc = new MultiFunctionMachine(printer, scanner);

            printer.Print(doc);
            scanner.Scan(doc);
            multiFunc.Print(doc);
            multiFunc.Scan(doc);

            Console.WriteLine("..");

        }

        //static void Main(string[] args)
        //{
        //    Run();
        //}
    }
}
