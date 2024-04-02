//using Menu.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Menu.Data.Services
//{
//    public class DsihServices 
//    {
//        private readonly MenuContext _context;

//        public DsihServices(MenuContext context)
//        {
//            _context = context;
//        }

//        public async Task AddNewDish(Dish dish)
//        {
//            var NewDsih = new Dish()
//            {
//                Name = dish.Name,
//                DishIngredients = dish.DishIngredients,
//                ImagUrl = dish.ImagUrl,
//                Price=dish.Price,
//            };
//            await _context.Dishes.AddAsync(NewDsih);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateDish(Dish dish)
//        {
//            var dbDish = await _context.Dishes.FirstOrDefaultAsync(d => d.Id == dish.Id);
//            if (dbDish != null) 
//            {
//                dbDish.Name = dish.Name;
//                dbDish.Price = dish.Price;
//                dbDish.DishIngredients= dish.DishIngredients;
//                dbDish.ImagUrl=dish.ImagUrl;
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
