using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.net.Models
{
    public class Pharma
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public String name { get; set; }
        public String Password { get; set; }

        public Pharma(int iD, string name, string password)
        {
            this.ID = iD;
            this.name = name;
            this.Password = password;
        }
        public Pharma()
        {

        }
    }
}