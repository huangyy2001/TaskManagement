namespace TaskManagement.Models
{
    public class UserModel
    {
        /// <summary>
        /// 使用者編號
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 使用者姓名
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 使用者email
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 使用者密碼
        /// </summary>
        public string? PasswordHash { get; set; }
        /// <summary>
        /// 登入成功
        /// </summary>
        public bool chack { get; set; }
    }
}
