using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products = new List<Product>();
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
        }

        public void AddProduct(Product p)
        {
            if (p != null)
                _products.Add(p);
        }

        public IReadOnlyList<Product> GetProducts()
        {
            return _products.AsReadOnly();
        }

        // shipping cost rule per spec: $5 if customer in USA, otherwise $35
        public decimal GetShippingCost()
        {
            return (_customer != null && _customer.IsInUSA()) ? 5m : 35m;
        }

        // total price = sum(product totals) + one-time shipping cost
        public decimal CalculateTotal()
        {
            decimal productsTotal = _products.Sum(p => p.GetTotalCost());
            return productsTotal + GetShippingCost();
        }

        // packing label lists name and product id for each product
        public string GetPackingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Packing Label:");
            foreach (var p in _products)
            {
                sb.AppendLine($"{p.GetName()} - {p.GetProductId()}");
            }
            return sb.ToString();
        }

        // shipping label lists customer name and address
        public string GetShippingLabel()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Shipping Label:");
            if (_customer != null)
            {
                sb.AppendLine(_customer.GetName());
                sb.AppendLine(_customer.GetAddress().GetFullAddress());
            }
            return sb.ToString();
        }

        // convenience display methods (used in Program.cs)
        public void DisplayPackingLabel()
        {
            Console.WriteLine(GetPackingLabel());
        }

        public void DisplayShippingLabel()
        {
            Console.WriteLine(GetShippingLabel());
        }
    }
}
