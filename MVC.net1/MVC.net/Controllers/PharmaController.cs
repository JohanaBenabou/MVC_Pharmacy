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
    public class PharmaController : Controller
    {
        IDB db = new DB();
        // GET: Pharma
        public async Task<ActionResult> Index()
        {
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            return View("Pharma", user);
        }

        public async Task<ActionResult> ShowMirsham()
        {
            int PID = int.Parse(Request.Form["PID1"]);
            List<Mirsham> l1 =await  db.GetMirshamByPId(PID);
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            MirshamUser m1 = new MirshamUser(user, l1,PID);
            return PartialView("Pharma1", m1);
        }

        public async Task<ActionResult> UpdateMirsham(string mid)
        {
            int id1 = int.Parse(mid);
            Debug.WriteLine(id1);
            Mirsham m = db.GetMirshamByID(id1);
            db.UpdateM(m);
            List<Mirsham> l1 = await  db.GetMirshamByPId(m.Patient);
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            MirshamUser m1 = new MirshamUser(user, l1,m.Patient);
            return PartialView("Pharma1", m1);
           
        }

        
        public async  Task<ActionResult> ShowTable(int id)
        {
            List<Mirsham> l1 = await db.GetMirshamByPId(id);
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            MirshamUser m1 = new MirshamUser(user, l1, id);
            return PartialView("PatientMirhsam", m1);
        }

        public async Task<ActionResult> ShowMirsham1()
        {
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            return View("ShowMirsham1",user);
        }

        public async Task<ActionResult> AddMed()
        {
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            List<Med> m = await db.GetMedList();
            MedUser m1 = new MedUser(user, m);
            return View("AddMed", m1);
        }

        public async Task<ActionResult> AddMed1()
        {
            string name = Request.Form["Med"];
            int count = int.Parse(Request.Form["Count"]);
            Med m = new Med(name, count);
            await db.AddMed(m);
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            return View("Pharma",user);
        }

        public async Task<ActionResult> UpdateMed()
        {
            string name = Request.Form["MN"];
            int quantity = int.Parse(Request.Form["quantity"]);
            var m = db.GetMedByName(name);
            Med m1 = await m;
            await db.UpdateMed(m1, quantity);
            Users user = await db.GetUserByID(int.Parse(HttpContext.User.Identity.Name));
            return View("Pharma", user);

        }
    }
}