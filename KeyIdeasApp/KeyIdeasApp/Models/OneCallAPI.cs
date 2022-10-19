using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyIdeasApp.Models
{
    public class OneCallAPI
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; } 
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }

}
