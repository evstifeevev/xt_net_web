using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;
using Task6.InversionOfControl;

namespace Task6.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating an instances of classe UserLogic and AwardLogic to interact with users and awards.
            var userLogic = DependencyResolver.UserLogic;
            var awardLogic = DependencyResolver.AwardLogic;

            // Show first message.
            Console.WriteLine("This is a demontration of 3-tier architecture. It allows to operate with users and awards, " +
                $"which are contained in .json files in the program directory ({Environment.CurrentDirectory}). Users have " +
                $"a name and date of birth, and awards have a title. To see all available commands type \"help\".");

            // The command line.
            string command = string.Empty;
            do
            {
                // Read command.
                command = Console.ReadLine();
                if (command.Length < 1)
                {
                    // Ignore.
                }
                else
                {
                    // Split command to the words.
                    string[] items = command.Trim().Split();

                    // If command contains two words or less.
                    if (items.Length < 3)
                    {

                        // Check command type.
                        if (items[0] == "getall")
                        {
                            // Check what entities to display.
                            if (items.Length < 2)
                            {
                                // Display all entities.
                                getAllUsers();
                                getAllAwards();
                            }
                            else
                            {
                                items[1] = items[1].ToLower();
                                if (items[1] == "user" || items[1] == "users")
                                {
                                    // Display users.
                                    getAllUsers();
                                }
                                else if (items[1] == "award" || items[1] == "awards")
                                {
                                    // Display awards.
                                    getAllAwards();
                                }
                                else
                                {
                                    Console.WriteLine("Unknown type of entity.");
                                }
                            }
                        }
                        else if (items[0] == "help")
                        {
                            // Display help message.
                            ShowHelpMessage();
                        }
                        else
                        {
                            Console.WriteLine("Unkown command. The command must contain type of operation, type of entity and it's properties.");
                        }
                    }
                    else
                    {
                        // Check the command type.
                        items[0] = items[0].ToLower();
                        if (items[0] == "add")
                        {
                            if (items.Length < 2)
                            {
                                Console.WriteLine("The type of entity must follow command \"add\".");
                            }
                            else
                            {
                                // Check entity type.
                                items[1] = items[1].ToLower();
                                if (items[1] != "user" && items[1] != "award")
                                {
                                    Console.WriteLine("Unkown entity. Available entities are user and award.");
                                }
                                else
                                if (items[1] == "user" && items.Length == 4)
                                {
                                    // Read date of birth.
                                    if (DateTime.TryParse(items[3], out DateTime dateOfBirth))
                                    {
                                        try
                                        {
                                            // Add user.
                                            userLogic.Add(new User(items[2], dateOfBirth));
                                            ShowSuccessMessage();
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                }
                                else if (items[1] == "award" && items.Length == 3)
                                {
                                    try
                                    {
                                        // Add award.
                                        awardLogic.Add(new Award(items[2]));
                                        ShowSuccessMessage();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect properties of the entered entity.");
                                }
                            }
                        }
                        else if (items[0] == "remove")
                        {
                            if (int.TryParse(items[2], out int id))
                            {
                                // Check entity type.
                                items[1] = items[1].ToLower();
                                if (items[1] == "user")
                                {
                                    try
                                    {
                                        // Remove user.
                                        userLogic.Remove(id);
                                        ShowSuccessMessage();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                else if (items[1] == "award")
                                {
                                    try
                                    {
                                        // Remove award.
                                        awardLogic.Remove(id);
                                        ShowSuccessMessage();
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                            }

                        }
                        else if (items[0] == "addawards")
                        {
                            // Read user's id.
                            if (int.TryParse(items[1], out int userId))
                            {
                                int[] awardIds = new int[items.Length - 2];
                                for (int i = 2; i < items.Length; i++)
                                {
                                    if (!int.TryParse(items[i], out awardIds[i - 2]))
                                    {
                                        Console.WriteLine($"Wrond award's id {items[i]}.");
                                    }
                                }
                                // Add the awards to the user.
                                userLogic.AddAwards(userId, awardIds);
                                ShowSuccessMessage();
                            }
                        }
                        else if (items[0] == "addusers")
                        {
                            // Read award's id.
                            if (int.TryParse(items[1], out int awardId))
                            {
                                int[] userIds = new int[items.Length - 2];
                                for (int i = 2; i < items.Length; i++)
                                {
                                    if (!int.TryParse(items[i], out userIds[i - 2]))
                                    {
                                        Console.WriteLine($"Wrond award's id {items[i]}.");
                                    }
                                }
                                // Add the award to users.
                                awardLogic.AddUsers(awardId, userIds);
                                ShowSuccessMessage();
                            }
                        }
                        else if (items[0] == "removeusers")
                        {
                            // Read award's id.
                            if (int.TryParse(items[1], out int awardId))
                            {
                                int[] userIds = new int[items.Length - 2];
                                for (int i = 2; i < items.Length; i++)
                                {
                                    if (!int.TryParse(items[i], out userIds[i - 2]))
                                    {
                                        Console.WriteLine($"Wrond award's id {items[i]}.");
                                    }
                                }
                                // Remove the award from users.
                                awardLogic.RemoveUsers(awardId, userIds);
                                ShowSuccessMessage();
                            }
                        }
                        else if (items[0] == "removeawards")
                        {
                            // Read user's id.
                            if (int.TryParse(items[1], out int userId))
                            {
                                int[] awardIds = new int[items.Length - 2];
                                for (int i = 2; i < items.Length; i++)
                                {
                                    if (!int.TryParse(items[i], out awardIds[i - 2]))
                                    {
                                        Console.WriteLine($"Wrond user's id {items[i]}.");
                                    }
                                }
                                // Add the awards from user.
                                userLogic.RemoveAwards(userId, awardIds);
                                ShowSuccessMessage();
                            }
                        }
                    }
                }

            } while (command.ToLower() != "exit" && command.ToLower() != "q");
        }
        private static void ShowHelpMessage()
        {
            Console.WriteLine("The list of available commands: " + Environment.NewLine
                + "add [user|award] [properties of (user|award)] - adds user or award with specified properties." + Environment.NewLine
                + "addawards [user's id] [list of awards ids] - adds awards to the user." + Environment.NewLine
                + "addusers [award's id] [list of users ids] - adds users to the award." + Environment.NewLine
                + "getall [user|award] - displays all users or awards. Entering just getall displays all entities." + Environment.NewLine
                + "help - displays this list of the available commands." + Environment.NewLine
                + "remove [user|award] [id of (user|award)] - removes user or award with specified id." + Environment.NewLine
                + "removeusers [award's id] [list of users ids] - removes users from the award." + Environment.NewLine
                + "removeawards [user's id] [list of awards ids] - removes awards from the user.");
        }
        private static void getAllUsers()
        {
            Console.WriteLine("Users:");
            try
            {
                foreach (var item in DependencyResolver.UserLogic.GetAll())
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void getAllAwards()
        {
            Console.WriteLine("Awards:");
            try
            {
                foreach (var item in DependencyResolver.AwardLogic.GetAll())
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ShowSuccessMessage()
        {
            Console.WriteLine("Operation has been successfully done.");
        }
    }
}
