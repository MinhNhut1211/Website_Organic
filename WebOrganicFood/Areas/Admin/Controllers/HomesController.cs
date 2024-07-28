using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList;
using WebOrganicFood.Models;

namespace WebOrganicFood.Areas.Admin.Controllers
{
    public class HomesController : Controller
    {
        // GET: Admin/Homes
        OrganicEntities db = new OrganicEntities();
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int( số nguyên)
            // page có thể có giá trị là null ( rỗng) và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn sql, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo Masp mới có thể phân trang.
            var sp = db.SanPhams.OrderBy(x => x.MaSanPham);

            // 4. Tạo kích thước trang (pageSize) hay là số sản phẩm hiển thị trên 1 trang
            int pageSize = 5;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các sản phẩm được phân trang theo kích thước và số trang.
            return View(sp.ToPagedList(pageNumber, pageSize));

        }

        // GET: Admin/Homes/Details/5
        public ActionResult Details(int id)
        {
            var dt = db.SanPhams.Find(id);
            return View(dt);
        }
        [HttpGet]
        // GET: Admin/Homes/Create
        public ActionResult Create()
        {
            ViewBag.IDLoai = new SelectList(db.Loais, "IDLoai", "TenLoai");
            return View();
        }

        // POST: Admin/Homes/Create


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create( SanPham sanpham, HttpPostedFileBase ImageFile)
        {
            
            if (string.IsNullOrEmpty(sanpham.TenSanPham) == true)
            {
                ModelState.AddModelError("", "Tên Sản Phẩm không Được Để Trống");
                return View();
            }
            if(sanpham.GiaTien < 1000)
            {
                ModelState.AddModelError("", "Giá Phải Lớn Hơn 0");
                return View();
            }
            if(ImageFile == null)
            {
                ModelState.AddModelError("", "Chọn Hình Ảnh");
                return View();
            }
           
            if(ModelState.IsValid)
            {
                var fileName = Path.GetFileName(ImageFile.FileName);
                //luu duong dan cua file
                var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);
                //kiem tra hinh anh da ton tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình Ảnh Đã Tồn Tại";
                }
                else
                {
                    ImageFile.SaveAs(path);
                }
                sanpham.HinhAnh = fileName;
                db.SanPhams.Add(sanpham);
            }
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
            }
            ViewBag.IDLoai = new SelectList(db.Loais, "IDLoai", "TenLoai", sanpham.IDLoai);
            return RedirectToAction("Index");

        }

        // GET: Admin/Homes/Edit/5
        [HttpGet]
        
        public ActionResult Edit(int? id)
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
        [ValidateInput(false)]
        public ActionResult Edit(SanPham sanpham, HttpPostedFileBase ImageFile)
        {

            //try
            //{
                if (ModelState.IsValid)
                {
                    var fileName = Path.GetFileName(ImageFile.FileName);
                    ////luu duong dan cua file
                    var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);
                    ////kiem tra hinh anh da ton tại chưa
                    //if (System.IO.File.Exists(path))
                    //{
                    //    ViewBag.ThongBao = "Hình Ảnh Đã Tồn Tại";
                    //}
                    //else
                    //{
                       ImageFile.SaveAs(path);
                    //}
                    sanpham.HinhAnh = fileName;
                    db.SanPhams.Attach(sanpham);
                    db.Entry(sanpham).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                // Sửa sản phẩm theo mã sản phẩm
                //var oldItem = db.SanPhams.Find(sanpham.MaSanPham);
                //oldItem.TenSanPham = sanpham.TenSanPham;
                //oldItem.HinhAnh = sanpham.HinhAnh;
                //oldItem.GiaTien = sanpham.GiaTien;
                //oldItem.MoTa = sanpham.MoTa;
                //oldItem.SoLuong= sanpham.SoLuong;
                //oldItem.IDLoai = sanpham.IDLoai;

                // lưu lại
                // xong chuyển qua index
                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
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
