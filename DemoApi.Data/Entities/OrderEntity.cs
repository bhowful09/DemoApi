using System;
using System.Collections.Generic;

namespace DemoApi.Data.Entities
{
    public class OrderEntity
    {
        public OrderEntity()
        {
            OrderItem = new HashSet<OrderItemEntity>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }

        public CustomerEntity Customer { get; set; }
        public ICollection<OrderItemEntity> OrderItem { get; set; }
    }
}