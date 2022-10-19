using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace KeyIdeasApp.Datas
{
    public interface IDatabase
    {
        SQLiteConnection GetConnection(string dbname="OneCallAPI.db3");
        SQLiteAsyncConnection GetConnectionAsync(string dbname ="OneCallAPI.db3");
    }
}
