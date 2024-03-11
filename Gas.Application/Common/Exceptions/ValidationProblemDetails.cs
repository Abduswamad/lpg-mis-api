using Microsoft.AspNetCore.Mvc;

namespace Gas.Application.Common.Exceptions
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public ICollection<ValidationError> ValidationErrors { get; set; }
    }

    public class ValidationError
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
