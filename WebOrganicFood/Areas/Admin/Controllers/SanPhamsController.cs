using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOrganicFood.Models;

namespace WebOrganicFood.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        // GET: Admin/SanPhams
        OrganicEntities db = new OrganicEntities();
        public ActionResult Index()
        {
            var sanphams = db.SanPhams.Include(s => s.Loai);
            return View(sanphams.ToList());
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanpham = db.SanPhams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.Mahang = new SelectList(db.Loais, "IDLoai", "TenLoai");
            return View();
        }

        // POST: Admin/SanPhams/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "MaSanPham, TenSanPham, HinhAnh, GiaTien, MoTa,SoLuong , IDLoai")] SanPham sanpham)
        {

            if (ModelState.IsValid)
            {

                db.SanPhams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDLoai = new SelectList(db.Loais, "IDLoai", "TenLoai", sanpham.IDLoai);
            return View(sanpham);
        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(int id)
        {
            // Hiển thị dropdownlist
            var dt = db.SanPhams.Find(id);
            var hangselected = new SelectList(db.Loais, "IDLoai", "TenLoai", dt.IDLoai);
            ViewBag.IDLoai = hangselected;
            // 
            return View(dt);
        }

        // POST: Admin/Homes/Edit/5
        [HttpPost]
        public ActionResult Edit(SanPham sanpham)
        {
            try
            {
                // Sửa sản phẩm theo mã sản phẩm
                var oldItem = db.SanPhams.Find(sanpham.MaSanPham);
                oldItem.TenSanPham = sanpham.TenSanPham;
                oldItem.HinhAnh = sanpham.HinhAnh;
                oldItem.GiaTien = sanpham.GiaTien;
                oldItem.MoTa = sanpham.MoTa;
                oldItem.SoLuong = sanpham.SoLuong;
                oldItem.IDLoai = sanpham.IDLoai;
                // lưu lại
                db.SaveChanges();
                // xong chuyển qua index
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Homes/Delete/5
        public ActionResult Delete(int id)
        {
            var dt = db.SanPhams.Find(id);
            return View(dt);
        }

        // POST: Admin/Homes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //Lấy được thông tin sản phẩm theo ID(mã sản phẩm)
                var dt = db.SanPhams.Find(id);
                // Xoá
                db.SanPhams.Remove(dt);
                // Lưu lại
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
