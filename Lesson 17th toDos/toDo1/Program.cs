using Microsoft.Graph;
using System.Linq;

namespace toDo1
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = UserManager.ListOfUsers();

            UserManager.DoSomething printUsersToConsole = UserManager.printUsersToConsole;

            printUsersToConsole(list.Where(u => u.Age > 20).ToList());

            var UsersListWithoutTurkishAndLowerAge10 = list.Where(u => (u.Age > 10) || (u.Country != "Turkey")).ToList();   
            
        }
    }
}
