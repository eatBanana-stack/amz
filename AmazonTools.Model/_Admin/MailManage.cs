using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
using System.Text.Json.Serialization;
using AmazonTools.Model;

namespace AmazonTools.Model._Admin
{
    /// <summary>
    /// 邮箱管理
    /// </summary>
	[Table("MailManages")]

    [Display(Name = "_Model.MailManage")]
    public class MailManage : BasePoco
    {
        [Display(Name = "_Model._MailManage._Mail")]
        [Comment("邮箱")]
        [RegularExpression("^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "Validate.{0}formaterror")]
        public string Mail { get; set; }
        [Display(Name = "_Model._MailManage._PassWord")]
        [Comment("密码")]
        public string PassWord { get; set; }

	}

}
