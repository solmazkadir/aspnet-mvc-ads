using App.Data.Entity;
using App.Web.Mvc.Utils;
using AspNetMvcAds.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing.Drawing2D;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")/*, Authorize(Policy = "AdminPolicy")*/]

    public class AdvertImageController : Controller
    {
        private readonly IService<AdvertImage>
        _service;

        public AdvertImageController(IService<AdvertImage> service)
        {
            _service = service;
        }
        // GET: AdvertImageController
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllAsync();
            return View(model);
        }

        // GET: AdvertImageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdvertImageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertImageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(AdvertImage collection, IFormFile? Image)
        {
            try
            {
                if (Image is not null)
                {
                    collection.ImagePath = await FileHelper.FileLoaderAsync(Image);
                }
                await _service.AddAsync(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View();
        }

        // GET: AdvertImageController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var model = await _service.FindAsync(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: AdvertImageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, AdvertImage collection, IFormFile? Image, bool? resmiSil)
        {
            try
            {
                if (resmiSil is not null && resmiSil == true)
                {
                    FileHelper.FileRemove(collection.ImagePath);
                    collection.ImagePath = "";
                }
                if (Image is not null)
                {
                    collection.ImagePath = await FileHelper.FileLoaderAsync(Image);
                }
                _service.Update(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View();
        }

        // GET: AdvertImageController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: AdvertImageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AdvertImage collection)
        {
            try
            {
                FileHelper.FileRemove(collection.ImagePath);
                _service.Delete(collection);
                _service.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
