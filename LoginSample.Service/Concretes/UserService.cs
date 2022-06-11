using LoginSample.Common;
using LoginSample.Common.Extensions;
using LoginSample.Data.Context;
using LoginSample.Data.Dto;
using LoginSample.Entites.Users;
using LoginSample.Service.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LoginSample.Service.Concretes
{
    internal class UserService : IUserService
    {
        private readonly LoginSampleDbContext dbContext;
        private readonly IOptions<Settings> option;

        public UserService(LoginSampleDbContext dbContext, IOptions<Settings> option)
        {
            this.dbContext = dbContext;
            this.option = option;
        }

        public bool CreateNewUser(NewUserDto dto)
        {
            var guidString = Guid.NewGuid().ToString();
            var hash = guidString.ComputeHash().Substring(0, 32);
            var password = (hash + dto.Password).ComputeHash();

            var @new = new User
            {
                Mail = dto.Mail,
                Phone = dto.Phone,
                Password = password,
                Hash = hash,
                DisplayName = dto.DisplayName,
                RefreshToken = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                UserType = Common.Enums.UserType.Admin
            };
            dbContext.Add(@new);
            return dbContext.SaveChanges() > 0;
        }

        public List<User> GetAllUsers()
        {
            return dbContext.Users.ToList();
        }

        public AuthenticationResult RefreshToken(RefreshTokenDto dto)
        {
            var entity = dbContext.Users.SingleOrDefault(x => x.Id == dto.UserId && x.IsActive && !x.IsDeleted);
            if (entity == null)
            {
                return null;
            }
            if(entity.RefreshToken != dto.RefreshToken)
            {
                return null;
            }
            var token = GetJwtToken();
            entity.RefreshToken = Guid.NewGuid();
            var result = new AuthenticationResult()
            {
                Token = token,
                ExpireAt = DateTime.Now.AddMinutes(option.Value.Jwt.Expires),
                RefreshToken = entity.RefreshToken.ToString(),
                UserId = entity.Id
            };
            dbContext.Update(entity);
            dbContext.SaveChanges();
            return result;
        }

        public AuthenticationResult SignIn(SignInUserDto dto)
        {
            var entity = dbContext.Users.SingleOrDefault(x => x.Mail == dto.Mail && x.IsActive && !x.IsDeleted);
            if(entity == null)
            {
                return null;
            }
            var password = (entity.Hash + dto.Password).ComputeHash();
            if(entity.Password != password)
            {
                return null;
            }

            var token = GetJwtToken();
            var result = new AuthenticationResult()
            {
                Token = token,
                ExpireAt = DateTime.Now.AddMinutes(option.Value.Jwt.Expires),
                RefreshToken = entity.RefreshToken.ToString(),
                UserId = entity.Id
            };
            return result;

        }

        private string GetJwtToken()
        {
            var claims = new Dictionary<string, object>();
            claims.Add("UserId", 1);
            claims.Add("Culture", "tr-TR");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddMinutes(option.Value.Jwt.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(option.Value.Jwt.Key)),
                                                            SecurityAlgorithms.HmacSha256Signature),
                Claims = claims,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }
    }
}