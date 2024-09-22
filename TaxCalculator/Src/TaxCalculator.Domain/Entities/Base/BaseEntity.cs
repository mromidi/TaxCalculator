namespace TaxCalculator.Domain.Entities.Base
{
    internal class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public BaseEntity()
        {
            CreateDate = DateTime.UtcNow;
        }
        
    }
}
