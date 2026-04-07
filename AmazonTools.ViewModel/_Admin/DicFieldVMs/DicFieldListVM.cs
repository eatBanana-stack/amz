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
    public partial class DicFieldListVM : BasePagedListVM<DicField_View, DicFieldSearcher>
    {
        
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
            };
        }
 

        protected override IEnumerable<IGridColumn<DicField_View>> InitGridHeader()
        {
            return new List<GridColumn<DicField_View>>{
                
                this.MakeGridHeaderAction(width: 200).SetHide(true)
            };
        }

        
        public override IOrderedQueryable<DicField_View> GetSearchQuery()
        {
            var query = DC.Set<DicField>()
                                .Select(x => new DicField_View
                {
				    ID = x.ID,
                                    })
                .OrderBy(x => x.ID);
            return query;
        }

        
    }
    public class DicField_View: DicField
    {
        
    }

}