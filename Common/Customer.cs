namespace Common
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Зв'язок \"один до багатьох\" з замовленнями
        public ICollection<Order> Orders { get; set; }
    }
}