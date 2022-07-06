using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.DTOs
{
    public class AddOrderDTO
    {
        [Required(ErrorMessage = "Customer Name is Required")]
        [MaxLength(50, ErrorMessage = "Max Length 50")]
        [MinLength(3, ErrorMessage = "Min Length 3")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Date order is Required")]
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }

       
        public List<OrderDetailsDTO> OrderDetails { get; set; }
    }

   
}
