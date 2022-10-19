using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KeyIdeasApp.Models
{
    public class OneCallSQL
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string cname { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }
}
