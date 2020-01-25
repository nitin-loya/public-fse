namespace Fsd_Mvc_Assign.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Division { get; set; }
        public string Region { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}