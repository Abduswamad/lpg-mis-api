
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Gas.Application.Common.Exceptions
{
    public sealed class ExceptionHandlingMiddleware : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Create a stream wrapper to capture the response body
            var originalBodyStream = context.Response.Body;
            using (var memoryStream = new MemoryStream())
            {
                // Set the response body to the MemoryStream
                
                try
                {
                    // Proceed with the next middleware in the pipeline
                    await next(context);

                    // After the response is generated, rewind the stream to read its content
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Read the response body
                    var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();

                    // Log or process the responseBody as needed
                    Console.WriteLine("Response Body: " + responseBody);
                    //SendEmailService.SendLogs(responseBody);
                }
                catch (Exception e)
                {
                    //  Logger.Error(e);
                    await HandleExceptionAsync(context, e);
                }
                finally
                {
                    // Restore the original response body stream
                    context.Response.Body = memoryStream;
                }
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var solutionName = Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule!.FileName);
            var problemDetails = new ValidationProblemDetails
            {
                Instance = $"urn:"+ solutionName + ":error:"+ Guid.NewGuid()
            };

            if (exception is ValidationException badHttpRequestException)
            {
                var errors = new List<ValidationError>();

                var details = "See ValidationErrors for details";

                foreach (var modelStateError in badHttpRequestException.Errors)
                {
                    var error = new ValidationError
                    {
                        Name = modelStateError.PropertyName,
                        Description = modelStateError.ErrorMessage
                    };

                    errors.Add(error);
                }

                problemDetails.Title = "Invalid Request";
                problemDetails.Type = "ValidationException";
                problemDetails.Status = GetStatusCode(exception);
                problemDetails.Detail = details;
                problemDetails.ValidationErrors = errors;

            }
            else if (exception is ApplicationException btException)
            {
                problemDetails.Title = "Error Encountered!";
                problemDetails.Type = GetTitle(exception);
                problemDetails.Status = GetStatusCode(exception);
                problemDetails.Detail = exception.Message.ToString();
            }
            else
            {
                problemDetails.Title = "An unexpected error occurred!";
                problemDetails.Type = GetTitle(exception);
                problemDetails.Status = GetStatusCode(exception);
                problemDetails.Detail = exception.Message.ToString();
            }

            // log the exception etc..

            httpContext.Response.StatusCode = problemDetails.Status.Value;
            httpContext.Response.ContentType = "application/problem+json";

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
            
        }
            
        private static int GetStatusCode(Exception exception) =>

            exception switch
            {

                NullReferenceException => StatusCodes.Status204NoContent,
                ArithmeticException => StatusCodes.Status406NotAcceptable,
                ArgumentException => StatusCodes.Status403Forbidden,
                InvalidOperationException => StatusCodes.Status417ExpectationFailed,
                AccessViolationException => StatusCodes.Status401Unauthorized,
                OracleException => StatusCodes.Status417ExpectationFailed,
                ValidationException => StatusCodes.Status400BadRequest,
                AggregateException => StatusCodes.Status400BadRequest,
                ApplicationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError,
            };

        private static string GetTitle(Exception exception) =>
            exception switch
            {
                ApplicationException applicationException => applicationException.GetType().Name,
                _ => exception.GetType().Name
            };    

    }
}
