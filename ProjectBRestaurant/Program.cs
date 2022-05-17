using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace ProjectBRestaurant
{

    class Program
    {
        static void Main(string[] args)
        {
            bool mainLoop = true;
            while (mainLoop)
            {
                string fileNameAccounts = "Studenten.json";
                string jsonString = File.ReadAllText(fileNameAccounts);
                var existAccount = JsonSerializer.Deserialize<Account>(jsonString)!;
                int Screen_1 = Options.listOfChoice(true, "Login\n", "Ga verder als gast\n");
                if (Screen_1 == -1)
                {
                    mainLoop = false;
                }
                else if (Screen_1 == 0)
                {
                    string accountType = Login();
                    if (accountType == "Klant") { Klant(); }
                    else if (accountType == "Werknemer") { Werknemer(); }
                    else if (accountType == "Admin") { Admin(); }
                }
                else if (Screen_1 == 1)
                {
                    for (bool gastLoop = true; gastLoop;)
                    {
                        int screen_Gast_Start = Options.listOfChoice(true, "Login\n", "Registreren\n", "Reserveren\n", "Contact\n");
                        if (screen_Gast_Start == -1)
                        {
                            mainLoop = false;
                            gastLoop = false;
                        }
                        else if (screen_Gast_Start == 0)
                        {
                            string accountType = Login();
                            if (accountType == "Klant") { Klant(); }
                            else if (accountType == "Werknemer") { Werknemer(); }
                            else if (accountType == "Admin") { Admin(); }
                        }
                        else if (screen_Gast_Start == 1)
                        {
                            int accountType = Register();
                            if (accountType == 0){break;}
                            Klant();
                            break;
                        }
                        else if (screen_Gast_Start == 2) { }
                        else if (screen_Gast_Start == 3) { }
                    }
                }
            }
        }

        public static int Register()
        {
            string fileNameAccounts = "Studenten.json";
            string jsonString = File.ReadAllText(fileNameAccounts);
            var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!;
            Console.WriteLine("Maak uw gebruikers naam");
            string usernameKlant = Console.ReadLine();
            bool nameNotUsed = true;
            for (int i = 0; i < existAccount.Accounts.Count && nameNotUsed; i++)
            {
                if (usernameKlant == existAccount.Accounts[i].username)
                {
                    nameNotUsed = false;
                    Console.WriteLine("Dit gebruikers naam is in gebruik, kies voor een nieuw gebruikers naam");
                    return 0;
                }
            }
            Console.WriteLine("Maak uw gebruikers wachtwoord");
            string passwordKlant = Console.ReadLine();
            int idKlant = existAccount.Accounts.Count + 1;
            existAccount.Accounts.Add(
                new Account {id = idKlant,username = usernameKlant, password = passwordKlant, typeOfAccount = "klant"}
            );
            jsonString = JsonSerializer.Serialize(existAccount);
            File.WriteAllText(fileNameAccounts, jsonString);
            return idKlant;
        }
        public static string Login()
        {
            string gebruikersNaam;
            string gebruikersWachtwoord;
            Console.Clear();
            Console.WriteLine("Gebruikers naam");
            gebruikersNaam = Console.ReadLine();
            Console.WriteLine("Gebruikers wachtwoord");
            gebruikersWachtwoord = Console.ReadLine();
            // Json file
            return "Werknemer"; // Return index of Dictionary with accounttype
        }
        public static void Klant()
        {
            int screen_Klant_Start = Options.listOfChoice(true, "Logout\n", "Mijn informatie\n", "Reserveren\n", "Contact\n");
        }
        public static void Werknemer()
        {
            int screen_Werknemer_Start = Options.listOfChoice(true, "Logout\n", "Menu\n", "Reserveren\n", "Contact\n");
        }
        public static void Admin()
        {
            int screen_Admin_Start = Options.listOfChoice(true, "Logout\n", "Accounts\n", "Menu\n", "Contact\n");
        }
    }
}
