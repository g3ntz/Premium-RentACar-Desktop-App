using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.BO.Entities
{
    public class User:BaseAuditObject
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastPasswordChangeDate { get; set; }
        public bool IsPasswordChanged { get; set; }

        public virtual Role Role { get; set; }

        // String Concatination
        public string StringUserID { get; set; }
        public string StringRoleName { get; set; }
        public string StringLastLoginDate { get; set; }
        public string StringLastPasswordChange{ get; set; }

        public void init()
        {
            StringUserID = $"#{this.UserID}";
            StringRoleName = this.Role.Name;
            StringLastLoginDate = this.LastLoginDate != DateTime.MinValue ? this.LastLoginDate.ToString("dd MMMM yyyy - H:mm") : "No Date";
            StringLastPasswordChange = this.LastPasswordChangeDate != DateTime.MinValue ? this.LastPasswordChangeDate.ToString("dd MMMM yyyy - H:mm") : "No Date";
        }
    }
}
