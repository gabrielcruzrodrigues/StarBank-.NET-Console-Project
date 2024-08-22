using StarBank.Display;
using StarBank.Entities;

namespace StarBank
{
    internal class Program
    {
        //In memory database;
        public static List<User> Users = new List<User>();

        static void Main(string[] args)
        {
            Menu menu = new();
            menu.InitialMenu();
        }
    }
}
