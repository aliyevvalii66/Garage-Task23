using BigonWebApp.Infrastructure.Entities;
using BigonWebApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BigonWebApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorsController : Controller
    {
        private readonly IColorRepository _repository;

        public ColorsController(IColorRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            var datas = _repository.GetWhere(x => !x.IsDeleted);
            return View(datas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Color color)
        {
            var flag = await _repository.AddAsync(color);
            if (!flag)
                return NotFound();

            await _repository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var data = await _repository.GetByIdAsync(id);

            return Ok(data);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data == null)
                return NotFound();

            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Color color)
        {
            var dbData = await _repository.GetSingleAsync(x => x.Id == color.Id);
            if (dbData == null)
                return NotFound();

            dbData.ColorName = color.ColorName;
            dbData.HaxCode = color.HaxCode;


            await _repository.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var data = await _repository.GetByIdAsync(id);
            if (data is null) return BadRequest();

            await _repository.DeleteAsync(data);
            await _repository.SaveAsync();

            var datas = _repository.GetWhere(x => !x.IsDeleted);

            return PartialView("_Grid", datas);
        }
    }
}
