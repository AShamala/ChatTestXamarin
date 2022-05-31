using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatTestXamarin.Activities;
using ChatTestXamarin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatTestXamarin.Presenters
{
    public class AddChatPresenter
    {
        private AddChatDialog _dialog;

        public AddChatPresenter(AddChatDialog dialog)
        {
            _dialog = dialog;
        }

        public void CancelDialog()
        {
            _dialog.Cancel();
        }
    }
}