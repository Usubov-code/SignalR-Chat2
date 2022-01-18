using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SignalR_Chat.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Chat.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Chat()
        {


            return View();
        }

        
    }
}
