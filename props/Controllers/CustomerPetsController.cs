using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using props.Models;

namespace props.Controllers
{
    public class CustomerPetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomerPets
        public ActionResult Index()
        {
            var customerPets = db.CustomerPets.Include(c => c.Customer).Include(c => c.Pet);
            return View(customerPets.ToList());
        }

        // GET: CustomerPets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPets customerPets = db.CustomerPets.Find(id);
            if (customerPets == null)
            {
                return HttpNotFound();
            }
            return View(customerPets);
        }

        // GET: CustomerPets/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.PetId = new SelectList(db.Pets, "Id", "Name");
            return View();
        }

        // POST: CustomerPets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,PetId")] CustomerPets customerPets)
        {
            if (ModelState.IsValid)
            {
                db.CustomerPets.Add(customerPets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", customerPets.CustomerId);
            ViewBag.PetId = new SelectList(db.Pets, "Id", "Name", customerPets.PetId);
            return View(customerPets);
        }

        // GET: CustomerPets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPets customerPets = db.CustomerPets.Find(id);
            if (customerPets == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", customerPets.CustomerId);
            ViewBag.PetId = new SelectList(db.Pets, "Id", "Name", customerPets.PetId);
            return View(customerPets);
        }

        // POST: CustomerPets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,PetId")] CustomerPets customerPets)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerPets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", customerPets.CustomerId);
            ViewBag.PetId = new SelectList(db.Pets, "Id", "Name", customerPets.PetId);
            return View(customerPets);
        }

        // GET: CustomerPets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerPets customerPets = db.CustomerPets.Find(id);
            if (customerPets == null)
            {
                return HttpNotFound();
            }
            return View(customerPets);
        }

        // POST: CustomerPets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerPets customerPets = db.CustomerPets.Find(id);
            db.CustomerPets.Remove(customerPets);
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
