using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC.net.Models
{
    public class Mirsham
    {
        [Key]
        public int ID { get; set; }

        public int Doc { get; set; }

        [Required(ErrorMessage ="You have to enter Patient ID")]
        public int Patient { get; set; }

        public String name { get; set; }

        public int quantity { get; set; }

        public bool isTake { get; set; }

        public Mirsham(int iD, int docID, int pID, string name, bool isTake)
        {
            ID = iD;
            Doc = docID;
            Patient = pID;
            this.name = name;
            this.isTake = isTake;
        }

        public Mirsham(int iD, int doc, int patient, string name, int quantity, bool isTake)
        {
            ID = iD;
            Doc = doc;
            Patient = patient;
            this.name = name;
            this.quantity = quantity;
            this.isTake = isTake;
            //quantite rajoute 

        }

        public Mirsham()
        {

        }
    }
}