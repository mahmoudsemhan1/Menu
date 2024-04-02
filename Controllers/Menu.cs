using Menu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _Context;

        public Menu(MenuContext context)
        {
            _Context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Dishes= await _Context.Dishes.ToListAsync();
            return View(Dishes);
        }
    }
}
