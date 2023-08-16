using App.Data.Entity;
using App.Web.Mvc.Utils;
using AspNetMvcAds.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]

    public class SettingController : Controller
    {
        private readonly IService<Setting> _service;

        public SettingController(IService<Setting> service)
        {
            _service = service;
        }
        // GET: SettingController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: SettingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Setting collection)
        {
            try
            {
                await _service.AddAsync(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(collection);
        }

        // GET: SettingController/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id is not null)
            {
                return View(await _service.FindAsync(id.Value));
            }
            return View();
        }

        // POST: SettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Setting collection)
        {
            try
            {
                _service.Update(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(collection);
        }

        // GET: SettingController/Delete/5

        public async Task<ActionResult> DeleteAsync(int id)
        {
            return View(await _service.FindAsync(id));
        }

        // POST: SettingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteAsync(int id, Setting collection)
        {
            try
            {
                var ayarlar = await _service.GetAllAsync();
                if (ayarlar.Count > 1)
                {
                    _service.Delete(collection);
                    await _service.SaveAsync();
                }
                else
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Kayıt Silinemedi! Sistemde en azından 1 tane ayar bulunmalıdır!!</div>";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(collection);
        }
    }
}
