
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs
{
    public partial class AmazonSiteInfoTemplateVM : BaseTemplateVM
    {
        
        [Display(Name = "_Model._AmazonSiteInfo._SiteName")]
        public ExcelPropety SiteName_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.SiteNameId);
        [Display(Name = "_Model._AmazonSiteInfo._Mail")]
        public ExcelPropety Mail_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.Mail);
        [Display(Name = "_Model._AmazonSiteInfo._MailPassWord")]
        public ExcelPropety MailPassWord_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.MailPassWord);
        [Display(Name = "_Model._AmazonSiteInfo._CreditCard")]
        public ExcelPropety CreditCard_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.CreditCard);
        [Display(Name = "_Model._AmazonSiteInfo._SecurityCode")]
        public ExcelPropety SecurityCode_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.SecurityCode);
        [Display(Name = "_Model._AmazonSiteInfo._ValidityPeriod")]
        public ExcelPropety ValidityPeriod_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.ValidityPeriod);
        [Display(Name = "_Model._AmazonSiteInfo._Phone")]
        public ExcelPropety Phone_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.Phone);
        [Display(Name = "_Model._AmazonSiteInfo._AmazonState")]
        public ExcelPropety AmazonState_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.AmazonStateId);
        [Display(Name = "_Model._AmazonSiteInfo._AmazonUser")]
        public ExcelPropety AmazonUser_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.AmazonUserId);
        [Display(Name = "_Model._AmazonSiteInfo._AccountPassWord")]
        public ExcelPropety AccountPassWord_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.AccountPassWord);
        [Display(Name = "_Model._AmazonSiteInfo._CreateTime")]
        public ExcelPropety CreateTime_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.CreateTime, true);
        [Display(Name = "_Model._AmazonSiteInfo._UpdateTime")]
        public ExcelPropety UpdateTime_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.UpdateTime, true);
        [Display(Name = "_Model._AmazonSiteInfo._CreateBy")]
        public ExcelPropety CreateBy_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.CreateBy);
        [Display(Name = "_Model._AmazonSiteInfo._UpdateBy")]
        public ExcelPropety UpdateBy_Excel = ExcelPropety.CreateProperty<AmazonSiteInfo>(x => x.UpdateBy);

	    protected override void InitVM()
        {
            
            SiteName_Excel.DataType = ColumnDataType.ComboBox;
            SiteName_Excel.ListItems = DC.Set<DicField>().Where(x => x.DicDef.DicName == "站点").OrderBy(x => x.Order).GetSelectListItems(Wtm, y => y.DicFieldDes.ToString(), SortByName: false);
            AmazonState_Excel.DataType = ColumnDataType.ComboBox;
            AmazonState_Excel.ListItems = DC.Set<DicField>().Where(x => x.DicDef.DicName == "站点状态").OrderBy(x => x.Order).GetSelectListItems(Wtm, y => y.DicFieldDes.ToString(), SortByName: false);
            AmazonUser_Excel.DataType = ColumnDataType.ComboBox;
            AmazonUser_Excel.ListItems = DC.Set<AmazonUserInfo>().GetSelectListItems(Wtm, y => y.FaUserNameCn.ToString());

        }

    }

    public class AmazonSiteInfoImportVM : BaseImportVM<AmazonSiteInfoTemplateVM, AmazonSiteInfo>
    {
            //import

    }

}