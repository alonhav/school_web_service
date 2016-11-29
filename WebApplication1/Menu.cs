using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Menu
    {
        public ObjectId _id;
        public ObjectId restaurantId;
        public string name;
    }
}