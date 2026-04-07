using System;
using System.Collections.Generic;
using System.Linq;
using AmazonTools.Model._Admin;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace AmazonTools.ViewModel._Admin.AmazonUserInfoVMs
{
    public partial class AmazonUserInfoListVM : BasePagedListVM<AmazonUserInfo_View, AmazonUserInfoSearcher>
    {

        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeAction("AmazonUserInfo","Create",@Localizer["Sys.Create"].Value,@Localizer["Sys.Create"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(false).SetHideOnToolBar(false).SetIconCls("fa fa-plus").SetMax(true),
                this.MakeAction("AmazonUserInfo","Edit",@Localizer["Sys.Edit"].Value,@Localizer["Sys.Edit"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(true).SetHideOnToolBar(true).SetIconCls("fa fa-pencil-square").SetButtonClass("layui-btn-warm").SetMax(true),
                this.MakeAction("AmazonUserInfo","Details",@Localizer["Page.详情"].Value,@Localizer["Page.详情"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(true).SetHideOnToolBar(true).SetIconCls("fa fa-info-circle").SetButtonClass("layui-btn-normal").SetMax(true),
                this.MakeStandardAction("AmazonUserInfo", GridActionStandardTypesEnum.SimpleDelete, @Localizer["Sys.Delete"].Value, "_Admin", dialogWidth: 800).SetIconCls("fa fa-trash").SetButtonClass("layui-btn-danger"),
                this.MakeStandardAction("AmazonUserInfo", GridActionStandardTypesEnum.SimpleBatchDelete, Localizer["Sys.BatchDelete"].Value, "_Admin", dialogWidth: 800).SetIconCls("fa fa-trash").SetButtonClass("layui-btn-danger"),
                this.MakeAction("AmazonUserInfo","Import",@Localizer["Sys.Import"].Value,@Localizer["Sys.Import"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(false).SetHideOnToolBar(false).SetIconCls("fa fa-tasks"),
                this.MakeAction("AmazonUserInfo","AmazonUserInfoExportExcel",@Localizer["Sys.Export"].Value,@Localizer["Sys.Export"].Value,GridActionParameterTypesEnum.MultiIdWithNull,"_Admin").SetShowInRow(false).SetShowDialog(false).SetHideOnToolBar(false).SetIsExport(true).SetIconCls("fa fa-arrow-circle-down"),
            };
        }


        protected override IEnumerable<IGridColumn<AmazonUserInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<AmazonUserInfo_View>>{

                this.MakeGridHeader(x => x.AmazonUserInfo_FaUserNameCn).SetTitle(@Localizer["Page.姓名中文"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_FaIdCard).SetTitle(@Localizer["Page.身份证"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_LicenseCn).SetTitle(@Localizer["Page.执照中文"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_License).SetTitle(@Localizer["Page.执照时间"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_BelongingName).SetTitle(@Localizer["Page.代理"].Value).SetWidth(60),
                this.MakeGridHeader(x => x.AmazonUserInfo_CreateTime).SetTitle(@Localizer["_Admin.CreateTime"].Value).SetWidth(180),
                this.MakeGridHeader(x => x.AmazonUserInfo_UpdateTime).SetTitle(@Localizer["_Admin.UpdateTime"].Value).SetWidth(180),
                this.MakeGridHeader(x => x.AmazonUserInfo_CreateBy).SetTitle(@Localizer["_Admin.CreateBy"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_UpdateBy).SetTitle(@Localizer["_Admin.UpdateBy"].Value),

                this.MakeGridHeaderAction(width: 200)
            };
        }



        public override IOrderedQueryable<AmazonUserInfo_View> GetSearchQuery()
        {
            if (LoginUserInfo.ITCode == "admin" || LoginUserInfo.ITCode == "志明")
            {
                return DC.Set<AmazonUserInfo>()

              .CheckContain(Searcher.FaUserNameCn, x => x.FaUserNameCn)
              .CheckContain(Searcher.FaUserNameUs, x => x.FaUserNameUs)
              .CheckContain(Searcher.FaIdCard, x => x.FaIdCard)
              .CheckContain(Searcher.FaBornTime, x => x.FaBornTime)
              .CheckContain(Searcher.FaEndTime, x => x.FaEndTime)
              .CheckContain(Searcher.LicenseCn, x => x.LicenseCn)
              .CheckContain(Searcher.LicenseUs, x => x.LicenseUs)
              .CheckContain(Searcher.LicenseCode, x => x.LicenseCode)
              .CheckContain(Searcher.License, x => x.License)
              .CheckContain(Searcher.MailingAddress, x => x.MailingAddress)
              .CheckContain(Searcher.MailingZipCode, x => x.MailingZipCode)
              .CheckEqual(Searcher.BelongingNameId, x => x.BelongingNameId)
              .CheckContain(Searcher.LicenseAddress, x => x.LicenseAddress)
              .CheckContain(Searcher.LicenseZipCode, x => x.LicenseZipCode)
              .CheckBetween(Searcher.CreateTime?.GetStartTime(), Searcher.CreateTime?.GetEndTime(), x => x.CreateTime, includeMax: false)
              .CheckBetween(Searcher.UpdateTime?.GetStartTime(), Searcher.UpdateTime?.GetEndTime(), x => x.UpdateTime, includeMax: false)
              .CheckContain(Searcher.CreateBy, x => x.CreateBy)
              .CheckContain(Searcher.UpdateBy, x => x.UpdateBy)
              .Select(x => new AmazonUserInfo_View
              {
                  ID = x.ID,
                  AmazonUserInfo_FaUserNameCn = x.FaUserNameCn,
                  AmazonUserInfo_FaIdCard = x.FaIdCard,
                  AmazonUserInfo_LicenseCn = x.LicenseCn,
                  AmazonUserInfo_License = x.License,
                  AmazonUserInfo_BelongingName = x.BelongingName.DicFieldDes,
                  AmazonUserInfo_CreateTime = x.CreateTime,
                  AmazonUserInfo_UpdateTime = x.UpdateTime,
                  AmazonUserInfo_CreateBy = x.CreateBy,
                  AmazonUserInfo_UpdateBy = x.UpdateBy,


              })
              .OrderByDescending(x => x.AmazonUserInfo_CreateTime);
            }
            else
            {
                var mode =  DC.Set<AmazonUserInfo>()

               .CheckContain(Searcher.FaUserNameCn, x => x.FaUserNameCn)
               .CheckContain(Searcher.FaUserNameUs, x => x.FaUserNameUs)
               .CheckContain(Searcher.FaIdCard, x => x.FaIdCard)
               .CheckContain(Searcher.FaBornTime, x => x.FaBornTime)
               .CheckContain(Searcher.FaEndTime, x => x.FaEndTime)
               .CheckContain(Searcher.LicenseCn, x => x.LicenseCn)
               .CheckContain(Searcher.LicenseUs, x => x.LicenseUs)
               .CheckContain(Searcher.LicenseCode, x => x.LicenseCode)
               .CheckContain(Searcher.License, x => x.License)
               .CheckContain(Searcher.MailingAddress, x => x.MailingAddress)
               .CheckContain(Searcher.MailingZipCode, x => x.MailingZipCode)
               .CheckEqual(Searcher.BelongingNameId, x => x.BelongingNameId)
               .CheckContain(Searcher.LicenseAddress, x => x.LicenseAddress)
               .CheckContain(Searcher.LicenseZipCode, x => x.LicenseZipCode)
               .CheckBetween(Searcher.CreateTime?.GetStartTime(), Searcher.CreateTime?.GetEndTime(), x => x.CreateTime, includeMax: false)
               .CheckBetween(Searcher.UpdateTime?.GetStartTime(), Searcher.UpdateTime?.GetEndTime(), x => x.UpdateTime, includeMax: false)
               .CheckContain(Searcher.CreateBy, x=>x.CreateBy)
               .CheckContain(Searcher.UpdateBy, x=>x.UpdateBy)
              .CheckContain(Searcher.UpdateBy, x => x.UpdateBy)
               .Select(x => new AmazonUserInfo_View
               {
                   ID = x.ID,
                   AmazonUserInfo_FaUserNameCn = x.FaUserNameCn,
                   AmazonUserInfo_FaIdCard = x.FaIdCard,
                   AmazonUserInfo_LicenseCn = x.LicenseCn,
                   AmazonUserInfo_License = x.License,
                   AmazonUserInfo_BelongingName = x.BelongingName.DicFieldDes,
                   AmazonUserInfo_CreateTime = x.CreateTime,
                   AmazonUserInfo_UpdateTime = x.UpdateTime,
                   AmazonUserInfo_CreateBy = x.CreateBy,
                   AmazonUserInfo_UpdateBy = x.UpdateBy,
               })
               .Where(x => x.AmazonUserInfo_CreateBy == LoginUserInfo.ITCode)
               .OrderByDescending(x => x.AmazonUserInfo_CreateTime);

                return mode;
            }


        }


    }
    public class AmazonUserInfo_View : AmazonUserInfo
    {

        public string AmazonUserInfo_FaUserNameCn { get; set; }
        public string AmazonUserInfo_FaIdCard { get; set; }
        public string AmazonUserInfo_LicenseCn { get; set; }
        public string AmazonUserInfo_License { get; set; }
        public string AmazonUserInfo_BelongingName { get; set; }
        public DateTime? AmazonUserInfo_CreateTime { get; set; }
        public DateTime? AmazonUserInfo_UpdateTime { get; set; }
        public string AmazonUserInfo_CreateBy { get; set; }
        public string AmazonUserInfo_UpdateBy { get; set; }

    }

}