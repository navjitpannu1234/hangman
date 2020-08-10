using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Hangman_44.Resources;
using SQLite;

namespace Hangman_44
{
    public class ConnectionClass
    {
        private string dbpath { get; set; }

        private SQLiteConnection db { get; set; }





        public ConnectionClass()
        {

            string dbPath =
                Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Hangman_Scores.sqlite");

            db = new SQLiteConnection(dbPath);

            db.CreateTable<Playerscores>();
        }




        public List<Playerscores> ViewAll()
        {
            try
            {
                ;
                return db.Query<Playerscores>("select *  from Playerscores  ORDER BY Score DESC");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }







        public string UpdateScore(int id, string name, int score)
        {


            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Hangman_Scores.sqlite");
                var db = new SQLiteConnection(dbPath);
                var item = new Playerscores();

                item.Id = id;
                item.Name = name;
                item.Score = score;

                db.Update(item);
                return "Record Updated";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

        }



        public string InsertNewPlayer(string name, int score)
        {


            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Hangman_Scores.sqlite");
                var db = new SQLiteConnection(dbPath);
                var item = new Playerscores();
                item.Name = name;
                item.Score = score;

                db.Insert(item);
                return "Record added to the database";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }

        }


        public string DeletePlayer(int id)
        {

            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "Hangman_Scores.sqlite");
                var db = new SQLiteConnection(dbPath);
                var item = new Playerscores();
                item.Id = id;


                db.Delete(item);
                return "Record Delete to the database";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }


        }

    }
}