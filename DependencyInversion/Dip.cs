using System;
using System.IO;
using Solid.SingleResponsibility;

namespace Solid.DependencyInversion
{
    class Dip : IPrinciple
    {
        public string Principle()
        {
            var customer = new Customer(new FileLogger());
            customer.Add(new Database());
            
            return "Dependency Inversion";
        }

        internal class FileLogger
        {
            public void Handle(string error)
            {
                File.WriteAllText(@"C:\Error.txt", error);
            }
        }

        internal class Customer
        {
            private readonly FileLogger _fileLogger;

            public Customer(FileLogger fileLogger)
            {
                _fileLogger = fileLogger;
            }

            public void Add(Database db)
            {
                try
                {
                    db.Add();
                }
                catch (Exception error)
                {
                    _fileLogger.Handle(error.ToString());
                }
            }
        }
    }
}
