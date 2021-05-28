using LD.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LD.API.Controllers
{
    [Route("api/[controller]")]
    public class LDControllerBase : Controller
    {
        protected readonly ILogger _logger;
        public LDControllerBase(ILogger logger)
        {
            _logger = logger;
        }

        protected IActionResult HandleUserException(Exception ex)
        {
            return BadRequest(ServiceResponse.ErrorResponse(ex));
        }
        protected IActionResult HandleOtherException(Exception ex)
        {
            _logger.Log(LogLevel.Error, _logger?.GetType()?.FullName, ex);
            return StatusCode(StatusCodes.Status500InternalServerError, ServiceResponse.ErrorResponse(ex));
        }
        protected IActionResult HandleUnauthorizedException(Exception ex)
        {
            return StatusCode(StatusCodes.Status401Unauthorized, ServiceResponse.ErrorResponse(ex));
        }
        protected IActionResult HandleForbiddenException(Exception ex)
        {
            return StatusCode(StatusCodes.Status403Forbidden, ServiceResponse.ErrorResponse(ex));
        }

        protected IActionResult DuplicateRecordExistException()
        {
            return StatusCode(StatusCodes.Status406NotAcceptable, ServiceResponse.ErrorResponse("This data already exist."));

        }

        protected IActionResult UserDefinedError()
        {
            return StatusCode(StatusCodes.Status400BadRequest, ServiceResponse.ErrorResponse("Some Error have occured."));

        }

        protected IActionResult UserDefinedErrorWithMessage(string message, int statusCode = StatusCodes.Status400BadRequest)
        {
            return StatusCode(statusCode, ServiceResponse.ErrorResponse(message));

        }
    }
}
