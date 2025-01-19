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
        /// �n�J����
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// ���U����
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// �n�J����
        /// </summary>
        /// <returns></returns>
        public ActionResult Task()
        {
            return View();
        }

        /// <summary>
        /// ���U�ϥΪ�
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Register(UserModel model)
        {
            bool resut = await taskManagementService.InsertUser(model);
            if (resut)
            {
                return Json(new { success = true, message = "���U���\" });
            }
            else
            {
                return Json(new { success = true, message = "���b���w���U�L,�Ъ����n�J" });
            }

        }

        /// <summary>
        /// �n�J
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> Login(UserModel model)
        {
            UserModel result = await taskManagementService.CheckLoginUser(model);
            if (result.chack)
            {
                return Json(new { success = true, message = "�n�J���\", userid = result.UserID });
            }
            else
            {
                return Json(new { success = false, message = "email�αK�X���~" });
            }
        }

        /// <summary>
        /// �����ȦC��
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
        /// �������ȸ��
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
        /// �s�W/�s�����
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> SetTask(TaskModel model)
        {
            await taskManagementService.setTask(model);
            return Json(new { success = true, message = "�s�ɦ��\" });
        }

        /// <summary>
        /// �R������
        /// </summary>
        /// <param name="id">�����ѧO�X</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> DelTask(int id)
        {
            await taskManagementService.DelTask(id);
            return Json(new { success = true, message = "�R�����\" });
        }
    }
}

