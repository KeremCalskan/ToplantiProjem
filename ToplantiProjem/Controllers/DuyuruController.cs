using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToplantiProjem.Models;
using ToplantiProjem.Utility;

namespace ToplantiProjem.Controllers
{
    //[Authorize(Roles =UserRoles.Role_Admin)]
    public class DuyuruController : Controller
    {
        private readonly IDuyuruRepository _duyuruRepository;
        private readonly IToplantiRepository _toplantiRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;


        public DuyuruController(IDuyuruRepository duyuruRepository, IToplantiRepository toplantiRepository, IWebHostEnvironment webHostEnvironment)
        {
            _duyuruRepository = duyuruRepository;
            _toplantiRepository = toplantiRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Duyuru> objDuyuruList= _duyuruRepository.GetAll(includeProps:"Toplanti").ToList();
           
            return View(objDuyuruList);
        }

        public IActionResult EkleGuncelle(int? id) 
        {
            IEnumerable<SelectListItem> ToplantiList = _toplantiRepository.GetAll().Select(k => new SelectListItem
            {
                Text = k.Ad,
                Value = k.Id.ToString()
            });
            ViewBag.ToplantiList = ToplantiList;
            if(id==null || id == 0)
            {
                //ekle
                return View();
            }
            else
            {
                //guncelle
                Duyuru? duyuruTurVt = _duyuruRepository.Get(u => u.Id == id);
                if (duyuruTurVt == null)
                {
                    return NotFound();
                }

                return View(duyuruTurVt);
            }
        }
        [HttpPost]
        public IActionResult EkleGuncelle(Duyuru duyuruTuru,IFormFile? file )
        {
            //var erros = ModelState.Values.SelectMany(x => x.Errors);
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string toplantiPath = Path.Combine(wwwRootPath, @"img");

                if (file != null)
                {
                    using (var fileStream = new FileStream(Path.Combine(toplantiPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    duyuruTuru.Dokuman = @"\img\" + file.FileName;
                }
                if (duyuruTuru.Id == 0)
                {
                    _duyuruRepository.Ekle(duyuruTuru);
                    TempData["basarili"] = "İşleminiz başarıyla gerçekleşti";
                }
                else
                {
                    _duyuruRepository.Guncelle(duyuruTuru);
                    TempData["basarili"] = "İşleminiz başarıyla gerçekleşti";
                }
               
                _duyuruRepository.Kaydet();
              
                return RedirectToAction("Index", "Duyuru");
            }
            return View();
        }
        /*public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Duyuru? duyuruTurVt = _duyuruRepository.Get(u=>u.Id==id);
            if (duyuruTurVt == null) 
            { 
                return NotFound(); 
            }
            
            return View(duyuruTurVt);
        }*/
        /*[HttpPost]
        public IActionResult Guncelle(Duyuru duyuruTuru)
        {
            if (ModelState.IsValid)
            {
                _duyuruRepository.Guncelle(duyuruTuru);
                _duyuruRepository.Kaydet();
                TempData["basarili"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index", "Duyuru");
            }
            return View();
        }*/
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Duyuru? duyuruTurVt = _duyuruRepository.Get(u => u.Id == id);
            if (duyuruTurVt == null)
            {
                return NotFound();
            }

            return View(duyuruTurVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int id)
        {
            Duyuru? duyuru = _duyuruRepository.Get(u => u.Id == id);
            if (duyuru == null) 
            {
                return NotFound(); 
            }
            _duyuruRepository.Sil(duyuru);
            _duyuruRepository.Kaydet();
            TempData["basarili"] = "İşleminiz başarıyla gerçekleşti";
            return RedirectToAction("Index", "Duyuru");
        }
    }
}
