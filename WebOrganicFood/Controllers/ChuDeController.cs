using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebOrganicFood.Models;

namespace WebOrganicFood.Controllers
{
    public class ChuDeController : Controller
    {
        OrganicEntities db = new OrganicEntities();
        // GET: ChuDe
        public ActionResult ChuDePartial()
        {
            List<Loai> listChuDe = db.Loais.ToList();
            return View(listChuDe);
        }

        public ActionResult LoaiChuDe(int? id )
        {
            List <SanPham> lstLoaiSP = db.SanPhams.Where(x=>x.IDLoai == id).OrderBy(x=>x.TenSanPham).ToList() ;
            //var listLoai = db.SanPhams.Where(s => s.IDLoai == id).ToList();
            //if(listLoai.Count == 0)
            //{
            //    ViewBag.Loai = "Không có sản phẩm thuộc loại này!";
            //}
            return View(lstLoaiSP);
        }
    }
}