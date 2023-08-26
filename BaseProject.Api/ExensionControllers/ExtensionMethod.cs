using Microsoft.AspNetCore.Mvc;
using SharedKernal.Operation;

namespace BaseProject.Api.ExtinsionControllers
{
    public static class ExtensionMethod
    {
        public static IActionResult ToActionResultes<T>(this OperartionResult<T> result)
        {

            switch (result.OperationResultType)
            {
                case OperationResultTypes.Exception:
                    return new JsonResult(new { Message = $"Exception  ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status500InternalServerError };
                case OperationResultTypes.Success:
                    return new JsonResult(new { Message = "Success ---", Resultes = result.RangeResult }) { StatusCode = StatusCodes.Status200OK };
                case OperationResultTypes.Failed:
                    return new JsonResult(new { Message = $"Failed ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status412PreconditionFailed };
                case OperationResultTypes.NotFound:
                    return new JsonResult(new { Message = $"Not Found ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status404NotFound };
                case OperationResultTypes.NoElement:
                    return new JsonResult(new { Message = $" No Elements Exist---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status404NotFound };
                case OperationResultTypes.Forbidden:
                    return new JsonResult(new { Message = $"Forbidden ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status403Forbidden };
                case OperationResultTypes.Unauthorized:
                    return new JsonResult(new { Message = $"Unauthorized ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status401Unauthorized };
                default:
                    return new JsonResult(new { Message = $"Unknown ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }
        public static IActionResult ToActionResult<T>(this OperartionResult<T> result)
        {

            switch (result.OperationResultType)
            {
                case OperationResultTypes.Exception:
                    return new JsonResult(new { Message = $"Exception  ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status500InternalServerError };
                case OperationResultTypes.Success:
                    return new JsonResult(new { Message = "Success ---", Resultes = result.Result }) { StatusCode = StatusCodes.Status200OK };
                case OperationResultTypes.Failed:
                    return new JsonResult(new { Message = $"Failed ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status412PreconditionFailed };
                case OperationResultTypes.NotFound:
                    return new JsonResult(new { Message = $"Not Found ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status404NotFound };
                case OperationResultTypes.NoElement:
                    return new JsonResult(new { Message = $" No Elements Exist---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status404NotFound };
                case OperationResultTypes.Forbidden:
                    return new JsonResult(new { Message = $"Forbidden ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status403Forbidden };
                case OperationResultTypes.Unauthorized:
                    return new JsonResult(new { Message = $"Unauthorized ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status401Unauthorized };
                default:
                    return new JsonResult(new { Message = $"Unknown ---- Message: {result.Message}" }) { StatusCode = StatusCodes.Status400BadRequest };
            }
        }


    }
}
