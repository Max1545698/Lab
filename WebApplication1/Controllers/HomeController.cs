using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string fileText = null;
            using (var fs = new FileStream("xml.xml", FileMode.OpenOrCreate))
            using (var reader = new StreamReader(fs))
            {
                fileText = reader.ReadToEnd();
            }

            return View("Index",fileText);
        }
        [HttpPost]
        public void Save(string text)
        {
            using (var fs = new FileStream("xml.xml", FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(fs))
            {
                writer.Write(text);
            }
        }
    }
}