using System;
using System.Text;

namespace OnlineOrdering
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _stateOrProvince;
        private string _country;

        public Address(string street, string city, string stateOrProvince, string country)
        {
            _street = street;
            _city = city;
            _stateOrProvince = stateOrProvince;
            _country = country;
        }

        public string GetStreet()
        {
            return _street;
        }

        public string GetCity()
        {
            return _city;
        }

        public string GetStateOrProvince()
        {
            return _stateOrProvince;
        }

        public string GetCountry()
        {
            return _country;
        }

        // determine whether the address is in USA (safe null check + normalization)
        public bool IsInUSA()
        {
            if (string.IsNullOrWhiteSpace(_country)) return false;
            var c = _country.Trim().ToLowerInvariant();
            return c == "usa" || c == "us" || c == "united states" || c == "united states of america";
        }

        // responsibility: produce a multi-line string representing this address
        public string GetFullAddress()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_street);
            sb.AppendLine($"{_city}, {_stateOrProvince}");
            sb.Append(_country);
            return sb.ToString();
        }
    }
}
