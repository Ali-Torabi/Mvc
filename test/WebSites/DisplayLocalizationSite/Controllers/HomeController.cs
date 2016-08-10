using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DisplayLocalizationSite.Controllers
{
    public class UserName
    {
        [UIHint("FirstName_UIHint")]
        [Display(Name = "FirstName_Name", Description = "FirstName_Description", Prompt = "FirstName_Prompt")]
        public string FirstName { get; set; }

        [UIHint("LastNameMissingUIHint")]
        [Display(Name = "LastNameMissingName", Description = "LastNameMissingDescription", Prompt = "LastNameMissingPrompt")]
        public string LastName { get; set; }
    }

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserName name)
        {
            return Json(name);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
