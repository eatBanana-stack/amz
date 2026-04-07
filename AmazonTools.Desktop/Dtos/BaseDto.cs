using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTools.Desktop.Dtos
{
    public class BaseDto<T>
    {
        public int StateCode { get; set; }
        public string Messge { get; set; }
        public T Data { get; set; }
    }
}
