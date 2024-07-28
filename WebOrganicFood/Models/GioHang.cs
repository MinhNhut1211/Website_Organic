using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebOrganicFood.Models
{
    public class GioHang
    {
        OrganicEntities db= new OrganicEntities();
        public List<GioHang> item { get; set; }
        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
      
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        public decimal GetTotal()
        {
            return (decimal)item.Sum(x => x.ThanhTien);
        }

        public GioHang(int msp)
        {
            iMasp = msp;
            SanPham sp= db.SanPhams.Single(n=>n.MaSanPham == iMasp);
            sTensp = sp.TenSanPham;
            sAnhBia = sp.HinhAnh;
            dDonGia = int.Parse(sp.GiaTien.ToString());
            iSoLuong = 1;
        }
    }
}