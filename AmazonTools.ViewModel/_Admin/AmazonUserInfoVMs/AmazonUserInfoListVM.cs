using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.AmazonUserInfoVMs
{
    public partial class AmazonUserInfoListVM : BasePagedListVM<AmazonUserInfo_View, AmazonUserInfoSearcher>
    {
        
        protected override IEnumerable<IGridColumn<AmazonUserInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<AmazonUserInfo_View>>{
                
                this.MakeGridHeader(x => x.AmazonUserInfo_FaUserNameCn).SetTitle(@Localizer["Page.姓名中文"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_FaUserNameUs).SetTitle(@Localizer["Page.姓名拼音"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_FaIdCard).SetTitle(@Localizer["Page.身份证"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_FaBornTime).SetTitle(@Localizer["Page.出生时间"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_FaEndTime).SetTitle(@Localizer["Page.有效时间"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_LicenseCn).SetTitle(@Localizer["Page.执照中文"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_LicenseUs).SetTitle(@Localizer["Page.执照拼音"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_LicenseCode).SetTitle(@Localizer["Page.执照代码"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_License).SetTitle(@Localizer["Page.执照时间"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_MailingAddress).SetTitle(@Localizer["Page.邮寄地址"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_MailingZipCode).SetTitle(@Localizer["Page.邮寄邮编"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_BelongingName).SetTitle(@Localizer["Page.代理"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_LicenseAddress).SetTitle(@Localizer["Page.营业执照地址"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_LicenseZipCode).SetTitle(@Localizer["Page.营业执照邮编"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_CreateTime).SetTitle(@Localizer["_Admin.CreateTime"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_UpdateTime).SetTitle(@Localizer["_Admin.UpdateTime"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_CreateBy).SetTitle(@Localizer["_Admin.CreateBy"].Value),
                this.MakeGridHeader(x => x.AmazonUserInfo_UpdateBy).SetTitle(@Localizer["_Admin.UpdateBy"].Value),

                this.MakeGridHeaderAction(width: 200)
            };
        }

        
        public override IOrderedQueryable<AmazonUserInfo_View> GetSearchQuery()
        {
            var query = DC.Set<AmazonUserInfo>()
                
                .CheckContain(Searcher.FaUserNameCn, x=>x.FaUserNameCn)
                .CheckContain(Searcher.FaUserNameUs, x=>x.FaUserNameUs)
                .CheckContain(Searcher.FaIdCard, x=>x.FaIdCard)
                .CheckContain(Searcher.FaBornTime, x=>x.FaBornTime)
                .CheckContain(Searcher.FaEndTime, x=>x.FaEndTime)
                .CheckContain(Searcher.LicenseCn, x=>x.LicenseCn)
                .CheckContain(Searcher.LicenseUs, x=>x.LicenseUs)
                .CheckContain(Searcher.LicenseCode, x=>x.LicenseCode)
                .CheckContain(Searcher.License, x=>x.License)
                .CheckContain(Searcher.MailingAddress, x=>x.MailingAddress)
                .CheckContain(Searcher.MailingZipCode, x=>x.MailingZipCode)
                .CheckEqual(Searcher.BelongingName, x=>x.BelongingName)
                .CheckContain(Searcher.LicenseAddress, x=>x.LicenseAddress)
                .CheckContain(Searcher.LicenseZipCode, x=>x.LicenseZipCode)
                .CheckBetween(Searcher.CreateTime?.GetStartTime(), Searcher.CreateTime?.GetEndTime(), x => x.CreateTime, includeMax: false)
                .CheckBetween(Searcher.UpdateTime?.GetStartTime(), Searcher.UpdateTime?.GetEndTime(), x => x.UpdateTime, includeMax: false)
                .CheckContain(Searcher.CreateBy, x=>x.CreateBy)
                .CheckContain(Searcher.UpdateBy, x=>x.UpdateBy)
                .Select(x => new AmazonUserInfo_View
                {
				    ID = x.ID,
                    
                    AmazonUserInfo_FaUserNameCn = x.FaUserNameCn,
                    AmazonUserInfo_FaUserNameUs = x.FaUserNameUs,
                    AmazonUserInfo_FaIdCard = x.FaIdCard,
                    AmazonUserInfo_FaBornTime = x.FaBornTime,
                    AmazonUserInfo_FaEndTime = x.FaEndTime,
                    AmazonUserInfo_LicenseCn = x.LicenseCn,
                    AmazonUserInfo_LicenseUs = x.LicenseUs,
                    AmazonUserInfo_LicenseCode = x.LicenseCode,
                    AmazonUserInfo_License = x.License,
                    AmazonUserInfo_MailingAddress = x.MailingAddress,
                    AmazonUserInfo_MailingZipCode = x.MailingZipCode,
                    AmazonUserInfo_BelongingName = x.BelongingName,
                    AmazonUserInfo_LicenseAddress = x.LicenseAddress,
                    AmazonUserInfo_LicenseZipCode = x.LicenseZipCode,
                    AmazonUserInfo_CreateTime = x.CreateTime,
                    AmazonUserInfo_UpdateTime = x.UpdateTime,
                    AmazonUserInfo_CreateBy = x.CreateBy,
                    AmazonUserInfo_UpdateBy = x.UpdateBy,
                })
                .OrderBy(x => x.ID);
            return query;
        }

        
    }
    public class AmazonUserInfo_View: AmazonUserInfo
    {
        
        public string AmazonUserInfo_FaUserNameCn { get; set; }
        public string AmazonUserInfo_FaUserNameUs { get; set; }
        public string AmazonUserInfo_FaIdCard { get; set; }
        public string AmazonUserInfo_FaBornTime { get; set; }
        public string AmazonUserInfo_FaEndTime { get; set; }
        public string AmazonUserInfo_LicenseCn { get; set; }
        public string AmazonUserInfo_LicenseUs { get; set; }
        public string AmazonUserInfo_LicenseCode { get; set; }
        public string AmazonUserInfo_License { get; set; }
        public string AmazonUserInfo_MailingAddress { get; set; }
        public string AmazonUserInfo_MailingZipCode { get; set; }
        public DicDef AmazonUserInfo_BelongingName { get; set; }
        public string AmazonUserInfo_LicenseAddress { get; set; }
        public string AmazonUserInfo_LicenseZipCode { get; set; }
        public DateTime? AmazonUserInfo_CreateTime { get; set; }
        public DateTime? AmazonUserInfo_UpdateTime { get; set; }
        public string AmazonUserInfo_CreateBy { get; set; }
        public string AmazonUserInfo_UpdateBy { get; set; }

    }

}