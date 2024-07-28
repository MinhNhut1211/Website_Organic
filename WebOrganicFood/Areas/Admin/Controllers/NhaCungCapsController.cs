using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOrganicFood.Models;

namespace WebOrganicFood.Areas.Admin.Controllers
{
    public class NhaCungCapsController : Controller
    {
        OrganicEntities db = new OrganicEntities();
        //
        // GET: /Admin/NhaCungCaps/
        public ActionResult Index()
        {
            return View(db.NhaCungCaps.ToList());
        }

        //
        // GET: /Admin/NhaCungCaps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap ncc = db.NhaCungCaps.Find(id);
            if (ncc == null)
            {
                return HttpNotFound();
            }
            return View(ncc);
        }

        //
        // GET: /Admin/NhaCungCaps/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/NhaCungCaps/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "MaNCC,TenNCC, DiaChi, SDT")] NhaCungCap ncc)
        {
            if (ModelState.IsValid)
            {
                db.NhaCungCaps.Add(ncc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ncc);
        }

        //
        // GET: /Admin/NhaCungCaps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap ncc = db.NhaCungCaps.Find(id);
            if (ncc == null)
            {
                return HttpNotFound();
            }
            return View(ncc);
        }

        // POST: Admin/ChuDes/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "MaNCC,TenNCC, DiaChi, SDT")] NhaCungCap ncc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ncc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ncc);
        }

        // GET: Admin/ChuDes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaCungCap ncc = db.NhaCungCaps.Find(id);
            if (ncc == null)
            {
                return HttpNotFound();
            }
            return View(ncc);
        }

        // POST: Admin/ChuDes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            NhaCungCap ncc = db.NhaCungCaps.Find(id);
            db.NhaCungCaps.Remove(ncc);
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
