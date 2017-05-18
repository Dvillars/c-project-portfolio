using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aboutme.Models;

namespace Aboutme.Controllers
{
    public class GetGithubController : Controller
    {
        public IActionResult Index(string returnedGithubs)
        {
            var result = Github.GetGithub(returnedGithubs);
            return View(result);
        }
    }
}
