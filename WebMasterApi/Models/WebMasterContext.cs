using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMasterApi.Models
{
    public class WebMasterContext:DbContext
    {
        public DbSet<SiteInfos> Sites { get; set; }
    }
}