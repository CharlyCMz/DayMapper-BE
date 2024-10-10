using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayMapper_BE.Models
{
    [Table("people")]
    public class Person
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20), MinLength(9)]
        [Column("identification")]
        public string Identification { get; set; }

        [Required]
        [MaxLength(20), MinLength(4)]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20), MinLength(4)]
        [Column("lastname_1")]
        public string Lastname1 { get; set; }

        [Required]
        [MaxLength(20), MinLength(4)]
        [Column("lastname_2")]
        public string Lastname2 { get; set; }

        [Required]
        [Column("birthdate")]
        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(20), MinLength(4)]
        [Phone]
        [Column("phone")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(20), MinLength(4)]
        [EmailAddress]
        [Column("mail")]
        public string Mail { get; set; }

        [ForeignKey("AddressId")]
        [Column("address_id")]
        public Guid AddressId { get; set; }

        public virtual Address Address { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; } = null;
    }
}
