using Microsoft.AspNetCore.Mvc;

namespace Gas.Application.Common.Exceptions
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public ICollection<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();
    }

    public class ValidationError
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
