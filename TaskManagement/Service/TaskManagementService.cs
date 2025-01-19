using TaskManagement.Interface;
using TaskManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManagement.Service
{
    public class TaskManagementService : ITaskManagementService
    {
        private ITaskManagementDac dac;

        public TaskManagementService(ITaskManagementDac dac)
        {
            this.dac = dac;
        }

        /// <summary>
        /// 新增人員
        /// </summary>
        /// <param name="userModel"></param>
        public async Task<bool> InsertUser(UserModel userModel)
        {
            UserModel user = await dac.GetLoginUser(userModel);

            //如果email沒有註冊過
            if (user == null)
            {
                await dac.AddUser(userModel);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 登入驗證
        /// </summary>
        /// <param name="userModel"></param>
        public async Task<UserModel> CheckLoginUser(UserModel userModel)
        {
            UserModel result = await dac.GetLoginUser(userModel);

            //驗證使用者密碼是否正確
            result.chack = userModel.PasswordHash == result.PasswordHash ? true : false;

            return result;
        }

        /// <summary>
        /// 取得任務列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<List<TaskModel>> GetTaskList(TaskQueryModel model)
        {
            var result = await dac.GetTaskList(model);

            DateTime currentDate = DateTime.Today;

            // 每日任務
            if (model.Kind == "daily")
            {
                return result.Where(t => t.EstimatedTime == currentDate).ToList();
            }//每周任務
            else
            {
                // 如果是星期日，將 DayOfWeek 設為 7
                int dayOfWeek = (int)currentDate.DayOfWeek == 0 ? 7 : (int)currentDate.DayOfWeek;

                // 計算本週的週一
                var startOfWeek = currentDate.AddDays(-dayOfWeek + (int)DayOfWeek.Monday);

                // 週日
                var endOfWeek = startOfWeek.AddDays(6);
                return result.Where(t => t.EstimatedTime >= startOfWeek && t.EstimatedTime <= endOfWeek).ToList();
            }
        }
        /// <summary>
        /// 取得任務資料
        /// </summary>
        /// <param name="id">任務識別碼</param>
        /// <returns></returns>
        public async Task<TaskModel> GetTaskById(int id)
        {
            var result = await dac.GetTask(id);
            return result;
        }

        /// <summary>
        /// 新增/編輯任務
        /// </summary>
        /// <param name="model"></param>
        public async Task setTask(TaskModel model)
        {
            //新增(判斷有無id)
            if (model.TaskID == 0)
            {
                await dac.InsertTask(model);
            }//編輯
            else
            {
                await dac.UpdateTask(model);
            }
        }

        /// <summary>
        /// 刪除任務
        /// </summary>
        /// <param name="id">任務識別碼</param>
        public async Task DelTask(int id)
        {
            await dac.DeleteTask(id);
        }



    }
}
