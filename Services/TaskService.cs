using System.Collections.Generic;
using mongo_dotnet_ep1.Models;
using MongoDB.Driver;

namespace mongo_dotnet_ep1.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMongoCollection<TaskModel> _tasks; 
        
        public TaskService(ITaskDataBaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName); 

            _tasks = database.GetCollection<TaskModel>(settings.TaskCollectionName);
        }

        public TaskModel Create(TaskModel task)
        {
            _tasks.InsertOne(task); 
            return task; 
        }

        public IList<TaskModel> Create(IList<TaskModel> task)
        {
            _tasks.InsertMany(task);
            return task;
        }

        public IList<TaskModel> Get()
        {
            return _tasks.Find(TaskModel => true).ToList();
        }

        public TaskModel Get(string id)
        {
            return _tasks.Find(task => task._id == id).FirstOrDefault();
        }

        public void Remove(TaskModel task)
        {
            _tasks.DeleteOne(task => task._id == task._id); 
        }

        public void Remove(string _id)
        {
            _tasks.DeleteOne(task => task._id == _id); 
        }

        public void Update(string id, TaskModel taskIn)
        {
            _tasks.ReplaceOne(x => x._id == taskIn._id, taskIn); 
        }
    }
}