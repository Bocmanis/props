using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace props.Models
{
    public class PropertyPattern
    {
        public string Id { get; set; }
        public List<FullProp> Properties { get; set; }
    }
}