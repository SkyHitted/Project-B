using System;

namespace HelloWorld
{
    class Program
    {
        public static void Main() {
            bool mainLoop = true;
            while (mainLoop){
                int Screen_1 = Options.listOfChoice(true, "Login\n", "Ga verder als gast\n");
                if (Screen_1 == -1) {
                    mainLoop = false;
                }
                else if (Screen_1 == 0) {
                    string accountType = Login();
                    if (accountType == "Klant"){Klant();}
                    else if (accountType == "Werknemer"){Werknemer();}
                    else if (accountType == "Admin"){Admin();}
                    }
                else if (Screen_1 == 1) {
                    for (bool gastLoop = true; gastLoop;){
                    int screen_Gast_Start = Options.listOfChoice(true, "Login\n", "Registreren\n", "Reserveren\n", "Contact\n");
                    if (screen_Gast_Start == -1) {
                        mainLoop = false;
                        gastLoop = false;
                    }
                    else if (screen_Gast_Start == 0){
                        string accountType = Login();
                        if (accountType == "Klant"){Klant();}
                        else if (accountType == "Werknemer"){Werknemer();}
                        else if (accountType == "Admin"){Admin();}
                    }
                    else if (screen_Gast_Start == 1){}
                    else if (screen_Gast_Start == 2){}
                    else if (screen_Gast_Start == 3){}
                    }
                }
            }
        }
        public static string Login() {
            string gebruikersNaam;
            string gebruikersWachtwoord;
            Console.Clear();
            Console.WriteLine("Gebruikers naam");
            gebruikersNaam = Console.ReadLine();
            Console.WriteLine("Gebruikers wachtwoord");
            gebruikersWachtwoord = Console.ReadLine();
            // Json file
            return "Klant"; // Return index of Dictionary with accounttype
        }
        public static void Klant() {
            int screen_Klant_Start = Options.listOfChoice(true, "Logout\n", "Mijn informatie\n", "Reserveren\n", "Contact\n");
        }
        public static void Werknemer() {
            int screen_Werknemer_Start = Options.listOfChoice(true, "Logout\n", "Menu\n", "Reserveren\n", "Contact\n");
        }
        public static void Admin() {
            int screen_Admin_Start = Options.listOfChoice(true, "Logout\n", "Accounts\n", "Menu\n", "Contact\n");
        }
    }
    class Options
    {
    public static int listOfChoice(bool canCancel, params string[] options)
        {
        // const int startY = 8;

        int currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
            {
            Console.Clear();

            for (int i = 0; i < options.Length; i++)
                {
                // Console.SetCursorPosition(0, startY + i);

                if(i == currentSelection)
                    Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write(options[i]);

                Console.ResetColor();
                }

            key = Console.ReadKey(true).Key;

            switch (key)
                {
                case ConsoleKey.UpArrow:
                    {
                    if (currentSelection > 0)
                        currentSelection--;
                    break;
                    }
                case ConsoleKey.DownArrow:
                    {
                    if (currentSelection < options.Length-1)
                        currentSelection++;
                    break;
                    }
                case ConsoleKey.Escape:
                    {
                    if (canCancel)
                        return -1;
                    break;
                    }
                }
            } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;

        return currentSelection;
        }
    }
}
