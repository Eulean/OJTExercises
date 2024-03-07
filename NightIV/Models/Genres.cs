using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightIV.Models
{
    public class Genres
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Genres")]
        public string Name { get; set; }

        
    }
}