using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;
using AmazonTools.Model;
using AmazonTools.ViewModel._Admin.AmazonUserInfoVMs;


namespace AmazonTools._Admin.Controllers
{
    [AuthorizeJwtWithCookie]
    public partial class AmazonUserInfoController : BaseApiController
    {
                                                
        [ActionDescription("Sys.Search")]
        [HttpPost("[action]")]
        public IActionResult SearchAmazonUserInfo(AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoSearcher searcher)
        {
            if (ModelState.IsValid)
            {
                var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoListVM>();
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
        public IActionResult AmazonUserInfoExportExcel(AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoSearcher searcher)
        {
            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoListVM>();
            vm.Searcher = searcher;
            vm.SearcherMode = ListVMSearchModeEnum.Export;
            return vm.GetExportData();
        }

        [ActionDescription("Sys.CheckExport")]
        [HttpPost("[action]")]
        public IActionResult AmazonUserInfoExportExcelByIds(string[] ids)
        {
            var vm = Wtm.CreateVM<AmazonTools.ViewModel._Admin.AmazonUserInfoVMs.AmazonUserInfoListVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = new List<string>(ids);
                vm.SearcherMode = ListVMSearchModeEnum.CheckExport;
            }
            return vm.GetExportData();
        }
    
    }
}


