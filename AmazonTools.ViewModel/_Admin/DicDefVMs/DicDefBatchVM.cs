
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

namespace AmazonTools.ViewModel._Admin.DicDefVMs
{
    public partial class DicDefBatchVM : BaseBatchVM<DicDef, DicDef_BatchEdit>
    {
        public DicDefBatchVM()
        {
            ListVM = new DicDefListVM();
            LinkedVM = new DicDef_BatchEdit();
        }

        public override bool DoBatchEdit()
        {
            
            return base.DoBatchEdit();
        }
    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class DicDef_BatchEdit : BaseVM
    {

        
        public List<string> _AdminDicDefBTempSelected { get; set; }
        [Display(Name = "_Model._DicDef._DicName")]
        public string DicName { get; set; }

        protected override void InitVM()
        {
           
        }
    }

}