using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.net.Models
{
    public class Med
    {
        [Key]
        public string name { get; set; }

        public int quantity { get; set; }

        public Med(string name,int quant)
        {
            this.name = name;
            quantity = quant;
        }

        public Med(string name)
        {
            this.name = name;
        }

        public Med()
        {
        }
    }
}