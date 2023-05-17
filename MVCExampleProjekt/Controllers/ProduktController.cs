using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCExampleProjekt.Models;

namespace MVCExampleProjekt.Controllers
{
    public class ProduktController : Controller
    {
        
        public IActionResult Index()
        {
            // Ett anrop https://localhost/Produkt/Index leda hit
            return View(Produkt.getAllProdukt() );
            // högerklick på getAllProdukt --> Go to Definition
        }

        public IActionResult RedigeraProdukt()
        {
            // kolla behörigheter
            if (HttpContext.Session.GetString("roll") != "admin") {
            return RedirectToAction("Error", "Home");
            }
            return View();
        }

        public IActionResult Redigera(int id)
        {           
            Produkt p = Produkt.getSingleProduktById(id);
            return View("RedigeraProdukt", p);
        }

        public IActionResult SparaProdukt(Produkt p)
        {          

            Produkt.sparaProdukt(p);            
            return View("Index", Produkt.getAllProdukt() );
        }

        public IActionResult SparaNyProdukt(ProduktAndImage pi)
        {
            try
            {

                
                Guid g = Guid.NewGuid();
                string fileName = g.ToString() + ".jpg";
                pi.ProduktImageFileName = fileName;

                

                string uploadpath = Path.Combine(Directory.GetCurrentDirectory(), "/Upload", fileName );

                var stream = new FileStream(uploadpath, FileMode.Create);

                pi.produktImage.CopyToAsync(stream);

                ViewBag.Message = "File uploaded successfully.";

            }

            catch

            {

                ViewBag.Message = "Error while uploading the files.";

            }

            Produkt.SparaNyProdukt(pi);
            ;
            return View("Index", Produkt.getAllProdukt());
        }



        public IActionResult NyProdukt()
        {
            return View();
        }


        public async Task<bool> UploadFile(IFormFile file)
        {
            string path = "";
            bool iscopied = false;
            try
            {
                if (file.Length > 0)
                {
                    string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Upload"));
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                    iscopied = true;
                }
                else
                {
                    iscopied = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return iscopied;
        }
    }
}

