
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;



namespace AmazonTools.ViewModel._Admin.DicFieldVMs
{
    public partial class DicFieldDicDefDetailListVM2 : BasePagedListVM<DicField, DicFieldDetailSearcher2>
    {
        
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
            };
        }
 
        protected override IEnumerable<IGridColumn<DicField>> InitGridHeader()
        {
            return new List<GridColumn<DicField>>{
                
                this.MakeGridHeader(x => x.DicFieldName).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["Page.键"].Value),
                this.MakeGridHeader(x => x.DicFieldDes).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["Page.值"].Value),
                this.MakeGridHeader(x => x.Order).SetEditType(EditTypeEnum.TextBox).SetTitle(@Localizer["Page.排序"].Value),

            };
        }

        
        public override IOrderedQueryable<DicField> GetSearchQuery()
        {
                
            var id = (Guid?)Searcher.DicDefId.ConvertValue(typeof(Guid?));
            if (id == null)
                return new List<DicField>().AsQueryable().OrderBy(x => x.ID);
            var query = DC.Set<DicField>()
                .Where(x => id == x.DicDefId)

                .OrderBy(x=>x.Order);
            return query;
        }

    }

    public partial class DicFieldDetailSearcher2 : BaseSearcher
    {
        
        [Display(Name = "_Model._DicField._DicDef")]
        public string DicDefId { get; set; }
    }

}

