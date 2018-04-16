using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mrProper.Models;
using props.Models;

namespace props.Controllers
{
    public class BasePropertiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BaseProperties
        public ActionResult Index()
        {
            var baseProperties = db.BaseProperties.Include(b => b.PropertyType);
            return View(baseProperties.ToList());
        }

        // GET: BaseProperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseProperty baseProperty = db.BaseProperties.Find(id);
            if (baseProperty == null)
            {
                return HttpNotFound();
            }
            return View(baseProperty);
        }

        // GET: BaseProperties/Create
        public ActionResult Create()
        {
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "Id", "Label");
            return View();
        }

        // POST: BaseProperties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PropertyTypeId,Select,Label")] BaseProperty baseProperty)
        {
            if (ModelState.IsValid)
            {
                db.BaseProperties.Add(baseProperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "Id", "Label", baseProperty.PropertyTypeId);
            return View(baseProperty);
        }

        // GET: BaseProperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseProperty baseProperty = db.BaseProperties.Find(id);
            if (baseProperty == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "Id", "Label", baseProperty.PropertyTypeId);
            return View(baseProperty);
        }

        // POST: BaseProperties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PropertyTypeId,Select,Label")] BaseProperty baseProperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(baseProperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "Id", "Label", baseProperty.PropertyTypeId);
            return View(baseProperty);
        }

        // GET: BaseProperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaseProperty baseProperty = db.BaseProperties.Find(id);
            if (baseProperty == null)
            {
                return HttpNotFound();
            }
            return View(baseProperty);
        }

        // POST: BaseProperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaseProperty baseProperty = db.BaseProperties.Find(id);
            db.BaseProperties.Remove(baseProperty);
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
