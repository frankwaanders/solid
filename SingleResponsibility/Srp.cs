using System;
using System.IO;

namespace Solid.SingleResponsibility
{
    class Srp : IPrinciple
    {
        public string Principle()
        {
            new Customer().Add(new Database());
            return "Single Responsibility";
        }
    }

    public class Customer
    {
        public void Add(Database db)
        {
            try
            {
                db.Add();
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Error.txt", ex.ToString());
            }
        }
    }
}
