using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;
using System.Text.Json.Serialization;
using AmazonTools.Model;
using AmazonTools.Model._Admin;

namespace AmazonTools.Model._Admin
{
    /// <summary>
    /// 站点信息
    /// </summary>
	[Table("AmazonSiteInfos")]

    [Display(Name = "_Model.AmazonSiteInfo")]
    public class AmazonSiteInfo : BasePoco
    {
        [Display(Name = "_Model._AmazonSiteInfo._SiteName")]
        [Comment("站点")]
        [RefDicName(Name = "站点")]
        public DicField SiteName { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._SiteName")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [Comment("站点")]
        public Guid? SiteNameId { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._Mail")]
        [Comment("邮箱")]
        [RegularExpression("^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "Validate.{0}formaterror")]
        public string Mail { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._MailPassWord")]
        [Comment("邮箱密码")]
        public string MailPassWord { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._CreditCard")]
        [Comment("信用卡")]
        public string CreditCard { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._SecurityCode")]
        [Comment("安全码")]
        public string SecurityCode { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._ValidityPeriod")]
        [Comment("有效期")]
        public string ValidityPeriod { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._Phone")]
        [Comment("手机号")]
        [RegularExpression("^[1][3456789][0-9]{9}$", ErrorMessage = "Validate.{0}formaterror")]
        public string Phone { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AmazonState")]
        [Comment("状态")]
        [RefDicName(Name = "站点状态")]
        public DicField AmazonState { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AmazonState")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [Comment("状态")]
        public Guid? AmazonStateId { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AmazonUser")]
        [Comment("客户")]
        public AmazonUserInfo AmazonUser { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AmazonUser")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [Comment("客户")]
        public Guid? AmazonUserId { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AccountPassWord")]
        [Comment("账户密码")]
        public string AccountPassWord { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._GooogleVerification")]
        [Comment("谷歌验证器")]
        public FileAttachment GooogleVerification { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._GooogleVerification")]
        [Comment("谷歌验证器")]
        public Guid? GooogleVerificationId { get; set; }

	}

}
