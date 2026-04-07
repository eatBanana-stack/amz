
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

using AmazonTools.Model._Admin;


namespace AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs
{
    public partial class AmazonSiteInfoAmazonUserDetailListVM2 : BasePagedListVM<AmazonSiteInfo, AmazonSiteInfoDetailSearcher2>
    {
        
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
            };
        }
 
        protected override IEnumerable<IGridColumn<AmazonSiteInfo>> InitGridHeader()
        {
            return new List<GridColumn<AmazonSiteInfo>>{
                
                this.MakeGridHeader(x => x.SiteNameId).SetEditType(EditTypeEnum.ComboBox,DC.Set<DicField>().Where(x => x.DicDef.DicName == "站点").OrderBy(x => x.Order).GetSelectListItems(Wtm, x => x.DicFieldDes,SortByName:false)).SetTitle(@Localizer["Page.站点"].Value),
                this.MakeGridHeader(x => x.Mail).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["_Admin.Email"].Value),
                this.MakeGridHeader(x => x.MailPassWord).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["Page.邮箱密码"].Value),
                this.MakeGridHeader(x => x.AccountPassWord).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["Page.账户密码"].Value),
                this.MakeGridHeader(x => x.CreditCard).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["Page.信用卡"].Value),
                this.MakeGridHeader(x => x.SecurityCode).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["Page.安全码"].Value),
                this.MakeGridHeader(x => x.ValidityPeriod).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["_Admin.ValidDate"].Value),
                this.MakeGridHeader(x => x.Phone).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["Page.手机号"].Value),
                this.MakeGridHeader(x => x.AmazonStateId).SetEditType(EditTypeEnum.ComboBox,DC.Set<DicField>().Where(x => x.DicDef.DicName == "站点状态").OrderBy(x => x.Order).GetSelectListItems(Wtm, x => x.DicFieldDes,SortByName:false)).SetTitle(@Localizer["Page.状态"].Value),

            };
        }

        
        public override IOrderedQueryable<AmazonSiteInfo> GetSearchQuery()
        {
                
            var id = (Guid?)Searcher.AmazonUserId.ConvertValue(typeof(Guid?));
            if (id == null)
                return new List<AmazonSiteInfo>().AsQueryable().OrderBy(x => x.ID);
            var query = DC.Set<AmazonSiteInfo>()
                .Where(x => id == x.AmazonUserId)

                .OrderBy(x => x.ID);
            return query;
        }

    }

    public partial class AmazonSiteInfoDetailSearcher2 : BaseSearcher
    {
        
        [Display(Name = "_Model._AmazonSiteInfo._AmazonUser")]
        public string AmazonUserId { get; set; }
    }

}

