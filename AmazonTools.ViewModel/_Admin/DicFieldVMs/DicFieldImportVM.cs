
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.DicFieldVMs
{
    public partial class DicFieldTemplateVM : BaseTemplateVM
    {
        
	    protected override void InitVM()
        {
            
        }

    }

    public class DicFieldImportVM : BaseImportVM<DicFieldTemplateVM, DicField>
    {
            //import

    }

}