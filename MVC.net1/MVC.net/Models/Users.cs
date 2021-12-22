using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC.net.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public String name { get; set; }
        public String job { get; set; }
        public String Password { get; set; }

        public Users(int iD, string name, string job, string password)
        {
            this.ID = iD;
            this.name = name;
            this.job = job;
            this.Password = password;
        }
        public Users()
        {

        }
    }
}