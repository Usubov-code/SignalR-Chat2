using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Chat.Models
{
    public class CustomUser:IdentityUser
    {


        [MaxLength(30), MinLength(3)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        public byte Age { get; set; }
    }
}
