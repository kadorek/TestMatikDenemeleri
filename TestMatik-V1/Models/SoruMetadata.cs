using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestMatik_V1.Models
{

    //[Bind(Exclude = "ID")]
    public class SoruMetadata
    {
        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Metin { get; set; }
    }
}