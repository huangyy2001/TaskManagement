namespace TaskManagement.Models
{
    public class TaskQueryModel
    {
        /// <summary>
        /// 使用者ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 每日/每周
        /// </summary>
        public string? Kind { get; set; }
    }
}
