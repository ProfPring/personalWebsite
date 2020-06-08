using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getCVFromServer()
        {
            string rootpath = "~/Data/";
            string path = Server.MapPath(rootpath);

            Response.Clear();

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "filename=" + "CV.doc");

            Response.TransmitFile(Server.MapPath(rootpath) + "CV.doc");
            Response.End();

            return View();
        }

    }

}