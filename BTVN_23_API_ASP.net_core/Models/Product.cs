namespace BTVN_23_API_ASP.net_core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set;}

        public bool IsActive { get; set; }
    }
}
