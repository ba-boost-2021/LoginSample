namespace LoginSample.Data.Dto
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }
        public string RefreshToken { get; set; }
        public Guid UserId { get; set; }
    }
}