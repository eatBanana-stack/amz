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
using AmazonTools.ViewModel._Admin.MailManageVMs;

namespace AmazonTools._Admin.Controllers
{
    public partial class MailManageController : BaseController
    {
        
        [ActionDescription("_Page._Admin.MailManage.Create")]
        public ActionResult Create()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.MailManage.Edit")]
        public ActionResult Edit(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageVM>(id);
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.MailManage.Index", IsPage = true)]
        public ActionResult Index(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageListVM>();
            if (string.IsNullOrEmpty(id) == false)
            {
            }
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.MailManage.Details")]
        public ActionResult Details(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageVM>(id);
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.MailManage.Import")]
        public ActionResult Import()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageImportVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.MailManage.BatchEdit")]
        [HttpPost]
        public ActionResult BatchEdit(string[] IDs)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageBatchVM>(Ids: IDs);
            return PartialView(vm);
        }


        #region Search
        [ActionDescription("SearchMailManage")]
        [HttpPost]
        public IActionResult SearchMailManage(AmazonTools.ViewModel._Admin.MailManageVMs.MailManageSearcher searcher)
        {
            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageListVM>(passInit: true);
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
        public IActionResult MailManageExportExcel(AmazonTools.ViewModel._Admin.MailManageVMs.MailManageListVM vm)
        {
            return vm.GetExportData();
        }
        
    }
}


