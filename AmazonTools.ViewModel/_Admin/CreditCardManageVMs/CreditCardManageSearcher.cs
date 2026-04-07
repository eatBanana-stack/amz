
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;
namespace AmazonTools.ViewModel._Admin.CreditCardManageVMs
{
    public partial class CreditCardManageSearcher : BaseSearcher
    {
        
        [Display(Name = "_Model._CreditCardManage._CreditCard")]
        public string CreditCard { get; set; }
        [Display(Name = "_Model._CreditCardManage._SecurityCode")]
        public string SecurityCode { get; set; }
        [Display(Name = "_Model._CreditCardManage._ValidityPeriod")]
        public string ValidityPeriod { get; set; }
        [Display(Name = "_Model._CreditCardManage._CreateTime")]
        public DateRange CreateTime { get; set; }
        [Display(Name = "_Model._CreditCardManage._UpdateTime")]
        public DateRange UpdateTime { get; set; }
        [Display(Name = "_Model._CreditCardManage._CreateBy")]
        public string CreateBy { get; set; }
        [Display(Name = "_Model._CreditCardManage._UpdateBy")]
        public string UpdateBy { get; set; }

        protected override void InitVM()
        {
            
        }
    }

}