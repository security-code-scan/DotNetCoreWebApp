using DotNetCoreWebApp.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DotNetCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IValidator<ErrorViewModel> _validator;

        public HomeController(ILogger<HomeController> logger, IValidator<ErrorViewModel> validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public IActionResult Index()
        {
            MD5.Create();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoWork(string input)
        {
            //Do an action in the context of the logged in user
            return new JsonResult(new { result = "Success" });
        }

        [HttpGet]
        public ActionResult LogItem(string input)
        {
            _logger.LogWarning(input + " log in requested.");
            
            //Do an action in the context of the logged in user
            return new JsonResult(new { result = "Success" });
        }

        public IActionResult ProcessRequest(HttpContext ctx)
        {
            string format = ctx.Request.Form["nameformat"];
            string Surname = "test", Forenames="test", FormattedName;
            // BAD: Uncontrolled format string.
            FormattedName = string.Format(format, Surname, Forenames);

            return View(new ErrorViewModel { RequestId = FormattedName });
        }

        [HttpGet]
        public IActionResult GetRequest(string nameformat)
        {
            string format = nameformat;
            string Surname = "test", Forenames="test", FormattedName;
            // BAD: Uncontrolled format string.
            FormattedName = string.Format(format, Surname, Forenames);

            return View(new ErrorViewModel { RequestId = FormattedName });
        }


        [HttpPost]
        public IActionResult ProcessRequest2([FromForm]string nameformatFromForm)
        {
            string format = nameformatFromForm;
            string Surname = "test", Forenames="test", FormattedName;
            // BAD: Uncontrolled format string.
            FormattedName = string.Format(format, Surname, Forenames);

            return View(new ErrorViewModel { RequestId = FormattedName });
        }

        [HttpPost]
        public IActionResult ProcessRequestVM(ErrorViewModel model)
        {
            ValidationResult result = _validator.Validate(model);

            if (!result.IsValid)
            {
                // Copy the validation results into ModelState.
                // ASP.NET uses the ModelState collection to populate 
                // error messages in the View.
                result.AddToModelState(this.ModelState);

                // re-render the view when validation failed.
                return View("Create", model);
            }


            string format = model.RequestId;
            string Surname = "test", Forenames="test", FormattedName;
            // BAD: Uncontrolled format string.
            FormattedName = string.Format(format, Surname, Forenames);

            return View(new ErrorViewModel { RequestId = FormattedName });
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
