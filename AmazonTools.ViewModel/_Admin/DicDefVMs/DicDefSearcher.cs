
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
    public partial class DicDefSearcher : BaseSearcher
    {
        
        public List<string> _AdminDicDefSTempSelected { get; set; }
        [Display(Name = "_Model._DicDef._DicName")]
        public string DicName { get; set; }

        protected override void InitVM()
        {
            
        }
    }

}