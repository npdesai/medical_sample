using Medical.Common;
using Medical.Common.Constants;
using Medical.Common.Helpers;
using Medical.Models.DTOs;
using Medical.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Medical.Services.Services
{
    public class IdentityService : IIdentityService
    {
        public async Task<LoginResponseDto> Login(LoginRequestDto login)
        {
            try
            {
                if (MemCache.LoginCredentials.UserName != login.Username)
                {
                    throw new Exception(Messages.MSG_AUTH_FAILED);
                }

                string hashPassword = Password.PasswordHash(MemCache.LoginCredentials.Password, "SHA512", null);

                bool isVerified = Password.VerifyPasswordHash(login.Password, "SHA512", hashPassword);

                if (isVerified)
                {
                    string token = Token.GenerateToken();

                    return new LoginResponseDto
                    {
                        Token = token
                    };
                }
                else
                {
                    throw new Exception(Messages.MSG_INVALID_CREDENTIAL);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
