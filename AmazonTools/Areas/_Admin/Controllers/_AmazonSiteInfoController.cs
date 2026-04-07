using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using System.Linq;
using System.Collections.Generic;
using AmazonTools.Model._Admin;
using AmazonTools.ViewModel._Admin.AmazonSiteInfoVMs;
using AmazonTools.Model;

namespace AmazonTools._Admin.Controllers
{
    [AuthorizeJwtWithCookie]
    [ActionDescription("_Model.AmazonSiteInfo")]
    [ApiController]
    [Route("/api/_Admin/AmazonSiteInfo")]
    public partial class AmazonSiteInfoController : BaseApiController
    {
        [ActionDescription("Sys.Get")]
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var vm = Wtm.CreateVM<AmazonSiteInfoVM>(id);
            return Ok(vm);
        }

        [ActionDescription("Sys.Create")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(AmazonSiteInfoVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                await vm.DoAddAsync();
   
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }

        }

        [ActionDescription("Sys.Edit")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Edit(AmazonSiteInfoVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                await vm.DoEditAsync(false);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.GetErrorJson());
                }
                else
                {
                    return Ok(vm.Entity);
                }
            }
        }
                

        [HttpPost("BatchEdit")]
        [ActionDescription("Sys.BatchEdit")]
        public ActionResult BatchEdit(AmazonSiteInfoBatchVM vm)
        {
            if (!ModelState.IsValid || !vm.DoBatchEdit())
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                return Ok(vm.Ids.Count());
            }
        }

		[HttpPost("BatchDelete")]
        [ActionDescription("Sys.Delete")]
        public IActionResult BatchDelete(string[] ids)
        {
            var vm = Wtm.CreateVM<AmazonSiteInfoBatchVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = ids;
            }
            else
            {
                return Ok();
            }
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return BadRequest(ModelState.GetErrorJson());
            }
            else
            {
                return Ok(ids.Count());
            }
        }

        [ActionDescription("Sys.DownloadTemplate")]
        [HttpGet("GetExcelTemplate")]
        public IActionResult GetExcelTemplate()
        {
            var vm = Wtm.CreateVM<AmazonSiteInfoImportVM>();
            var qs = new Dictionary<string, string>();
            foreach (var item in Request.Query.Keys)
            {
                qs.Add(item, Request.Query[item]);
            }
            vm.SetParms(qs);
            var data = vm.GenerateTemplate(out string fileName);
            return File(data, "application/vnd.ms-excel", fileName);
        }

        [ActionDescription("Sys.Import")]
        [HttpPost("Import")]
        public ActionResult Import(AmazonSiteInfoImportVM vm)
        {

            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return BadRequest(vm.GetErrorJson());
            }
            else
            {
                return Ok(vm.EntityList.Count);
            }
        }



        
        [HttpGet("GetAmazonUserInfos")]
        public ActionResult GetAmazonUserInfos()
        {
            return Ok(DC.Set<AmazonUserInfo>().GetSelectListItems(Wtm, x => x.FaUserNameCn));
        }
        [HttpPost("[action]")]
        public ActionResult Select_GetAmazonUserInfoByAmazonUserInfoId(List<string> id)
        {
            var rv = DC.Set<AmazonUserInfo>().CheckIDs(id).GetSelectListItems(Wtm, x => x.FaUserNameCn);
            return Ok(rv);
        }

        [HttpPost("[action]")]
        public ActionResult Select_GetAmazonSiteInfoByAmazonUserInfo(List<string> id)
        {
            var rv = DC.Set<AmazonSiteInfo>().CheckIDs(id, x => x.AmazonUserId).GetSelectListItems(Wtm,x=>x.Mail.ToString());
            return Ok(rv);
        }


    }
}