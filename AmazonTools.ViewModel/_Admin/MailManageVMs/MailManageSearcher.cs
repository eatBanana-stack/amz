
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;
namespace AmazonTools.ViewModel._Admin.MailManageVMs
{
    public partial class MailManageSearcher : BaseSearcher
    {
        
        [Display(Name = "_Model._MailManage._Mail")]
        public string Mail { get; set; }
        [Display(Name = "_Model._MailManage._PassWord")]
        public string PassWord { get; set; }
        [Display(Name = "_Model._MailManage._CreateTime")]
        public DateRange CreateTime { get; set; }
        [Display(Name = "_Model._MailManage._UpdateTime")]
        public DateRange UpdateTime { get; set; }
        [Display(Name = "_Model._MailManage._CreateBy")]
        public string CreateBy { get; set; }
        [Display(Name = "_Model._MailManage._UpdateBy")]
        public string UpdateBy { get; set; }

        protected override void InitVM()
        {
            
        }
    }

}