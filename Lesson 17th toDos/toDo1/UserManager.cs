using System;
using System.Collections.Generic;

namespace toDo1
{
    public static class UserManager
    {

        public static List<User> ListOfUsers()
        {
            return new List<User>()
            {
            new User("Namiq", "Karimov", 23, "Azerbaijan"),
            new User("Samira", "Karimova", 21, "Azerbaijan"),
            new User("Namik", "Demir", 9, "Turkey"),
            new User("Josh", "Shroot", 17, "USA"),
            new User("Dilbar", "Irani", 5, "Turkey"),
            new User("Antony", "Kramov", 23, "Russia"),
            new User("Hanna", "Welbach", 11, "Turkey"),
            new User("Bella", "Jish", 9, "Belgia"),
            new User("Anne", "Redhead", 7, "Canada"),
            new User("Billy", "Swish", 5, "Ireland")
            };
        }


        public delegate void DoSomething(List<User> list);
        public static void printUsersToConsole(List<User> list)
        {
            foreach (var u in list)
            {
                Console.WriteLine(u.ToString());
            }
        }
    }
}
