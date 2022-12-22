using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransaccionesBancarias.Commons.Response
{
    public class RecordsResponse<T>
    {
        public bool HasItems
        {
            get
            {
                return Items != null && Items.Any();
            }
        }

        public IEnumerable<T>? Items { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }
    }
}
