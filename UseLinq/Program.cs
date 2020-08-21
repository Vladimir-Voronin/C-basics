using System;
using System.Linq;
using System.Collections.Generic;

namespace UseLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqSelection();
        }

        public static void LinqSelection()
        {
            List<User> users = new List<User>
            {
                new User {Name="Том", Age=23, Languages = new List<string> {"английский", "немецкий" }},
                new User {Name="Боб", Age=27, Languages = new List<string> { "французский", "английский" }},
                new User {Name="Джон", Age=29, Languages = new List<string> {"английский", "испанский" }},
                new User {Name="Элис", Age=24, Languages = new List<string> {"испанский", "немецкий" }}
            };

            List<Country> countries = new List<Country>
            {
                new Country { Name = "Великобритания", Language = "английский"},
                new Country { Name = "Франция", Language = "французский"},
                new Country { Name = "Германия", Language = "немецкий"},
                new Country { Name = "Испания", Language = "испанский"}
            };

            var set = from user in users
                      from lang in user.Languages
                      where user.Age < 27
                      where lang == "английский"
                      select user;

            foreach (User user in set)
                Console.WriteLine($"{user.Name} - {user.Age}");

            var setwithgroup = users.GroupBy(u => u.Age > 25).Select(u=>new { Name = u.Key ? ">25" : "<25", user = u });

            foreach (var g in setwithgroup)
            {
                Console.WriteLine(g.Name);
                foreach (var item in g.user)
                {
                    Console.WriteLine(item.Name);
                }
            }

            var setcountryes = users.Join(countries,
                                          u => u.Languages[0],
                                          p => p.Language,
                                          (u, p) => new { Name = u.Name, MainLang = u.Languages[0], MainCountry = p.Name });

            foreach (var item in setcountryes)
            {
                Console.WriteLine($"{item.Name} - {item.MainLang} ({item.MainCountry})");
            }
        }
    }

    class User
    {

        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public User()
        {
            Languages = new List<string>();
        }
    }
    
    class Country
    {
        public string Name { get; set; }
        public string Language { get; set; }
    }
}