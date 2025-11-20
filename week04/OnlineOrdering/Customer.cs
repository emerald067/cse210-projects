using System;

namespace OnlineOrdering
{
    public class Customer
    {
        private string _name;
        private Address _address;

        public Customer(string name, Address address)
        {
            _name = name;
            _address = address;
        }

        public string GetName()
        {
            return _name;
        }

        public Address GetAddress()
        {
            return _address;
        }

        // responsibility: tell whether the customer lives in the USA (delegates to Address)
        public bool IsInUSA()
        {
            return _address != null && _address.IsInUSA();
        }
    }
}
