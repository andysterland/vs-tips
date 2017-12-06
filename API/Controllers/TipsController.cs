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
using API.Models;

namespace API.Controllers
{
    public class TipsController : ApiController
    {
        private TipContainer db = new TipContainer();

        // GET: api/Tips
        public IQueryable<Tip> GetTips()
        {
            return db.Tips;
        }

        // GET: api/Tips/5
        [ResponseType(typeof(Tip))]
        public IHttpActionResult GetTip(int id)
        {
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return NotFound();
            }

            return Ok(tip);
        }

        // PUT: api/Tips/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTip(int id, Tip tip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tip.Id)
            {
                return BadRequest();
            }

            db.Entry(tip).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipExists(id))
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

        // POST: api/Tips
        [ResponseType(typeof(Tip))]
        public IHttpActionResult PostTip(Tip tip)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tips.Add(tip);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tip.Id }, tip);
        }

        // DELETE: api/Tips/5
        [ResponseType(typeof(Tip))]
        public IHttpActionResult DeleteTip(int id)
        {
            Tip tip = db.Tips.Find(id);
            if (tip == null)
            {
                return NotFound();
            }

            db.Tips.Remove(tip);
            db.SaveChanges();

            return Ok(tip);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipExists(int id)
        {
            return db.Tips.Count(e => e.Id == id) > 0;
        }
    }
}