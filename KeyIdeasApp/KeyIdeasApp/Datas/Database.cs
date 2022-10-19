using KeyIdeasApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using static Android.Media.Image;

namespace KeyIdeasApp.Datas
{
    public class Database
        {
            static object locker = new object();

            SQLiteConnection _sqlconnection;

            public Database()
            {
                _sqlconnection = DependencyService.Get<IDatabase>().GetConnection();
            
            //`if(_sqlconnection==null)
                _sqlconnection.CreateTable<OneCallSQL>();
            }
            public int Insert(OneCallSQL user)
            {
                lock (locker)
                {
                    return _sqlconnection.Insert(user);
                }
            }
            public int Update(OneCallSQL user)
            {
                lock (locker)
                {
                    return _sqlconnection.Update(user);
                }
            }
            public int Delete(int id)
            {
                lock (locker)
                {
                    return _sqlconnection.Delete<OneCallSQL>(id);
                }
            }
            public IEnumerable<OneCallSQL> GetAll()
            {
                lock (locker)
                {
                    return (from i in _sqlconnection.Table<OneCallSQL>() select i).ToList();
                }
            }
            public int FullDelete()
            {
                lock (locker)
                {
                    return _sqlconnection.DeleteAll<OneCallSQL>();
                }
            }
            public OneCallSQL Get(int id)
            {
                lock (locker)
                {
                    return _sqlconnection.Table<OneCallSQL>().FirstOrDefault(t => t.id == id);
                }
            }
            public void Dispose()
            {
                _sqlconnection.Dispose();
            }
        }
    }
