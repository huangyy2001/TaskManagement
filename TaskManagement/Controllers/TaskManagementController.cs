using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interface;
using TaskManagement.Models;
using TaskManagement.Service;

namespace TaskManagement.Controllers
{
    public class TaskManagementController : Controller
    {
        private ITaskManagementService taskManagementService;

        public TaskManagementController(ITaskManagementService taskManagementService)
        {
            this.taskManagementService = taskManagementService;
        }

        /// <summary>
        /// 登入頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 註冊頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 登入頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult Task()
        {
            return View();
        }

        /// <summary>
        /// 註冊使用者
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Register(UserModel model)
        {
            bool resut = await taskManagementService.InsertUser(model);
            if (resut)
            {
                return Json(new { success = true, message = "註冊成功" });
            }
            else
            {
                return Json(new { success = true, message = "此帳號已註冊過,請直接登入" });
            }

        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Login(UserModel model)
        {
            UserModel result = await taskManagementService.CheckLoginUser(model);
            if (result.chack)
            {
                return Json(new { success = true, message = "登入成功", userid = result.UserID });
            }
            else
            {
                return Json(new { success = false, message = "email或密碼錯誤" });
            }
        }

        /// <summary>
        /// 取任務列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> GetTaskList(TaskQueryModel model)
        {
            List<TaskModel> result = await taskManagementService.GetTaskList(model);
            return Json(result);
        }

        /// <summary>
        /// 取的任務資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetTaskDetails(int id)
        {
            var task = await taskManagementService.GetTaskById(id);
            return Json(task);
        }

        /// <summary>
        /// 新增/編輯任務
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> SetTask(TaskModel model)
        {
            await taskManagementService.setTask(model);
            return Json(new { success = true, message = "存檔成功" });
        }

        /// <summary>
        /// 刪除任務
        /// </summary>
        /// <param name="id">任務識別碼</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> DelTask(int id)
        {
            await taskManagementService.DelTask(id);
            return Json(new { success = true, message = "刪除成功" });
        }
    }
}

