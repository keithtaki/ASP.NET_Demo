using IOFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOFile.Controllers
{
    public class NhapDiemController : Controller
    {
        // GET: NhapDiem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(SinhVien s)
        {
            if (s.diem < 0)
                return View("loi");
            string path = Server.MapPath("~/sinhVienInfomation.txt");
            var anh = Request.Files["myImage"];
            var pathImage= Server.MapPath("~/Image/"+anh.FileName);
            anh.SaveAs(pathImage);
            string[] dong = { s.id, s.name, s.diem.ToString(), anh.FileName };
            System.IO.File.WriteAllLines(path, dong);
            return View("Index");
        }
        public ActionResult Open()
        {
            SinhVien s = new SinhVien();
            string path = Server.MapPath("~/sinhVienInfomation.txt");
            string[] dong = System.IO.File.ReadAllLines(path);
            s.id = dong[0];
            s.name = dong[1];
            s.diem = Convert.ToDouble(dong[2]);
            s.img = dong[3];
            ViewBag.thongTin = s.id + "_" + s.name + "_" + s.diem;
            ViewBag.ma = s.id;
            ViewBag.ten = s.name;
            ViewBag.d = s.diem;
            ViewBag.image = "../../Image/" + s.img;
            return View("Index");
        }
    }
}