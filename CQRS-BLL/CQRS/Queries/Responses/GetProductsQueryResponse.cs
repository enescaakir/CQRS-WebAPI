namespace CQRS_BLL.CQRS.Queries.Responses
{
    public class GetProductsQueryResponse
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
