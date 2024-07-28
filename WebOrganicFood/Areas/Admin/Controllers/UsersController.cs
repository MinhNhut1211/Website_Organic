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
    public class UsersController : Controller
    {
        // GET: Admin/Users
        OrganicEntities db = new OrganicEntities();
        public ActionResult Index()
        {
            var nguoidungs = db.NguoiDungs.Include(n => n.PhanQuyen);
            return View(nguoidungs.ToList());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Khai báo một người dùng theo mã
            NguoiDung nguoidung = db.NguoiDungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            // trả về trang chi tiết người dùng
            return View(nguoidung);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen");
            return View();
        }

        // POST: Admin/Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNguoiDung,Hoten,NgaySinh, SoDienThoai, GioiTinh, DiaChi, Email,Matkhau,IDQuyen")] NguoiDung nguoidung)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nguoidung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDQuyen = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", nguoidung.IDQuyen);
            return View(nguoidung);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
           
            var user = db.NguoiDungs.Find(id);
            var quyenselect = new SelectList(db.PhanQuyens, "IDQuyen", "TenQuyen", user.IDQuyen);
            ViewBag.IDLoai = quyenselect;
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(NguoiDung nguoidung)
        {

            if (ModelState.IsValid)
            {
                // Sửa sản phẩm theo mã sản phẩm
                //var oldItem = db.NguoiDungs.Find(nguoidung.MaNguoiDung);
                //oldItem.HoTen = nguoidung.HoTen;
                //oldItem.NgaySinh = nguoidung.NgaySinh;
                //oldItem.SoDienThoai = nguoidung.SoDienThoai;
                //oldItem.GioiTinh = nguoidung.GioiTinh;
                //oldItem.DiaChi = nguoidung.DiaChi;
                //oldItem.Email = nguoidung.Email;
                //oldItem.MatKhau = nguoidung.MatKhau;
                db.NguoiDungs.Attach(nguoidung);
                db.Entry(nguoidung).State = System.Data.Entity.EntityState.Modified;
                //    // lưu lại
                db.SaveChanges();
            }
                // xong chuyển qua index
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            
           
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoidung = db.NguoiDungs.Find(id);
            if (nguoidung == null)
            {
                return HttpNotFound();
            }
            return View(nguoidung);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {   
            NguoiDung nguoidung = db.NguoiDungs.Find(id);
            db.NguoiDungs.Remove(nguoidung);
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
