using System;
using System.Collections.Generic;
using System.Linq;
using AmazonTools.Model._Admin;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs
{
    public partial class AmazonSiteInfoListVM : BasePagedListVM<AmazonSiteInfo_View, AmazonSiteInfoSearcher>
    {

        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeAction("AmazonSiteInfo","Create",@Localizer["Sys.Create"].Value,@Localizer["Sys.Create"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(false).SetHideOnToolBar(false).SetIconCls("fa fa-plus"),
                this.MakeAction("AmazonSiteInfo","Edit",@Localizer["Sys.Edit"].Value,@Localizer["Sys.Edit"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(true).SetHideOnToolBar(true).SetIconCls("fa fa-pencil-square").SetButtonClass("layui-btn-warm"),
                this.MakeAction("AmazonSiteInfo","Details",@Localizer["Page.详情"].Value,@Localizer["Page.详情"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(true).SetHideOnToolBar(true).SetIconCls("fa fa-info-circle").SetButtonClass("layui-btn-normal"),
                this.MakeStandardAction("AmazonSiteInfo", GridActionStandardTypesEnum.SimpleDelete, @Localizer["Sys.Delete"].Value, "_Admin", dialogWidth: 800).SetIconCls("fa fa-trash").SetButtonClass("layui-btn-danger"),
                this.MakeStandardAction("AmazonSiteInfo", GridActionStandardTypesEnum.SimpleBatchDelete, Localizer["Sys.BatchDelete"].Value, "_Admin", dialogWidth: 800).SetIconCls("fa fa-trash").SetButtonClass("layui-btn-danger"),
                this.MakeAction("AmazonSiteInfo","BatchEdit",@Localizer["Sys.BatchEdit"].Value,@Localizer["Sys.BatchEdit"].Value,GridActionParameterTypesEnum.MultiIds,"_Admin",800).SetShowInRow(false).SetHideOnToolBar(false).SetIconCls("fa fa-pencil-square"),
                this.MakeAction("AmazonSiteInfo","Import",@Localizer["Sys.Import"].Value,@Localizer["Sys.Import"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(false).SetHideOnToolBar(false).SetIconCls("fa fa-tasks"),
                this.MakeAction("AmazonSiteInfo","AmazonSiteInfoExportExcel",@Localizer["Sys.Export"].Value,@Localizer["Sys.Export"].Value,GridActionParameterTypesEnum.MultiIdWithNull,"_Admin").SetShowInRow(false).SetShowDialog(false).SetHideOnToolBar(false).SetIsExport(true).SetIconCls("fa fa-arrow-circle-down"),
            };
        }


        protected override IEnumerable<IGridColumn<AmazonSiteInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<AmazonSiteInfo_View>>{

                this.MakeGridHeader(x => x.AmazonSiteInfo_SiteName).SetTitle(@Localizer["Page.站点"].Value),
                    this.MakeGridHeader(x => x.AmazonSiteInfo_AmazonUser).SetTitle(@Localizer["Page.客户"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_Mail).SetTitle(@Localizer["_Admin.Email"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_MailPassWord).SetTitle(@Localizer["Page.邮箱密码"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_AccountPassWord).SetTitle(@Localizer["Page.账户密码"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_CreditCard).SetTitle(@Localizer["Page.信用卡"].Value),
                //this.MakeGridHeader(x => x.AmazonSiteInfo_SecurityCode).SetTitle(@Localizer["Page.安全码"].Value),
                //this.MakeGridHeader(x => x.AmazonSiteInfo_ValidityPeriod).SetTitle(@Localizer["_Admin.ValidDate"].Value),
                //this.MakeGridHeader(x => x.AmazonSiteInfo_Phone).SetTitle(@Localizer["Page.手机号"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_AmazonState).SetTitle(@Localizer["Page.状态"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_CreateTime).SetTitle(@Localizer["_Admin.CreateTime"].Value).SetWidth(180),
                this.MakeGridHeader(x => x.AmazonSiteInfo_UpdateTime).SetTitle(@Localizer["_Admin.UpdateTime"].Value).SetWidth(180),
                this.MakeGridHeader(x => x.AmazonSiteInfo_CreateBy).SetTitle(@Localizer["_Admin.CreateBy"].Value),
                this.MakeGridHeader(x => x.AmazonSiteInfo_UpdateBy).SetTitle(@Localizer["_Admin.UpdateBy"].Value),

                this.MakeGridHeaderAction(width: 200)
            };
        }



        public override IOrderedQueryable<AmazonSiteInfo_View> GetSearchQuery()
        {
            if (LoginUserInfo.ITCode == "admin" || LoginUserInfo.ITCode == "志明")
            {
                return DC.Set<AmazonSiteInfo>()

             .CheckEqual(Searcher.SiteNameId, x => x.SiteNameId)
             .CheckContain(Searcher.Mail, x => x.Mail)
             .CheckContain(Searcher.MailPassWord, x => x.MailPassWord)
             .CheckContain(Searcher.AccountPassWord, x => x.AccountPassWord)
             .CheckContain(Searcher.CreditCard, x => x.CreditCard)
             .CheckContain(Searcher.SecurityCode, x => x.SecurityCode)
             .CheckContain(Searcher.ValidityPeriod, x => x.ValidityPeriod)
             .CheckEqual(Searcher.Phone, x => x.Phone)
             .CheckEqual(Searcher.AmazonStateId, x => x.AmazonStateId)
             .CheckEqual(Searcher.AmazonUserId, x => x.AmazonUserId)
             .CheckBetween(Searcher.CreateTime?.GetStartTime(), Searcher.CreateTime?.GetEndTime(), x => x.CreateTime, includeMax: false)
             .CheckBetween(Searcher.UpdateTime?.GetStartTime(), Searcher.UpdateTime?.GetEndTime(), x => x.UpdateTime, includeMax: false)
             .CheckContain(Searcher.CreateBy, x => x.CreateBy)
             .CheckContain(Searcher.UpdateBy, x => x.UpdateBy)
             .Select(x => new AmazonSiteInfo_View
             {
                 ID = x.ID,

                 AmazonSiteInfo_SiteName = x.SiteName.DicFieldDes,
                 AmazonSiteInfo_Mail = x.Mail,
                 AmazonSiteInfo_MailPassWord = x.MailPassWord,
                 AmazonSiteInfo_AccountPassWord = x.AccountPassWord,
                 AmazonSiteInfo_CreditCard = x.CreditCard,
                 AmazonSiteInfo_SecurityCode = x.SecurityCode,
                 AmazonSiteInfo_ValidityPeriod = x.ValidityPeriod,
                 AmazonSiteInfo_Phone = x.Phone,
                 AmazonSiteInfo_AmazonState = x.AmazonState.DicFieldDes,
                 AmazonSiteInfo_AmazonUser = x.AmazonUser.FaUserNameCn,
                 AmazonSiteInfo_CreateTime = x.CreateTime,
                 AmazonSiteInfo_UpdateTime = x.UpdateTime,
                 AmazonSiteInfo_CreateBy = x.CreateBy,
                 AmazonSiteInfo_UpdateBy = x.UpdateBy,
             })
             .OrderByDescending(x => x.AmazonSiteInfo_CreateTime);
            }
            else
            {
                return DC.Set<AmazonSiteInfo>()

 .CheckEqual(Searcher.SiteNameId, x => x.SiteNameId)
 .CheckContain(Searcher.Mail, x => x.Mail)
 .CheckContain(Searcher.MailPassWord, x => x.MailPassWord)
 .CheckContain(Searcher.AccountPassWord, x => x.AccountPassWord)
 .CheckContain(Searcher.CreditCard, x => x.CreditCard)
 .CheckContain(Searcher.SecurityCode, x => x.SecurityCode)
 .CheckContain(Searcher.ValidityPeriod, x => x.ValidityPeriod)
 .CheckEqual(Searcher.Phone, x => x.Phone)
 .CheckEqual(Searcher.AmazonStateId, x => x.AmazonStateId)
 .CheckEqual(Searcher.AmazonUserId, x => x.AmazonUserId)
 .CheckBetween(Searcher.CreateTime?.GetStartTime(), Searcher.CreateTime?.GetEndTime(), x => x.CreateTime, includeMax: false)
 .CheckBetween(Searcher.UpdateTime?.GetStartTime(), Searcher.UpdateTime?.GetEndTime(), x => x.UpdateTime, includeMax: false)
 .CheckContain(Searcher.CreateBy, x => x.CreateBy)
 .CheckContain(Searcher.UpdateBy, x => x.UpdateBy)
 .Select(x => new AmazonSiteInfo_View
 {
     ID = x.ID,

     AmazonSiteInfo_SiteName = x.SiteName.DicFieldDes,
     AmazonSiteInfo_Mail = x.Mail,
     AmazonSiteInfo_MailPassWord = x.MailPassWord,
     AmazonSiteInfo_AccountPassWord = x.AccountPassWord,
     AmazonSiteInfo_CreditCard = x.CreditCard,
     AmazonSiteInfo_SecurityCode = x.SecurityCode,
     AmazonSiteInfo_ValidityPeriod = x.ValidityPeriod,
     AmazonSiteInfo_Phone = x.Phone,
     AmazonSiteInfo_AmazonState = x.AmazonState.DicFieldDes,
     AmazonSiteInfo_AmazonUser = x.AmazonUser.FaUserNameCn,
     AmazonSiteInfo_CreateTime = x.CreateTime,
     AmazonSiteInfo_UpdateTime = x.UpdateTime,
     AmazonSiteInfo_CreateBy = LoginUserInfo.ITCode,
     AmazonSiteInfo_UpdateBy = x.UpdateBy,

 })
 .OrderByDescending(x => x.AmazonSiteInfo_CreateTime);
            }


        }


    }
    public class AmazonSiteInfo_View : AmazonSiteInfo
    {

        public string AmazonSiteInfo_SiteName { get; set; }
        public string AmazonSiteInfo_Mail { get; set; }
        public string AmazonSiteInfo_MailPassWord { get; set; }
        public string AmazonSiteInfo_AccountPassWord { get; set; }
        public string AmazonSiteInfo_CreditCard { get; set; }
        public string AmazonSiteInfo_SecurityCode { get; set; }
        public string AmazonSiteInfo_ValidityPeriod { get; set; }
        public string AmazonSiteInfo_Phone { get; set; }
        public string AmazonSiteInfo_AmazonState { get; set; }
        public string AmazonSiteInfo_AmazonUser { get; set; }
        public DateTime? AmazonSiteInfo_CreateTime { get; set; }
        public DateTime? AmazonSiteInfo_UpdateTime { get; set; }
        public string AmazonSiteInfo_CreateBy { get; set; }
        public string AmazonSiteInfo_UpdateBy { get; set; }

    }

}