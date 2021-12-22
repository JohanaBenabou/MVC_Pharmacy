using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC.net.Models
{
    public class DB : IDB
    {
        private LoginContext Db;

        public DB()
        {
            Db = new LoginContext();
        }

        public async Task<Med> GetMedByName(string name)
        {
            var m = Db.Med.FirstOrDefaultAsync(x => x.name == name);
            Med m1 = await m;
            return m1;
        }

        public async Task AddDoc(Doctor d)
        {
            Db.Doctor.Add(d);
            await Db.SaveChangesAsync();
        }

        public async Task AddPharma(Pharma p)
        {
            Db.Pharma.Add(p);
            await Db.SaveChangesAsync();
        }

        public async Task AddMed(Med m)
        {
            Db.Med.Add(m); 
            await Db.SaveChangesAsync();

        }
        public async Task<List<Med>> GetMedList()
        {
            List<Med> m = await Db.Med.ToListAsync();
            return m;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            Debug.WriteLine("Start");
            var l = Db.User.ToListAsync();
            List<Users> l1 =  await l;
            Debug.WriteLine("Finish");
            return l1 ;

        }

        public List<Mirsham> GetMirshams()
        {
             return Db.Mirshams.ToList();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task AddUser(Users u)
        {
            Db.User.Add(u);
            Debug.WriteLine("Start");
            await Db.SaveChangesAsync();
            Debug.WriteLine("Finish");
        }
        public async Task<Users> GetUserByID(int id)
        {
            var u =   Db.User.FirstOrDefaultAsync(users => users.ID == id);
            Users user = await u;
            return user;
            
            
        }

        public Users GetUserByID1(int id)
        {
            Users user = Db.User.FirstOrDefault(users => users.ID == id);
            return user;

        }

        public async Task Addmirsham(Mirsham m)
        {
            Debug.WriteLine("Start Add");
            Db.Mirshams.Add(m);
            await Db.SaveChangesAsync();
            Debug.WriteLine("Finish Add");
        }

        public void Addmirsham1(Mirsham m)
        {
            Debug.WriteLine("Start Add");
            Db.Mirshams.Add(m);
            Db.SaveChanges();
            Debug.WriteLine("Finish Add");
        }

        public int GetNextMirshamNumber()
        {
            return (Db.Mirshams.ToList().Count + 1);
        }

        public async Task<List<Mirsham>> GetMirshamByPId(int id)
        {
            //List<Mirsham> l2 = new List<Mirsham>();
            var l = Db.Mirshams.Where(x => x.Patient == id).ToListAsync();
            /*var l1 = from b in Db.Mirshams where b.Patient == id select b;
            foreach(var item in l1)
            {
                l2.Add(item);
            }*/
            List<Mirsham> l2 = await l;
            return l2;
        }

        public List<Mirsham> GetMirshamByPId1(int id)
        {
            List<Mirsham> l2  = Db.Mirshams.Where(x => x.Patient == id).ToList();
            return l2;
        }

        public void UpdateM(Mirsham m)
        {
            
            m.isTake = true;
            Db.Entry(m).State = EntityState.Modified;
            Db.SaveChanges();
            string name = m.name;
            Med m1 = Db.Med.FirstOrDefault(x => x.name == name);
            m1.quantity -= m.quantity;
            Db.Entry(m1).State = EntityState.Modified;
            Db.SaveChanges();

        }

        public async Task UpdateMed(Med m, int quantity)
        {
            m.quantity += quantity;
            Db.Entry(m).State = EntityState.Modified;
            await  Db.SaveChangesAsync();
        }

        public Mirsham GetMirshamByID(int id)
        {
            var m1 = from b in Db.Mirshams where b.ID == id select b;
            Mirsham u = Db.Mirshams.FirstOrDefault(Mirsham => Mirsham.ID == id);
            return u;
        }
    }
}