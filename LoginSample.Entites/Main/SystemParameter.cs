namespace LoginSample.Entites.Main;

[Table("SystemParameters", Schema = "Main")]
public class SystemParameter : EntityBase
{
    [Required]
    [MaxLength(32)]
    public string Key { get; set; }

    [Required]
    [MaxLength(32)]
    public string Value { get; set; }
}