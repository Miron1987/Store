using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternetStore.Models
{


    public class Product
    {
        // ID 
        public int Id { get; set; }
        // название 
        public string Name { get; set; }
        // цена
        public int Price { get; set; }
        // категория
        public string Category { get; set; }
    }



}