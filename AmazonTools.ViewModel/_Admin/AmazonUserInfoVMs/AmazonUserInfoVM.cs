using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;

using AmazonTools.ViewModel._Admin.DicFieldVMs;
using AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs;
using AmazonTools.Model._Admin;
using AmazonTools.Model;
namespace AmazonTools.ViewModel._Admin.AmazonUserInfoVMs
{
    public partial class AmazonUserInfoVM : BaseCRUDVM<AmazonUserInfo>
    {
        
        public List<string> _AdminAmazonUserInfoFTempSelected { get; set; }
        public AmazonSiteInfoAmazonUserDetailListVM AmazonSiteInfoAmazonUserList { get; set; }
        public AmazonSiteInfoAmazonUserDetailListVM1 AmazonSiteInfoAmazonUserList1 { get; set; }
        public AmazonSiteInfoAmazonUserDetailListVM2 AmazonSiteInfoAmazonUserList2 { get; set; }

        public AmazonUserInfoVM()
        {
            
            SetInclude(x => x.BelongingName);
            SetInclude(x => x.IDcardheld);
            SetInclude(x => x.BusinessLicenseHeld);
            AmazonSiteInfoAmazonUserList = new AmazonSiteInfoAmazonUserDetailListVM();
            AmazonSiteInfoAmazonUserList.DetailGridPrix = "Entity.AmazonSiteInfo_AmazonUser";
            AmazonSiteInfoAmazonUserList1 = new AmazonSiteInfoAmazonUserDetailListVM1();
            AmazonSiteInfoAmazonUserList1.DetailGridPrix = "Entity.AmazonSiteInfo_AmazonUser";
            AmazonSiteInfoAmazonUserList2 = new AmazonSiteInfoAmazonUserDetailListVM2();
            AmazonSiteInfoAmazonUserList2.DetailGridPrix = "Entity.AmazonSiteInfo_AmazonUser";

        }

        protected override void InitVM()
        {
            
            AmazonSiteInfoAmazonUserList.CopyContext(this);
            AmazonSiteInfoAmazonUserList1.CopyContext(this);
            AmazonSiteInfoAmazonUserList2.CopyContext(this);

        }

        public override DuplicatedInfo<AmazonUserInfo> SetDuplicatedCheck()
        {
            return null;

        }

        public override async Task DoAddAsync()        
        {
            
            await base.DoAddAsync();

        }

        public override async Task DoEditAsync(bool updateAllFields = false)
        {
            await base.DoEditAsync();
        }

        public override async Task DoDeleteAsync()
        {
            await base.DoDeleteAsync();
        }
    }
}
