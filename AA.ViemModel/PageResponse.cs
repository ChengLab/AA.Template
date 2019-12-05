using System;
using System.Collections.Generic;
using System.Text;

namespace AA.ViemModel
{
   public class PageResponse<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<T> data { get; set; }
        public string error { get; set; }
    }
}
