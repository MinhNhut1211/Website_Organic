using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebOrganicFood.Models
{
    public class Location
    {
        private static string[] lTinhThanh = {
            "Hồ Chí Minh",
            "Hà Nội"
        };

        //HN
        private static string[] lQuanHuyen_HN = {
            "Quận Ba Đình",
            "Quận Hoàn Kiếm",
            "Quận Tây Hồ",
            "Quận Long Biên",
            "Quận Cầu Giấy",
            "Quận Đống Đa",
            "Quận Hai Bà Trưng",
            "Quận Hoàng Mai",
            "Quận Thanh Xuân",
            "Quận Hà Đông",
            "Quận Bắc Từ Liêm",
            "Quận Nam Từ Liêm",
            "Thị xã Sơn Tây",
            "Huyện Ba Vì",
            "Huyện Chương Mỹ",
            "Huyện Đan Phượng",
            "Huyện Đông Anh",
            "Huyện Gia Lâm",
            "Huyện Hoài Đức",
            "Huyện Mê Linh",
            "Huyện Mỹ Đức",
            "Huyện Phú Xuyên",
            "Huyện Phúc Thọ",
            "Huyện Quốc Oai",
            "Huyện Sóc Sơn",
            "Huyện Thạch Thất",
            "Huyện Thanh Oai",
            "Huyện Thanh Trì",
            "Huyện Thường Tín",
            "Huyện Ứng Hòa"
        };

        //HCM
        private static string[] lQuanHuyen_HCM = {
            "Quận 1",
            "Quận 3",
            "Quận 4",
            "Quận 5",
            "Quận 6",
            "Quận 7",
            "Quận 8",
            "Quận 10",
            "Quận 11",
            "Quận 12",
            "Bình Thạnh",
            "Thủ Đức",
            "Gò Vấp",
            "Phú Nhuận",
            "Tân Bình",
            "Tân Phú",
            "Bình Tân",
            "Huyện Nhà Bè",
            "Huyện Hóc Môn",
            "Huyện Củ Chi",
            "Huyện Cần Giờ",
            "Huyện Bình Chánh"
        };

        private static string[] PhuongXa_ThuDuc =
        {
            "Phường An Khánh",
            "Phường An Lợi Đông",
            "Phường An Phú",
            "Phường Bình Chiểu",
            "Phường Bình Thọ",
            "Phường Bình Trưng Đông",
            "Phường Bình Trưng Tây",
            "Phường Cát Lái",
            "Phường Hiệp Bình Chánh",
            "Phường Hiệp Bình Phước",
            "Phường Hiệp Phú",
            "Phường Linh Chiểu",
            "Phường Linh Đông",
            "Phường Linh Tây",
            "Phường Linh Trung",
            "Phường Linh Xuân",
            "Phường Long Bình",
            "Phường Long Phước",
            "Phường Long Thạnh Mỹ",
            "Phường Long Trường",
            "Phường Phú Hữu",
            "Phường Phước Bình",
            "Phường Phước Long A",
            "Phường Phước Long B",
            "Phường Tam Bình",
            "Phường Tam Phú",
            "Phường Tăng Nhơn Phú A",
            "Phường Tăng Nhơn Phú B",
            "Phường Tân Phú",
            "Phường Thảo Điền",
            "Phường Thạnh Mỹ Lợi",
            "Phường Thủ Thiêm",
            "Phường Trường Thạnh",
            "Phường Trường Thọ",
        };
        private static string[] PhuongXa_Quan1 = {"Phường Bến Nghé",
"Phường Bến Thành",
"Phường Cầu Kho",
"Phường Cầu Ông Lãnh",
"Phường Cô Giang",
"Phường Đa Kao",
"Phường Nguyễn Cư Trinh",
"Phường Nguyễn Thái Bình",
"Phường Phạm Ngũ Lão",
"Phường Tân Định",};
        private static string[] PhuongXa_Quan3 =
        {
            "Phường 01",
"Phường 02",
"Phường 03",
"Phường 04",
"Phường 05",
"Phường Võ Thị Sáu",
"Phường 09",
"Phường 10",
"Phường 11",
"Phường 12",
"Phường 13",
"Phường 14",
        };
        private static string[] PhuongXa_Quan4 = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 04",
"Phường 06",
"Phường 08",
"Phường 09",
"Phường 10",
"Phường 13",
"Phường 14",
"Phường 15",
"Phường 16",
"Phường 18",};
        private static string[] PhuongXa_Quan5 = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 04",
"Phường 05",
"Phường 06",
"Phường 07",
"Phường 08",
"Phường 09",
"Phường 10",
"Phường 11",
"Phường 12",
"Phường 13",
"Phường 14", };
        private static string[] PhuongXa_Quan6 = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 04",
