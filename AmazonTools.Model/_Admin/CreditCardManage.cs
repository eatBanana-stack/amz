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
    /// 信用卡管理
    /// </summary>
	[Table("CreditCardManages")]

    [Display(Name = "_Model.CreditCardManage")]
    public class CreditCardManage : BasePoco
    {
        [Display(Name = "_Model._CreditCardManage._CreditCard")]
        [Comment("卡号")]
        public string CreditCard { get; set; }
        [Display(Name = "_Model._CreditCardManage._SecurityCode")]
        [Comment("安全码")]
        public string SecurityCode { get; set; }
        [Display(Name = "_Model._CreditCardManage._ValidityPeriod")]
        [Comment("有效期")]
        public string ValidityPeriod { get; set; }

	}

}
