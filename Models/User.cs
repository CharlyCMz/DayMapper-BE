using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DayMapper_BE.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(15), MinLength(4)]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        [Column("hash_password")]
        public string HashPassword { get; set; }

        [Column("last_login")]
        public DateTime? LastLogin { get; set; }

        [Column("status")]
        public UserStatus Status { get; set; }

        [ForeignKey("RolId")]
        [Column("rol_id")]
        public int RolId { get; set; }

        public virtual Rol Rol { get; set; }

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

    public enum UserStatus
    {
        Inactive,
        Active,
        Suspended,
    }
}
