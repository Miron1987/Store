using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetStore.Models
{
    public class Buyer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
}