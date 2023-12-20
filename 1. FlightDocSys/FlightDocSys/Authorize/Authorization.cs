using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace FlightDocSys.Authorize
{
    public class Authorization : IAuthorizationMiddlewareResultHandler
    {
        private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();

        public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
        {
            // Nếu ủy quyền bị cấm và tài nguyên có yêu cầu cụ thể,
            // cung cấp một phản hồi 404 tùy chỉnh.
            if (authorizeResult.Forbidden && authorizeResult.AuthorizationFailure!.FailedRequirements.OfType<Show404Requirement>().Any())
            {
                // Trả về 404 để làm cho nó xuất hiện như thể tài nguyên không tồn tại.
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                return;
            }
            // Trở lại triển khai mặc định.
            await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
        }
    }
    public class Show404Requirement : IAuthorizationRequirement
    {
    }
}
