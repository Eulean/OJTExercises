﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightIV.Models
{
    public class MemberShipTypes
    {
        public byte Id {  get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}