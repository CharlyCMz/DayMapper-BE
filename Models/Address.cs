using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayMapper_BE.Models
{
    [Table("addresses")]
    public class Address
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(9)]
        [Column("street")]
        public string Street { get; set; }

        [Required]
        [MaxLength(20), MinLength(9)]
        [Column("reference")]
        public string Suit { get; set; }

        [Required]
        [MaxLength(20), MinLength(9)]
        [Column("city")]
        public string City { get; set; }

        [Required]
        [MaxLength(20), MinLength(9)]
        [Column("state")]
        public string State { get; set; }

        [Required]
        [MaxLength(20), MinLength(9)]
        [Column("country")]
        public string Country { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; } = null;
    }
}
