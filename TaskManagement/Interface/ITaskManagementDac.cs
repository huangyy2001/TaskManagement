using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface ITaskManagementDac
    {
        Task AddUser(UserModel user);
        Task DeleteTask(int id);
        Task<UserModel> GetLoginUser(UserModel model);
        Task<TaskModel> GetTask(int id);
        Task<List<TaskModel>> GetTaskList(TaskQueryModel model);
        Task InsertTask(TaskModel model);
        Task UpdateTask(TaskModel model);
    }
}
