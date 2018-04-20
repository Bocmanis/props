using props.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace props.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Colour { get; set; }
        public bool FavouritePet { get; set; }
    }
}