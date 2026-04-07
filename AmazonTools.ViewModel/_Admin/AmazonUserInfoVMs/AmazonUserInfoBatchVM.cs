
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.AmazonUserInfoVMs
{
    public partial class AmazonUserInfoBatchVM : BaseBatchVM<AmazonUserInfo, AmazonUserInfo_BatchEdit>
    {
        public AmazonUserInfoBatchVM()
        {
            ListVM = new AmazonUserInfoListVM();
            LinkedVM = new AmazonUserInfo_BatchEdit();
        }

        public override bool DoBatchEdit()
        {
            
            return base.DoBatchEdit();
        }
    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class AmazonUserInfo_BatchEdit : BaseVM
    {

        
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
        public DicDef BelongingName { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseAddress")]
        public string LicenseAddress { get; set; }
        [Display(Name = "_Model._AmazonUserInfo._LicenseZipCode")]
        public string LicenseZipCode { get; set; }

        protected override void InitVM()
        {
           
        }
    }

}