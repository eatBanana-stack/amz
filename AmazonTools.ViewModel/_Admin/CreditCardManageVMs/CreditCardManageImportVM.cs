
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.CreditCardManageVMs
{
    public partial class CreditCardManageTemplateVM : BaseTemplateVM
    {
        
        [Display(Name = "_Model._CreditCardManage._CreditCard")]
        public ExcelPropety CreditCard_Excel = ExcelPropety.CreateProperty<CreditCardManage>(x => x.CreditCard);
        [Display(Name = "_Model._CreditCardManage._SecurityCode")]
        public ExcelPropety SecurityCode_Excel = ExcelPropety.CreateProperty<CreditCardManage>(x => x.SecurityCode);
        [Display(Name = "_Model._CreditCardManage._ValidityPeriod")]
        public ExcelPropety ValidityPeriod_Excel = ExcelPropety.CreateProperty<CreditCardManage>(x => x.ValidityPeriod);
        [Display(Name = "_Model._CreditCardManage._CreateTime")]
        public ExcelPropety CreateTime_Excel = ExcelPropety.CreateProperty<CreditCardManage>(x => x.CreateTime, true);
        [Display(Name = "_Model._CreditCardManage._UpdateTime")]
        public ExcelPropety UpdateTime_Excel = ExcelPropety.CreateProperty<CreditCardManage>(x => x.UpdateTime, true);
        [Display(Name = "_Model._CreditCardManage._CreateBy")]
        public ExcelPropety CreateBy_Excel = ExcelPropety.CreateProperty<CreditCardManage>(x => x.CreateBy);
        [Display(Name = "_Model._CreditCardManage._UpdateBy")]
        public ExcelPropety UpdateBy_Excel = ExcelPropety.CreateProperty<CreditCardManage>(x => x.UpdateBy);

	    protected override void InitVM()
        {
            
        }

    }

    public class CreditCardManageImportVM : BaseImportVM<CreditCardManageTemplateVM, CreditCardManage>
    {
            //import

    }

}