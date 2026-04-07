using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;

using AmazonTools.ViewModel._Admin.DicFieldVMs;
using AmazonTools.Model._Admin;
using AmazonTools.Model;
namespace AmazonTools.ViewModel._Admin.DicDefVMs
{
    public partial class DicDefVM : BaseCRUDVM<DicDef>
    {
        
        public List<string> _AdminDicDefFTempSelected { get; set; }
        public DicFieldDicDefDetailListVM DicFieldDicDefList { get; set; }
        public DicFieldDicDefDetailListVM1 DicFieldDicDefList1 { get; set; }
        public DicFieldDicDefDetailListVM2 DicFieldDicDefList2 { get; set; }

        public DicDefVM()
        {
            
            DicFieldDicDefList = new DicFieldDicDefDetailListVM();
            DicFieldDicDefList.DetailGridPrix = "Entity.DicField_DicDef";
            DicFieldDicDefList1 = new DicFieldDicDefDetailListVM1();
            DicFieldDicDefList1.DetailGridPrix = "Entity.DicField_DicDef";
            DicFieldDicDefList2 = new DicFieldDicDefDetailListVM2();
            DicFieldDicDefList2.DetailGridPrix = "Entity.DicField_DicDef";

        }

        protected override void InitVM()
        {
            
            DicFieldDicDefList.CopyContext(this);
            DicFieldDicDefList1.CopyContext(this);
            DicFieldDicDefList2.CopyContext(this);

        }

        public override DuplicatedInfo<DicDef> SetDuplicatedCheck()
        {
            var rv = CreateFieldsInfo(SimpleField(x => x.DicName));
            return rv;

        }

        public override async Task DoAddAsync()        
        {
            
            await base.DoAddAsync();

        }

        public override async Task DoEditAsync(bool updateAllFields = false)
        {
            
            await base.DoEditAsync();

        }

        public override async Task DoDeleteAsync()
        {
            await base.DoDeleteAsync();

        }
    }
}
