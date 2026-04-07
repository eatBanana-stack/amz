using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonTools.Model
{

    public class RefDicNameAttribute : Attribute
    {
        public string Name { get; set; }
    }
}