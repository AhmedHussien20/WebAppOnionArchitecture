using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DTOs
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public DateTime DateOrder { get; set; }
         
    }
}
