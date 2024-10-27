using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Sofa.CourseManagement.RestApi.Extensions
{
    public enum ErrorCode
    {
        None = 0,
        NotFound = 4040,
        BadRequest = 4001,
        RequestSchemaValidation = 4002,
        BusinessRuleValidation = 4003,
        InternalServerError = 5000
    }
}
