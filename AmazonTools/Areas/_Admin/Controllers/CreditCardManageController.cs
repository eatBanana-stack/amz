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
using AmazonTools.ViewModel._Admin.CreditCardManageVMs;

namespace AmazonTools._Admin.Controllers
{
    public partial class CreditCardManageController : BaseController
    {
        
        [ActionDescription("_Page._Admin.CreditCardManage.Create")]
        public ActionResult Create()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.CreditCardManageVMs.CreditCardManageVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.CreditCardManage.Edit")]
        public ActionResult Edit(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.CreditCardManageVMs.CreditCardManageVM>(id);
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.CreditCardManage.Index", IsPage = true)]
        public ActionResult Index(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.CreditCardManageVMs.CreditCardManageListVM>();
            if (string.IsNullOrEmpty(id) == false)
            {
            }
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.CreditCardManage.Details")]
        public ActionResult Details(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.CreditCardManageVMs.CreditCardManageVM>(id);
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.CreditCardManage.Import")]
        public ActionResult Import()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.CreditCardManageVMs.CreditCardManageImportVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.CreditCardManage.BatchEdit")]
        [HttpPost]
        public ActionResult BatchEdit(string[] IDs)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.CreditCardManageVMs.CreditCardManageBatchVM>(Ids: IDs);
            return PartialView(vm);
        }


        #region Search
        [ActionDescription("SearchCreditCardManage")]
        [HttpPost]
        public IActionResult SearchCreditCardManage(AmazonTools.ViewModel._Admin.CreditCardManageVMs.CreditCardManageSearcher searcher)
        {
            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.CreditCardManageVMs.CreditCardManageListVM>(passInit: true);
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
        public IActionResult CreditCardManageExportExcel(AmazonTools.ViewModel._Admin.CreditCardManageVMs.CreditCardManageListVM vm)
        {
            return vm.GetExportData();
        }
        
    }
}


