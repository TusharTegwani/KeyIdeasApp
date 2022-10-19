using Foundation;
using KeyIdeasApp.Datas;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

namespace KeyIdeasApp.iOS.Connection
{
    public class SQLiOS : IDatabase
    {
        public SQLiteConnection GetConnection(string dbname = "OneCallAPI.db3")
        {
            var sqliteFilename = dbname;
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder

            var path = Path.Combine(documentsPath, sqliteFilename);
            var conn = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex);
            return conn;
        }

        public SQLiteAsyncConnection GetConnectionAsync(string dbname = "OneCallAPI.db3")
        {
            var sqliteFilename = dbname;
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            return new SQLiteAsyncConnection(path);
        }
    }
}