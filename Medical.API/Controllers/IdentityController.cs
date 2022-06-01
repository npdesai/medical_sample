using Medical.Common;
using Medical.Common.Constants;
using Medical.Common.Helpers;
using Medical.Models.DTOs;
using Medical.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Medical.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        /// <summary>
        /// Login to generate token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.Identity.Login)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<LoginResponseDto>>> Login([FromBody] LoginRequestDto request)
        {
            ResponseDto<LoginResponseDto> response = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = Messages.MSG_INVALID_ARGUMENTS;

                    return BadRequest(response);
                }

                response.Data = await _identityService.Login(request);
                response.Success = true;
                return Ok(response);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                response.Data = null;
                response.Success = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }
    }
}
