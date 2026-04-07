using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using AmazonTools.Model._Admin;
using AmazonTools.Model;

namespace AmazonTools.ViewModel._Admin.MailManageVMs
{
    public partial class MailManageListVM : BasePagedListVM<MailManage_View, MailManageSearcher>
    {
        
        protected override IEnumerable<IGridColumn<MailManage_View>> InitGridHeader()
        {
            return new List<GridColumn<MailManage_View>>{
                
                this.MakeGridHeader(x => x.MailManage_Mail).SetTitle(@Localizer["_Admin.Email"].Value),
                this.MakeGridHeader(x => x.MailManage_PassWord).SetTitle(@Localizer["_Admin.Password"].Value),
                this.MakeGridHeader(x => x.MailManage_CreateTime).SetTitle(@Localizer["_Admin.CreateTime"].Value),
                this.MakeGridHeader(x => x.MailManage_UpdateTime).SetTitle(@Localizer["_Admin.UpdateTime"].Value),
                this.MakeGridHeader(x => x.MailManage_CreateBy).SetTitle(@Localizer["_Admin.CreateBy"].Value),
                this.MakeGridHeader(x => x.MailManage_UpdateBy).SetTitle(@Localizer["_Admin.UpdateBy"].Value),

                this.MakeGridHeaderAction(width: 200)
            };
        }

        
        public override IOrderedQueryable<MailManage_View> GetSearchQuery()
        {
            var query = DC.Set<MailManage>()
                
                .CheckContain(Searcher.Mail, x=>x.Mail)
                .CheckContain(Searcher.PassWord, x=>x.PassWord)
                .CheckBetween(Searcher.CreateTime?.GetStartTime(), Searcher.CreateTime?.GetEndTime(), x => x.CreateTime, includeMax: false)
                .CheckBetween(Searcher.UpdateTime?.GetStartTime(), Searcher.UpdateTime?.GetEndTime(), x => x.UpdateTime, includeMax: false)
                .CheckContain(Searcher.CreateBy, x=>x.CreateBy)
                .CheckContain(Searcher.UpdateBy, x=>x.UpdateBy)
                .Select(x => new MailManage_View
                {
				    ID = x.ID,
                    
                    MailManage_Mail = x.Mail,
                    MailManage_PassWord = x.PassWord,
                    MailManage_CreateTime = x.CreateTime,
                    MailManage_UpdateTime = x.UpdateTime,
                    MailManage_CreateBy = x.CreateBy,
                    MailManage_UpdateBy = x.UpdateBy,
                })
                .OrderBy(x => x.ID);
            return query;
        }

        
    }
    public class MailManage_View: MailManage
    {
        
        public string MailManage_Mail { get; set; }
        public string MailManage_PassWord { get; set; }
        public DateTime? MailManage_CreateTime { get; set; }
        public DateTime? MailManage_UpdateTime { get; set; }
        public string MailManage_CreateBy { get; set; }
        public string MailManage_UpdateBy { get; set; }

    }

}