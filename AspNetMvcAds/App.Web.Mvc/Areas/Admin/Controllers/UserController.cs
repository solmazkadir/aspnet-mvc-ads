using App.Data.Entity;
using AspNetMvcAds.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Areas.Admin.Controllers
{
	[Area("Admin")/*, Authorize(Policy = "AdminPolicy")*/]

	public class UserController : Controller
	{
		private readonly IService<User> _service;

		public UserController(IService<User> service)
		{
			_service = service;
		}
		// GET: UserController
		public async Task<ActionResult> Index()
		{
			var model = await _service.GetAllAsync();
			return View(model);
		}

		// GET: UserController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: UserController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UserController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> CreateAsync(User collection)
		{
			try
			{
				collection.UserGuid = Guid.NewGuid();
				await _service.AddAsync(collection);
				await _service.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UserController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			var model = await _service.FindAsync(id);
			return View(model);
		}

		// POST: UserController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> EditAsync(int id, User collection)
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

		// GET: UserController/Delete/5
		public async Task<ActionResult> DeleteAsync(int id)
		{
			var model = await _service.FindAsync(id);
			return View(model);
		}

		// POST: AppUsersController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteAsync(int id, User collection)
		{
			try
			{
				_service.Delete(collection);
				await _service.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
