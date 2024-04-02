namespace Menu.Models
{
    public class Ingredient
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<DishIngerdient>? DishIngredients { get; set; }
         

    }
}
