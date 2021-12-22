using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.net.Models
{
  public  interface IDB : IDisposable
    { 
        Task AddUser(Users u);
        Task<List<Users>> GetAllUsers();
        List<Mirsham> GetMirshams();
        Task<Users> GetUserByID(int id);
        Users GetUserByID1(int id);
        Task Addmirsham(Mirsham m);
        void Addmirsham1(Mirsham m);
        int GetNextMirshamNumber();
        Task<List<Mirsham>> GetMirshamByPId(int id);
        List<Mirsham> GetMirshamByPId1(int id);
        void UpdateM(Mirsham id);
        Mirsham GetMirshamByID(int id);
        Task<List<Med>> GetMedList();
        Task AddMed(Med m);
        Task AddPharma(Pharma p);
        Task AddDoc(Doctor d);
        Task<Med> GetMedByName(string name);
        Task UpdateMed(Med m, int quantity);


    }
}
