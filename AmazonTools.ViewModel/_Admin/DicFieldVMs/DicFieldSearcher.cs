
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
    public partial class DicFieldSearcher : BaseSearcher
    {
        
        public List<string> _AdminDicFieldSTempSelected { get; set; }

        protected override void InitVM()
        {
            
        }
    }

}