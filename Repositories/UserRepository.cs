using APPFinanceiro;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAsk.Models;
using TAsk.Repositories.interfaces;

namespace TAsk.Repositories
{
    public class UserRepository 
    {
        private  LiteDatabase _database = new LiteDatabase($"Filename={AppSettings.DatabasePatch};Connection=Shared");
        private readonly string CollectionName = "Users";

        public UserRepository()
        {
           
        }

        public void AddUser(Users user)
        {
            var col = _database.GetCollection<Users>(CollectionName);
            col.Insert(user);            
        }

        public void DeleteUser()
        {
            throw new NotImplementedException();
        }

        public bool GetUsers(string emaail, string senha)
        {
            var retorno =  _database.GetCollection<Users>(CollectionName).Query().Where(a => a.email == emaail && a.senha == senha).FirstOrDefault();
            if (retorno != null)
            {
                return true;
            }
            else
            {
                 return false;
            }
        }
        public Users get(string email) 
        {
          return  _database.GetCollection<Users>(CollectionName).Query().Where(a => a.email == email).FirstOrDefault();
        }      
        public Users GetUserManterLogado(string email, string Senha) 
        {
          return  _database.GetCollection<Users>(CollectionName).Query().Where(a => a.email == email && a.senha == Senha ).FirstOrDefault();
        }

        public void UpdateUser(Users user)
        {
            var col = _database.GetCollection<Users>(CollectionName);
            col.Update(user);
        }
    }
}
