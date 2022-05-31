using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ChatTestXamarin.Adapters;
using ChatTestXamarin.Models;
using ChatTestXamarin.Presenters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatTestXamarin.Activities
{
    [Activity(Label = "")]
    public class ChatActivity : AppCompatActivity
    {
        private MessageAdapter _adapter;
        private RecyclerView _recyclerView;
        private ChatPresenter _presenter;
        private int _itemCount;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_chat);

            var chat = JsonConvert.DeserializeObject<Chat>(Intent.GetStringExtra(nameof(Chat)));
            var buttonSend = FindViewById<ImageButton>(Resource.Id.imageButton2);
            var editText = FindViewById<EditText>(Resource.Id.editText2);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            var model = new ChatModel(chat);
            _presenter = new ChatPresenter(model, this);
            _itemCount = chat.Messages.Count;

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView2);
            _adapter = new MessageAdapter(chat.Messages);
            var layoutManager = new LinearLayoutManager(this);
            layoutManager.StackFromEnd = true;
            _recyclerView.SetAdapter(_adapter);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.AddItemDecoration(new MessagesItemDecoration());
            _recyclerView.ScrollToPosition(_itemCount - 1);

            buttonSend.Click += (sender, e) => 
            { 
                _presenter.SendMessage(editText.Text);
                _itemCount += 1;
                _adapter.NotifyItemInserted(_itemCount - 1);
                _itemCount += 1;
                RobotAnswer();
                editText.Text = string.Empty;
                _recyclerView.SmoothScrollToPosition(_itemCount - 1);
            };
        }

        async private void RobotAnswer()
        {
            await _presenter.RobotAnswer();
            _adapter.NotifyItemInserted(_itemCount - 1);
            _recyclerView.SmoothScrollToPosition(_itemCount - 1);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}
