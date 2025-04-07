public class Order
{
    public int Id { get; set; }
    public int FoodItemId { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}