using DotNetCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ErrorController : ControllerBase
{
    [HttpGet]
    public IActionResult Error([FromQuery]ErrorViewModel model)
    {
        string format = model.RequestId;
        string Surname = "test", Forenames="test", FormattedName;
        // BAD: Uncontrolled format string.
        FormattedName = string.Format(format, Surname, Forenames);

        return new JsonResult(new { result = FormattedName });
    }

    [HttpPost]
    public IActionResult ErrorPost([FromBody]ErrorViewModel model)
    {
        string format = model.RequestId;
        string Surname = "test", Forenames="test", FormattedName;
        // BAD: Uncontrolled format string.
        FormattedName = string.Format(format, Surname, Forenames);

        return new JsonResult(new { result = FormattedName });
    }

    [HttpPost]
    public IActionResult ErrorGeneric(ErrorViewModel model)
    {
        string format = model.RequestId;
        string Surname = "test", Forenames="test", FormattedName;
        // BAD: Uncontrolled format string.
        FormattedName = string.Format(format, Surname, Forenames);

        return new JsonResult(new { result = FormattedName });
    }

    [HttpPost]
    public IActionResult ErrorForm([FromForm]ErrorViewModel model)
    {
        string format = model.RequestId;
        string Surname = "test", Forenames="test", FormattedName;
        // BAD: Uncontrolled format string.
        FormattedName = string.Format(format, Surname, Forenames);

        return new JsonResult(new { result = FormattedName });
    }

    [HttpPost]
    public IActionResult ErrorSimple(string simpleInput)
    {
        string format = simpleInput;
        string Surname = "test", Forenames="test", FormattedName;
        // BAD: Uncontrolled format string.
        FormattedName = string.Format(format, Surname, Forenames);

        return new JsonResult(new { result = FormattedName });
    }


        [HttpGet]
        public IActionResult ErrorName(string nameformat)
        {
            string format = nameformat;
            string Surname = "test", Forenames="test", FormattedName;
            // BAD: Uncontrolled format string.
            FormattedName = string.Format(format, Surname, Forenames);

            return new JsonResult(new { result = FormattedName });
        }

        [HttpPost]
        public IActionResult ErrorNamePost(string nameformat)
        {
            string format = nameformat;
            string Surname = "test", Forenames="test", FormattedName;
            // BAD: Uncontrolled format string.
            FormattedName = string.Format(format, Surname, Forenames);

            return new JsonResult(new { result = FormattedName });
        }

}