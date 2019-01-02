using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApi.Domain
{
    public class CustomerCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }
}