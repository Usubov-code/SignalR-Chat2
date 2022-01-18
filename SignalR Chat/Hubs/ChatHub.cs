using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SignalR_Chat.Data;
using SignalR_Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Chat.Hubs
{
    public class ChatHub:Hub
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public ChatHub(AppDbContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendPrivateMessage(string recieverid,string senderid,string message)
        {
            await Clients.User(recieverid).SendAsync("ReceivePrivateMessage", senderid, message);

            Message newMessage = new Message();

            newMessage.Text = message;
            newMessage.CreatedDate = DateTime.Now;
            newMessage.RecieverId = recieverid;
            newMessage.SenderId = senderid;

            _context.Messages.Add(newMessage);
            _context.SaveChanges();


        }
    }
}
