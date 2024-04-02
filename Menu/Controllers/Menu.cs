using Menu.Data;
using Menu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class Menu : Controller
    {

        private readonly MenuContext _context;

        public Menu(MenuContext context)
        {
            _context = context;

        }

        public async Task<IActionResult> Index(string SearchString)
        {
            var Dishes = from d in _context.Dishes
                         select d;
            if (!string.IsNullOrEmpty(SearchString))
            {
                Dishes = Dishes.Where(d => d.Name.Contains(SearchString));
                return View(await Dishes.ToListAsync());
            }
            return View(await Dishes.ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            var Dish = await _context.Dishes
                .Include(di => di.DishIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (Dish == null)
            {
                return NotFound();
            }
            else
                return View(Dish);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Dish dish)
        {
            if (!Uri.TryCreate(dish.ImagUrl, UriKind.Absolute, out Uri validatedUri))
            {
                // The provided URL is not a valid absolute URI
                ModelState.AddModelError("ImageUrl", "The ImageUrl field must be a valid URL.");
                return View(dish); // or handle the error as needed
            }

            var newDish = new Dish()
            {
                Name = dish.Name,
                DishIngredients = dish.DishIngredients,
                ImagUrl = validatedUri.AbsoluteUri, // Store the validated absolute URI
                Price = dish.Price,
            };

            await _context.Dishes.AddAsync(newDish);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Edit(int id)
        {
        
            var dish = await _context.Dishes
                .Include(di => di.DishIngredients)
                 .ThenInclude(i => i.Ingredient)
                 .FirstOrDefaultAsync(x => x.Id == id);
            if (dish == null) return NotFound();

            var response = new Dish()
            {
                 DishIngredients= dish.DishIngredients,
                   Name=dish.Name,
                   Price=dish.Price,
                    ImagUrl=dish.ImagUrl
            };

            return View(response); 
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Dish dish,int id)
        {
            if (id != dish.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(dish);
            }

            var Dbdish= await _context.Dishes.FirstOrDefaultAsync(d=>d.Id== id);

            if (Dbdish != null)
            {
                Dbdish.Name = dish.Name;
                Dbdish.Price = dish.Price;
                Dbdish.DishIngredients = dish.DishIngredients;
                Dbdish.ImagUrl = dish.ImagUrl;
                await _context.SaveChangesAsync();
            }
            else { return View(dish); }
            return RedirectToAction("Index");    
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dish = await _context.Dishes.
                Include(di => di.DishIngredients)
                .ThenInclude(i => i.Ingredient).FirstOrDefaultAsync(d=>d.Id==id);   

            if (dish != null)
            {
                _context.Remove(dish);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }


    }
}
