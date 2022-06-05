using LoginSample.Data.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSample.Service.Abstractions
{
    public interface IUserService
    {
        bool CreateNewUser(NewUserDto dto);
        AuthenticationResult SignIn(SignInUserDto dto);
    }
}
