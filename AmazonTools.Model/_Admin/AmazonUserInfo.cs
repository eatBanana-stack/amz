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
    /// 客户信息
    /// </summary>
	[Table("AmazonUserInfos")]

    [Display(Name = "_Model.AmazonUserInfo")]
    public class AmazonUserInfo : BasePoco
    {
        [Display(Name = "_Model._AmazonUserInfo._FaUserNameCn")]
        [Comment("姓名中文")]
        public string FaUserNameCn { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._FaUserNameUs")]
        [Comment("姓名拼音")]
        public string FaUserNameUs { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._FaIdCard")]
        [Comment("身份证")]
        public string FaIdCard { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._FaBornTime")]
        [Comment("出生时间")]
        public string FaBornTime { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._FaEndTime")]
        [Comment("有效时间")]
        public string FaEndTime { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseCn")]
        [Comment("执照中文")]
        public string LicenseCn { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseUs")]
        [Comment("执照拼音")]
        public string LicenseUs { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseCode")]
        [Comment("执照代码")]
        public string LicenseCode { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicensePhoto")]
        [Comment("营业执照")]
        public FileAttachment LicensePhoto { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicensePhoto")]
        [Comment("营业执照")]
        public Guid? LicensePhotoId { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._IDCardPhotoZ")]
        [Comment("身份证正")]
        public FileAttachment IDCardPhotoZ { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._IDCardPhotoZ")]
        [Comment("身份证正")]
        public Guid? IDCardPhotoZId { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._IDCardPhotoF")]
        [Comment("身份证反")]
        public FileAttachment IDCardPhotoF { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._IDCardPhotoF")]
        [Comment("身份证反")]
        public Guid? IDCardPhotoFId { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._License")]
        [Comment("执照时间")]
        public string License { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._MailingAddress")]
        [Comment("邮寄地址")]
        public string MailingAddress { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._MailingZipCode")]
        [Comment("邮寄邮编")]
        public string MailingZipCode { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._BelongingName")]
        [Comment("代理")]
        [RefDicName(Name = "代理")]
        public DicField BelongingName { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._BelongingName")]
        [Comment("代理")]
        public Guid? BelongingNameId { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._IDcardheld")]
        [Comment("身份证手持")]
        public List<AmazonUserInfoIDcardheld> IDcardheld { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._BusinessLicenseHeld")]
        [Comment("营业执照手持")]
        public List<AmazonUserInfoBusinessLicenseHeld> BusinessLicenseHeld { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseAddress")]
        [Comment("营业执照地址")]
        public string LicenseAddress { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseZipCode")]
        [Comment("营业执照邮编")]
        public string LicenseZipCode { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AmazonUser")]
        [InverseProperty("AmazonUser")]
        public List<AmazonSiteInfo> AmazonSiteInfo_AmazonUser { get; set; }

	}
    public class AmazonUserInfoIDcardheld : TopBasePoco, ISubFile
    {
        public Guid AmazonUserInfoId { get; set; }
        public AmazonUserInfo AmazonUserInfo { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
    public class AmazonUserInfoBusinessLicenseHeld : TopBasePoco, ISubFile
    {
        public Guid AmazonUserInfoId { get; set; }
        public AmazonUserInfo AmazonUserInfo { get; set; }
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }

}
