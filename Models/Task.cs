using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAsk.Models
{
     public class Tasks
    {
        [BsonId]
        public int Id { get; set; }
        public string Description { get; set; }
        public string start { get; set; }
        public string finish { get; set; }
        public int IdUser { get; set; }

    }
}
