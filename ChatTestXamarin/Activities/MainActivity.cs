using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using ChatTestXamarin.Activities;
using ChatTestXamarin.Adapters;
using ChatTestXamarin.Models;
using ChatTestXamarin.Presenters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ChatTestXamarin
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private ImageButton addChatButton;
        private RecyclerView recyclerView;
        private MainPresenter _presenter;
        private ChatsAdapter _adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            addChatButton = FindViewById<ImageButton>(Resource.Id.imageButton1);
            addChatButton.Click += (sender, e) => _presenter.OpenAddChatDialog();

            var model = new MainModel();
            setPresenter(new MainPresenter(this, model));
            List<Chat> chats = _presenter.GetChats(); 
            _adapter = new ChatsAdapter(chats);
            _adapter.ChatClick += (sender, chat) => _presenter.ChatClick(chat);
            var layoutManager = new LinearLayoutManager(this);
            layoutManager.StackFromEnd = true;

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView1);
            recyclerView.SetAdapter(_adapter);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.AddItemDecoration(new DividerItemDecoration(this, layoutManager.Orientation));
        }

        private void setPresenter(MainPresenter presenter)
        {
            _presenter = presenter;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}