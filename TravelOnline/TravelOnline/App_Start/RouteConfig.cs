using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TravelOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
           
            routes.MapRoute(
            name: "Tour nước ngoài",
            url: "tour-nuoc-ngoai",
            defaults: new { controller = "Tour", action = "TourNuocNgoai", id = UrlParameter.Optional },
            namespaces: new string[] { "TravelOnline.Controllers" }
            );

           routes.MapRoute(
           name: "Cập nhật thông tin khách hàng",
           url: "khach-hang/cap-nhat-thong-tin",
           defaults: new { controller = "KhachHang", action = "UpdateProfile", id = UrlParameter.Optional },
           namespaces: new string[] { "TravelOnline.Controllers" }
           );

           routes.MapRoute(
             name: "Giới thiệu",
             url: "gioi-thieu",
             defaults: new { controller = "Home", action = "GioiThieu", id = UrlParameter.Optional },
             namespaces: new string[] { "TravelOnline.Controllers" }
             );

           routes.MapRoute(
                name: "Tour của tôi",
                url: "khach-hang/tour-cua-toi",
                defaults: new { controller = "KhachHang", action = "TourCuaToi", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
                );

           routes.MapRoute(
            name: "Lấy lại mật khẩu",
            url: "khach-hang/quen-mat-khau",
            defaults: new { controller = "KhachHang", action = "LayLaiMatKhau", id = UrlParameter.Optional },
            namespaces: new string[] { "TravelOnline.Controllers" }
            );

           routes.MapRoute(
            name: "Cập nhật mật khẩu",
            url: "khach-hang/cap-nhat-mat-khau/{id}",
            defaults: new { controller = "KhachHang", action = "CapNhatMatKhau", id = UrlParameter.Optional },
            namespaces: new string[] { "TravelOnline.Controllers" }
            );

           routes.MapRoute(
            name: "Liên hệ",
            url: "lien-he",
            defaults: new { controller = "LienHe", action = "Index", id = UrlParameter.Optional },
            namespaces: new string[] { "TravelOnline.Controllers" }
            );

            routes.MapRoute(
                name: "Tour khuyến mại",
                url: "tour-khuyen-mai",
                defaults: new { controller = "Tour", action = "TourKhuyenMai", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
               );

            routes.MapRoute(
                name: "Lịch khởi hành",
                url: "lich-khoi-hanh",
                defaults: new { controller = "Tour", action = "LichKhoiHanh", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
               );

            routes.MapRoute(
               name: "Đăng nhập",
               url: "khach-hang/dang-nhap",
               defaults: new { controller = "KhachHang", action = "Login", id = UrlParameter.Optional },
               namespaces: new string[] { "TravelOnline.Controllers" }
              );

            routes.MapRoute(
                name: "Tin tức",
                url: "tin-tuc",
                defaults: new { controller = "TinTuc", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
            );

           routes.MapRoute(
           name: "Tour trong nước",
           url: "tour-trong-nuoc",
           defaults: new { controller = "Tour", action = "TourTrongNuoc", id = UrlParameter.Optional },
           namespaces: new string[] { "TravelOnline.Controllers" }
           );

           routes.MapRoute(
           name: "Chi tiết tour",
           url: "chi-tiet-tour/{metatitle}-{id}",
           defaults: new { controller = "Tour", action = "DetailTour", id = UrlParameter.Optional },
           namespaces: new string[] { "TravelOnline.Controllers" }
            );

           routes.MapRoute(
                name: "Sửa tour",
                url: "khach-hang/sua-tour-{id}",
                defaults: new { controller = "DatTour", action = "SuaTour", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
                );

           routes.MapRoute(
    name: "Hủy tour",
    url: "khach-hang/huy-tour-{id}",
    defaults: new { controller = "DatTour", action = "HuyTour", id = UrlParameter.Optional },
    namespaces: new string[] { "TravelOnline.Controllers" }
    );

           routes.MapRoute(
                name: "Search",
                url: "search",
                defaults: new { controller = "Tour", action = "Search", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
                );

           routes.MapRoute(
                name: "Đặt tour thành công",
                url: "dat-tour/thanh-cong",
                defaults: new { controller = "DatTour", action = "DatTourThanhCong", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
                );

           routes.MapRoute(
         name: "Đặt tour",
         url: "dat-tour/{metatitle}-{id}",
         defaults: new { controller = "DatTour", action = "DatTour", id = UrlParameter.Optional },
         namespaces: new string[] { "TravelOnline.Controllers" }
          );

           routes.MapRoute(
                name: "Đăng ký",
                url: "khach-hang/dang-ky",
                defaults: new { controller = "KhachHang", action = "Register", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
            );

           routes.MapRoute(
                name: "Đăng xuất",
                url: "khach-hang/dang-xuat",
                defaults: new { controller = "KhachHang", action = "Logout", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
            );

           routes.MapRoute(
                name: "Chi tiết tin tức",
                url: "chi-tiet-tin-tuc/{metatitle}-{id}",
                defaults: new { controller = "TinTuc", action = "DetailNews", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "TravelOnline.Controllers" }
            );
        }
    }
}