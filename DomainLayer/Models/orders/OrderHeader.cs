using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer.Models.orders
{
    public class OrderHeader : BaseEntity
    {
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }

        //Navigation 
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
