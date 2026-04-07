
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;
namespace AmazonTools.ViewModel._Admin.AmazonUserInfoVMs
{
    public partial class AmazonUserInfoSearcher : BaseSearcher
    {
        
        public List<string> _AdminAmazonUserInfoSTempSelected { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._FaUserNameCn")]
        public string FaUserNameCn { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._FaUserNameUs")]
        public string FaUserNameUs { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._FaIdCard")]
        public string FaIdCard { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._FaBornTime")]
        public string FaBornTime { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._FaEndTime")]
        public string FaEndTime { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseCn")]
        public string LicenseCn { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseUs")]
        public string LicenseUs { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseCode")]
        public string LicenseCode { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._License")]
        public string License { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._MailingAddress")]
        public string MailingAddress { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._MailingZipCode")]
        public string MailingZipCode { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._BelongingName")]
        public Guid? BelongingNameId { get; set; }
        public List<ComboSelectListItem> AllBelongingNames { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseAddress")]
        public string LicenseAddress { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseZipCode")]
        public string LicenseZipCode { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._CreateTime")]
        public DateRange CreateTime { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._UpdateTime")]
        public DateRange UpdateTime { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._CreateBy")]
        public string CreateBy { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._UpdateBy")]
        public string UpdateBy { get; set; }

        protected override void InitVM()
        {
            

        }
    }

}