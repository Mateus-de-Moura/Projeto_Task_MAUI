using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk.Models
{
    public class UserLogado
    {
        [BsonId]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int IdUser { get; set; }
    }
}
