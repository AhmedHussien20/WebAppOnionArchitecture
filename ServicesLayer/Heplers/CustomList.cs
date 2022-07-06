using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Heplers
{
    public class CustomListParam
    {
        private const int MaxPageSize = 99999;
        private int pageSize = 10;
        public int PageNumber { get; set; } = 1;
        public int? Status { get; set; }
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public string Search { get; set; }



    }
}
