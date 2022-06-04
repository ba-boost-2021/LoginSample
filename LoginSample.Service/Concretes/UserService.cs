using LoginSample.Data.Context;
using LoginSample.Data.Dto;
using LoginSample.Entites.Users;
using LoginSample.Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var @new = new User
            {
             Mail=dto.Mail,
              Phone=dto.Phone,
              Password=dto.Password,
               DisplayName=dto.DisplayName,

            };
            dbContext.Add(@new);
            return dbContext.SaveChanges() > 0;
        }
    }
}
