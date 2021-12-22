using MVC.net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.net.ViewModel
{
    public class MedUser
    {
        public Users user;
        public List<Med> m;

        public MedUser(Users user, List<Med> m)
        {
            this.user = user;
            this.m = m;
        }
    }
}