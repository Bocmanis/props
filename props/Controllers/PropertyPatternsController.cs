using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PropertyBuilder;
using props.Models;
using StorageAccess;

namespace props.Controllers
{
    public class PropertyPatternsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyPatterns
        public ActionResult Index()
        {
            return View(new PropertyManager().GetPropertyPatternKeys().Select(x => new PropertyPattern() { Id = x }));
        }

        // GET: PropertyPatterns/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyPattern propertyPattern = new PropertyPattern()
            {
                Id = id,
                Properties = new PropertyManager().GetPropertyKeys().Where(x=>x.Contains(id)).Select(s => new FullProp() { Id = s, Value = new PropertyManager().GetValue(s) }).ToList()
            };
            if (propertyPattern == null)
            {
                return HttpNotFound();
            }
            return View(propertyPattern);
        }

        // GET: PropertyPatterns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyPatterns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] PropertyPattern propertyPattern)
        {
            if (ModelState.IsValid)
            {
                db.PropertyPatterns.Add(propertyPattern);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyPattern);
        }

        // GET: PropertyPatterns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyPattern propertyPattern = db.PropertyPatterns.Find(id);
            if (propertyPattern == null)
            {
                return HttpNotFound();
            }
            return View(propertyPattern);
        }

        // POST: PropertyPatterns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] PropertyPattern propertyPattern)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyPattern).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyPattern);
        }

        // GET: PropertyPatterns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyPattern propertyPattern = db.PropertyPatterns.Find(id);
            if (propertyPattern == null)
            {
                return HttpNotFound();
            }
            return View(propertyPattern);
        }

        // POST: PropertyPatterns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PropertyPattern propertyPattern = db.PropertyPatterns.Find(id);
            db.PropertyPatterns.Remove(propertyPattern);
            db.SaveChanges();
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
