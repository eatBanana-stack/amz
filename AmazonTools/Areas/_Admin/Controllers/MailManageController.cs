using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;
using AmazonTools.Model;
using AmazonTools.ViewModel._Admin.MailManageVMs;


namespace AmazonTools._Admin.Controllers
{
    [AuthorizeJwtWithCookie]
    public partial class MailManageController : BaseApiController
    {
                                                
        [ActionDescription("Sys.Search")]
        [HttpPost("[action]")]
        public IActionResult SearchMailManage(AmazonTools.ViewModel._Admin.MailManageVMs.MailManageSearcher searcher)
        {
            if (ModelState.IsValid)
            {
                var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageListVM>();
                vm.Searcher = searcher;
                return Content(vm.GetJson(enumToString: false));
            }
            else
            {
                return BadRequest(ModelState.GetErrorJson());
            }
        }

        [ActionDescription("Sys.Export")]
        [HttpPost("[action]")]
        public IActionResult MailManageExportExcel(AmazonTools.ViewModel._Admin.MailManageVMs.MailManageSearcher searcher)
        {
            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageListVM>();
            vm.Searcher = searcher;
            vm.SearcherMode = ListVMSearchModeEnum.Export;
            return vm.GetExportData();
        }

        [ActionDescription("Sys.CheckExport")]
        [HttpPost("[action]")]
        public IActionResult MailManageExportExcelByIds(string[] ids)
        {
            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.MailManageVMs.MailManageListVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = new List<string>(ids);
                vm.SearcherMode = ListVMSearchModeEnum.CheckExport;
            }
            return vm.GetExportData();
        }
    
    }
}


