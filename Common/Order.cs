using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLayerArchitecture.Common;

namespace Common
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        // Додати Foreign Key для зв'язку з Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Зв'язок із деталями замовлення
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
