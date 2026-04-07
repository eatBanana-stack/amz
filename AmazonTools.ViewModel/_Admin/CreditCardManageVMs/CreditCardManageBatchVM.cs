
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

namespace AmazonTools.ViewModel._Admin.CreditCardManageVMs
{
    public partial class CreditCardManageBatchVM : BaseBatchVM<CreditCardManage, CreditCardManage_BatchEdit>
    {
        public CreditCardManageBatchVM()
        {
            ListVM = new CreditCardManageListVM();
            LinkedVM = new CreditCardManage_BatchEdit();
        }

        public override bool DoBatchEdit()
        {
            
            return base.DoBatchEdit();
        }
    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class CreditCardManage_BatchEdit : BaseVM
    {

        
        public List<string> _AdminCreditCardManageBTempSelected { get; set; }
        [Display(Name = "_Model._CreditCardManage._CreditCard")]
        public string CreditCard { get; set; }
        [Display(Name = "_Model._CreditCardManage._SecurityCode")]
        public string SecurityCode { get; set; }
        [Display(Name = "_Model._CreditCardManage._ValidityPeriod")]
        public string ValidityPeriod { get; set; }

        protected override void InitVM()
        {
           
        }
    }

}