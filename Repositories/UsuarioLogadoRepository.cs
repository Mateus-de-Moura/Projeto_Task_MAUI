using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAsk.Models;

namespace TAsk.Repositories
{
     public class UsuarioLogadoRepository
    {
        private LiteDatabase _database = new LiteDatabase($"Filename={Path.Combine(FileSystem.AppDataDirectory, "UsersLogados.db")};Connection=Shared");
        private readonly string CollectionName = "UserLOg";

        public (UserLogado,bool) user() 
        {
            try
            {
                var User = _database.GetCollection<UserLogado>(CollectionName).Query().FirstOrDefault();
                if (User == null) return (null,false);

                return (User, true);
                
            }
            catch (Exception )
            { 
                return (new UserLogado(),false);
            }
        }
        public void Add(UserLogado user) 
        {
            var col = _database.GetCollection<UserLogado>(CollectionName);
            col.Insert(user);
        }
        public void Delete() 
        {
            var col = _database.GetCollection<UserLogado>(CollectionName);
            col.DeleteAll();
        }
    }
}
