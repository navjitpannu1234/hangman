using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hangman_44.Resources;

namespace Hangman_44
{
    [Activity(Label = "PlayerHighScore")]
    public class PlayerHighScore : Activity
    {
        List<Playerscores> myList;
        public ConnectionClass myConnectionClass;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PlayerHighScore );

            myConnectionClass = new ConnectionClass();
            myList = myConnectionClass.ViewAll();

            Button btn_Home = FindViewById<Button>
                (Resource.Id.btn_Home);

            btn_Home.Click += btn_Home_Click;

            // Display the player names and high scores 
            ListView Lv_HighScore = FindViewById<ListView>(Resource.Id.Lv_HighScore);
            Lv_HighScore.Adapter = new Hangman_Adapter(this, myList);
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}