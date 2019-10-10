using pleeweasse.Models;
using System;
using System.Linq;

namespace pleeweasse
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            using(var db = new semester3Context())
            {
                //Read all users
                var user = db.User
                    .OrderBy(b => b.UserId.First()).ToList();

                foreach (User test in user)
                {
                    Console.WriteLine(test.UserId);

                }
                
                 //Add new user
                db.Add(new User 
                {
                    UserId = "fuck dig",
                    UserLogin = "hjæawdawd",
                    UserPassword = "FUCK",
                    UserEmail = "hjælp mig"
                });
                db.SaveChanges();
               

            }
        }
    }
}
