namespace Routing.Models
{
    public class User
    {
        public string FirstName {get;set;}
    }
    public class Pizza
    {
        public string Name {get;set;}
    }
    public class HomeView
    {
        public User MyUser {get;set;}
        public Pizza MyPizza {get;set;}
    }
}