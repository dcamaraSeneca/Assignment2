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
using SQLite;
using Assignment2.Droid;
using System.IO;
using System.Runtime.CompilerServices;
using Assignment2.Views;

[assembly: Xamarin.Forms.Dependency(typeof(Assignment2.Droid.SQLiteDB))]
namespace Assignment2.Droid
{
    public class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var doucment_path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(doucment_path, "MovieDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
