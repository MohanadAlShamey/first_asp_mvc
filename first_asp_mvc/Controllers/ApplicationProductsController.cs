using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using first_asp_mvc.Models;
using first_asp_mvc.Repositories;

namespace first_asp_mvc.Controllers
{
    public class ApplicationProductsController : Controller
    {
        private readonly IProduct _repo;
        private readonly ICategory _repo_cat;

        public ApplicationProductsController(IProduct repo,ICategory repo_cat)
        {
            _repo = repo;
            _repo_cat = repo_cat;
        }

        // GET: ApplicationProducts
        public async Task<IActionResult> Index()
        {
            ViewData["products"] = await _repo.GetAll();
            return View();
        }

        // GET: ApplicationProducts/Details/5
        public async Task<IActionResult> Details(Guid id)
        {


            var applicationProduct = await _repo.GetById(id);
                
           

            return View(applicationProduct);
        }


        public async Task<IActionResult> Create()
        {

            ViewData["categories"] =await _repo_cat.GetAll();
            return View("~/Views/ApplicationProducts/Create.cshtml");
        }

        [HttpPost]
        
        public async Task<IActionResult> Create( ApplicationProduct product)
        {
            
                product.Id = Guid.NewGuid();
                await _repo.Add(product);

                return RedirectToAction(nameof(Index));
          
           
            
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var categoryApplication = await _repo.GetById(id);
            if (categoryApplication == null)
            {
                return NotFound();
            }
            return View(categoryApplication);
        }

    }
}
