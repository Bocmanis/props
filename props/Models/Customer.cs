using props.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace props.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<Case> Cases { get; set; }
        [NotMapped]
        public Pet FavouritePet { get; set; }
    }
}