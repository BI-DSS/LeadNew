using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using LeadNew.Models;

namespace LeadNew
{
    public class LoginController : Controller
    {

        private readonly LeadNewDB _context;

        public LoginController(LeadNewDB context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}