"Phường 05",
"Phường 06",
"Phường 07",
"Phường 08",
"Phường 09",
"Phường 10",
"Phường 11",
"Phường 12",
"Phường 13",
"Phường 14", };
        private static string[] PhuongXa_Quan7 = {"Phường Bình Thuận",
"Phường Phú Mỹ",
"Phường Phú Thuận",
"Phường Tân Hưng",
"Phường Tân Kiểng",
"Phường Tân Phong",
"Phường Tân Phú",
"Phường Tân Quy",
"Phường Tân Thuận Đông",
"Phường Tân Thuận Tây", };
        private static string[] PhuongXa_Quan8 = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 04",
"Phường 05",
"Phường 06",
"Phường 07",
"Phường 08",
"Phường 09",
"Phường 10",
"Phường 11",
"Phường 12",
"Phường 13",
"Phường 14",
"Phường 15",
"Phường 16", };
        private static string[] PhuongXa_Quan10 = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 04",
"Phường 05",
"Phường 06",
"Phường 07",
"Phường 08",
"Phường 09",
"Phường 10",
"Phường 11",
"Phường 12",
"Phường 13",
"Phường 14",
"Phường 15",};
        private static string[] PhuongXa_Quan11 = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 04",
"Phường 05",
"Phường 06",
"Phường 07",
"Phường 08",
"Phường 09",
"Phường 10",
"Phường 11",
"Phường 12",
"Phường 13",
"Phường 14",
"Phường 15",
"Phường 16", };
        private static string[] PhuongXa_Quan12 = { "Phường An Phú Đông",
"Phường Đông Hưng Thuận",
"Phường Hiệp Thành",
"Phường Tân Chánh Hiệp",
"Phường Tân Hưng Thuận",
"Phường Tân Thới Hiệp",
"Phường Tân Thới Nhất",
"Phường Thạnh Lộc",
"Phường Thạnh Xuân",
"Phường Thới An",
"Phường Trung Mỹ Tây",};
        private static string[] PhuongXa_BinhTan = {"Phường An Lạc",
"Phường An Lạc A",
"Phường Bình Hưng Hòa",
"Phường Bình Hưng Hoà A",
"Phường Bình Hưng Hoà B",
"Phường Bình Trị Đông",
"Phường Bình Trị Đông A",
"Phường Bình Trị Đông B",
"Phường Tân Tạo",
"Phường Tân Tạo A", };
        private static string[] PhuongXa_BinhThanh = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 05",
"Phường 06",
"Phường 07",
"Phường 11",
"Phường 12",
"Phường 13",
"Phường 14",
"Phường 15",
"Phường 17",
"Phường 19",
"Phường 21",
"Phường 22",
"Phường 24",
"Phường 25",
"Phường 26",
"Phường 27",
"Phường 28", };
        private static string[] PhuongXa_GoVap = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 05",
"Phường 06",
"Phường 07",
"Phường 11",
"Phường 12",
"Phường 13",
"Phường 14",
"Phường 15",
"Phường 17", };
        private static string[] PhuongXa_PhuNhuan = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 04",
