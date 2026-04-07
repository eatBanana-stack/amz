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
    [Area("_Admin")]
    [ActionDescription("_Model.AmazonSiteInfo")]
    public partial class AmazonSiteInfoController : BaseController
    {
        #region Create
        [HttpPost]
        [ActionDescription("Sys.Create")]
        public async Task<ActionResult> Create(AmazonSiteInfoVM vm)
        {
            if (!ModelState.IsValid)
            {
                
                return PartialView(vm.FromView, vm);
            }
            else
            {
                await vm.DoAddAsync();
                
                if (!ModelState.IsValid)
                {
                    
                    vm.DoReInit();
                    return PartialView("../AmazonSiteInfo/Create", vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGrid();
                }
            }
        }
        #endregion

        #region Edit
       
        [ActionDescription("Sys.Edit")]
        [HttpPost]
        [ValidateFormItemOnly]
        public async Task<ActionResult> Edit(AmazonSiteInfoVM vm)
        {
            if (!ModelState.IsValid)
            {
                
                return PartialView(vm.FromView, vm);
            }
            else
            {
                await vm.DoEditAsync();
                if (!ModelState.IsValid)
                {
                    
                    vm.DoReInit();
                    return PartialView("../AmazonSiteInfo/Edit", vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGridRow(CurrentWindowId);
                }
            }
        }
        #endregion
      
                


        #region BatchEdit

        [HttpPost]
        [ActionDescription("Sys.BatchEdit")]
        public ActionResult DoBatchEdit(AmazonSiteInfoBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchEdit())
            {
                return PartialView(vm.FromView, vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert(Localizer["Sys.BatchEditSuccess", vm.Ids.Length]);
            }
        }
        #endregion

        #region BatchDelete
        [HttpPost]
        [ActionDescription("Sys.BatchDelete")]
        public ActionResult BatchDelete(string[] ids)
        {
            var vm = Wtm.CreateVM<AmazonSiteInfoBatchVM>();
            if (ids != null && ids.Length > 0)
            {
                vm.Ids = ids;
            }
            else
            {
                return Ok();
            }
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return FFResult().Alert(ModelState.GetErrorJson().GetFirstError());
            }
            else
            {
                return FFResult().RefreshGrid(CurrentWindowId).Alert(Localizer["Sys.BatchDeleteSuccess",vm.Ids.Length]);
            }
        }
        #endregion
      
        #region Import
        [HttpPost]
        [ActionDescription("Sys.Import")]
        public ActionResult Import(AmazonSiteInfoImportVM vm, IFormCollection nouse)
        {
            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return PartialView(vm.FromView, vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert(Localizer["Sys.ImportSuccess", vm.EntityList.Count.ToString()]);
            }
        }
        #endregion



        
        public ActionResult GetDicFields站点()
        {
            return JsonMore(DC.Set<DicField>().Where(x => x.DicDef.DicName == "站点").OrderBy(x => x.Order).GetSelectListItems(Wtm, x => x.DicFieldDes, SortByName: false));
        }
        public ActionResult Select_GetDicFieldByDicFieldId站点(List<string> id)
        {
            var rv = DC.Set<DicField>().Where(x => x.DicDef.DicName == "站点").CheckIDs(id).OrderBy(x => x.Order).GetSelectListItems(Wtm, x => x.DicFieldDes, SortByName: false);
            return JsonMore(rv);
        }

        public ActionResult Select_GetAmazonSiteInfoByDicField(List<string> id)
        {
            var rv = DC.Set<AmazonSiteInfo>().CheckIDs(id, x => x.SiteNameId).GetSelectListItems(Wtm,x=>x.Mail.ToString(), SortByName: false);
            return JsonMore(rv);
        }


        public ActionResult GetDicFields站点状态()
        {
            return JsonMore(DC.Set<DicField>().Where(x => x.DicDef.DicName == "站点状态").OrderBy(x => x.Order).GetSelectListItems(Wtm, x => x.DicFieldDes, SortByName: false));
        }
        public ActionResult Select_GetDicFieldByDicFieldId站点状态(List<string> id)
        {
            var rv = DC.Set<DicField>().Where(x => x.DicDef.DicName == "站点状态").CheckIDs(id).OrderBy(x => x.Order).GetSelectListItems(Wtm, x => x.DicFieldDes, SortByName: false);
            return JsonMore(rv);
        }


        public ActionResult GetAmazonUserInfos()
        {
            return JsonMore(DC.Set<AmazonUserInfo>().GetSelectListItems(Wtm, x => x.FaUserNameCn));
        }
        public ActionResult Select_GetAmazonUserInfoByAmazonUserInfoId(List<string> id)
        {
            var rv = DC.Set<AmazonUserInfo>().CheckIDs(id).GetSelectListItems(Wtm, x => x.FaUserNameCn);
            return JsonMore(rv);
        }

        public ActionResult Select_GetAmazonSiteInfoByAmazonUserInfo(List<string> id)
        {
            var rv = DC.Set<AmazonSiteInfo>().CheckIDs(id, x => x.AmazonUserId).GetSelectListItems(Wtm,x=>x.Mail.ToString());
            return JsonMore(rv);
        }

    }
}