using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KeyIdeasApp.Datas;
using KeyIdeasApp.Droid.Connection;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Environment = Android.OS.Environment;


[assembly: Dependency(typeof(SQLAndroid))]
namespace KeyIdeasApp.Droid.Connection
{
    public class SQLAndroid: IDatabase
    {
        public SQLiteConnection GetConnection(string dbname = "OneCallAPI.db3")
        {
            var sqliteFilename = dbname;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex);
            return conn;
        }

        public SQLiteAsyncConnection GetConnectionAsync(string dbname = "OneCallAPI.db3")
        {
            var sqliteFilename = dbname;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return new SQLiteAsyncConnection(path);
        }
    }
}