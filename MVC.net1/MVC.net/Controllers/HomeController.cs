using MVC.net.Models;
using MVC.net.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.net.Controllers
{
    public class HomeController : Controller
    {
        public IDB db = new DB();
        // GET: Home
        public ActionResult Index()
        {
           
            return View();
        }
      
        public ActionResult Login()
        {
            return PartialView();
        }
        public ActionResult Register()
        {
            return PartialView();
        }
        //It works asynchronoius with the function addUser
        public ActionResult CreateUser()
        {
            int ID = int.Parse(Request.Form["ID1"]);
            string Name = Request.Form["Name"];
            string Job = Request.Form["Job"];
            string Password = Request.Form["password1"];
            Users u = new Users(ID, Name, Job, Password);
            db.AddUser(u);
            Debug.WriteLine("After");
            FormsAuthentication.SetAuthCookie(u.ID.ToString(), false);
            if (u.job.Equals("Doctor"))
            {
                Doctor d = new Doctor(u.ID, u.name, u.Password);
                db.AddDoc(d);
                return RedirectToAction("Index", "Doctor");
            }
            else if(u.job.Equals("Pharma"))
            {
                Pharma p = new Pharma(u.ID, u.name, u.Password);
                db.AddPharma(p);
                return RedirectToAction("Index", "Pharma");
            }

            return View("Error");


        }

       /* Synchronous task but need to change the GetAllUser fonction so it will return List<Users>
        * public ActionResult Login()
        {

            int ID = int.Parse(Request.Form["ID"]);
            string Password = Request.Form["password"];
            List<Users> l1 = db.GetAllUsers();
            foreach (Users s in l1)
            {
                if (s.ID == ID && s.Password.Equals(Password) && s.job.Equals("Doc"))
                {
                    FormsAuthentication.SetAuthCookie(s.ID.ToString(), false);
                    return RedirectToAction("Index", "Doctor");
                    //  return View("Doctor",l);
                }
                if (s.ID == ID && s.Password.Equals(Password) && s.job.Equals("Pharma"))
                {
                    FormsAuthentication.SetAuthCookie(s.ID.ToString(), false);
                    return RedirectToAction("Index", "Pharma");
                }
            }
            return View("Error");
        }
        
            */

        public async Task<ActionResult> Login1()
        {
           
            int ID = int.Parse(Request.Form["ID"]);
            string Password = Request.Form["password"];
             var l =  db.GetAllUsers();
             Debug.WriteLine("After");
            List<Users> l1 = await  l;
           // Users u = new Users(1, "Dyl", "Doctor", "d");
            //List<Users> l1 = new List<Users>();
           // l1.Add(u);
            foreach (Users s in l1)
            {
                if (s.ID == ID && s.Password.Equals(Password) && s.job.Equals("Doctor"))
                {
                    FormsAuthentication.SetAuthCookie(s.ID.ToString(), false);
                    return RedirectToAction("Index", "Doctor");
                  //  return View("Doctor",l);
                }
                if (s.ID == ID && s.Password.Equals(Password) && s.job.Equals("Pharma"))
                {
                    FormsAuthentication.SetAuthCookie(s.ID.ToString(), false);
                    return RedirectToAction("Index", "Pharma");
                }
            }
            return View("Error");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }
    }
}