
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.MailManageVMs
{
    public partial class MailManageTemplateVM : BaseTemplateVM
    {
        
        [Display(Name = "_Model._MailManage._Mail")]
        public ExcelPropety Mail_Excel = ExcelPropety.CreateProperty<MailManage>(x => x.Mail);
        [Display(Name = "_Model._MailManage._PassWord")]
        public ExcelPropety PassWord_Excel = ExcelPropety.CreateProperty<MailManage>(x => x.PassWord);
        [Display(Name = "_Model._MailManage._CreateTime")]
        public ExcelPropety CreateTime_Excel = ExcelPropety.CreateProperty<MailManage>(x => x.CreateTime, true);
        [Display(Name = "_Model._MailManage._UpdateTime")]
        public ExcelPropety UpdateTime_Excel = ExcelPropety.CreateProperty<MailManage>(x => x.UpdateTime, true);
        [Display(Name = "_Model._MailManage._CreateBy")]
        public ExcelPropety CreateBy_Excel = ExcelPropety.CreateProperty<MailManage>(x => x.CreateBy);
        [Display(Name = "_Model._MailManage._UpdateBy")]
        public ExcelPropety UpdateBy_Excel = ExcelPropety.CreateProperty<MailManage>(x => x.UpdateBy);

	    protected override void InitVM()
        {
            
        }

    }

    public class MailManageImportVM : BaseImportVM<MailManageTemplateVM, MailManage>
    {
            //import

    }

}