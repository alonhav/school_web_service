using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MongoDB.Driver;
using System.Web.Services.Description;
using System.Web.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using static WebApplication1.DbConnector;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    //[System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        DbConnector dbConnector = new DbConnector("haifa_db");


        // Restaurant // Restaurant // Restaurant // Restaurant // Restaurant // Restaurant // Restaurant // Restaurant // Restaurant // Restaurant // 
        [WebMethod]

        public void getRestaurants(string user_Id)
        {
            string restaurantListToReturn = dbConnector.getRestaurantByUserId(user_Id);
            Context.Response.Write(restaurantListToReturn); // print the json list
        }

        // this Method get a name and address and a new restaurant. 
        // ?????????? I still need to bring a userId too somehow ???????? now it uses some userID of Giraffe restaurant.
        [WebMethod]
        public void addRestaurant(string user_Id, string name, string address)
        {
            dbConnector.addRestaurantToDb(user_Id, name, address);
        }

        // This Method remove a Restaurant by it's _id
        [WebMethod]
        public void removeRestaurant(string restaurant_Id, string user_Id)
        {
            dbConnector.removeRestaurantByRestaurantId(restaurant_Id, user_Id);
            dbConnector.removeMenuByRestaurantId(restaurant_Id);
        }

        [WebMethod]
        public void editRestaurant(string restaurant_Id, string name, string address)
        {
            dbConnector.editRestaurantByRestaurantId(restaurant_Id, name, address);
        }

        // Users // Users // Users // Users // Users // Users // Users // Users // Users // Users // Users // Users // Users // Users // Users // Users // Users // 


        // this Method get a name and password and add a new user. 
        [WebMethod]
        public void addUser(string name, string password)
        {
            dbConnector.addUserToDb(name, password);
        }

        // This Method remove a User by it's _id and remove all Restaurant belongs to that User.
        [WebMethod]
        public void removeUser(string user_Id)
        {
            dbConnector.removeDishByUserId(user_Id);
            dbConnector.removeRestaurantByUserId(user_Id);
            dbConnector.removeUserByUserId(user_Id);
        }

        [WebMethod]
        public void editUser(string user_Id, string name, string password)
        {
            dbConnector.editUserByUserId(user_Id, name, password);
        }


        // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish // Dish //

        [WebMethod]
        public void addDish(string user_Id, string name, string description, float default_Price)
        {
            string dishAddToReturn = dbConnector.addDishToDb(user_Id, name, description, default_Price);
            Context.Response.Write(dishAddToReturn); // print the json list
        }

        [WebMethod]
        public void getDishes(string user_Id)
        {
            string dishesListToReturn = dbConnector.getDishesByUserId(user_Id);
            Context.Response.Write(dishesListToReturn); // print the json list
        }

        [WebMethod]
        public void removeDish(string dish_Id, string user_Id)
        {
            string dishRemovedToReturn = dbConnector.removeDishByDishId(dish_Id, user_Id);
            Context.Response.Write(dishRemovedToReturn); // print the json list
        }

        [WebMethod]
        public void editDish(string dish_Id, string name, string description, float default_Price)
        {
            string editDishToReturn = dbConnector.editDishByDishId(dish_Id, name, description, default_Price);
            Context.Response.Write(editDishToReturn); // print the json list
        }

        // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu // Menu 

        [WebMethod]
        public void addMenu(string restaurant_Id, string name)
        {
            string menuAddToReturn = dbConnector.addMenuToDb(restaurant_Id, name);
            Context.Response.Write(menuAddToReturn); // print the json list
        }

        [WebMethod]
        public void getMenus(string restaurant_Id)
        {
            string menusListToReturn = dbConnector.getMenusByRestaurantId(restaurant_Id);
            Context.Response.Write(menusListToReturn); // print the json list
        }

        [WebMethod]
        public void removeMenu(string menu_Id, string restaurant_Id)
        {
            string menuRemovedToReturn = dbConnector.removeMenuByMenuId(menu_Id, restaurant_Id);
            Context.Response.Write(menuRemovedToReturn); // print the json list
        }

        [WebMethod]
        public void editMenu(string menu_Id, string name)
        {
            string editMenuToReturn = dbConnector.editMenuByMenuId(menu_Id, name);
            Context.Response.Write(editMenuToReturn); // print the json list
        }

        // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu // SubMenu 

        [WebMethod]
        public void addSubMenu(string menu_Id, string name)
        {
            string subMenuAddToReturn = dbConnector.addSubMenuToDb(menu_Id, name);
            Context.Response.Write(subMenuAddToReturn); // print the json list
        }

        [WebMethod]
        public void getSubMenus(string menu_Id)
        {
            string subMenusListToReturn = dbConnector.getSubMenusByMenuId(menu_Id);
            Context.Response.Write(subMenusListToReturn); // print the json list
        }

        [WebMethod]
        public void removeSubMenu(string subMenu_Id, string menu_Id)
        {
            string subMenuRemovedToReturn = dbConnector.removeSubMenuBySubMenuId(subMenu_Id, menu_Id);
            Context.Response.Write(subMenuRemovedToReturn); // print the json list
        }

        [WebMethod]
        public void editSubMenu(string subMenu_Id, string name)
        {
            string editSubMenuToReturn = dbConnector.editSubMenuBySubMenuId(subMenu_Id, name);
            Context.Response.Write(editSubMenuToReturn); // print the json list
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        [WebMethod]
        public void Login(String username, String password)

        {

            Context.Response.Clear();

            Context.Response.ContentType = "application/json";

            var json = "";

            var keyValues = new Dictionary<string, string>

        {

            {"status", "Login faild" }

        };

            if (username == "lior" && password == "123")

            {

                keyValues = new Dictionary<string, string>

            {

                {"sessionId", "123456" },

                {"status", "Login success"}

            };

            }

            JavaScriptSerializer jss = new JavaScriptSerializer();

            json = jss.Serialize(keyValues);

            Context.Response.Write(json);

        }


        [WebMethod]

        public void Signup(String username, String password)

        {

            Context.Response.Clear();

            Context.Response.ContentType = "application/json";

            var json = "";

            var keyValues = new Dictionary<string, string>

        {

            {"status", "Login faild" }

        };

            if (username == "lior" && password == "123")

            {

                keyValues = new Dictionary<string, string>

            {

                {"sessionId", "123456" },

                {"status", "Login success"}

            };

            }

            JavaScriptSerializer jss = new JavaScriptSerializer();

            json = jss.Serialize(keyValues);

            Context.Response.Write(json);

        }

        [WebMethod]
        // This method get a IQueryable<> object and return a Json String
        private static string convertQueryToJson(IQueryable<object> query) // object means it could be any kind of IQueryable
        {
            var json = JsonConvert.SerializeObject(query); // Turn the query into Json String
            return json;
        }

        
    }
}
