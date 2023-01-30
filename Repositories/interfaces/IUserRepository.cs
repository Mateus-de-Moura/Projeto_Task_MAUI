using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAsk.Models;

namespace TAsk.Repositories.interfaces
{
    public interface IUserRepository
    {
        public bool GetUser(string emaail, string senha);
        public void AddUser(Users user);
        public void UpdateUser();
        public void DeleteUser();
    }
}
