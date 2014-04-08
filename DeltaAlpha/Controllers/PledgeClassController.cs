using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DeltaAlpha.Models;

namespace DeltaAlpha.Controllers
{
    public class PledgeClassController : Controller
    {
        private DeltaAlphaDbContext db = new DeltaAlphaDbContext();

        // GET: /PledgeClass/
        public async Task<ActionResult> Index()
        {
            return
                View(
                    await
                        db.PledgeClasses.OrderByDescending(m => m.Year).ThenByDescending(m => m.Semester).ToListAsync());
        }

        // GET: /PledgeClass/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PledgeClass pledgeclass =
                await db.PledgeClasses.Include(p => p.Members).FirstOrDefaultAsync(b => b.Id == id);
            if (pledgeclass == null)
            {
                return HttpNotFound();
            }
            return View(pledgeclass);
        }

        // GET: /PledgeClass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PledgeClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Year,Semester")] PledgeClass pledgeclass)
        {
            if (ModelState.IsValid)
            {
                db.PledgeClasses.Add(pledgeclass);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pledgeclass);
        }

        // GET: /PledgeClass/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PledgeClass pledgeclass = await db.PledgeClasses.FindAsync(id);
            if (pledgeclass == null)
            {
                return HttpNotFound();
            }
            return View(pledgeclass);
        }

        // POST: /PledgeClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Year,Semester")] PledgeClass pledgeclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pledgeclass).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pledgeclass);
        }

        // GET: /PledgeClass/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PledgeClass pledgeclass = await db.PledgeClasses.FindAsync(id);
            if (pledgeclass == null)
            {
                return HttpNotFound();
            }
            return View(pledgeclass);
        }

        // POST: /PledgeClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PledgeClass pledgeclass = await db.PledgeClasses.FindAsync(id);
            db.PledgeClasses.Remove(pledgeclass);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}