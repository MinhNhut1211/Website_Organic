using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebOrganicFood.Models;

namespace WebOrganicFood.Controllers
{
    public class GioHangController : Controller
    {
        OrganicEntities db = new OrganicEntities();
        // GET: GioHang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int iMasp, string strURL)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSanPham == iMasp);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp này đã tồn tại trong session[giohang] chưa
            GioHang sanpham = lstGioHang.Find(n => n.iMasp == iMasp);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMasp);
                //Add sản phẩm mới thêm vào list
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }

            
        }
        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            //Kiểm tra masp
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSanPham == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMasp == iMaSP);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }

            return RedirectToAction("GioHang");
        }
        public ActionResult XoaGioHang(int iMaSP)
        {
            //Kiểm tra masp
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSanPham == iMaSP);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMasp == iMaSP);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMasp == iMaSP);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();

            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);

        }

        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DatHang(FormCollection donhangForm)
        {
            //Kiểm tra đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("GioHang", "GioHang");
            }
            Console.WriteLine(donhangForm);
            string diachinhanhang = donhangForm["Diachinhanhang"].ToString();
            string thanhtoan = donhangForm["MaTT"].ToString();
            int ptthanhtoan = Int32.Parse(thanhtoan);

            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            NguoiDung kh = (NguoiDung)Session["use"];
            List<GioHang> gh = LayGioHang();
            ddh.MaNguoiDung = kh.MaNguoiDung;
            ddh.NgayDat = DateTime.Now;
            ddh.ThanhToan = ptthanhtoan;
            ddh.DiaChiNhanHang = diachinhanhang;
            decimal tongtien = 0;
            foreach (var item in gh)
            {
                decimal thanhtien = item.iSoLuong * (decimal)item.dDonGia;
                tongtien += thanhtien;
            }
            ddh.TongTien = tongtien;
            db.DonHangs.Add(ddh);
            db.SaveChanges();
            //Thêm chi tiết đơn hàng
            foreach (var item in gh)
            {
                ChiTietDonHang ctDH = new ChiTietDonHang();
                decimal thanhtien = item.iSoLuong * (decimal)item.dDonGia;
                ctDH.MaDonHang = ddh.MaDonHang;
                ctDH.MaSanPham = item.iMasp;
                ctDH.SoLuong = item.iSoLuong;
                ctDH.DonGia = (decimal)item.dDonGia;
                ctDH.ThanhTien = (decimal)thanhtien;
                ctDH.PhuongThucThanhToan = 1;
                db.ChiTietDonHangs.Add(ctDH);
            }
            db.SaveChanges();
            return RedirectToAction("Index", "DonHang");
        }
        public ActionResult ThanhToanDonHang()
        {

            ViewBag.MaTT = new SelectList(new[]
                {
                    new { MaTT = 1, TenPT="Thanh toán tiền mặt" },
                    new { MaTT = 2, TenPT="Thanh toán chuyển khoản" },
                }, "MaTT", "TenPT", 1);

            ViewBag.MaTP = Location.layDanhSachTinhThanh();
            ViewBag.QH_HCM = Location.layDanhSachQuanHuyenHCM();
            ViewBag.QH_HN = Location.layDanhSachQuanHuyenHaNoi();

            ViewBag.HCM_Quan1 = Location.layDanhSachPhuongXa_HCM_Quan1();
            ViewBag.HCM_Quan3 = Location.layDanhSachPhuongXa_HCM_Quan3();
            ViewBag.HCM_Quan4 = Location.layDanhSachPhuongXa_HCM_Quan4();
            ViewBag.HCM_Quan5 = Location.layDanhSachPhuongXa_HCM_Quan5();
            ViewBag.HCM_Quan6 = Location.layDanhSachPhuongXa_HCM_Quan6();
            ViewBag.HCM_Quan7 = Location.layDanhSachPhuongXa_HCM_Quan7();
            ViewBag.HCM_Quan8 = Location.layDanhSachPhuongXa_HCM_Quan8();
            ViewBag.HCM_Quan10 = Location.layDanhSachPhuongXa_HCM_Quan10();
            ViewBag.HCM_Quan11 = Location.layDanhSachPhuongXa_HCM_Quan11();
            ViewBag.HCM_Quan12 = Location.layDanhSachPhuongXa_HCM_Quan12();
            ViewBag.HCM_QuanBinhTan = Location.layDanhSachPhuongXa_HCM_QuanBinhTan();
            ViewBag.HCM_QuanBinhThanh = Location.layDanhSachPhuongXa_HCM_QuanBinhThanh();
            ViewBag.HCM_QuanGoVap = Location.layDanhSachPhuongXa_HCM_QuanGoVap();
            ViewBag.HCM_QuanPhuNhuan = Location.layDanhSachPhuongXa_HCM_QuanPhuNhuan();
            ViewBag.HCM_QuanTanBinh = Location.layDanhSachPhuongXa_HCM_QuanTanBinh();
            ViewBag.HCM_QuanTanPhu = Location.layDanhSachPhuongXa_HCM_QuanTanPhu();
            ViewBag.HCM_QuanBinhChanh = Location.layDanhSachPhuongXa_HCM_QuanBinhChanh();
            ViewBag.HCM_QuanCanGio = Location.layDanhSachPhuongXa_HCM_QuanCanGio();
            ViewBag.HCM_QuanCuChi = Location.layDanhSachPhuongXa_HCM_QuanCuChi();
            ViewBag.HCM_QuanHocMon = Location.layDanhSachPhuongXa_HCM_QuanHocMon();
            ViewBag.HCM_QuanNhaBe = Location.layDanhSachPhuongXa_HCM_QuanNhaBe();
            ViewBag.HCM_QuanThuDuc = Location.layDanhSachPhuongXa_HCM_QuanThuDuc();

            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung", "HoTen");

            //Kiểm tra đăng đăng nhập
            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "User");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            DonHang ddh = new DonHang();
            NguoiDung kh = (NguoiDung)Session["use"];
            List<GioHang> gh = LayGioHang();
            decimal tongtien = 0;
            foreach (var item in gh)
            {
                decimal thanhtien = item.iSoLuong * (decimal)item.dDonGia;
                tongtien += thanhtien;
            }

            ddh.NguoiDung = kh;
            ddh.NgayDat = DateTime.Now;
            ChiTietDonHang ctDH = new ChiTietDonHang();
            ViewBag.tongtien = tongtien;
            return View(ddh);

        }



    }
}