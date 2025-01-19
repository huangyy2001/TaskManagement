using TaskManagement.Models;

namespace TaskManagement.Interface
{
    public interface ITaskManagementService
    {
        Task<UserModel> CheckLoginUser(UserModel userModel);
        Task DelTask(int id);
        Task<TaskModel> GetTaskById(int id);
        Task<List<TaskModel>> GetTaskList(TaskQueryModel model);
        Task<bool> InsertUser(UserModel userModel);
        Task setTask(TaskModel model);
    }
}
