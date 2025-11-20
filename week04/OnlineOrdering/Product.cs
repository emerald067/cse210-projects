using System;

namespace OnlineOrdering
{
    public class Product
    {
        private string _name;
        private string _productId;
        private decimal _price; // price per unit (use decimal for currency)
        private int _quantity;

        public Product(string name, string productId, decimal price, int quantity)
        {
            _name = name;
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetProductId()
        {
            return _productId;
        }

        public decimal GetPrice()
        {
            return _price;
        }

        public int GetQuantity()
        {
            return _quantity;
        }

        // responsibility: compute total cost for this product (price * quantity)
        public decimal GetTotalCost()
        {
            return _price * _quantity;
        }
    }
}
