using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR_Chat.Data;
using SignalR_Chat.Models;
using SignalR_Chat.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Chat.Controllers
{
    public class MessengerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public MessengerController(AppDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {

            List<CustomUser> users = _context.CustomUsers.Where(u => u.Id != _userManager.GetUserId(User)).ToList();
            return View(users);
        }

        public IActionResult Chat(string recieverid)
        {
            string senderid = _userManager.GetUserId(User);
            VmChat model = new VmChat();
            model.Reciever = _context.CustomUsers.Find(recieverid);
            model.Messages=_context.Messages.Where(m => (m.SenderId == senderid && m.RecieverId == recieverid) ||
                                                          (m.SenderId == recieverid && m.RecieverId == senderid))
                                              .ToList();


            return View(model);
        }

    }
}
