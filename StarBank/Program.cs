using StarBank.Display;
using StarBank.Entities;

namespace StarBank
{
    internal class Program
    {
        //In memory database;
        public static List<User> Users = new List<User>();
        public static int LoggedUser;

        static void Main(string[] args)
        {
            Menu.InitialMenu();
        }
    }
}
