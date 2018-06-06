using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMatik_V1.Models
{
    public class SecenekMetadata
    {
        [UIHint("tinymce_full_secenek"),AllowHtml]
        public string Metin { get; set; }
    }
}