using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMasterApi.Models
{
    public class SiteInfos
    {
        [Key]
        public int SiteID { get; set; }

        public string SiteUrl { get; set; }
    }
}