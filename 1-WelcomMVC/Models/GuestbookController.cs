using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1_WelcomMVC.Models
{
    public class GuestbookController : Controller
    {
        private GuestbookEntities db = new GuestbookEntities();

        //
        // GET: /Guestbook/

        public ActionResult Index()
        {
            return View(db.GBs.ToList());
        }

        //
        // GET: /Guestbook/Details/5

        public ActionResult Details(Guid id)
        {
            GB gb = db.GBs.Find(id);
            if (gb == null)
            {
                return HttpNotFound();
            }
            return View(gb);
        }

        //
        // GET: /Guestbook/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Guestbook/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GB gb)
        {
            if (ModelState.IsValid)
            {
                gb.Id = Guid.NewGuid();
                db.GBs.Add(gb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gb);
        }

        //
        // GET: /Guestbook/Edit/5

        public ActionResult Edit(Guid id)
        {
            GB gb = db.GBs.Find(id);
            if (gb == null)
            {
                return HttpNotFound();
            }
            return View(gb);
        }

        //
        // POST: /Guestbook/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GB gb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gb);
        }

        //
        // GET: /Guestbook/Delete/5

        public ActionResult Delete(Guid id )
        {
            GB gb = db.GBs.Find(id);
            if (gb == null)
            {
                return HttpNotFound();
            }
            return View(gb);
        }

        //
        // POST: /Guestbook/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GB gb = db.GBs.Find(id);
            db.GBs.Remove(gb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}