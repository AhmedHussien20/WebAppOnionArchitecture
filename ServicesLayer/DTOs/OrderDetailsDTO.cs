using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer.DTOs
{
    public class OrderDetailsDTO
    {
        [Required(ErrorMessage = "ItemNo is Required")]
        public string ItemNo { get; set; }
        [Required(ErrorMessage = "ItemDescription is Required")]
        public string ItemDescription { get; set; }
        [Required(ErrorMessage = "Quantity is Required")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Total is Required")]
        public double Total { get; set; }
    }
}
