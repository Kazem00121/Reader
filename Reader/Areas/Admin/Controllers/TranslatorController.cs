using Reader.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reader.Models.ViewModels;

namespace Reader.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TranslatorController : Controller
	{
		private readonly ReaderContext _context;
		public TranslatorController(ReaderContext context )
		{
			_context = context;
		
		}
		public async Task<IActionResult> Index()
		{
			return View(await _context.Translator.ToListAsync());
		}

		[HttpGet]
		public IActionResult Create()
		{ 
		return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TranslatorsCreateViewModel viewModel)
		{
			if (ModelState.IsValid)
			{ 
				Translator translator = new Translator()
				{
					Name = viewModel.Name,
					Family = viewModel.Family,
					
				};

				_context.Translator.Add(translator);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(viewModel);
		
		}

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            else
            {
                var Translator = await _context.Translator.FirstOrDefaultAsync(m => m.TranslatorID == id);
                if (Translator == null)
                {
                    return NotFound();
                }

                else
                {
                    return View(Translator);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Translator translator)
        {
            if (ModelState.IsValid)
            {
                _context.Update(translator);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(translator);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            else
            {
                var Tranlator = await _context.Translator.FirstOrDefaultAsync(m => m.TranslatorID == id);
                if (Tranlator == null)
                {
                    return NotFound();
                }

                else
                {
                    return View(Tranlator);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleted(int? id)
        {
            var Translator = await _context.Translator.FindAsync(id);
            _context.Translator.Remove(Translator);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }





    }
}
