using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{ 
    public class getCvController : Controller
    {
        public ActionResult index
        {
           
        }

        public void getCVFromServer()
        {
            String rootpath = @"~/Data/";
            string path = Server.MapPath(rootpath);
            String[] FileList = Directory.GetFiles(rootpath);

            FileInfo FI = new FileInfo(rootpath);

            foreach (string file in FileList)
            {

                FI = new FileInfo(file);
                Console.WriteLine(FI.Name);
            }

            if (FI.Exists)
            {       
                    Response.Clear();

                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("Content-Disposition", "filename=" +FI.Name);
                    
                    Response.TransmitFile(Server.MapPath(rootpath)+FI.Name);
                    Response.End();
            }
            else
            {
                Response.Write("this file does not exist");
            }
            
        }
    }
}
