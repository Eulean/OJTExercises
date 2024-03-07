using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NightIV.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [Required]
        [Display(Name = "Number of Stock")]
        public int Stock {  get; set; }


        public Genres Genres { get; set; }
        [Required]
        [Display(Name="Genre")]
        public byte GenresId { get; set; }

        
        
    }
}