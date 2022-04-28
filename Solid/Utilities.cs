using System;
using System.Collections.Generic;
using System.Text;

namespace Solid
{
    public class Customer
    {
        public int BaseDiscount = 10;

        public virtual int Discount(int sales)
        {
            return BaseDiscount - sales;
        }

        public virtual void Add(Database db)
        {
            db.Add();
        }
    }

    public class Database : IDatabase
    {
        public void Add() { }
        public void Read()
        {
            // detail implementation
        }

        public void Duplicate()
        {
            // detail implementation
        }

        public void AddExistingCustomer() { }

        public void AnotherExtension() { }
    }

    public class CustomerDatabase : IDatabase
    {
        public void AddConsumer()
        {
            // detail implementation
        }

        public void AddBusiness()
        {
            // detail implementation
        }

        public void AddEnterpriseBusiness()
        {
            // detail implementation
        }

        public void Add()
        {
            // should not be called, throw not implemented excecption
            throw new NotImplementedException();
        }

        public void Read()
        {
            // detail implementation
        }

        public void Duplicate()
        {
            // detail implementation
        }
    }

    public interface IDatabase
    {
        void Add();
        void Read();
        void Duplicate();
    }
}