"Phường 05",
"Phường 07",
"Phường 08",
"Phường 09",
"Phường 10",
"Phường 11",
"Phường 13",
"Phường 15",
"Phường 17", };
        private static string[] PhuongXa_TanBinh = {"Phường 01",
"Phường 02",
"Phường 03",
"Phường 04",
"Phường 05",
"Phường 06",
"Phường 07",
"Phường 08",
"Phường 09",
"Phường 10",
"Phường 11",
"Phường 12",
"Phường 13",
"Phường 14",
"Phường 15", };
        private static string[] PhuongXa_TanPhu = {"Phường Hiệp Tân",
"Phường Hoà Thạnh",
"Phường Phú Thạnh",
"Phường Phú Thọ Hoà",
"Phường Phú Trung",
"Phường Sơn Kỳ",
"Phường Tân Qúy",
"Phường Tân Sơn Nhì",
"Phường Tân Thành",
"Phường Tân Thới Hoà",
"Phường Tây Thạnh", };
        private static string[] PhuongXa_BinhChanh = {"Thị trấn Tân Túc",
"Xã An Phú Tây",
"Xã Bình Chánh",
"Xã Bình Hưng",
"Xã Bình Lợi",
"Xã Đa Phước",
"Xã Hưng Long",
"Xã Lê Minh Xuân",
"Xã Phạm Văn Hai",
"Xã Phong Phú",
"Xã Quy Đức",
"Xã Tân Kiên",
"Xã Tân Nhựt",
"Xã Tân Quý Tây",
"Xã Vĩnh Lộc A",
"Xã Vĩnh Lộc B", };
        private static string[] PhuongXa_CanGio = {"Thị trấn Cần Thạnh",
"Xã An Thới Đông",
"Xã Bình Khánh",
"Xã Long Hòa",
"Xã Lý Nhơn",
"Xã Tam Thôn Hiệp",
"Xã Thạnh An", };
        private static string[] PhuongXa_CuChi = {"Thị trấn Củ Chi",
"Xã An Nhơn Tây",
"Xã An Phú",
"Xã Bình Mỹ",
"Xã Hòa Phú",
"Xã Nhuận Đức",
"Xã Phạm Văn Cội",
"Xã Phú Hòa Đông",
"Xã Phú Mỹ Hưng",
"Xã Phước Hiệp",
"Xã Phước Thạnh",
"Xã Phước Vĩnh An",
"Xã Tân An Hội",
"Xã Tân Phú Trung",
"Xã Tân Thạnh Đông",
"Xã Tân Thạnh Tây",
"Xã Tân Thông Hội",
"Xã Thái Mỹ",
"Xã Trung An",
"Xã Trung Lập Hạ",
"Xã Trung Lập Thượng", };
        private static string[] PhuongXa_HocMon = {"Thị trấn Hóc Môn",
"Xã Bà Điểm",
"Xã Đông Thạnh",
"Xã Nhị Bình",
"Xã Tân Hiệp",
"Xã Tân Thới Nhì",
"Xã Tân Xuân",
"Xã Thới Tam Thôn",
"Xã Trung Chánh",
"Xã Xuân Thới Đông",
"Xã Xuân Thới Sơn",
"Xã Xuân Thới Thượng", };
        private static string[] PhuongXa_NhaBe = {"Thị trấn Nhà Bè",
"Xã Hiệp Phước",
"Xã Long Thới",
"Xã Nhơn Đức",
"Xã Phú Xuân",
"Xã Phước Kiển",
"Xã Phước Lộc", };


        public static SelectList layDanhSachTinhThanh()
        {
            List<object> t = new List<object>();
            foreach(var e in lTinhThanh)
            {
                t.Add(new { TenTP = e });
            }
            return new SelectList(t, "TenTP", "TenTP", 1);
        }

        public static SelectList layDanhSachQuanHuyenHCM()
        {
            List<object> t = new List<object>();
            foreach (var e in lQuanHuyen_HCM)
            {
                t.Add(new { TenQH = e });
            }
            return new SelectList(t, "TenQH", "TenQH", 1);
        }

        public static SelectList layDanhSachQuanHuyenHaNoi()
        {
            List<object> t = new List<object>();
            foreach (var e in lQuanHuyen_HN)
            {
                t.Add(new { TenQH = e });
            }
            return new SelectList(t, "TenQH", "TenQH", 1);
        }

        public static SelectList layDanhSachPhuongXa_HCM_Quan1()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan1)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_Quan3()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan3)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_Quan4()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan4)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_Quan5()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan5)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_Quan6()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan6)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_Quan7()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan7)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_Quan8()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan8)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_Quan10()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan10)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_Quan11()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan11)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_Quan12()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_Quan12)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanBinhTan()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_BinhTan)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanBinhThanh()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_BinhThanh)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanGoVap()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_GoVap)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanPhuNhuan()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_PhuNhuan)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanTanBinh()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_TanBinh)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanTanPhu()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_TanPhu)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanBinhChanh()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_BinhChanh)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanCanGio()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_CanGio)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanCuChi()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_CuChi)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanHocMon()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_HocMon)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanNhaBe()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_NhaBe)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
        public static SelectList layDanhSachPhuongXa_HCM_QuanThuDuc()
        {
            List<object> t = new List<object>();
            foreach (var e in PhuongXa_ThuDuc)
            {
                t.Add(new { TenPX = e });
            }
            return new SelectList(t, "TenPX", "TenPX", 1);
        }
    }
}