using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOrganicFood.Models;

namespace WebOrganicFood.Areas.Admin.Controllers
{
    public class ChiTietDonHangsController : Controller
    {
        OrganicEntities db = new OrganicEntities();

        //
        // GET: /Admin/ChiTietDonHangs/
        public ActionResult Index()
        {
            var ctdh = db.ChiTietDonHangs.Include(d => d.DonHang);
            return View();
        }

        //
        // GET: /Admin/ChiTietDonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang ctdh = db.ChiTietDonHangs.Find(id);
            if (ctdh == null)
            {
                return HttpNotFound();
            }
            return View(ctdh);
        }

        //
        // GET: /Admin/ChiTietDonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaDonHang = new SelectList(db.DonHangs, "MaDonHang");
            return View();
        }

        //
        // POST: /Admin/ChiTietDonHangs/Create
        [HttpPost]
        public ActionResult Create(ChiTietDonHang ctdh)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDonHangs.Add(ctdh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDonHang = new SelectList(db.DonHangs, "MaDonHang");
            return View(ctdh);

        }

        //
        // GET: /Admin/ChiTietDonHangs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Admin/ChiTietDonHangs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/ChiTietDonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        //
        // POST: /Admin/ChiTietDonHangs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonHang ctdh = db.ChiTietDonHangs.Find(id);
            if (ctdh == null)
            {
                return HttpNotFound();
            }
            return View(ctdh);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ChiTietDonHang ctdh = db.ChiTietDonHangs.Find(id);
            db.ChiTietDonHangs.Remove(ctdh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
