
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.AmazonUserInfoVMs
{
    public partial class AmazonUserInfoTemplateVM : BaseTemplateVM
    {
        
        [Display(Name = "_Model._AmazonUserInfo._FaUserNameCn")]
        public ExcelPropety FaUserNameCn_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.FaUserNameCn);
        [Display(Name = "_Model._AmazonUserInfo._FaUserNameUs")]
        public ExcelPropety FaUserNameUs_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.FaUserNameUs);
        [Display(Name = "_Model._AmazonUserInfo._FaIdCard")]
        public ExcelPropety FaIdCard_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.FaIdCard);
        [Display(Name = "_Model._AmazonUserInfo._FaBornTime")]
        public ExcelPropety FaBornTime_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.FaBornTime);
        [Display(Name = "_Model._AmazonUserInfo._FaEndTime")]
        public ExcelPropety FaEndTime_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.FaEndTime);
        [Display(Name = "_Model._AmazonUserInfo._LicenseCn")]
        public ExcelPropety LicenseCn_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.LicenseCn);
        [Display(Name = "_Model._AmazonUserInfo._LicenseUs")]
        public ExcelPropety LicenseUs_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.LicenseUs);
        [Display(Name = "_Model._AmazonUserInfo._LicenseCode")]
        public ExcelPropety LicenseCode_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.LicenseCode);
        [Display(Name = "_Model._AmazonUserInfo._License")]
        public ExcelPropety License_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.License);
        [Display(Name = "_Model._AmazonUserInfo._MailingAddress")]
        public ExcelPropety MailingAddress_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.MailingAddress);
        [Display(Name = "_Model._AmazonUserInfo._MailingZipCode")]
        public ExcelPropety MailingZipCode_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.MailingZipCode);
        [Display(Name = "_Model._AmazonUserInfo._BelongingName")]
        public ExcelPropety BelongingName_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.BelongingNameId);
        [Display(Name = "_Model._AmazonUserInfo._LicenseAddress")]
        public ExcelPropety LicenseAddress_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.LicenseAddress);
        [Display(Name = "_Model._AmazonUserInfo._LicenseZipCode")]
        public ExcelPropety LicenseZipCode_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.LicenseZipCode);
        [Display(Name = "_Model._AmazonUserInfo._CreateTime")]
        public ExcelPropety CreateTime_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.CreateTime, true);
        [Display(Name = "_Model._AmazonUserInfo._UpdateTime")]
        public ExcelPropety UpdateTime_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.UpdateTime, true);
        [Display(Name = "_Model._AmazonUserInfo._CreateBy")]
        public ExcelPropety CreateBy_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.CreateBy);
        [Display(Name = "_Model._AmazonUserInfo._UpdateBy")]
        public ExcelPropety UpdateBy_Excel = ExcelPropety.CreateProperty<AmazonUserInfo>(x => x.UpdateBy);

	    protected override void InitVM()
        {
            
            BelongingName_Excel.DataType = ColumnDataType.ComboBox;
            BelongingName_Excel.ListItems = DC.Set<DicField>().Where(x => x.DicDef.DicName == "代理").OrderBy(x => x.Order).GetSelectListItems(Wtm, y => y.DicFieldDes.ToString(), SortByName: false);

        }

    }

    public class AmazonUserInfoImportVM : BaseImportVM<AmazonUserInfoTemplateVM, AmazonUserInfo>
    {
            //import

    }

}