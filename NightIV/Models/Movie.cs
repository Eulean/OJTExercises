using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NightIV.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Generes {  get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int Stock {  get; set; }
    }
}