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
    /// 字典集
    /// </summary>
	[Table("DicDefs")]

    [Display(Name = "_Model.DicDef")]
    public class DicDef : TopBasePoco
    {
        [Display(Name = "_Model._DicDef._DicName")]
        [Comment("字典集名")]
        public string DicName { get; set; }
        [Display(Name = "_Model._DicField._DicDef")]
        [InverseProperty("DicDef")]
        public List<DicField> DicField_DicDef { get; set; }

	}

}
