namespace mongo_dotnet_ep1.Models
{
    public class TaskDataBaseSettings : ITaskDataBaseSettings
    {
        public string TaskCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITaskDataBaseSettings
    {
        public string TaskCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}