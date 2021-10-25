using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

//TODO: Update these using statements to include your project name
using BevobnbTeam30.Models;
using BevobnbTeam30.Utilities;
using BevobnbTeam30.DAL;
using System.Threading.Tasks;


namespace BevobnbTeam30.Seeding
{
    public static class SeedUsers
    {
        public async static Task<IdentityResult> SeedAllUsers(UserManager<AppUser> userManager, AppDbContext context)
        {
            //Create a list of AddUserModels
            List<AddUserModel> AllUsers = new List<AddUserModel>();

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    PhoneNumber = "(512)555-1234",

                    //Add additional fields that you created on the AppUser class
                    FirstName = "Admin",
                    LastName = "Admin",
                    Birthday = new DateTime(2000, 10, 25),
                    Address ="310 Longhorn Drive, Austin TX"

                },
                Password = "Abc123!",
                RoleName = "Admin"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "bevo@example.com",
                    Email = "bevo@example.com",
                    PhoneNumber = "(512)555-5555",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Bevo",
                    LastName = "Bevo",
                    Birthday = new DateTime(2000, 10, 25),
                    Address = "310 Longhorn Drive, Austin TX"
                },
                Password = "Password123!",
                RoleName = "Customer"
            });

            AllUsers.Add(new AddUserModel()
            {
                User = new AppUser()
                {
                    //populate the user properties that are from the 
                    //IdentityUser base class
                    UserName = "host@example.com",
                    Email = "host@example.com",
                    PhoneNumber = "(512)555-5000",

                    //TODO: Add additional fields that you created on the AppUser class
                    //FirstName is included as an example
                    FirstName = "Host",
                    LastName = "Host",
                    Birthday = new DateTime(2000, 10, 25),
                    Address = "310 Longhorn Drive, Austin TX"
                },
                Password = "Password123!",
                RoleName = "Host"
            });

            //create flag to help with errors
            String errorFlag = "Start";

            //create an identity result
            IdentityResult result = new IdentityResult();
            //call the method to seed the user
            try
            {
                foreach (AddUserModel aum in AllUsers)
                {
                    errorFlag = aum.User.Email;
                    result = await Utilities.AddUser.AddUserWithRoleAsync(aum, userManager, context);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("There was a problem adding the user with email: " 
                    + errorFlag, ex);
            }

            return result;
        }
    }
}
