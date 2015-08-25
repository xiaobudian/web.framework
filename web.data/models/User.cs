using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.data.models
{
    public class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }
        [Key]
        public int UserID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "必填")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "{2}到{1}个字符")]
        public string UserName { get; set; }



        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "必填")]
        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        //[Required(ErrorMessage = "必填")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "{1}到{0}个字符")]
        [Display(Name = "显示名")]
        public string DisplayName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        //[Required(ErrorMessage = "必填")]
        [Display(Name = "邮箱")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistrationTime { get; set; }

        /// <summary>
        /// 上次登陆时间
        /// </summary>
        public Nullable<DateTime> LoginTime { get; set; }

        /// <summary>
        /// 上次登陆IP
        /// </summary>
        public string LoginIP { get; set; }

        public string GroupName { get; set; }

        public int Status { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}