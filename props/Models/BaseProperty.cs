using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace props.Models
{
    public class BaseProperty
    {
        public int Id { get; set; }
        public PropertyType PropertyType { get; set; }
        public int PropertyTypeId { get; set; }
        public string Select { get; set; }
        public string Label { get; set; }
    }
}