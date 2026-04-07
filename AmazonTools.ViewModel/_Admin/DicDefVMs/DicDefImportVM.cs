
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.DicDefVMs
{
    public partial class DicDefTemplateVM : BaseTemplateVM
    {
        
        [Display(Name = "_Model._DicDef._DicName")]
        public ExcelPropety DicName_Excel = ExcelPropety.CreateProperty<DicDef>(x => x.DicName);

	    protected override void InitVM()
        {
            
        }

    }

    public class DicDefImportVM : BaseImportVM<DicDefTemplateVM, DicDef>
    {
            //import

    }

}