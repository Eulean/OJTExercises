using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NightIV.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Pls Enter Customer Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }

        /*[Required]
        [StringLength(50)]
        public string Email { get; set; }
        public string Password { get; set; }*/

        
        public bool IsSubscribed { get; set; }


        public MemberShipTypes MemberShipType { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte MemberShipTypeId { get; set; }
    }

    
}