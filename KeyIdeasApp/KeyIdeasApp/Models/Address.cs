using System;
using System.Collections.Generic;
using System.Text;
using SQLiteNetExtensions.Attributes;

namespace KeyIdeasApp.Models
{
    public class Geo
    {
        
        public string lat { get; set; }
        public string lng { get; set; }
    }
   
    public class Address
    {
        
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }
    
}
