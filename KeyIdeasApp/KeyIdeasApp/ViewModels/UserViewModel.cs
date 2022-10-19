using KeyIdeasApp.Datas;
using KeyIdeasApp.Models;
using KeyIdeasApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyIdeasApp.ViewModels
{
    public class UserViewModel
    {
        private IList<OneCallAPI> _userList;
        public IList<OneCallAPI> UserList
        {
            get
            {
                if (_userList == null)
                    _userList = new ObservableCollection<OneCallAPI>();
                return _userList;
            }
            set
            {
                _userList = value;
            }
        }

        private async Task APIAsync()
        {
            
            var user = await UserAPI.GetOneCallAPIAsync();
          
            for (int i = 0; i < user.Count(); i++) { 
                UserList.Add(user[i]);
                
                OneCallSQL oneCallSQL = new OneCallSQL();
                oneCallSQL.id = user[i].id;
                oneCallSQL.name = user[i].name;
                oneCallSQL.username = user[i].username;
                oneCallSQL.email = user[i].email;
                oneCallSQL.street = user[i].address.street;
                oneCallSQL.suite = user[i].address.suite;
                oneCallSQL.city = user[i].address.city;
                oneCallSQL.zipcode = user[i].address.zipcode;
                oneCallSQL.lat = user[i].address.geo.lat;
                oneCallSQL.lng = user[i].address.geo.lng;
                oneCallSQL.phone = user[i].phone;
                oneCallSQL.website = user[i].website;
                oneCallSQL.cname = user[i].company.name;
                oneCallSQL.catchPhrase= user[i].company.catchPhrase;
                oneCallSQL.bs= user[i].company.bs;
                
                App.Database.Insert(oneCallSQL);
            }
            
        }

        public UserViewModel() 
        {
            Task.Run(APIAsync);
           
        }
    }
}
