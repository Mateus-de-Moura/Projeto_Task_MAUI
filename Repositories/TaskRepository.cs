using APPFinanceiro;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAsk.Models;

namespace TAsk.Repositories
{
    public class TaskRepository
    {
        private LiteDatabase _database = new LiteDatabase($"Filename={Path.Combine(FileSystem.AppDataDirectory, "tarefas.db")};Connection=Shared");
        private readonly string CollectionName = "Tasks";

        public void AddTask(Tasks task)
        {
            var col = _database.GetCollection<Tasks>(CollectionName);
            col.Insert(task);
            col.EnsureIndex(a => a.start);
        }

        public void Delete(Tasks tasks)
        {
            var col = _database.GetCollection<Tasks>(CollectionName);
            col.Delete(tasks.Id);

        }      
        public List<Tasks> get()
        {
            try
            {
                var retorno = _database.GetCollection<Tasks>(CollectionName).Query().OrderBy(x => x.start).ToList();               
                return retorno;
               
            }
            catch (Exception ex)
            {

                return new List<Tasks>();
            }           
        }

        public void UpdateUser(Tasks task)
        {
            var col = _database.GetCollection<Tasks>(CollectionName);
            col.Update(task);
        }
    }
}
