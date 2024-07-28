using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOrganicFood.Models;
using PagedList;

namespace WebOrganicFood.Controllers
{
    public class SanPhamController : Controller
    {
        OrganicEntities db = new OrganicEntities();
        // GET: SanPham

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
        public ActionResult SanPhamPartial()
        {
           
            var listSP = db.SanPhams.Take(12).ToList();
            return View(listSP);
        }

        public ActionResult xemChiTiet(int masp = 0)
        {
            var chiTiet = db.SanPhams.SingleOrDefault(n => n.MaSanPham == masp);
            if (chiTiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chiTiet);
        }

        public ActionResult SanPhamTheoLoai(int? MaLoai)
        {
            //List<SanPham> sp= db.SanPhams.Where(n=>n.IDLoai == IDLoai).ToList();
             List < SanPham > sp = db.SanPhams.Where(x => x.IDLoai == MaLoai).OrderBy(x=>x.GiaTien).ToList();
            if(sp.Count==0)
            {
                ViewBag.IDLoai = "Không có sản phẩm thuộc loại này";
            }
            ViewBag.SanPham = sp;
            return View(sp);
        }

        public ActionResult SanPhamPartialFull()
        {
            var listSP = db.SanPhams.ToList();
            return View(listSP);
        }

        public ActionResult TimKiemSP(string searching)
        {
            var lstSP = db.SanPhams.Where(n => n.TenSanPham.Contains(searching));
            return View(lstSP);
        }

        public ActionResult SanPhamNgang ()
        {
            var listSP = db.SanPhams
                .ToList();
            return View(listSP);
        }

    }
}