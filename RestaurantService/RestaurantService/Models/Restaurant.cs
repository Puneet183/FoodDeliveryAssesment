namespace RestaurantService.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuItem> Menu { get; set; }
    }
}
