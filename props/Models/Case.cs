using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mrProper.Models
{
    public class Case
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public string Number { get; set; }
        public DateTime CreationDate { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}