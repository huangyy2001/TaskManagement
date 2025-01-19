using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using TaskManagement.Interface;
using TaskManagement.Models;

namespace TaskManagement.Dac
{
    public class TaskManagementDac : _Dac, ITaskManagementDac
    {
        private readonly IConfiguration _configuration;

        public TaskManagementDac(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }


        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns>userId</returns>
        public async Task AddUser(UserModel model)
        {
            string sql = @"INSERT INTO Users (
                                UserName, 
                                Email, 
                                PasswordHash
                            )VALUES (
                                @UserName, 
                                @Email, 
                                @PasswordHash
                            );";

            await ExecuteAsync(sql, model);
        }

        /// <summary>
        /// 取得使用者資訊
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UserModel> GetLoginUser(UserModel model)
        {
            string sql = @"SELECT UserID,
                                  UserName,
                                  PasswordHash
                            FROM Users (nolock)
                            WHERE Email=@EMAIL";

            return (await QueryAsync<UserModel>(sql, model)).FirstOrDefault();
        }

        /// <summary>
        /// 取得任務列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<TaskModel>> GetTaskList(TaskQueryModel model)
        {
            string sql = @"SELECT TaskID,
                                  TaskName,
                                  Priority,
                                  Status,
                                  EstimatedTime
                            FROM Tasks (nolock)
                            WHERE UserID = @UserID";

            return (await QueryAsync<TaskModel>(sql, model)).ToList();
        }

        /// <summary>
        /// 取得任務資料
        /// </summary>
        /// <param name="id">任務識別碼</param>
        /// <returns></returns>
        public async Task<TaskModel> GetTask(int id)
        {
            string sql = @"SELECT TaskID,
                                  TaskName,
                                  Priority,
                                  Status,
                                  EstimatedTime
                            FROM Tasks (nolock)
                            WHERE TaskID = @TaskID";

            return (await QueryAsync<TaskModel>(sql, new { TaskID = id })).FirstOrDefault();
        }

        /// <summary>
        /// 新增任務
        /// </summary>
        /// <param name="model"></param>
        /// <returns>userId</returns>
        public async Task InsertTask(TaskModel model)
        {
            string sql = @"INSERT INTO Tasks (
                              UserID,
                              TaskName,
                              Priority,
                              Status,
                              EstimatedTime
                            )VALUES (
                              @UserID,
                              @TaskName,
                              @Priority,
                              @Status,
                              @EstimatedTime
                            );";

            await ExecuteAsync(sql, model);
        }

        /// <summary>
        /// 編輯任務
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateTask(TaskModel model)
        {
            string sql = @"UPDATE Tasks
                           SET  TaskName = @TaskName,
                                Priority= @Priority,
                                Status = @Status,
                                EstimatedTime = @EstimatedTime
                           WHERE TaskID = @TaskID";

            await ExecuteAsync(sql, model);
        }

        /// <summary>
        /// 刪除任務
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteTask(int id)
        {
            string sql = @"DELETE Tasks
                           WHERE TaskID = @TaskID";

            await ExecuteAsync(sql, new { TaskID = id });
        }


    }
}
