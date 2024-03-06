using NightIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NightIV.ModelsView
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MemberShipTypes> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}