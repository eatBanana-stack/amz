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
using AmazonTools.ViewModel._Admin.AmazonUserInfoVMs;
using AmazonTools.Model;

namespace AmazonTools._Admin.Controllers
{
    [Area("_Admin")]
    [ActionDescription("_Model.AmazonUserInfo")]
    public partial class AmazonUserInfoController : BaseController
    {
        #region Create
        [HttpPost]
        [ActionDescription("Sys.Create")]
        public async Task<ActionResult> Create(AmazonUserInfoVM vm)
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
                    return PartialView("../AmazonUserInfo/Create", vm);
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
        public async Task<ActionResult> Edit(AmazonUserInfoVM vm)
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
                    return PartialView("../AmazonUserInfo/Edit", vm);
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
        public ActionResult DoBatchEdit(AmazonUserInfoBatchVM vm, IFormCollection nouse)
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
            var vm = Wtm.CreateVM<AmazonUserInfoBatchVM>();
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
        public ActionResult Import(AmazonUserInfoImportVM vm, IFormCollection nouse)
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



        
        public ActionResult GetDicFields代理()
        {
            return JsonMore(DC.Set<DicField>().Where(x => x.DicDef.DicName == "代理").OrderBy(x => x.Order).GetSelectListItems(Wtm, x => x.DicFieldDes, SortByName: false));
        }
        public ActionResult Select_GetDicFieldByDicFieldId代理(List<string> id)
        {
            var rv = DC.Set<DicField>().Where(x => x.DicDef.DicName == "代理").CheckIDs(id).OrderBy(x => x.Order).GetSelectListItems(Wtm, x => x.DicFieldDes, SortByName: false);
            return JsonMore(rv);
        }

        public ActionResult Select_GetAmazonUserInfoByDicField(List<string> id)
        {
            var rv = DC.Set<AmazonUserInfo>().CheckIDs(id, x => x.BelongingNameId).GetSelectListItems(Wtm,x=>x.FaUserNameCn, SortByName: false);
            return JsonMore(rv);
        }

    }
}