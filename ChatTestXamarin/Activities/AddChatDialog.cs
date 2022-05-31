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
using ChatTestXamarin.Presenters;
using ChatTestXamarin.Models;

namespace ChatTestXamarin.Activities
{
    public class AddChatDialog : Dialog
    {
        private Context _context;
        private AddChatPresenter _presenter;

        public AddChatDialog(Context context) : base(context)
        {
            _context = context;
        }

        public event EventHandler<string> ChatAdd;

        private void OnChatAdd(string title)
        {
            ChatAdd?.Invoke(this, title);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dialog_add_chat);

            var buttonAdd = FindViewById<Button>(Resource.Id.button2);
            var buttoCancel = FindViewById<Button>(Resource.Id.button1);
            var editText = FindViewById<EditText>(Resource.Id.editText1);
            _presenter = new AddChatPresenter(this);
            buttonAdd.Click += (sender, e) =>
            {
                OnChatAdd(editText.Text);
                _presenter.CancelDialog();
            };
            buttoCancel.Click += (sender, e) => _presenter.CancelDialog();
        }
    }
}