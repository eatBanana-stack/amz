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
    /// 字典配置
    /// </summary>
	[Table("DicFields")]

    [Display(Name = "_Model.DicField")]
    public class DicField : TopBasePoco
    {
        [Display(Name = "_Model._DicField._DicFieldName")]
        [Comment("字典配置KEY")]
        public string DicFieldName { get; set; }
        [Display(Name = "_Model._DicField._DicFieldDes")]
        [Comment("字典配置VALUE")]
        public string DicFieldDes { get; set; }
        [Display(Name = "_Model._DicField._Order")]
        [Comment("排序")]
        public int? Order { get; set; }
        [Display(Name = "_Model._DicField._DicDef")]
        public DicDef DicDef { get; set; }
        [Display(Name = "_Model._DicField._DicDef")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public Guid? DicDefId { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._BelongingName")]
        [InverseProperty("BelongingName")]
        public List<AmazonUserInfo> AmazonUserInfo_BelongingName { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._SiteName")]
        [InverseProperty("SiteName")]
        public List<AmazonSiteInfo> AmazonSiteInfo_SiteName { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AmazonState")]
        [InverseProperty("AmazonState")]
        public List<AmazonSiteInfo> AmazonSiteInfo_AmazonState { get; set; }

	}

}
