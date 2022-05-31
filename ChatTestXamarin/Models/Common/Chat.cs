using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatTestXamarin.Models
{
    public class Chat
    {
        public string Title { get; set; }
        public List<ChatMessage> Messages { get; set; }

        public Chat(string title) 
        {
            Title = title;
            Messages = new List<ChatMessage>();
        }

        public ChatMessage GetLastMessage()
        {
            return Messages.OrderBy(x => x.Date).LastOrDefault();
        }
    }
}