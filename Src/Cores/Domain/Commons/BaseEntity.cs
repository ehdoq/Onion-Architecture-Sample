using System.ComponentModel.DataAnnotations;

namespace Domain.Commons
{
    public abstract class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; private set; }

        public BaseEntity()
        {
            UpdatedDate = DateTime.Now;
        }
    }
}