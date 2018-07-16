using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestMatik_V1.Models
{
    [MetadataType(typeof(SecenekMetadata))]
    public partial class Secenek
    {
        public bool DogruMu { get; set; }
    }
}