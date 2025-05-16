using Microsoft.AspNetCore.Mvc;
using RentalAndSales.Application.Common.Models;

namespace RentalAndSales.Application.Common.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return new OkObjectResult(result.Value);

        // Можно расширить: вернуть 404 или 401 по коду ошибки
        var lower = result.Error?.ToLowerInvariant() ?? "";

        return lower switch
        {
            var e when e.Contains("не найден") => new NotFoundObjectResult(new { error = result.Error }),
            var e when e.Contains("доступ запрещен") || e.Contains("unauthorized") => new UnauthorizedResult(),
            _ => new BadRequestObjectResult(new { error = result.Error })
        };
    }
}
