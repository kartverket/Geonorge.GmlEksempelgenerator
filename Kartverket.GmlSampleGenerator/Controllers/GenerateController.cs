﻿using System;
using Kartverket.Generators;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Kartverket.GmlSampleGenerator.Controllers
{
    public class GenerateController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public FileContentResult GmlFromXsdUrl(string urlToXsd)
        {
            if (!string.IsNullOrEmpty(urlToXsd)) 
            {
                CheckFileSize(urlToXsd);
                Stream xsdStream = WebRequest.Create(urlToXsd).GetResponse().GetResponseStream();
                string xsdFilename = urlToXsd.Split('/').Last();

                return GmlFileFromXsdStream(xsdStream, xsdFilename);
            }

            return null;
        }

        [HttpPost]
        public FileContentResult GmlFromXsdFile(HttpPostedFileBase xsdfile)
        {
            if (xsdfile != null && xsdfile.ContentLength > 0)
            {
                Stream xsdStream = xsdfile.InputStream;
                string xsdFileName = Path.GetFileName(xsdfile.FileName);

                return GmlFileFromXsdStream(xsdStream, xsdFileName);
            }

            return null;
        }

        private FileContentResult GmlFileFromXsdStream(Stream xsdStream, string xsdFilename)
        {
            MemoryStream gmlStream = new SampleGmlGenerator(xsdStream, xsdFilename).GenerateGml();
            String timestamp = DateTime.Now.ToString("yyyy-MM-ddTHHmmss");
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(xsdFilename);

            string gmlFileName = $"{fileNameWithoutExtension}-Example-GML-{timestamp}.xml";

            return File(gmlStream.ToArray(), "text/xml", gmlFileName);
        }

        private void CheckFileSize(string urlToXsd)
        {
            Stream xsdStream = WebRequest.Create(urlToXsd).GetResponse().GetResponseStream();

            var buffer = new byte[4096];
            long totalBytesRead = 0;
            int bytesRead;

            while ((bytesRead = xsdStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                totalBytesRead += bytesRead;
                if (totalBytesRead > 10485760) // 10 MB
                    throw new Exception("File size too large");
            }
        }
    }
}
