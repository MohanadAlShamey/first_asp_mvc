using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using first_asp_mvc.Models;
using first_asp_mvc.Repositories;

namespace first_asp_mvc.Controllers
{
    public class CategoryApplicationsController : Controller
    {
        private readonly CategoryRepo _repo;

        public CategoryApplicationsController(CategoryRepo repo)
        {
            _repo = repo;
        }

        // GET: CategoryApplications
        public async Task<IActionResult> Index()
        {
            IEnumerable<CategoryApplication> categories = await _repo.GetAll();
            ViewData["categories"]= categories;
            return View("~/Views/CategoryApplications/Index.cshtml");
                          
        }

        // GET: CategoryApplications/Details/5
        public async Task<IActionResult> Details(Guid id)
        {

            var categoryApplication = await _repo.GetById(id);
            if (categoryApplication == null)
            {
                return NotFound();
            }

            return View(categoryApplication);
        }

        // GET: CategoryApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryApplications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Img")] CategoryApplication categoryApplication)
        {
            if (ModelState.IsValid)
            {
                categoryApplication.Id = Guid.NewGuid();
                await _repo.Add(categoryApplication);
               
                return RedirectToAction(nameof(Index));
            }
            return View(categoryApplication);
        }

        // GET: CategoryApplications/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var categoryApplication = await _repo.GetById(id);
            if (categoryApplication == null)
            {
                return NotFound();
            }
            return View(categoryApplication);
        }

        // POST: CategoryApplications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Img")] CategoryApplication categoryApplication)
        {
            if (id != categoryApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _repo.Edit(categoryApplication);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        throw;
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryApplication);
        }

        // GET: CategoryApplications/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
          

            var categoryApplication = await _repo.GetById(id);
            if (categoryApplication == null)
            {
                return NotFound();
            }

            return View(categoryApplication);
        }

        // POST: CategoryApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            var categoryApplication = await _repo.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }

        
    }
}
