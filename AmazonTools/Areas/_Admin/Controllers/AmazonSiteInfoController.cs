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
using AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs;

namespace AmazonTools._Admin.Controllers
{
    public partial class AmazonSiteInfoController : BaseController
    {
        
        [ActionDescription("_Page._Admin.AmazonSiteInfo.Create")]
        public ActionResult Create()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs.AmazonSiteInfoVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonSiteInfo.Edit")]
        public ActionResult Edit(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs.AmazonSiteInfoVM>(id);
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonSiteInfo.Index", IsPage = true)]
        public ActionResult Index(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs.AmazonSiteInfoListVM>();
            if (string.IsNullOrEmpty(id) == false)
            {
            }
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonSiteInfo.Details")]
        public ActionResult Details(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs.AmazonSiteInfoVM>(id);
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonSiteInfo.Import")]
        public ActionResult Import()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs.AmazonSiteInfoImportVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.AmazonSiteInfo.BatchEdit")]
        [HttpPost]
        public ActionResult BatchEdit(string[] IDs)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs.AmazonSiteInfoBatchVM>(Ids: IDs);
            return PartialView(vm);
        }


        #region Search
        [ActionDescription("SearchAmazonSiteInfo")]
        [HttpPost]
        public IActionResult SearchAmazonSiteInfo(AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs.AmazonSiteInfoSearcher searcher)
        {
            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs.AmazonSiteInfoListVM>(passInit: true);
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
        public IActionResult AmazonSiteInfoExportExcel(AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs.AmazonSiteInfoListVM vm)
        {
            return vm.GetExportData();
        }
        
    }
}


