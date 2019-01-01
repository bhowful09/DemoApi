using System.Collections.Generic;

namespace DemoApi.Data.Entities
{
    public class ProductEntity
    {
        public ProductEntity()
        {
            OrderItem = new HashSet<OrderItemEntity>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public SupplierEntity Supplier { get; set; }
        public ICollection<OrderItemEntity> OrderItem { get; set; }
    }
}