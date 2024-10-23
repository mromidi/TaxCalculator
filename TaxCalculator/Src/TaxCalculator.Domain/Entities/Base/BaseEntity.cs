using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Domain.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public BaseEntity()
        {
            CreateDate = DateTime.UtcNow;
        }
        
    }
}
