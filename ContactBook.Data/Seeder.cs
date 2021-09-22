using ContactBook.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Data
{
    public class Seeder
    {
        public async static Task SeedData(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ContactBookContext context)
        {
            try
            {
                var dirDb = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var dab = typeof(ContactBookContext).Name;


                await context.Database.EnsureCreatedAsync();
                if (!context.Users.Any())
                {
                    List<string> roles = new() { "Admin", "Regular" };
                    foreach (var role in roles)
                    {
                        await roleManager.CreateAsync(new IdentityRole { Name = role });
                    }
                    

                    //var appUsers = File.ReadAllText(dirDb + @"/JSONfiles/AppUsers.json");
                    //var users = JsonConvert.DeserializeObject<List<AppUser>>(appUsers);
                    //await context.AppUsers.AddRangeAsync(users);
                    //var result = await context.SaveChangesAsync();
                    List<User> users = new()
                    {
                     new User
                     {
                         FirstName = "John",
                         LastName = "James",
                         Email = "JJ@gmail.com",
                         UserName = "jjgh",
                         PhoneNumber = "080479379494"
                     },
                     new User
                     {
                         FirstName = "Anne",
                         LastName = "Perry",
                         Email = "Anne@gmail.com",
                         UserName = "Annie",
                         PhoneNumber = "080743979494"
                     },
                     new User
                     {
                         FirstName = "Glenna",
                         LastName = "Waters",
                         Email = "glennawaters@roughies.com",
                         UserName = "Mcdaniel",
                         PhoneNumber = "+1 (848) 443-2870"
                     },
                     new User
                     {
                         FirstName = "Vonda",
                         LastName = "Ramsey",
                         Email = "vondaramsey@roughies.com",
                         UserName = "Michael",
                         PhoneNumber = "+1 (828) 400-3241"
                     },
                     new User
                     {
                         FirstName = "Mollie",
                         LastName = "Hewitt",
                         Email = "molliehewitt@roughies.com",
                         UserName = "Coleen",
                         PhoneNumber = "+1 (835) 549-2103"
                     },
                     new User
                     {
                         FirstName = "Reyna",
                         LastName = "Chavez",
                         Email = "reynachavez@roughies.com",
                         UserName = "Cooper",
                         PhoneNumber = "+1 (958) 505-2869",
                     },
                     new User
                     {
                         FirstName = "Ramona",
                         LastName = "Hines",
                         Email = "ramonahines@roughies.com",
                         UserName = "Amy",
                         PhoneNumber = "+1 (813) 579-2259",
                     },
                     new User
                     {
                         FirstName = "Damon",
                         LastName = "Dash",
                         Email = "damonahines@roughies.com",
                         UserName = "Damondash",
                         PhoneNumber = "+1 (813) 539-2159",
                     },
                     new User
                     {
                         FirstName = "Reed",
                         LastName = "Keller",
                         Email = "reedkeller@roughies.com",
                         UserName = "Sheena",
                         PhoneNumber = "+1 (959) 586-2171"
                     },
                     new User
                     {
                         FirstName = "Pierce",
                         LastName = "Wilkerson",
                         Email = "piercewilkerson@roughies.com",
                         UserName = "Jan",
                         PhoneNumber = "+1 (800) 472-3639"
                     },
                     new User
                     {
                         FirstName = "Pierre",
                         LastName = "Boznian",
                         Email = "pierreboz@roughies.com",
                         UserName = "BozPierre",
                         PhoneNumber = "+1 (860) 412-3629"
                     },
                     new User
                     {
                         FirstName = "Mikavel",
                         LastName = "Wilkers",
                         Email = "mikavelwilker@roughies.com",
                         UserName = "Mikawil",
                         PhoneNumber = "+1 (814) 467-3639"
                     },
                     new User
                     {
                         FirstName = "Savage",
                         LastName = "Langley",
                         Email = "savagelangley@roughies.com",
                         UserName = "Tonya",
                         PhoneNumber = "+1 (833) 567-3506"
                     },
                     new User
                     {
                         FirstName = "Crawford",
                         LastName = "Vaughan",
                         Email = "crawfordvaughan@roughies.com",
                         UserName = "Jannie",
                         PhoneNumber = "+1 (821) 550-2612"
                     },
                     new User
                     {
                         FirstName = "Gordon",
                         LastName = "Brennan",
                         Email = "gordonbrennan@roughies.com",
                         UserName = "William",
                         PhoneNumber = "+1 (864) 589-2150"
                     },
                     new User
                     {
                         FirstName = "Walton",
                         LastName = "Holland",
                         Email = "waltonholland@roughies.com",
                         UserName = "Nell",
                         PhoneNumber = "+1 (952) 439-2584"
                     },
                     new User
                     {
                         FirstName = "Jody",
                         LastName = "Dawson",
                         Email = "jodydawson@roughies.com",
                         UserName = "Kinney",
                         PhoneNumber = "+1 (919) 590-2619"
                     },
                     new User
                     {
                         FirstName = "Burris",
                         LastName = "Carver",
                         Email = "burriscarver@roughies.com",
                         UserName = "Osborn",
                         PhoneNumber = "+1 (858) 578-2987"
                     },
                     new User
                     {
                         FirstName = "Valeria",
                         LastName = "Meyers",
                         Email = "valeriameyers@roughies.com",
                         UserName = "Ashley",
                         PhoneNumber = "+1 (941) 475-3205"
                     },
                     new User
                     {
                         FirstName = "Terrie",
                         LastName = "French",
                         Email = "terriefrench@roughies.com",
                         UserName = "Knight",
                         PhoneNumber = "+1 (961) 469-2281"
                     },
                     new User
                     {
                         FirstName = "Mindy",
                         LastName = "Hopkins",
                         Email = "mindyhopkins@roughies.com",
                         UserName = "Rachel",
                         PhoneNumber = "+1 (927) 431-2553"
                     },
                     new User
                     {
                         FirstName = "Key",
                         LastName = "Wilcox",
                         Email = "keywilcox@roughies.com",
                         UserName = "Geneva",
                         PhoneNumber = "+1 (874) 473-3137"
                     },
                     new User
                     {
                         FirstName = "Margret",
                         LastName = "Goodwin",
                         Email = "margretgoodwin@roughies.com",
                         UserName = "Mckenzie",
                         PhoneNumber = "+1 (981) 465-3439",
                     }
                     
                    };


                    foreach (var user in users)
                    {
                        await userManager.CreateAsync(user, "Jimmy@12345");
                        if (user == users[0])
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                        }
                        else
                        {
                            await userManager.AddToRoleAsync(user, "Regular");
                        }

                    }

                }
            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.Message); ;
            }
        }
    }
}
