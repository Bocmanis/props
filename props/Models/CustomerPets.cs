using props.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace props.Models
{
    public class CustomerPets
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Pet Pet { get; set; }
        public int PetId { get; set; }
    }
}