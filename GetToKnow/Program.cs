using System;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace GetToKnow
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "Caspian", "Sanjeev", "Daniel", "Ted", "Tevin", "Tobey", "Elisa", "Jermaine" };
            string[] surnames = { "Melendez", "Padilla", "Barrow", "Scott", "Lowery", "Reeve", "Mosley", "Mays" };
            string[] hometowns = { "Detroit, MI", "Dearborn, MI", "Bloomfield Hills, MI", "Sterling Heights, MI", "Warren, MI", "Roseville, MI", "Eastpointe, MI", "Detroit, MI" };
            string[] faveFoods = { "pizza", "ramen", "elote", "pesto", "cookies", "bulgogi", "burgers", "sushi" };
            string[] birthdays = { "March 7th", "June 30th", "July 10th", "October 20th", "January 4th", "December 15th", "June 22nd", "April 3rd", };

            bool userContinue = true;

            Console.WriteLine("Welcome to our C# class! Here are our students:\n");
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i+1}\t{names[i]}");
            }

            while (userContinue)
            {
                string input = GetUserInput($"\nWhich student would you like to learn more about? Please enter a number between 1-{names.Length}.");

                bool proceed = true;
                
                while (proceed)
                {
                    try
                    {
                        if (Int32.TryParse(input, out int studentNumber))
                        {
                            int index = studentNumber - 1;

                            Console.Write($"Student {studentNumber} is {names[index]} {surnames[index]}. ");
                            string moreInfo = GetUserInput($"What would you like to know about {names[index]}? (enter hometown, favorite food or birthday)");
                            
                            Console.Write(GetMoreInfo(index, moreInfo, names[index], hometowns, faveFoods, birthdays));
                            proceed = UserContinue("Do you want to learn more about this student? (y/n)");
                        }
                        else
                        {
                            input = GetUserInput($"That student does not exist. Please try again. (enter a number 1-{names.Length})");
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        input = GetUserInput($"That student does not exist. Please try again. (enter a number 1-{names.Length})");
                    }
                    catch (FormatException)
                    {
                        input = GetUserInput($"That student does not exist. Please try again. (enter a number 1-{names.Length})");
                    }
                }
                userContinue = UserContinue("Do you want to learn about another student? (y/n)");
            }
            Console.WriteLine("Thanks!");
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().Trim();
            return input;
        }
        public static string GetMoreInfo(int index, string input, string name, string[] info1, string[] info2, string[] info3)
        {
            try 
            { 
                if (input == "hometown")
                {
                    return $"{name} is from {info1[index]}. ";
                }
                else if (input == "favorite food")
                {
                    return $"{name}'s favorite food is {info2[index]}. ";
                }
                else if (input == "birthday")
                {
                    return $"{name}'s birthday is {info3[index]}. ";
                }
                else
                    return "That data does not exist. ";
            }
            catch (FormatException)
            {
                 return $"That data does not exist. ";
            }
        }
        public static bool UserContinue(string message)
        {
            Console.WriteLine(message);
            string proceed = Console.ReadLine().Trim().ToLower();

            while (proceed != "n" && proceed != "y")
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                proceed = Console.ReadLine().Trim().ToLower();
            }

            if (proceed == "y")
            {
                return true;
            }
            else
                return false;
        }
    }
}
