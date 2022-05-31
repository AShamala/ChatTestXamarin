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
    public class ChatMessage
    {
        public User Sender { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public ChatMessage(User sender, string text)
        {
            Sender = sender;
            Text = text;
            Date = DateTime.Now;
        }
    }
}