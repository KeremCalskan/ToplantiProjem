using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using ToplantiProjem.Models;
using ToplantiProjem.Utility;

namespace ToplantiProjem.Controllers
{
//[Authorize(Roles = UserRoles.Role_Admin)]
    public class ToplantiController : Controller
    {
        private readonly IToplantiRepository _toplantiRepository;
        
        public ToplantiController(IToplantiRepository context)
        {
            _toplantiRepository = context;
        }
        public IActionResult Index()
        {
            List<Toplanti> objToplantiList= _toplantiRepository.GetAll().ToList();
            return View(objToplantiList);
        }

        public IActionResult Ekle() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Toplanti toplantiTuru )
        {
            if (ModelState.IsValid)
            {
                _toplantiRepository.Ekle(toplantiTuru);
                _toplantiRepository.Kaydet();
                TempData["basarili"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index", "Toplanti");
            }
            return View();
        }
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Toplanti? toplantiTurVt = _toplantiRepository.Get(u=>u.Id==id);
            if (toplantiTurVt == null) 
            { 
                return NotFound(); 
            }
            
            return View(toplantiTurVt);
        }
        [HttpPost]
        public IActionResult Guncelle(Toplanti toplantiTuru)
        {
            if (ModelState.IsValid)
            {
                _toplantiRepository.Guncelle(toplantiTuru);
                _toplantiRepository.Kaydet();
                TempData["basarili"] = "İşleminiz başarıyla gerçekleşti";
                return RedirectToAction("Index", "Toplanti");
            }
            return View();
        }
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Toplanti? toplantiTurVt = _toplantiRepository.Get(u => u.Id == id);
            if (toplantiTurVt == null)
            {
                return NotFound();
            }

            return View(toplantiTurVt);
        }
        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int id)
        {
            Toplanti? toplanti = _toplantiRepository.Get(u => u.Id == id);
            if (toplanti == null) 
            {
                return NotFound(); 
            }
            _toplantiRepository.Sil(toplanti);
            _toplantiRepository.Kaydet();
            TempData["basarili"] = "İşleminiz başarıyla gerçekleşti";
            return RedirectToAction("Index", "Toplanti");
        }
    }
}
