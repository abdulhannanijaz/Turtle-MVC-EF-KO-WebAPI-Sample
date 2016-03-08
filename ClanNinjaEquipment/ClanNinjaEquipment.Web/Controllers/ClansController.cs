using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ClanNinjaEquipment.DataLayer;

namespace ClanNinjaEquipment.Web.Controllers
{
    public class ClansController : ApiController
    {
        private TurtleEntities db;

        public ClansController()
        {
            db = new TurtleEntities();
        }

        // GET: api/Clans
        public IQueryable<Clan> GetClan()
        {
            return db.Clan;
        }

        // GET: api/Clans/5
        [ResponseType(typeof(Clan))]
        public async Task<IHttpActionResult> GetClan(int id)
        {
            Clan clan = await db.Clan.FindAsync(id);
            if (clan == null)
            {
                return NotFound();
            }

            return Ok(clan);
        }

        // PUT: api/Clans/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutClan(int id, Clan clan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clan.ClanID)
            {
                return BadRequest();
            }

            db.Entry(clan).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClanExists(id))
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

        // POST: api/Clans
        [ResponseType(typeof(Clan))]
        public async Task<IHttpActionResult> PostClan(Clan clan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clan.Add(clan);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clan.ClanID }, clan);
        }

        // DELETE: api/Clans/5
        [ResponseType(typeof(Clan))]
        public async Task<IHttpActionResult> DeleteClan(int id)
        {
            Clan clan = await db.Clan.FindAsync(id);
            if (clan == null)
            {
                return NotFound();
            }

            db.Clan.Remove(clan);
            await db.SaveChangesAsync();

            return Ok(clan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClanExists(int id)
        {
            return db.Clan.Count(e => e.ClanID == id) > 0;
        }
    }
}