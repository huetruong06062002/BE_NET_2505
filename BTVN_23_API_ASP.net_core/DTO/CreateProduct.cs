namespace BTVN_23_API_ASP.net_core.DTO
{
    public class CreateProduct
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsActive { get; set; }
    }
}
