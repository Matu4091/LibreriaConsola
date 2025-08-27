using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaConsola.domain
{
    internal class Payment_Method
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Payment_Method()
        {
            Id = 0;
            Description = string.Empty;
        }
    }
}
