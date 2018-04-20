using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace props.Models
{
    public class Gender
    {
        public int Id { get; set; }
        [DisplayName("Gender")]
        public string Label { get; set; }
        public string Text_Fin { get; set; }
        public string Text_En { get; set; }
        public string Text_Swe { get; set; }
    }
}