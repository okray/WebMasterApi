using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebMasterApi.Models;

namespace WebMasterApi.Controllers
{
    public class SitesController : ApiController
    {
        private WebMasterContext db = new WebMasterContext();

        // GET api/Sites
        public IQueryable<SiteInfos> GetSites()
        {
            return db.Sites;
        }

        // GET api/Sites/5
        [ResponseType(typeof(SiteInfos))]
        public IHttpActionResult GetSiteInfos(int id)
        {
            SiteInfos siteinfos = db.Sites.Find(id);
            if (siteinfos == null)
            {
                return NotFound();
            }

            return Ok(siteinfos);
        }

        // PUT api/Sites/5
        public IHttpActionResult PutSiteInfos(int id, SiteInfos siteinfos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siteinfos.SiteID)
            {
                return BadRequest();
            }

            db.Entry(siteinfos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteInfosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Sites
        [ResponseType(typeof(SiteInfos))]
        public IHttpActionResult PostSiteInfos(SiteInfos siteinfos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sites.Add(siteinfos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = siteinfos.SiteID }, siteinfos);
        }

        // DELETE api/Sites/5
        [ResponseType(typeof(SiteInfos))]
        public IHttpActionResult DeleteSiteInfos(int id)
        {
            SiteInfos siteinfos = db.Sites.Find(id);
            if (siteinfos == null)
            {
                return NotFound();
            }

            db.Sites.Remove(siteinfos);
            db.SaveChanges();

            return Ok(siteinfos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SiteInfosExists(int id)
        {
            return db.Sites.Count(e => e.SiteID == id) > 0;
        }
    }
}