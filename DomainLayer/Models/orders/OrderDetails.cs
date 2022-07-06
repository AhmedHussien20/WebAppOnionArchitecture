
namespace DomainLayer.Models.orders
{
    public class OrderDetails:BaseEntity
    {
        public int OrderID { get; set; }
        public string ItemNo { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }   

        public virtual OrderHeader OrderHeader { get; set; }    
    }
}
