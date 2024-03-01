using Microsoft.AspNetCore.Mvc;

namespace HumanCapitalManagement.Web.Infrastructure;

public static class TasksExtensions
{
    public static async Task<OkObjectResult> ToOkResult<T>(this Task<T> task)
        => new(await task);

    public static async Task<OkResult> ToOkResult(this Task task)
    {
        await task;
        return new OkResult();
    }
}