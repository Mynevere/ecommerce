using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.OrderAggregate
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string firstName, string lastName, string street,
        string city, string state, string zipcode)
        {
                Firstname = firstName;
                Lastname = lastName;
                Street = street;
                City = city;
                State = state;
                Zipcode = zipcode;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}
