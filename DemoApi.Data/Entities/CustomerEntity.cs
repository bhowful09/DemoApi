using System;
using System.Collections.Generic;

namespace DemoApi.Data.Entities
{
    public class CustomerEntity
    {
        public CustomerEntity()
        {
            Order = new HashSet<OrderEntity>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public ICollection<OrderEntity> Order { get; set; }
    }
}