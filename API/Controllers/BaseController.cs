using API.Responses;
using Common.ApiException;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public abstract class BaseController:ControllerBase
    {
        private const string commonErrorMsg = "An error occured. Please contact system administrator.";

        /// <summary>
        /// Handles API exceptions.
        /// </summary>
        protected IActionResult HandleApiException(ApiException ex)
        {

            ErrorCodeResponse errorModel = new(ex.ErrorCode, ex.Message);

            return ex.ErrorCode switch
            {
                ApiErrorCodes.BadRequest => BadRequest(errorModel),
                ApiErrorCodes.Conflict => Conflict(errorModel),
                ApiErrorCodes.Unauthorized => Unauthorized(),
                ApiErrorCodes.Forbidden => Forbid(),
                ApiErrorCodes.NotFound => NotFound(errorModel),
                _ => StatusCode(ApiErrorCodes.InternalError, errorModel),
            };
        }

        /// <summary>
        /// Handles uncategorized exceptions.
        /// </summary>
        protected IActionResult HandleApiException(Exception ex)
        {
            ErrorCodeResponse errorModel = new(ApiErrorCodes.InternalError, commonErrorMsg);
            return StatusCode(ApiErrorCodes.InternalError, errorModel);
        }
    }
}
