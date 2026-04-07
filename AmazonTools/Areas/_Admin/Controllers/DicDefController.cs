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
using AmazonTools.ViewModel._Admin.DicDefVMs;

namespace AmazonTools._Admin.Controllers
{
    public partial class DicDefController : BaseController
    {
        
        [ActionDescription("_Page._Admin.DicDef.Create")]
        public ActionResult Create()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.DicDefVMs.DicDefVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.DicDef.Edit")]
        public ActionResult Edit(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.DicDefVMs.DicDefVM>(id);
            vm.DicFieldDicDefList1.Searcher.DicDefId = id;
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.DicDef.Index", IsPage = true)]
        public ActionResult Index(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.DicDefVMs.DicDefListVM>();
            if (string.IsNullOrEmpty(id) == false)
            {
            }
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.DicDef.Details")]
        public ActionResult Details(string id)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.DicDefVMs.DicDefVM>(id);
            vm.DicFieldDicDefList2.Searcher.DicDefId = id;
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.DicDef.Import")]
        public ActionResult Import()
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.DicDefVMs.DicDefImportVM>();
            return PartialView(vm);
        }

        
        [ActionDescription("_Page._Admin.DicDef.BatchEdit")]
        [HttpPost]
        public ActionResult BatchEdit(string[] IDs)
        {

            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.DicDefVMs.DicDefBatchVM>(Ids: IDs);
            return PartialView(vm);
        }


        #region Search
        [ActionDescription("SearchDicDef")]
        [HttpPost]
        public IActionResult SearchDicDef(AmazonTools.ViewModel._Admin.DicDefVMs.DicDefSearcher searcher)
        {
            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.DicDefVMs.DicDefListVM>(passInit: true);
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
        public IActionResult DicDefExportExcel(AmazonTools.ViewModel._Admin.DicDefVMs.DicDefListVM vm)
        {
            return vm.GetExportData();
        }
        
    }
}


