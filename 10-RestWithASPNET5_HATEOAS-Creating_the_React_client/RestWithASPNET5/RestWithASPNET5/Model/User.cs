using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Model
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("user_name")]
        public string Username { get; set; }

        [Column("full_name")]
        public string Fullname { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("refresh_token")]
        public string RefreshToken { get; set; }

        [Column("refresh_toke_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
