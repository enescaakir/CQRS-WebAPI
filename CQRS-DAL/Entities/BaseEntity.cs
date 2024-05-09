namespace CQRS_DAL.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
