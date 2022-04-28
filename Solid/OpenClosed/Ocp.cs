namespace Solid.OpenClosed
{
    public enum CustomerType
    {
        Consumer = 0,
        Business = 1,
        EnterpriseBusiness = 2
    }
    
    class Ocp : IPrinciple
    {
        public string Principle()
        {
            var customer = new Customer(CustomerType.Consumer);
            customer.Add(new CustomerDatabase());
            
            var businessCustomer = new Customer(CustomerType.Business);
            customer.Add(new CustomerDatabase());
            
            var enterpriseBusiness = new Customer(CustomerType.EnterpriseBusiness);
            customer.Add(new CustomerDatabase());

            return "Open for Extension, Closed for Modification";
        }
    }

    internal class Customer
    {
        private readonly CustomerType _type;

        public Customer(CustomerType type)
        {
            _type = type;
        }
        
        public virtual void Add(CustomerDatabase db)
        {
            if (_type == CustomerType.Consumer)
            {
                db.AddConsumer();
            } 
            else if (_type == CustomerType.Business)
            {
                db.AddBusiness();
            }
            else if (_type == CustomerType.EnterpriseBusiness)
            {
                db.AddEnterpriseBusiness();
            }
        }
    }
}
