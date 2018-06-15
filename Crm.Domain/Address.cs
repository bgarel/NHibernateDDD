
namespace Crm.Domain
{
    public class Address
    {
        public string Street { get; }

        public string City { get; }

        public string Country { get; }

        protected Address()
        {
        }

        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }
    }
}
