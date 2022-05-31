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
    public class MainModel
    {
        public static User User = new User("Пользователь");
        public static User Robot = new User("Робот");

        public List<Chat> Chats { get; set; }
        public MainModel() 
        {
            Chats = new List<Chat>();
        }

    }
}