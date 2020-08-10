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
    [Activity(Label = "Activity_New_Palyer")]
    public class Activity_New_Palyer : Activity
    {
        List<Playerscores > List_Names;

        public TextView txt_Name_;
        private Spinner Name_Score_Spinner;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.New_Player_Layout);

            ConnectionClass myConnectionClass = new ConnectionClass();
            List_Names = myConnectionClass.ViewAll();

            Name_Score_Spinner = FindViewById<Spinner>(Resource.Id.Spinnner_select);
            Hangman_44.Resources.Hangman_Adapter da = new Resources.Hangman_Adapter(this, List_Names);

            Name_Score_Spinner.Adapter = da;

            Name_Score_Spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            txt_Name_ = FindViewById<TextView>(Resource.Id.txt_Name);

            Button btn_Play_Game = FindViewById<Button>(Resource.Id.btn_Play_Game);
            btn_Play_Game.Click += btn_Play_Game_Click;


            Button btn_save = FindViewById<Button>(Resource.Id.btn_save);
            btn_save.Click += btn_save_Click;

            Button btn_Home_Page = FindViewById<Button>(Resource.Id.btn_Home_Page);

            btn_Home_Page.Click += btn_Home_Page_Click;

        }

        private void btn_Home_Page_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }

        private void btn_Play_Game_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Game));
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            // If the length of the text is more then 0.. do this..
            if (txt_Name_.Text.Length > 0)
            {
                // Set the new PlayerName to the text in the textfield
                Game.PlayerName = txt_Name_.Text.ToString();
                // Give them a score of 0 to begin with
               Game.score = 0;
                var cc = new ConnectionClass();
               // Insert the Players name and score into the database
                cc.InsertNewPlayer(Game.PlayerName, Game.score);

                // And update the list
                List_Names = cc.ViewAll();


                var da = new Resources.Hangman_Adapter(this, List_Names);
                // And display the updated list on the spinner
                Name_Score_Spinner.Adapter = da;

            }
            // Display a message if there is an empty textfield
            else
            {


                Toast.MakeText(this, "Please Fill Name", ToastLength.Short).Show();
            }
        }





        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            // The Player Name and  score code
           Game.Id = this.List_Names.ElementAt(e.Position).Id;
           Game.PlayerName = this.List_Names.ElementAt(e.Position).Name;
            Game.score = this.List_Names.ElementAt(e.Position).Score;
        }







    }
}