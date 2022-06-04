namespace LoginSample.Entites.Main;

[Table("LookUpTypes", Schema = "Main")]
public class LookUpType : EntityBase
{
    [Required]
    [MaxLength(32)]
    public string Name { get; set; }
}
