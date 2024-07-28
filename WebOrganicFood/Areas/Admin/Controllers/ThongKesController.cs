using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebOrganicFood.Models;

namespace WebOrganicFood.Areas.Admin.Controllers
{
    public class ThongKesController : Controller
    {
        // GET: Admin/ThongKes
        OrganicEntities db = new OrganicEntities();
        public ActionResult Index()
        {
            var donhangs = db.DonHangs.ToList();
            var dataThongke = (from s in db.DonHangs
                               join x in db.NguoiDungs on s.MaNguoiDung equals x.MaNguoiDung
                               group s by s.MaNguoiDung into g
                               select new ThongKe
                               {
                                   Tennguoidung = g.FirstOrDefault().NguoiDung.HoTen,
                                   Tongtien = g.Sum(x => x.TongTien),
                                   Dienthoai = g.FirstOrDefault().NguoiDung.SoDienThoai,
                                   Soluong = g.Count()
                               });
            var dataFinal = dataThongke.OrderByDescending(s => s.Tongtien).Take(5).ToList();
            return View(dataFinal);
        }
    }
}