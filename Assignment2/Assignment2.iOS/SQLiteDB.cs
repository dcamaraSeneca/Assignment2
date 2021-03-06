using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using System.Runtime.CompilerServices;
using SQLite;
using Assignment2.iOS;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Assignment2.iOS.SQLiteDB))]
namespace Assignment2.iOS
{
    public class SQLiteDB : SQLiteDBInterface
    {
        public SQLiteAsyncConnection createSQLiteDB()
        {
            var doucment_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(doucment_path, "MovieDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}