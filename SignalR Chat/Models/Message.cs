using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_Chat.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public CustomUser Sender { get; set; }
        [ForeignKey("Reciever")]
        public string RecieverId { get; set; }
        public CustomUser Reciever { get; set; }
    }
}
