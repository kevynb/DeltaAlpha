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
    public class BrotherController : Controller
    {
        private DeltaAlphaDbContext db = new DeltaAlphaDbContext();

        // GET: /Brother/
        public async Task<ActionResult> Index()
        {
            var brothers = db.Brothers.Include(b => b.BigBrother).Include(b => b.Family).Include(b => b.PledgeClass);
            return View(await brothers.ToListAsync());
        }

        // GET: /Brother/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brother brother =
                await
                    db.Brothers.Include(b => b.BigBrother)
                        .Include(b => b.Family)
                        .Include(b => b.PledgeClass)
                        .FirstAsync(b => b.Id == id);
            if (brother == null)
            {
                return HttpNotFound();
            }
            return View(brother);
        }

        // GET: /Brother/Create
        public ActionResult Create()
        {
            ViewBag.BigBrotherId = new SelectList(db.Brothers, "Id", "FirstName");
            ViewBag.FamilyId = new SelectList(db.Families, "Id", "Name");
            ViewBag.PledgeClassId = new SelectList(db.PledgeClasses, "Id", "Name");
            return View();
        }

        // POST: /Brother/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(
                Include =
                    "Id,FirstName,MiddleName,LastName,HomeTown,NickName,Position,PledgeClassId,BigBrotherId,FamilyId")] Brother brother)
        {
            if (ModelState.IsValid)
            {
                db.Brothers.Add(brother);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BigBrotherId = new SelectList(db.Brothers, "Id", "FirstName", brother.BigBrotherId);
            ViewBag.FamilyId = new SelectList(db.Families, "Id", "Name", brother.FamilyId);
            ViewBag.PledgeClassId = new SelectList(db.PledgeClasses, "Id", "Name", brother.PledgeClassId);
            return View(brother);
        }

        // GET: /Brother/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brother brother = await db.Brothers.FindAsync(id);
            if (brother == null)
            {
                return HttpNotFound();
            }
            ViewBag.BigBrotherId = new SelectList(db.Brothers.Where(b => b.Id != id), "Id", "FirstName",
                brother.BigBrotherId);
            ViewBag.FamilyId = new SelectList(db.Families, "Id", "Name", brother.FamilyId);
            ViewBag.PledgeClassId = new SelectList(db.PledgeClasses, "Id", "Name", brother.PledgeClassId);
            return View(brother);
        }

        // POST: /Brother/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(
                Include =
                    "Id,FirstName,MiddleName,LastName,HomeTown,NickName,Position,PledgeClassId,BigBrotherId,FamilyId")] Brother brother)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brother).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BigBrotherId = new SelectList(db.Brothers.Where(b => b.Id != brother.Id), "Id", "FirstName",
                brother.BigBrotherId);
            ViewBag.FamilyId = new SelectList(db.Families, "Id", "Name", brother.FamilyId);
            ViewBag.PledgeClassId = new SelectList(db.PledgeClasses, "Id", "Name", brother.PledgeClassId);
            return View(brother);
        }

        // GET: /Brother/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brother brother = await db.Brothers.FindAsync(id);
            if (brother == null)
            {
                return HttpNotFound();
            }
            return View(brother);
        }

        // POST: /Brother/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Brother brother = await db.Brothers.FindAsync(id);
            db.Brothers.Remove(brother);
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