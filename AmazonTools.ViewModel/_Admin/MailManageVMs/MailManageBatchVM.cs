
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

namespace AmazonTools.ViewModel._Admin.MailManageVMs
{
    public partial class MailManageBatchVM : BaseBatchVM<MailManage, MailManage_BatchEdit>
    {
        public MailManageBatchVM()
        {
            ListVM = new MailManageListVM();
            LinkedVM = new MailManage_BatchEdit();
        }

        public override bool DoBatchEdit()
        {
            
            return base.DoBatchEdit();
        }
    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class MailManage_BatchEdit : BaseVM
    {

        
        public List<string> _AdminMailManageBTempSelected { get; set; }
        [Display(Name = "_Model._MailManage._Mail")]
        public string Mail { get; set; }
        [Display(Name = "_Model._MailManage._PassWord")]
        public string PassWord { get; set; }

        protected override void InitVM()
        {
           
        }
    }

}