
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;
namespace AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs
{
    public partial class AmazonSiteInfoSearcher : BaseSearcher
    {
        
        [Display(Name = "_Model._AmazonSiteInfo._SiteName")]
        public DicDef SiteName { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._Mail")]
        public string Mail { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._MailPassWord")]
        public string MailPassWord { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AccountPassWord")]
        public string AccountPassWord { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._CreditCard")]
        public string CreditCard { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._SecurityCode")]
        public string SecurityCode { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._ValidityPeriod")]
        public string ValidityPeriod { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._Phone")]
        public string Phone { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AmazonState")]
        public DicDef AmazonState { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._AmazonUser")]
        public Guid? AmazonUserId { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._CreateTime")]
        public DateRange CreateTime { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._UpdateTime")]
        public DateRange UpdateTime { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._CreateBy")]
        public string CreateBy { get; set; }
        [Display(Name = "_Model._AmazonSiteInfo._UpdateBy")]
        public string UpdateBy { get; set; }

        protected override void InitVM()
        {
            

        }
    }

}