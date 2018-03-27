using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HTHAplication.Areas.Admin.Models
{
    public class PasswordModel
    {
        [Key]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời bạn nhập password")]
        public string OldPassword { set; get; }

        [Required(ErrorMessage = "Mời bạn nhập mật khẩu mới")]
        public string NewPassword { set; get; }
        [Required(ErrorMessage = "Gõ lại mật khẩu mới")]
        public string RepeatPassword { set; get; }
    }
}