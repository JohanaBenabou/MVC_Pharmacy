using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.net.Models;

namespace MVC.net.ViewModel
{
    public class MirshamUser
    {
        public Users U { get; set; }
        public List<Mirsham> l1 { get; set; }
        public int pid { get; set; }

        public MirshamUser(Users u, List<Mirsham> l1, int pid)
        {
            U = u;
            this.l1 = l1;
            this.pid = pid;
        }
    }
}