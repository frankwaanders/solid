using System;
using System.Collections.Generic;

namespace Solid.Liskov
{
    class Lsp : IPrinciple
    {
        public string Principle()
        {
            ParseCustomers();
            return "Liskov Substitution";
        }
        
        public void ParseCustomers()
        {
            var database = new Database();
            var customers = new List<Customer>
            {
                new GoldCustomer(), 
                new SilverCustomer(), 
                new EnquiryCustomer()
            };

            foreach (var customer in customers)
            {
                customer.Add(database); // what happens here...?
            }
        }

        public class EnquiryCustomer : Customer
        {
            public override int Discount(int sales)
            {
                return BaseDiscount - (sales * 5);
            }

            public override void Add(Database db)
            {
                throw new Exception("Not allowed");
            }
        }
        
        public class GoldCustomer : Customer
        {
            public override int Discount(int sales)
            {
                return BaseDiscount - sales - 100;
            }
        }

        public class SilverCustomer : Customer
        {
            public override int Discount(int sales)
            {
                return BaseDiscount - sales - 50;
            }
        }
    }
}
