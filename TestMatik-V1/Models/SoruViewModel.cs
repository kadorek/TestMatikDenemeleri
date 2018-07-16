using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMatik_V1.Models
{
    public class SoruViewModel
    {
        public Soru S { get; set; }
        public List<Secenek> SecenekListesi { get; set; }
    }
}