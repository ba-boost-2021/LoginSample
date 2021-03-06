using LoginSample.Common.Enums;

namespace LoginSample.Entites.Users;

[Table("Users", Schema = "Profile")]
public class User : EntityBase
{
    [Required]
    [MaxLength(30)]
    public string Mail { get; set; }
    [Required]
    [MaxLength(128)]
    public string Password { get; set; }
    [MaxLength(32)]
    public string Hash { get; set; }
    [MaxLength(30)]
    public string DisplayName { get; set; }
    [MaxLength(30)]
    public string Phone { get; set; }
    public Guid RefreshToken { get; set; }
    public UserType UserType { get; set; }

}