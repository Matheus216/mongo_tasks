using MongoDB.Driver;
using mongo_dotnet_ep1.Models;
using System.Collections.Generic;

namespace mongo_dotnet_ep1.Services
{
    public interface ITaskService
    {
        IList<TaskModel> Get();
        TaskModel Get(string id);
        TaskModel Create(TaskModel task);
        IList<TaskModel> Create(IList<TaskModel> task);
        void Update(string id, TaskModel taskIn); 
        void Remove(TaskModel task);
        void Remove(string _id);
    }
}