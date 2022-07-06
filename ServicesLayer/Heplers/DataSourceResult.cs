using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Heplers
{
    public class DataSourceResult<T> where T : class
    {
        public List<T> Data { get; set; }
        public int Total { get; set; }
    }
}
