namespace TaskManagement.Models
{
    public class TaskModel
    {
        /// <summary>
        /// 任務編號
        /// </summary>
        public int TaskID { get; set; }

        /// <summary>
        /// 使用者編號
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// 任務名稱
        /// </summary>
        public string? TaskName { get; set; }

        /// <summary>
        /// 任務等級
        /// </summary>
        public string? Priority { get; set; }

        /// <summary>
        /// 任務狀態
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// 預計完成日
        /// </summary>
        public DateTime EstimatedTime { get; set; }

    }
}
