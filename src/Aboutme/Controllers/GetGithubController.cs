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
        public IActionResult Index()
        {
            var result = Github.GetGithub();
            return View(result);
        }
    }
}
