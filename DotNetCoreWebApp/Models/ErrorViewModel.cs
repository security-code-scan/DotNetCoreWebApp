using System;
using FluentValidation;

namespace DotNetCoreWebApp.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class ErrorViewModelValidator : AbstractValidator<ErrorViewModel>
    {
        public ErrorViewModelValidator()
        {            
            RuleFor(x => x.RequestId).Length(0, 10);
            RuleFor(x => x.RequestId).Matches("[A-z0-9]");            
        }
    }
}
