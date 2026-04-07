using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.DicDefVMs
{
    public partial class DicDefListVM : BasePagedListVM<DicDef_View, DicDefSearcher>
    {
        
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeAction("DicDef","Create",@Localizer["Sys.Create"].Value,@Localizer["Sys.Create"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(false).SetHideOnToolBar(false).SetIconCls("fa fa-plus"),
                this.MakeAction("DicDef","Edit",@Localizer["Sys.Edit"].Value,@Localizer["Sys.Edit"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(true).SetHideOnToolBar(true).SetIconCls("fa fa-pencil-square"),
                this.MakeAction("DicDef","Details",@Localizer["Page.详情"].Value,@Localizer["Page.详情"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(true).SetHideOnToolBar(true).SetIconCls("fa fa-info-circle"),
                this.MakeStandardAction("DicDef", GridActionStandardTypesEnum.SimpleDelete, @Localizer["Sys.Delete"].Value, "_Admin", dialogWidth: 800).SetIconCls("fa fa-trash").SetButtonClass("layui-btn-danger"),
                this.MakeStandardAction("DicDef", GridActionStandardTypesEnum.SimpleBatchDelete, Localizer["Sys.BatchDelete"].Value, "_Admin", dialogWidth: 800).SetIconCls("fa fa-trash").SetButtonClass("layui-btn-danger"),
                this.MakeAction("DicDef","BatchEdit",@Localizer["Sys.BatchEdit"].Value,@Localizer["Sys.BatchEdit"].Value,GridActionParameterTypesEnum.MultiIds,"_Admin",800).SetShowInRow(false).SetHideOnToolBar(false).SetIconCls("fa fa-pencil-square"),
                this.MakeAction("DicDef","Import",@Localizer["Sys.Import"].Value,@Localizer["Sys.Import"].Value,GridActionParameterTypesEnum.SingleIdWithNull,"_Admin",800).SetShowInRow(false).SetHideOnToolBar(false).SetIconCls("fa fa-tasks"),
                this.MakeAction("DicDef","DicDefExportExcel",@Localizer["Sys.Export"].Value,@Localizer["Sys.Export"].Value,GridActionParameterTypesEnum.MultiIdWithNull,"_Admin").SetShowInRow(false).SetShowDialog(false).SetHideOnToolBar(false).SetIsExport(true).SetIconCls("fa fa-arrow-circle-down"),
            };
        }
 

        protected override IEnumerable<IGridColumn<DicDef_View>> InitGridHeader()
        {
            return new List<GridColumn<DicDef_View>>{
                
                this.MakeGridHeader(x => x.DicDef_DicName).SetTitle(@Localizer["Page.字典集名"].Value),
                this.MakeGridHeader(x => x.DicDef_DicField_DicDef_ID_Count).SetTitle(@Localizer["Page.数量"].Value),

                this.MakeGridHeaderAction(width: 200)
            };
        }

        

        public override IOrderedQueryable<DicDef_View> GetSearchQuery()
        {
            var query = DC.Set<DicDef>()
                
                .CheckContain(Searcher.DicName, x=>x.DicName)
                .Select(x => new DicDef_View
                {
				    ID = x.ID,
                    
                    DicDef_DicName = x.DicName,
                    DicDef_DicField_DicDef_ID_Count = x.DicField_DicDef.Count(),
                })
                .OrderBy(x => x.ID);
            return query;
        }

        
    }
    public class DicDef_View: DicDef
    {
        
        public string DicDef_DicName { get; set; }
        public int? DicDef_DicField_DicDef_ID_Count { get; set; }

    }

}