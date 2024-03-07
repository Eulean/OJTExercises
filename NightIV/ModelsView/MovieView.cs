using NightIV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightIV.ModelsView
{
    public class MovieView
    {
        public IEnumerable<Genres> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenresId { get; set; }

        [Required]
        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public int? Stock {  get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieView()
        {
            Id = 0;
        }

        public MovieView(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenresId = movie.GenresId;
        }
    }
}