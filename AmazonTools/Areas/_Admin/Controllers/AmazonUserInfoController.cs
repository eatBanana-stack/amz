using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using System.Collections.Generic;
using AmazonTools.Model;
using AmazonTools.ViewModel._Admin.AmazonUserInfoVMs;

namespace AmazonTools._Admin.Controllers
{
    public partial class AmazonUserInfoController : BaseController
    {
        
        [ActionDescription("_Page._Admin.AmazonUserInfo.Create")]
        public ActionResult Create()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonUserInfo.Edit")]
        public ActionResult Edit(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoVM>(id);
            vm.AmazonSiteInfoAmazonUserList1.Searcher.AmazonUserId = id;
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonUserInfo.Index", IsPage = true)]
        public ActionResult Index(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoListVM>();
            if (string.IsNullOrEmpty(id) == false)
            {
            }
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonUserInfo.Details")]
        public ActionResult Details(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoVM>(id);
            vm.AmazonSiteInfoAmazonUserList2.Searcher.AmazonUserId = id;
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonUserInfo.Import")]
        public ActionResult Import()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoImportVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonUserInfo.BatchEdit")]
        [HttpPost]
        public ActionResult BatchEdit(string[] IDs)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoBatchVM>(Ids: IDs);
            return PartialView(vm);
        }


        #region Search
        [ActionDescription("SearchAmazonUserInfo")]
        [HttpPost]
        public IActionResult SearchAmazonUserInfo(AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoSearcher searcher)
        {
            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoListVM>(passInit: true);
            if (ModelState.IsValid)
            {
                vm.Searcher = searcher;
                return Content(vm.GetJson(false));
            }
            else
            {
                return Content(vm.GetError());
            }
        }
        #endregion

        [ActionDescription("Sys.Export")]
        [HttpPost]
        public IActionResult AmazonUserInfoExportExcel(AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoListVM vm)
        {
            return vm.GetExportData();
        }
        
    }
}


