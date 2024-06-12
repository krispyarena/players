using Crud.Data;
using Crud.Models;
using Crud.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud.Controllers
{
    public class FootballersController : Controller
    {

        private readonly ApplicationDbContext _dbContext;

        public FootballersController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var viewModel = new AddFootballersViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFootballersViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.PlayerId == null)
                {
                    var footballer = new Footballers
                    {
                        PlayerId = Guid.NewGuid(),
                        Name = viewModel.Name,
                        Goals = viewModel.Goals,
                        Country = viewModel.Country,
                        Email = viewModel.Email,
                        IsSubscribed = viewModel.IsSubscribed,
                    };

                    _dbContext.Footballers.Add(footballer);
                }
                else
                {
                    var footballer = await _dbContext.Footballers.FindAsync(viewModel.PlayerId);
                    if(footballer != null)
                    {
                        footballer.Name = viewModel.Name;
                        footballer.Goals = viewModel.Goals;
                        footballer.Country = viewModel.Country;
                        footballer.Email = viewModel.Email;
                        footballer.IsSubscribed = viewModel.IsSubscribed;
                    }
                }
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("List");
            }

            // If the model state is not valid, return the same view with the model to show validation errors
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var footballers = await _dbContext.Footballers.ToListAsync();

            return View(footballers);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var footballer = await _dbContext.Footballers.FindAsync(id);
            if (footballer == null)
            {
                return NotFound();
            }

            var viewModel = new AddFootballersViewModel
            {
                PlayerId = footballer.PlayerId,
                Name = footballer.Name,
                Goals = footballer.Goals,
                Country = footballer.Country,
                Email = footballer.Email,
                IsSubscribed = footballer.IsSubscribed
            };

            return View("Add", viewModel); // Reuse the Add view
        }

        [HttpPost]
        public async Task<IActionResult> Update(AddFootballersViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var footballer = await _dbContext.Footballers.FindAsync(viewModel.PlayerId);
                if (footballer != null)
                {
                    footballer.Name = viewModel.Name;
                    footballer.Goals = viewModel.Goals;
                    footballer.Country = viewModel.Country;
                    footballer.Email = viewModel.Email;
                    footballer.IsSubscribed = viewModel.IsSubscribed;

                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("List");
                }

                return NotFound();
            }

            return View("Add", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Footballers f)
        {
            var footballer = await _dbContext.Footballers.FindAsync(f.PlayerId);

            if(footballer != null)
            {
                _dbContext.Footballers.Remove(footballer);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Footballers");
        }
    }
}
