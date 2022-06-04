using LoginSample.Common.Extensions;
using LoginSample.Data.Context;
using LoginSample.Data.Dto;
using LoginSample.Entites.Users;
using LoginSample.Service.Abstractions;

namespace LoginSample.Service.Concretes
{
    internal class UserService : IUserService
    {
        private readonly LoginSampleDbContext dbContext;

        public UserService(LoginSampleDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                VerificationCode = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                UserType = Common.Enums.UserType.Admin
            };
            dbContext.Add(@new);
            return dbContext.SaveChanges() > 0;
        }
    }
}