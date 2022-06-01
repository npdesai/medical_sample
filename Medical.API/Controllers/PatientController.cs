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
    [Authorize]
    [Produces("application/json")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Add Patient
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(ApiRoute.Patients.AddPatient)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ResponseDto<bool?>>> AddPatient(AddPatientRequestDto request)
        {
            ResponseDto<bool?> response = new();

            try
            {
                if (ModelState.IsValid)
                {
                    Logger.Info(request);
                    response.Data = await _patientService.AddPatient(request);
                    response.Success = true;
                    response.Message = Messages.MSG_PATIENT_ADDED;

                    return Ok(response);
                }
                else
                {
                    response.Message = Messages.MSG_INVALID_ARGUMENTS;
                    response.Data = null;
                    response.Success = false;

                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                response.Message = ex.Message;
                response.Data = null;
                response.Success = false;

                return BadRequest(response);
            }
        }
    }
}
