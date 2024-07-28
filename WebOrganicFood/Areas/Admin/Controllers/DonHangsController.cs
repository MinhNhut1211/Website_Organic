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
    public class DonHangsController : Controller
    {
        OrganicEntities db = new OrganicEntities();
        // GET: Admin/DonHangs
        public ActionResult Index()
        {
            var donhangs = db.DonHangs.Include(d => d.NguoiDung);
            return View(donhangs.ToList());
        }
        [HttpGet]
        // GET: Admin/DonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            var lstChiTietDH = db.ChiTietDonHangs.Where(n => n.MaDonHang == id);
            ViewBag.ListChiTietDH = lstChiTietDH;
            return View(donhang);
        }

        [HttpPost]
        public ActionResult Details(DonHang dh)
        {
            Xacnhan(dh.MaDonHang);
            var lstChiTietDH = db.ChiTietDonHangs.Where(n => n.MaDonHang == dh.MaDonHang);
            ViewBag.ListChiTietDH = lstChiTietDH;
            return View(dh);
        }


        // GET: Admin/DonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaNguoidung = new SelectList(db.NguoiDungs, "MaNguoiDung");
            return View();
        }

        public ActionResult Xacnhan(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.Find(id);
            donhang.TinhTrangGiaoHang = 1;
            db.SaveChanges();
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/DonHangs/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "MaDonHang,NgayDat,TinhTrangDonHang,ThanhToan,MaNguoiDung,DiaChiNhanHang")] DonHang donhang)
        {
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNguoidung = new SelectList(db.NguoiDungs, "MaNguoiDung");
            return View(donhang);
        }

        // GET: Admin/DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNguoidung = new SelectList(db.NguoiDungs, "MaNguoiDung");
            return View(donhang);
        }

        // POST: Admin/DonHangs/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "MaDonHang,NgayDat,TinhTrangGiaoHang,ThanhToan,MaNguoiDung,DiaChiNhanHang")] DonHang donhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung");
            return View(donhang);
        }

        // GET: Admin/DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donhang = db.DonHangs.Find(id);
            if (donhang == null)
            {
                return HttpNotFound();
            }
            return View(donhang);
        }

        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            DonHang donhang = db.DonHangs.Find(id);
            db.DonHangs.Remove(donhang);
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
