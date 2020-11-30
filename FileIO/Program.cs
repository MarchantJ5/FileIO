using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileIO
{
    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayLoginScreen();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        static void DisplayLoginScreen()
        {
            string dataPath = @"C:\Users\James Marchant\Desktop\School\Coding\Submissions\FileIO\FileIO\TextFiles\Password.txt";
            string fileText;
            string[] fileTextArray;
            string username;
            string password;
            bool validUsername = false;
            bool validPassword = false;

          
           

            fileText = File.ReadAllText(dataPath);
            fileTextArray = fileText.Split(',');

            username = fileTextArray[0];
            password = fileTextArray[1];

            Console.WriteLine("Please enter username");
            do
            {
                if (Console.ReadLine().ToLower() == username)
                {
                    Console.WriteLine("Correct username.");
                    validUsername = true;  
                }
                else
                {
                    Console.WriteLine("Incorrect username.");
                }

            } while (!validUsername);

            Console.WriteLine("Please enter password");
            do
            {
                if (Console.ReadLine().ToLower() == password)
                {
                    Console.WriteLine("Correct password.");
                    validPassword = true;
                }
                else
                {
                    Console.WriteLine("Incorrect password.");
                }
            } while (!validPassword);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
           static void SetTheme()
        {
            string dataPath = @"C:\Users\James Marchant\Desktop\School\Coding\Submissions\FileIO\FileIO\TextFiles\Color.txt";
            string[] fileTextArray;
            ConsoleColor backgroundColor;
            ConsoleColor foregroundColor;

            fileTextArray = File.ReadAllLines(dataPath);

              Enum.TryParse(fileTextArray[0], out backgroundColor);
              Enum.TryParse(fileTextArray[1], out foregroundColor);

            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Clear();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;



            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Change Username and Password");
                Console.WriteLine("\tb) Change Console Theme");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayPasswordChangeScreen();
                        break;

                    case "b":
                        DisplayChangeColorScreen();
                        break;

                    case "q":

                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        static void DisplayChangeColorScreen()
        {
            DisplayScreenHeader("New Colors");


            bool validResponse = false;
            string[] fileTextArray = new string[2];
            Console.WriteLine("New Background Color");
            
            do
            {
                string background = Console.ReadLine();
                if (Enum.TryParse(background, out ConsoleColor backgroundColor))
                {
                    Console.BackgroundColor = backgroundColor;
                    validResponse = true;
                    fileTextArray[0] = backgroundColor.ToString();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Please enter a valid color");
                }
            } while (!validResponse);

            validResponse = false;
            Console.WriteLine("New Foreground Color");
            do
            {
                string foreground = Console.ReadLine();
                if (Enum.TryParse(foreground, out ConsoleColor foregroundColor))
                {
                    Console.ForegroundColor = foregroundColor;
                    validResponse = true;
                    fileTextArray[1] = foregroundColor.ToString();
                }
                else
                {
                    Console.WriteLine("Please enter a valid color");
                }
            } while (!validResponse);
            
            Console.Clear();

            DisplayWriteToFile(fileTextArray);

            DisplayContinuePrompt();
        }

        static void DisplayWriteToFile(string[] fileTextArray)
        {
            string dataPath = @"C:\Users\James Marchant\Desktop\School\Coding\Submissions\FileIO\FileIO\TextFiles\Color.txt";
            File.WriteAllLines(dataPath, fileTextArray);
        }

        static void DisplayPasswordChangeScreen()
        {
            string dataPath = @"C:\Users\James Marchant\Desktop\School\Coding\Submissions\FileIO\FileIO\TextFiles\Password.txt";
            string username;
            string password;
            string fileText;

            File.WriteAllText(dataPath, String.Empty);

            Console.WriteLine("Please enter new username.");
            username = Console.ReadLine();

            Console.Clear();

            Console.WriteLine("Please enter new password.");
            password = Console.ReadLine();

            Console.Clear();

            Console.WriteLine($"New username: {username}");
            Console.WriteLine($"New password: {password}");

            fileText = username + "," + password;

            File.WriteAllText(dataPath, fileText);

        }
        #region USER INTERFACE

        // <summary>
        // *****************************************************************
        // *                     Welcome Screen                            *
        // *****************************************************************
        // </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFileIO");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        // <summary>
        //*****************************************************************
        // *                     Closing Screen                            *
        // *****************************************************************
        // </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        // <summary>
        // display continue prompt
        // </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        // <summary>
        // display menu prompt
        // </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        // <summary>
        // display screen header
        // </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
        