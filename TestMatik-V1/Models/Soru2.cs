﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMatik_V1.Models
{
    [MetadataType(typeof(SoruMetadata))]
    public partial class Soru
    {
        public IList<Secenek> SecenekList { get; set; }
        public IList<Secenek> YeniSecenekList { get; set; }
    }
}