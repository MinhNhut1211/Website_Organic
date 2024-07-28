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
    public class ChuDesController : Controller
    {
        // GET: Admin/ChuDes
        OrganicEntities db = new OrganicEntities();
        public ActionResult Index()
        {
            return View(db.Loais.ToList());
        }

        // GET: Admin/ChuDes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai hangsanxuat = db.Loais.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        // GET: Admin/ChuDes/Create
        public ActionResult Create()
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC");

            return View();
        }

        // POST: Admin/ChuDes/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IDLoai,TênLoai, MaNCC")] Loai hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                db.Loais.Add(hangsanxuat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", hangsanxuat.MaNCC);

            return View(hangsanxuat);
        }

        // GET: Admin/ChuDes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai hangsanxuat = db.Loais.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", hangsanxuat.MaNCC);
            return View(hangsanxuat);
        }

        // POST: Admin/ChuDes/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "IDLoai,TenLoai, MaNCC")] Loai hangsanxuat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hangsanxuat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNCC = new SelectList(db.NhaCungCaps, "MaNCC", "TenNCC", hangsanxuat.MaNCC);
            return View(hangsanxuat);
        }

        // GET: Admin/ChuDes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai hangsanxuat = db.Loais.Find(id);
            if (hangsanxuat == null)
            {
                return HttpNotFound();
            }
            return View(hangsanxuat);
        }

        // POST: Admin/ChuDes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Loai hangsanxuat = db.Loais.Find(id);
            db.Loais.Remove(hangsanxuat);
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
