using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;

using AmazonTools.Model._Admin;
using AmazonTools.Model;
namespace AmazonTools.ViewModel._Admin.DicFieldVMs
{
    public partial class DicFieldVM : BaseCRUDVM<DicField>
    {
        
        public List<string> _AdminDicFieldFTempSelected { get; set; }

        public DicFieldVM()
        {
            
        }

        protected override void InitVM()
        {
            
        }

        public override DuplicatedInfo<DicField> SetDuplicatedCheck()
        {
            return null;

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
