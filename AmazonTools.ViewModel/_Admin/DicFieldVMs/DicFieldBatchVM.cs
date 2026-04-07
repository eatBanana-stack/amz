
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

namespace AmazonTools.ViewModel._Admin.DicFieldVMs
{
    public partial class DicFieldBatchVM : BaseBatchVM<DicField, DicField_BatchEdit>
    {
        public DicFieldBatchVM()
        {
            ListVM = new DicFieldListVM();
            LinkedVM = new DicField_BatchEdit();
        }

        public override bool DoBatchEdit()
        {
            
            return base.DoBatchEdit();
        }
    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class DicField_BatchEdit : BaseVM
    {

        
        public List<string> _AdminDicFieldBTempSelected { get; set; }

        protected override void InitVM()
        {
           
        }
    }

}