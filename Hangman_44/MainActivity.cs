using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Hangman_44
{
    [Activity(Label = "Hang Man Game", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Button MyButton_new = FindViewById<Button>(Resource.Id.MyButton_new);
            MyButton_new.Click += MyButton_new_Click;

            Button MyButton_High_Score = FindViewById<Button>(Resource.Id.MyButton_High_Score);
            MyButton_High_Score.Click += MyButton_High_Score_Click;


            Button MyButton_Delete = FindViewById<Button>(Resource.Id.MyButton_Delete);
            MyButton_Delete.Click += MyButton_Delete_Click;

            Button MyButton_Exit = FindViewById<Button>(Resource.Id.MyButton_Exit);
            MyButton_Exit.Click += MyButton_Exit_Click; ;


        }

        private void MyButton_High_Score_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(PlayerHighScore ));
        }

        private void MyButton_Exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void MyButton_Delete_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Delete_Player_Record ));
        }

        private void MyButton_new_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(Activity_New_Palyer));
        }
    }
}
