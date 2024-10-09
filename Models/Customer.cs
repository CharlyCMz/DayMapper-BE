using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayMapper_BE.Models
{
    public class Customer
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(4)]
        [Column("business_name")]
        public string BusinessName { get; set; }

        [Required]
        [MaxLength(20), MinLength(9)]
        [Column("tax_id")]
        public string TaxId { get; set; }

        [Column("status")]
        public CustomerStatus Status { get; set; }

        [ForeignKey("PersonId")]
        [Column("person_id")]
        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; } = null;
    }

    public enum CustomerStatus
    {
        Inactive,
        Active,
    }
}
