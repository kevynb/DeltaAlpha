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
    public class FamilyController : Controller
    {
        private DeltaAlphaDbContext db = new DeltaAlphaDbContext();

        // GET: /Family/
        public async Task<ActionResult> Index()
        {
            return
                View(
                    await
                        db.Families.Include(m => m.Members)
                            .OrderBy(f => f.Name)
                            .ThenBy(f => f.Members.Count)
                            .ToListAsync());
        }

        // GET: /Family/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family family = await db.Families.Include(f => f.Members).FirstOrDefaultAsync(b => b.Id == id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        // GET: /Family/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Family/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Family family)
        {
            if (ModelState.IsValid)
            {
                db.Families.Add(family);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(family);
        }

        // GET: /Family/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family family = await db.Families.FindAsync(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        // POST: /Family/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Family family)
        {
            if (ModelState.IsValid)
            {
                db.Entry(family).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(family);
        }

        // GET: /Family/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family family = await db.Families.FindAsync(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        // POST: /Family/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Family family = await db.Families.FindAsync(id);
            db.Families.Remove(family);
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