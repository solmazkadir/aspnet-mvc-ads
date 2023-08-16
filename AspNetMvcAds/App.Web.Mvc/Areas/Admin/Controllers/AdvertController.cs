using App.Data.Entity;
using AspNetMvcAds.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class AdvertsController : Controller
    {
        private readonly IService<Advert> _service; // readonly nesneler sadece constructor metotta doldurulabilir
        public AdvertsController(IService<Advert> service)
        {
            _service = service;
        }
        // GET: AdvertController
        public ActionResult Index()
        {
            var model = _service.GetAll();
            return View(model);
        }

        // GET: AdvertController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdvertController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdvertController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Advert collection, IFormFile? Logo)
        {
            try
            {
                await _service.AddAsync(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: AdvertController/Edit/5
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

        // POST: AdvertController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(int id, Advert collection)
        {
            try
            {
                _service.Update(collection);
                await _service.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdvertController/Delete/5
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var model = await _service.FindAsync(id);
            return View(model);
        }

        // POST: BrandsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Advert collection)
        {
            try
            {
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


