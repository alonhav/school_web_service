using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Dish
    {
        public ObjectId _id;
        public ObjectId userId;
        public string name;
        public string description;
        public float defaultPrice; 
    }
}