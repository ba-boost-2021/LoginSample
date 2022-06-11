namespace LoginSample.Data.Dto
{
    public class RefreshTokenDto
    {
        public Guid RefreshToken { get; set; }
        public Guid UserId { get; set; }
    }
}