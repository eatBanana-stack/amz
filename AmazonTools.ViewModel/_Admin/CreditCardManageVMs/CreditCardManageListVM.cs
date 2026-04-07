using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.CreditCardManageVMs
{
    public partial class CreditCardManageListVM : BasePagedListVM<CreditCardManage_View, CreditCardManageSearcher>
    {
        
        protected override IEnumerable<IGridColumn<CreditCardManage_View>> InitGridHeader()
        {
            return new List<GridColumn<CreditCardManage_View>>{
                
                this.MakeGridHeader(x => x.CreditCardManage_CreditCard).SetTitle(@Localizer["Page.卡号"].Value),
                this.MakeGridHeader(x => x.CreditCardManage_SecurityCode).SetTitle(@Localizer["Page.安全码"].Value),
                this.MakeGridHeader(x => x.CreditCardManage_ValidityPeriod).SetTitle(@Localizer["_Admin.ValidDate"].Value),
                this.MakeGridHeader(x => x.CreditCardManage_CreateTime).SetTitle(@Localizer["_Admin.CreateTime"].Value),
                this.MakeGridHeader(x => x.CreditCardManage_UpdateTime).SetTitle(@Localizer["_Admin.UpdateTime"].Value),
                this.MakeGridHeader(x => x.CreditCardManage_CreateBy).SetTitle(@Localizer["_Admin.CreateBy"].Value),
                this.MakeGridHeader(x => x.CreditCardManage_UpdateBy).SetTitle(@Localizer["_Admin.UpdateBy"].Value),

                this.MakeGridHeaderAction(width: 200)
            };
        }

        
        public override IOrderedQueryable<CreditCardManage_View> GetSearchQuery()
        {
            var query = DC.Set<CreditCardManage>()
                
                .CheckContain(Searcher.CreditCard, x=>x.CreditCard)
                .CheckContain(Searcher.SecurityCode, x=>x.SecurityCode)
                .CheckContain(Searcher.ValidityPeriod, x=>x.ValidityPeriod)
                .CheckBetween(Searcher.CreateTime?.GetStartTime(), Searcher.CreateTime?.GetEndTime(), x => x.CreateTime, includeMax: false)
                .CheckBetween(Searcher.UpdateTime?.GetStartTime(), Searcher.UpdateTime?.GetEndTime(), x => x.UpdateTime, includeMax: false)
                .CheckContain(Searcher.CreateBy, x=>x.CreateBy)
                .CheckContain(Searcher.UpdateBy, x=>x.UpdateBy)
                .Select(x => new CreditCardManage_View
                {
				    ID = x.ID,
                    
                    CreditCardManage_CreditCard = x.CreditCard,
                    CreditCardManage_SecurityCode = x.SecurityCode,
                    CreditCardManage_ValidityPeriod = x.ValidityPeriod,
                    CreditCardManage_CreateTime = x.CreateTime,
                    CreditCardManage_UpdateTime = x.UpdateTime,
                    CreditCardManage_CreateBy = x.CreateBy,
                    CreditCardManage_UpdateBy = x.UpdateBy,
                })
                .OrderBy(x => x.ID);
            return query;
        }

        
    }
    public class CreditCardManage_View: CreditCardManage
    {
        
        public string CreditCardManage_CreditCard { get; set; }
        public string CreditCardManage_SecurityCode { get; set; }
        public string CreditCardManage_ValidityPeriod { get; set; }
        public DateTime? CreditCardManage_CreateTime { get; set; }
        public DateTime? CreditCardManage_UpdateTime { get; set; }
        public string CreditCardManage_CreateBy { get; set; }
        public string CreditCardManage_UpdateBy { get; set; }

    }

}