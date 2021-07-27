using System;
using Cashless.Common;
using Microsoft.AspNetCore.Mvc;

namespace Cashless.WebApi.Extentions
{
    public static class ControllerExtensions
    {
        public static ActionResult GetHttpResponse<T>(this Controller controller, Result<T> response)
        {
            if (response == null)
                return controller.BadRequest(response);

            var reponseValidation = response;
            if (!reponseValidation.Valid())
            {
                reponseValidation.Message = reponseValidation.Detail();

                switch (reponseValidation.ErrorCode)
                {
                    case ErrorCode.CC_005:
                            return controller.StatusCode(409, response);
                        break;
                }

                switch (reponseValidation.ErrorType)
                {
                    case ErrorType.Validation:
                        return controller.BadRequest(response);
                        break;
                    case ErrorType.BusinessRule:
                        return controller.StatusCode(422, response);
                        break;
                    case ErrorType.Application:
                        return controller.StatusCode(500, response);
                        break;
                }
                
                    
            }

            return controller.Ok(response);
        }
    }
}
