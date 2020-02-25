using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace LeadNew
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}

