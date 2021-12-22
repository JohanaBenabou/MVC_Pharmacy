using MVC.net.Models;
using MVC.net.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace MVC.net.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        IDB db = new DB();
        // GET: Doctor
        public async Task<ActionResult> Index()
        {
           
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            return View("Doctor",user);
        }

        public async Task<ActionResult> AddMirsham()
        {
            int PID = int.Parse(Request.Form["PID"]);
            string Name = Request.Form["MN"];
            int quantity = int.Parse(Request.Form["quantity"]);
            int num = db.GetNextMirshamNumber();
            int did = int.Parse(HttpContext.User.Identity.Name);
            var med1 = db.GetMedByName(Name);
            Med med = await med1;
            if (med.quantity < quantity)
            {
                Users user1 = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
                List<Med> m2 = await db.GetMedList();
                MedUser m3 = new MedUser(user1, m2);
                return PartialView("QuantityError", m3);
            }
            Mirsham m = new Mirsham(num, did, PID, Name,quantity, false);
            await db.Addmirsham(m);
            List<Mirsham> l1 = await db.GetMirshamByPId(PID);
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            MirshamUser m1 = new MirshamUser(user,l1,PID);
            return PartialView("partielTable", m1);

        }

      /*  public ActionResult AddMirsham1(string pid, string name) { 
            int PID = int.Parse(pid);
            string Name = name;
            //  string date = Request.Form["date"];
            int num = db.GetNextMirshamNumber();
            int did = int.Parse(HttpContext.User.Identity.Name);
            Mirsham m = new Mirsham(num, did, PID, Name, false);
            db.Addmirsham1(m);
            List<Mirsham> l1 = db.GetMirshamByPId1(PID);
            Users user = db.GetUserByID1(int.Parse(HttpContext.User.Identity.Name));
            MirshamUser m1 = new MirshamUser(user, l1, PID);
            return PartialView("partielTable", m1);
        }
        */

            public async Task<ActionResult> ShowMirsham(string pid)
        {
            int PID = int.Parse(pid);
            List<Mirsham> l1 = await db.GetMirshamByPId(PID);
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            MirshamUser m1 = new MirshamUser(user, l1,PID);
            return PartialView("PartielTable", m1);
        }

        public async Task<ActionResult> AddMirsham2()
        {
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            List<Med> m = await db.GetMedList();
            MedUser m1 = new MedUser(user, m);
            return View("Add Mirsham", m1); ;
        }
        public async Task<ActionResult> ShowMirsham1()
        { 
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            return View("Show Mirsham", user); ;
        }
    }
}