namespace Solid.InterfaceSegregation
{
    class Isp : IPrinciple
    {
        public string Principle()
        {
            ManipulateCustomers();
            return "Interface Segregation";
        }
        
        public void ManipulateCustomers()
        {
            var database = new Database();
            
            var customer = new Customer();
            customer.Add(database);

            var customerWithReadAndDupliate = new CustomerWithReadAndDuplicate();
            customerWithReadAndDupliate.Duplicate(database);
            customerWithReadAndDupliate.Add(database);
        }

        interface ICustomer
        {
            void Add(IDatabase database);
            void Read(IDatabase database);
            void Duplicate(IDatabase database);
        }

        public class Customer : ICustomer
        {
            public void Add(IDatabase database)
            {
                database.Add();
            }

            public void Read(IDatabase database)
            {
                database.Read();
            }

            public void Duplicate(IDatabase database)
            {
                database.Duplicate();
            }
        }

        public class CustomerWithReadAndDuplicate : ICustomer
        {
            public void Add(IDatabase database)
            {
                database.Add();
            }

            public void Read(IDatabase database)
            {
                database.Read();
            }

            public void Duplicate(IDatabase database)
            {
                database.Duplicate();
            }
        }
    }
}
