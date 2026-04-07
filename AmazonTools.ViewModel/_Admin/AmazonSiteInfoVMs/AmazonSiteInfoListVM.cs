using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs
{
    public partial class AmazonSiteInfoListVM : BasePagedListVM<AmazonSiteInfo_View, AmazonSiteInfoSearcher>
    {
        
        protected override IEnumerable<IGridColumn<AmazonSiteInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<AmazonSiteInfo_View>>{
                
                this.MakeGridHeader(x => x.AmazonSiteInfo_SiteName).SetTitle(@Localizer["Page.站点"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_Mail).SetTitle(@Localizer["_Admin.Email"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_MailPassWord).SetTitle(@Localizer["Page.邮箱密码"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_AccountPassWord).SetTitle(@Localizer["Page.账户密码"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_CreditCard).SetTitle(@Localizer["Page.信用卡"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_SecurityCode).SetTitle(@Localizer["Page.安全码"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_ValidityPeriod).SetTitle(@Localizer["_Admin.ValidDate"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_Phone).SetTitle(@Localizer["Page.手机号"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_AmazonState).SetTitle(@Localizer["Page.状态"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_AmazonUser).SetTitle(@Localizer["Page.客户"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_CreateTime).SetTitle(@Localizer["_Admin.CreateTime"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_UpdateTime).SetTitle(@Localizer["_Admin.UpdateTime"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_CreateBy).SetTitle(@Localizer["_Admin.CreateBy"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_UpdateBy).SetTitle(@Localizer["_Admin.UpdateBy"].Value),

                this.MakeGridHeaderAction(width: 200)
            };
        }

        
        public override IOrderedQueryable<AmazonSiteInfo_View> GetSearchQuery()
        {
            var query = DC.Set<AmazonSiteInfo>()
                
                .CheckEqual(Searcher.SiteName, x=>x.SiteName)
                .CheckContain(Searcher.Mail, x=>x.Mail)
                .CheckContain(Searcher.MailPassWord, x=>x.MailPassWord)
                .CheckContain(Searcher.AccountPassWord, x=>x.AccountPassWord)
                .CheckContain(Searcher.CreditCard, x=>x.CreditCard)
                .CheckContain(Searcher.SecurityCode, x=>x.SecurityCode)
                .CheckContain(Searcher.ValidityPeriod, x=>x.ValidityPeriod)
                .CheckEqual(Searcher.Phone, x=>x.Phone)
                .CheckEqual(Searcher.AmazonState, x=>x.AmazonState)
                .CheckEqual(Searcher.AmazonUserId, x=>x.AmazonUserId)
                .CheckBetween(Searcher.CreateTime?.GetStartTime(), Searcher.CreateTime?.GetEndTime(), x => x.CreateTime, includeMax: false)
                .CheckBetween(Searcher.UpdateTime?.GetStartTime(), Searcher.UpdateTime?.GetEndTime(), x => x.UpdateTime, includeMax: false)
                .CheckContain(Searcher.CreateBy, x=>x.CreateBy)
                .CheckContain(Searcher.UpdateBy, x=>x.UpdateBy)
                .Select(x => new AmazonSiteInfo_View
                {
				    ID = x.ID,
                    
                    AmazonSiteInfo_SiteName = x.SiteName,
                    AmazonSiteInfo_Mail = x.Mail,
                    AmazonSiteInfo_MailPassWord = x.MailPassWord,
                    AmazonSiteInfo_AccountPassWord = x.AccountPassWord,
                    AmazonSiteInfo_CreditCard = x.CreditCard,
                    AmazonSiteInfo_SecurityCode = x.SecurityCode,
                    AmazonSiteInfo_ValidityPeriod = x.ValidityPeriod,
                    AmazonSiteInfo_Phone = x.Phone,
                    AmazonSiteInfo_AmazonState = x.AmazonState,
                    AmazonSiteInfo_AmazonUser = x.AmazonUser.FaUserNameCn,
                    AmazonSiteInfo_CreateTime = x.CreateTime,
                    AmazonSiteInfo_UpdateTime = x.UpdateTime,
                    AmazonSiteInfo_CreateBy = x.CreateBy,
                    AmazonSiteInfo_UpdateBy = x.UpdateBy,
                })
                .OrderBy(x => x.ID);
            return query;
        }

        
    }
    public class AmazonSiteInfo_View: AmazonSiteInfo
    {
        
        public DicDef AmazonSiteInfo_SiteName { get; set; }
        public string AmazonSiteInfo_Mail { get; set; }
        public string AmazonSiteInfo_MailPassWord { get; set; }
        public string AmazonSiteInfo_AccountPassWord { get; set; }
        public string AmazonSiteInfo_CreditCard { get; set; }
        public string AmazonSiteInfo_SecurityCode { get; set; }
        public string AmazonSiteInfo_ValidityPeriod { get; set; }
        public string AmazonSiteInfo_Phone { get; set; }
        public DicDef AmazonSiteInfo_AmazonState { get; set; }
        public string AmazonSiteInfo_AmazonUser { get; set; }
        public DateTime? AmazonSiteInfo_CreateTime { get; set; }
        public DateTime? AmazonSiteInfo_UpdateTime { get; set; }
        public string AmazonSiteInfo_CreateBy { get; set; }
        public string AmazonSiteInfo_UpdateBy { get; set; }

    }

}