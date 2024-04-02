namespace Menu.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagUrl { get; set; }
        public double Price { get; set; }

        public List<DishIngerdient>?  DishIngredients { get; set; }

    }
}
