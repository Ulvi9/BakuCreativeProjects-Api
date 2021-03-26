namespace BakuCreativeProjects.DTO.Product
{
    public class ProductReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ChildCategoryId { get; set; }
        public string ChildCategory { get; set; }
        public string PhotoUrl { get; set; }
    }
}