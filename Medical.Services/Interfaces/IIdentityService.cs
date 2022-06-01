using Medical.Models.DTOs;
using System.Threading.Tasks;

namespace Medical.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<LoginResponseDto> Login(LoginRequestDto login);
    }
}
