using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DemoWeb.Tests.Controllers
{
    public static class ActionResultExtensions
    {
        public static T ShouldHaveValue<T>(this ActionResult<T> result, int? expectedStatusCode = 200)
        {
            if (result.Result == null)
            {
#pragma warning disable xUnit2000 // Constants and literals should be the expected argument
                // ActionResult<T> with Value is treated as 200
                Assert.Equal(expectedStatusCode, 200);
#pragma warning restore xUnit2000 // Constants and literals should be the expected argument

                return result.Value;
            }

            if (result.Result is ObjectResult objResult)
            {
                Assert.Equal(expectedStatusCode, objResult.StatusCode);

                return Assert.IsAssignableFrom<T>(objResult.Value);
            }

            throw new ArgumentException($"Result does not have Value of type {typeof(T).Name}.");
        }
    }
}
