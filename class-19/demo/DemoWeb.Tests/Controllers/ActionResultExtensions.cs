using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Xunit;

namespace DemoWeb.Tests.Controllers
{
    public static class ActionResultExtensions
    {
        public static T ShouldHaveValue<T>(this IActionResult result, int? expectedStatusCode = 200)
        {
            Assert.NotNull(result);

            if (result is ObjectResult objResult)
            {
                Assert.Equal(expectedStatusCode, objResult.StatusCode);

                return Assert.IsAssignableFrom<T>(objResult.Value);
            }

            throw new ArgumentException($"Result does not have Value of type {typeof(T).Name}.");
        }

        public static T ShouldHaveValue<T>(this IActionResult result, T expectedValue, int? expectedStatusCode = 200)
        {
            var value = result.ShouldHaveValue<T>(expectedStatusCode);
            Assert.Equal(expectedValue, value);
            return value;
        }

        public static T ShouldHaveValue<T>(this IConvertToActionResult result, int? expectedStatusCode = 200)
        {
            Assert.NotNull(result);
            return result.Convert().ShouldHaveValue<T>(expectedStatusCode);
        }

        public static T ShouldHaveValue<T>(this IConvertToActionResult result, T expectedValue, int? expectedStatusCode = 200)
        {
            Assert.NotNull(result);
            return result.Convert().ShouldHaveValue<T>(expectedValue, expectedStatusCode);
        }
    }
}
