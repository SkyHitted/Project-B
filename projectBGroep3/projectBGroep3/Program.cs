using System;

using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace projectBGroep3
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("Accounts.json")) // Check of json file er is
            {
                var tmp = new TypesOfChoice();
                tmp.Accounts = new List<Account>
                {
                    new Account {id = 1, username = "Admin", password = "Admin1", typeOfAccount = "admin"}//Maakt admin account
                };
                string fileNameAccounts = "Accounts.json";
                string jsonString = JsonSerializer.Serialize(tmp);//Saved naar json file
                File.WriteAllText(fileNameAccounts, jsonString);
            }
            if (!File.Exists("OpenSlotsReserveren.json"))
            {
                var tmp = new NewDay();
                tmp.Reserveren = new List<ReserverenClass>
                {
                    new ReserverenClass
                    {
                        deDatum = DateTime.Today.AddDays(-1).Date.ToString(),
                        allTime = new List<slotsAndReseveren>
                        {
                            new slotsAndReseveren
                            {
                                openSlotten = new Dictionary<int, int>
                                {
                                    [10] = 100,
                                    [12] = 100,
                                    [14] = 100,
                                    [16] = 100,
                                    [18] = 100,
                                    [20] = 100,
                                    [22] = 100,

                                },
                                reserveert = new Dictionary<int, int> 
                                {
                                    [10] = 0,
                                    [12] = 0,
                                    [14] = 0,
                                    [16] = 0,
                                    [18] = 0,
                                    [20] = 0,
                                    [22] = 0,
                                }
                            }
                        }
                    }
                };
                string fileNameReserveren = "OpenSlotsReserveren.json";
                string jsonString = JsonSerializer.Serialize(tmp);//Saved naar json file
                File.WriteAllText(fileNameReserveren, jsonString);
                for (int i = 1; i < 15; i++)
                {
                    DateTime day = DateTime.Today.AddDays(i);
                    ReserverenC.ReserveringChecker(day);
                }
            }
            if (!File.Exists("ConfirmReserveren.json"))
            {
                var tmp = new NewReservering();
                tmp.deReserveringAgenda = new List<ConfirmReservering>
                {
                    new ConfirmReservering
                    {
                        deID = 0,
                        alleReserveringen = new List<Reserveringen>
                        {
                            new Reserveringen
                            {
                                naamReservering = "Test",
                                datumReservering = DateTime.Today.Date.ToShortDateString(),
                                tijdReservering = "10:00",
                                gastenReservering = 6,
                                bevestigingCode = "13/05/2022101"
                            }

                        }
                    }
                };
                string fileNameConfirm = "ConfirmReserveren.json";
                string jsonString = JsonSerializer.Serialize(tmp);//Saved naar json file
                File.WriteAllText(fileNameConfirm, jsonString);
            }
            if (!File.Exists("Menu.json"))
            {
                var tmp = new NewKeuken();
                tmp.Menu = new List<MenuClass>
                {
                    new MenuClass
                    {
                        keukenNaam = "Arabische Keuken",
                        ontbijt = new List<MenuGerechten>
                        {
                            new MenuGerechten
                            {
                                naamGerecht = "Falafel",
                                prijsGerecht = 6,
                                allergieGerecht = "Geen"
                            }
                        },
                        lunch = new List<MenuGerechten>
                        {
                            new MenuGerechten
                            {
                                naamGerecht = "Hummus",
                                prijsGerecht = 4
                            }
                        },
                        avondeten = new List<MenuGerechten>
                        {
                            new MenuGerechten
                            {
                                naamGerecht = "Shakshuka",
                                prijsGerecht = 10
                            }
                        },
                        desert = new List<MenuGerechten>
                        {
                            new MenuGerechten
                            {
                                naamGerecht = "Baklava",
                                prijsGerecht = 8
                            }
                        }
                    }
                };
                tmp.Menu.Add(
                    new MenuClass
                    {
                        keukenNaam = "Itiaanse Keuken",
                        ontbijt = new List<MenuGerechten>
                        {
                            new MenuGerechten
                            {
                                naamGerecht = "Croissant",
                                prijsGerecht = 2.5,
                            }
                        },
                        lunch = new List<MenuGerechten>
                        {
                            new MenuGerechten
                            {
                                naamGerecht = "Aspergesoep",
                                prijsGerecht = 4
                            }
                        },
                        avondeten = new List<MenuGerechten>
                        {
                            new MenuGerechten
                            {
                                naamGerecht = "Kip masrala",
                                prijsGerecht = 12
                            }
                        },
                        desert = new List<MenuGerechten>
                        {
                            new MenuGerechten
                            {
                                naamGerecht = "Tiramisu",
                                prijsGerecht = 6
                            }
                        }
                    });
                string fileNameReserveren = "Menu.json";
                string jsonString = JsonSerializer.Serialize(tmp);//Saved naar json file
                File.WriteAllText(fileNameReserveren, jsonString);
            }
            bool mainLoop = true;
            string s = "";
            for (int i = 1; i < 15; i++)
            {
                DateTime day = DateTime.Today.AddDays(i);
                ReserverenC.ReserveringChecker(day);
            }
            while (mainLoop)//Loop voor hele applicatie
            {
                string fileNameAccounts = "Accounts.json";//json file locatie
                s = 
@"░██╗░░░░░░░██╗███████╗██╗░░░░░░█████╗░░█████╗░███╗░░░███╗███████╗
░██║░░██╗░░██║██╔════╝██║░░░░░██╔══██╗██╔══██╗████╗░████║██╔════╝
░╚██╗████╗██╔╝█████╗░░██║░░░░░██║░░╚═╝██║░░██║██╔████╔██║█████╗░░
░░████╔═████║░██╔══╝░░██║░░░░░██║░░██╗██║░░██║██║╚██╔╝██║██╔══╝░░
░░╚██╔╝░╚██╔╝░███████╗███████╗╚█████╔╝╚█████╔╝██║░╚═╝░██║███████╗
░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚══════╝

╔═══════════════════════════════════════════════════════════╗
║ Navigeer de applicatie door middel van de pijltjestoetsen.║
║ Uw geselecteerd optie is in blauw.                        ║
║ Bevestig uw keuze door middel van de Enter toets.         ║
╚═══════════════════════════════════════════════════════════╝" + "\n";
                int Screen_1 = Options.listOfChoice(true, s, "Inloggen\n", "Ga verder als gast\n");//Roept class Options voor een int return
                if (Screen_1 == -1) // gebruiker drukt esc
                {
                    mainLoop = false;
                }
                else if (Screen_1 == 0) // eerste optie "Login"
                {
                    Console.Clear();
                    bool notLoggedIn = false;
                    for (int i = 4; i > 0 && !notLoggedIn; i--)
                    {
                        int accountID = Login();// Roept Login functie
                        if (accountID > 0)
                        {
                            var jsonString = File.ReadAllText(fileNameAccounts); // json
                            var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!;
                            for (int j = 0; j < existAccount.Accounts.Count; j++) // loop id to find accounttype
                            {
                                if (accountID == existAccount.Accounts[j].id)
                                {
                                    if (existAccount.Accounts[j].typeOfAccount == "klant")
                                    {
                                        Klant(accountID); // roept klant functie
                                        break;
                                    }
                                    else if (existAccount.Accounts[j].typeOfAccount == "werknemer")
                                    {
                                        Werknemer(accountID); // roept werknemer functie
                                        break;
                                    }
                                    else if (existAccount.Accounts[j].typeOfAccount == "admin")
                                    {
                                        Admin(accountID); // roept admin functie
                                        break;
                                    }
                                }
                            }
                            notLoggedIn = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Fout gebruikersnaam of gebruikerswachtwoord. U heeft nog {i - 1} kans(en) over\n");
                        }
                    }

                }
                else if (Screen_1 == 1) // 2de optie "Ga verder ..."
                {
                    for (bool gastLoop = true; gastLoop;) // Gastloop
                    {
                        s = @"╔═══════════════════════════════════════════════════════════╗
║ Navigeer de applicatie door middel van de pijltjestoetsen.║
║ Uw geselecteerd optie is in blauw.                        ║
║ Bevestig uw keuze door middel van de Enter toets.         ║
╚═══════════════════════════════════════════════════════════╝

Welcome gast!" + "\n";
                        int screen_Gast_Start = Options.listOfChoice(true, s, "Inloggen\n", "Registreren\n", "Reserveren\n", "Contact\n");
                        if (screen_Gast_Start == -1)
                        {
                            gastLoop = false;
                        }
                        else if (screen_Gast_Start == 0)
                        {
                            Console.Clear();
                            bool notLoggedIn = false;
                            for (int i = 4; i > 0 && !notLoggedIn; i--)
                            {
                                int accountID = Login();// Roept Login functie
                                if (accountID > 0)
                                {
                                    var jsonString = File.ReadAllText(fileNameAccounts); // json
                                    var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!;
                                    for (int j = 0; j < existAccount.Accounts.Count; j++) // loop id to find accounttype
                                    {
                                        if (accountID == existAccount.Accounts[j].id)
                                        {
                                            if (existAccount.Accounts[j].typeOfAccount == "klant")
                                            {
                                                Klant(accountID); // roept klant functie
                                                break;
                                            }
                                            else if (existAccount.Accounts[j].typeOfAccount == "werknemer")
                                            {
                                                Werknemer(accountID); // roept werknemer functie
                                                break;
                                            }
                                            else if (existAccount.Accounts[j].typeOfAccount == "admin")
                                            {
                                                Admin(accountID); // roept admin functie
                                                break;
                                            }
                                        }
                                    }
                                    notLoggedIn = true;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine($"Fout gebruikersnaam of gebruikerswachtwoord. U heeft nog {i - 1} kans(en) over\n");
                                }
                            }
                        }
                        else if (screen_Gast_Start == 1)
                        {
                            int accountType = Register("klant");
                            if (accountType == 0) { continue; }// registratie ging fout, reset loop
                            Klant(accountType);
                            break;
                        }
                        else if (screen_Gast_Start == 2)
                        {
                            Reserveren(0);
                        }
                        else if (screen_Gast_Start == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("No function atm");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public static int Register(string type)
        {
            Console.Clear();
            string fileNameAccounts = "Accounts.json";
            string jsonString = File.ReadAllText(fileNameAccounts);
            var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!; // json
            string s =
@"██████╗░███████╗░██████╗░██╗░██████╗████████╗██████╗░███████╗██████╗░███████╗███╗░░██╗
██╔══██╗██╔════╝██╔════╝░██║██╔════╝╚══██╔══╝██╔══██╗██╔════╝██╔══██╗██╔════╝████╗░██║
██████╔╝█████╗░░██║░░██╗░██║╚█████╗░░░░██║░░░██████╔╝█████╗░░██████╔╝█████╗░░██╔██╗██║
██╔══██╗██╔══╝░░██║░░╚██╗██║░╚═══██╗░░░██║░░░██╔══██╗██╔══╝░░██╔══██╗██╔══╝░░██║╚████║
██║░░██║███████╗╚██████╔╝██║██████╔╝░░░██║░░░██║░░██║███████╗██║░░██║███████╗██║░╚███║
╚═╝░░╚═╝╚══════╝░╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝" + "\n";
            Console.WriteLine(s);
            Console.WriteLine("Maak uw gebruikers naam");
            string usernameKlant = Console.ReadLine();
            for (int i = 0; i < existAccount.Accounts.Count; i++)
            {
                if (usernameKlant.Length == 0)
                {
                    Console.WriteLine("U kan geen leeg gebruikers naam hebben");
                    Console.ReadKey();
                    return 0;
                }
                else if (usernameKlant == existAccount.Accounts[i].username)
                {
                    Console.WriteLine("Dit gebruikers naam is in gebruik, kies voor een nieuw gebruikers naam");
                    Console.ReadKey();
                    return 0;
                }
            }
            Console.WriteLine("Maak uw gebruikers wachtwoord");
            string passwordKlant = Console.ReadLine();
            int idKlant = existAccount.Accounts[existAccount.Accounts.Count - 1].id + 1;
            if (type == "klant")
            {
                existAccount.Accounts.Add(
                    new Account { id = idKlant, username = usernameKlant, password = passwordKlant, typeOfAccount = "klant" }
                );
            }
            else
            {
                existAccount.Accounts.Add(
                    new Account { id = idKlant, username = usernameKlant, password = passwordKlant, typeOfAccount = "werknemer" }
                );
            }
            jsonString = JsonSerializer.Serialize(existAccount);
            File.WriteAllText(fileNameAccounts, jsonString);
            return idKlant;
        }
        public static int Login()
        {
            string gebruikersNaam;
            string gebruikersWachtwoord;
            string fileNameAccounts = "Accounts.json";
            string jsonString = File.ReadAllText(fileNameAccounts);
            var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!;
            string s =
@"██╗███╗░░██╗██╗░░░░░░█████╗░░██████╗░░██████╗░███████╗███╗░░██╗
██║████╗░██║██║░░░░░██╔══██╗██╔════╝░██╔════╝░██╔════╝████╗░██║
██║██╔██╗██║██║░░░░░██║░░██║██║░░██╗░██║░░██╗░█████╗░░██╔██╗██║
██║██║╚████║██║░░░░░██║░░██║██║░░╚██╗██║░░╚██╗██╔══╝░░██║╚████║
██║██║░╚███║███████╗╚█████╔╝╚██████╔╝╚██████╔╝███████╗██║░╚███║
╚═╝╚═╝░░╚══╝╚══════╝░╚════╝░░╚═════╝░░╚═════╝░╚══════╝╚═╝░░╚══╝"+"\n";
            Console.WriteLine(s);
            Console.WriteLine("Voer in uw gebruikers naam:");
            gebruikersNaam = Console.ReadLine();
            Console.WriteLine("Voer in uw gebruikers wachtwoord:");
            gebruikersWachtwoord = Console.ReadLine();
            for (int i = 0; i < existAccount.Accounts.Count; i++)
            {
                if (gebruikersNaam == existAccount.Accounts[i].username && gebruikersWachtwoord == existAccount.Accounts[i].password)
                {
                    int typeID = existAccount.Accounts[i].id;
                    return typeID;
                }
            }
            return 0;
        }
        public static void Klant(int id)
        {
            string fileNameAccounts = "Accounts.json";//json file locatie
            var jsonString = File.ReadAllText(fileNameAccounts); // json
            var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!;
            int indexUser = GetUserIndex(id);
            if (indexUser < 0)
            {
                return;
            }
            string nameUser = existAccount.Accounts[indexUser].username;
            for (bool klantLoop = true; klantLoop;)
            {
                string s =
@"╔═══════════════════════════════════════════════════════════╗
║ Navigeer de applicatie door middel van de pijltjestoetsen.║
║ Uw geselecteerd optie is in blauw.                        ║
║ Bevestig uw keuze door middel van de Enter toets.         ║
╚═══════════════════════════════════════════════════════════╝";
                s += $"\nWelcome {nameUser}\n";
                int screen_Klant_Start = Options.listOfChoice(true, s, "Uitloggen\n", "Mijn informatie\n", "Reserveren\n", "Contact\n");
                if (screen_Klant_Start == -1 || screen_Klant_Start == 0)
                {
                    break;
                }
                else if (screen_Klant_Start == 1)
                {
                    for (bool mijnInfoLoop = true; mijnInfoLoop;)
                    {
                        Console.Clear();
                        string fileNameConfirm = "ConfirmReserveren.json";
                        var jsonConfirmString = File.ReadAllText(fileNameConfirm);
                        var existConfirm = JsonSerializer.Deserialize<NewReservering>(jsonConfirmString)!;
                        int reserveerChecker = ReserverenC.BevestigChecker(id);
                        s =
@"███╗░░░███╗██╗░░░░░██╗███╗░░██╗  ██╗███╗░░██╗███████╗░█████╗░██████╗░███╗░░░███╗░█████╗░████████╗██╗███████╗
████╗░████║██║░░░░░██║████╗░██║  ██║████╗░██║██╔════╝██╔══██╗██╔══██╗████╗░████║██╔══██╗╚══██╔══╝██║██╔════╝
██╔████╔██║██║░░░░░██║██╔██╗██║  ██║██╔██╗██║█████╗░░██║░░██║██████╔╝██╔████╔██║███████║░░░██║░░░██║█████╗░░
██║╚██╔╝██║██║██╗░░██║██║╚████║  ██║██║╚████║██╔══╝░░██║░░██║██╔══██╗██║╚██╔╝██║██╔══██║░░░██║░░░██║██╔══╝░░
██║░╚═╝░██║██║╚█████╔╝██║░╚███║  ██║██║░╚███║██║░░░░░╚█████╔╝██║░░██║██║░╚═╝░██║██║░░██║░░░██║░░░██║███████╗
╚═╝░░░░░╚═╝╚═╝░╚════╝░╚═╝░░╚══╝  ╚═╝╚═╝░░╚══╝╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝╚══════╝

╔═══════════════════════════════════════════════════════════╗
║ Navigeer de applicatie door middel van de pijltjestoetsen.║
║ Uw geselecteerd optie is in blauw.                        ║
║ Bevestig uw keuze door middel van de Enter toets.         ║
╚═══════════════════════════════════════════════════════════╝" + "\n";
                        s = $"\nHallo {nameUser}\n";
                        try
                        {
                            s += "Uw reservering(en):\n";
                            var tmpSmallVariable = existConfirm.deReserveringAgenda[reserveerChecker].alleReserveringen;
                            for (int i = 0; i < tmpSmallVariable.Count; i++)
                            {
                                s += $"\tNaam: {tmpSmallVariable[i].naamReservering}, Datum: {tmpSmallVariable[i].datumReservering}, Tijd: {tmpSmallVariable[i].tijdReservering}, Aantal gasten: {tmpSmallVariable[i].gastenReservering}, Bevestigingcode: {tmpSmallVariable[i].bevestigingCode}\n";
                            }
                            int screenMijnInformatie = Options.listOfChoice(true, s, "Annuleer een reservering\n", "Ga terug\n");
                            if (screenMijnInformatie == -1 || screenMijnInformatie == 1)
                            {
                                mijnInfoLoop = false;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("No function atm");
                                Console.ReadKey();
                            }
                        }
                        catch (System.ArgumentOutOfRangeException)
                        {
                            s += "U heeft nog geen reseveringen";
                            int screenMijnInformatie = Options.listOfChoice(true, s, "Ga terug\n");
                            if (screenMijnInformatie == -1 || screenMijnInformatie == 0)
                            {
                                mijnInfoLoop = false;
                                break;
                            }
                        }
                    }
                }
                else if (screen_Klant_Start == 2)
                {
                    Reserveren(id);
                }
                else if (screen_Klant_Start == 3)
                {
                    Console.Clear();
                    Console.WriteLine("No function atm");
                    Console.ReadKey();
                }
                    }
        }
        public static void Werknemer(int id)
        {
            string fileNameAccounts = "Accounts.json";//json file locatie
            var jsonString = File.ReadAllText(fileNameAccounts); // json
            var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!;
            int indexUser = GetUserIndex(id);
            if (indexUser < 0)
            {
                return;
            }
            string nameUser = existAccount.Accounts[indexUser].username;
            for (bool WerknemerLoop = true; WerknemerLoop;)
            {
                string s =
@"╔═══════════════════════════════════════════════════════════╗
║ Navigeer de applicatie door middel van de pijltjestoetsen.║
║ Uw geselecteerd optie is in blauw.                        ║
║ Bevestig uw keuze door middel van de Enter toets.         ║
╚═══════════════════════════════════════════════════════════╝";
                s += $"\nWelcome {nameUser}\n";
                int screen_Werknemer_Start = Options.listOfChoice(true, s, "Uitloggen\n", "Mijn Informatie\n", "Menu\n", "Reserveren\n", "Contact\n");
                if (screen_Werknemer_Start == -1 || screen_Werknemer_Start == 0)
                {
                    break;
                }
                else if (screen_Werknemer_Start == 1)
                {
                    {
                        for (bool mijnInfoLoop = true; mijnInfoLoop;)
                        {
                            Console.Clear();
                            string fileNameConfirm = "ConfirmReserveren.json";
                            var jsonConfirmString = File.ReadAllText(fileNameConfirm);
                            var existConfirm = JsonSerializer.Deserialize<NewReservering>(jsonConfirmString)!;
                            int reserveerChecker = ReserverenC.BevestigChecker(id);
                            s =
@"███╗░░░███╗██╗░░░░░██╗███╗░░██╗  ██╗███╗░░██╗███████╗░█████╗░██████╗░███╗░░░███╗░█████╗░████████╗██╗███████╗
████╗░████║██║░░░░░██║████╗░██║  ██║████╗░██║██╔════╝██╔══██╗██╔══██╗████╗░████║██╔══██╗╚══██╔══╝██║██╔════╝
██╔████╔██║██║░░░░░██║██╔██╗██║  ██║██╔██╗██║█████╗░░██║░░██║██████╔╝██╔████╔██║███████║░░░██║░░░██║█████╗░░
██║╚██╔╝██║██║██╗░░██║██║╚████║  ██║██║╚████║██╔══╝░░██║░░██║██╔══██╗██║╚██╔╝██║██╔══██║░░░██║░░░██║██╔══╝░░
██║░╚═╝░██║██║╚█████╔╝██║░╚███║  ██║██║░╚███║██║░░░░░╚█████╔╝██║░░██║██║░╚═╝░██║██║░░██║░░░██║░░░██║███████╗
╚═╝░░░░░╚═╝╚═╝░╚════╝░╚═╝░░╚══╝  ╚═╝╚═╝░░╚══╝╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝╚══════╝

╔═══════════════════════════════════════════════════════════╗
║ Navigeer de applicatie door middel van de pijltjestoetsen.║
║ Uw geselecteerd optie is in blauw.                        ║
║ Bevestig uw keuze door middel van de Enter toets.         ║
╚═══════════════════════════════════════════════════════════╝" + "\n";
                            s = $"\nHallo {nameUser}\n";
                            try
                            {
                                s += "Uw reservering(en):\n";
                                var tmpSmallVariable = existConfirm.deReserveringAgenda[reserveerChecker].alleReserveringen;
                                for (int i = 0; i < tmpSmallVariable.Count; i++)
                                {
                                    s += $"\tNaam: {tmpSmallVariable[i].naamReservering}, Datum: {tmpSmallVariable[i].datumReservering}, Tijd: {tmpSmallVariable[i].tijdReservering}, Aantal gasten: {tmpSmallVariable[i].gastenReservering}, Bevestigingcode: {tmpSmallVariable[i].bevestigingCode}\n";
                                }
                                int screenMijnInformatie = Options.listOfChoice(true, s, "Annuleer een reservering\n", "Ga terug\n");
                                if (screenMijnInformatie == -1 || screenMijnInformatie == 1)
                                {
                                    mijnInfoLoop = false;
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("No function atm");
                                    Console.ReadKey();
                                }
                            }
                            catch (System.ArgumentOutOfRangeException)
                            {
                                s += "U heeft nog geen reseveringen";
                                int screenMijnInformatie = Options.listOfChoice(true, s, "Ga terug\n");
                                if (screenMijnInformatie == -1 || screenMijnInformatie == 0)
                                {
                                    mijnInfoLoop = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (screen_Werknemer_Start == 2)
                {
                    Menu();
                }
                else if (screen_Werknemer_Start == 3)
                {
                    Reserveren(id);
                }
                else if (screen_Werknemer_Start == 4)
                {
                    Console.Clear();
                    Console.WriteLine("No function atm");
                    Console.ReadKey();
                }
            }
        }
        public static void Admin(int id)
        {
            string fileNameAccounts = "Accounts.json";//json file locatie
            var jsonString = File.ReadAllText(fileNameAccounts); // json
            var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!;
            int indexUser = GetUserIndex(id);
            if (indexUser < 0)
            {
                return;
            }
            string nameUser = existAccount.Accounts[indexUser].username;
            for (bool adminLoop = true; adminLoop;)
            {
                string s =
@"╔═══════════════════════════════════════════════════════════╗
║ Navigeer de applicatie door middel van de pijltjestoetsen.║
║ Uw geselecteerd optie is in blauw.                        ║
║ Bevestig uw keuze door middel van de Enter toets.         ║
╚═══════════════════════════════════════════════════════════╝";
                s += $"\nWelcome {nameUser}\n";
                int screen_Admin_Start = Options.listOfChoice(true, s, "Uitloggen\n", "Accounts\n", "Menu\n", "Contact\n");
                if (screen_Admin_Start == -1 || screen_Admin_Start == 0)
                {
                    break;
                }
                else if (screen_Admin_Start == 1)
                {
                    for (bool accountLoop = true; accountLoop;)
                    {
                        s = 
@"░█████╗░░█████╗░░█████╗░░█████╗░██╗░░░██╗███╗░░██╗████████╗░██████╗
██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░░░██║████╗░██║╚══██╔══╝██╔════╝
███████║██║░░╚═╝██║░░╚═╝██║░░██║██║░░░██║██╔██╗██║░░░██║░░░╚█████╗░
██╔══██║██║░░██╗██║░░██╗██║░░██║██║░░░██║██║╚████║░░░██║░░░░╚═══██╗
██║░░██║╚█████╔╝╚█████╔╝╚█████╔╝╚██████╔╝██║░╚███║░░░██║░░░██████╔╝
╚═╝░░╚═╝░╚════╝░░╚════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝░░░╚═╝░░░╚═════╝░" + "\n";
                        int screen_Admin_Accounts = Options.listOfChoice(true, s, "Account verwijderen\n", "Werknemer account registeren\n", "Ga terug\n");
                        if (screen_Admin_Accounts == -1 || screen_Admin_Accounts == 2)
                        {
                            break;
                        }
                        else if (screen_Admin_Accounts == 0)
                        {
                            Console.Clear();
                            jsonString = File.ReadAllText(fileNameAccounts); // json
                            existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!;
                            for (int i = 0; i < existAccount.Accounts.Count; i++)
                            {
                                s += $"Account information:\n\tId: {existAccount.Accounts[i].id}, Gebruikersnaam: {existAccount.Accounts[i].username}, Gebruikerswachtwoord: {existAccount.Accounts[i].password}, Account type: {existAccount.Accounts[i].typeOfAccount}\n";
                            }

                            int screen_Account_Verwijderen = Options.listOfChoice(true, s, "Verwijder account\n", "Ga terug\n");
                            if (screen_Account_Verwijderen == -1 || screen_Account_Verwijderen == 1)
                            {
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(s);
                                Console.WriteLine("Voer in de ID van de account dat u wilt verwijderen. Voer in 0 om te annuleren.");
                                int idToDelete = int.Parse(Console.ReadLine());
                                if (idToDelete == 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    int indexOfUser = GetUserIndex(idToDelete);
                                    if (indexOfUser == -1) { continue; }
                                    else
                                    {
                                        existAccount.Accounts.RemoveAt(indexOfUser);
                                        jsonString = JsonSerializer.Serialize(existAccount);//Saved naar json file
                                        File.WriteAllText(fileNameAccounts, jsonString);
                                    }
                                }

                            };
                        }
                        else if (screen_Admin_Accounts == 1)
                        {
                            Register("werknemer");
                        }
                    }
                }
                else if (screen_Admin_Start == 2)
                {
                    Menu();
                }
                else if (screen_Admin_Start == 3)
                {
                    Console.Clear();
                    Console.WriteLine("No function atm");
                    Console.ReadKey();
                }
            }
        }
        public static void Reserveren(int id)
        {
            string s = "";
            string nameOfOption =
@"██████╗░███████╗░██████╗███████╗██████╗░██╗░░░██╗███████╗██████╗░███████╗███╗░░██╗
██╔══██╗██╔════╝██╔════╝██╔════╝██╔══██╗██║░░░██║██╔════╝██╔══██╗██╔════╝████╗░██║
██████╔╝█████╗░░╚█████╗░█████╗░░██████╔╝╚██╗░██╔╝█████╗░░██████╔╝█████╗░░██╔██╗██║
██╔══██╗██╔══╝░░░╚═══██╗██╔══╝░░██╔══██╗░╚████╔╝░██╔══╝░░██╔══██╗██╔══╝░░██║╚████║
██║░░██║███████╗██████╔╝███████╗██║░░██║░░╚██╔╝░░███████╗██║░░██║███████╗██║░╚███║
╚═╝░░╚═╝╚══════╝╚═════╝░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝" + "\n";

            string fileNameReserveren = "OpenSlotsReserveren.json";
            var jsonString = File.ReadAllText(fileNameReserveren); // json
            var existReserveren = JsonSerializer.Deserialize<NewDay>(jsonString)!;
            string fileNameConfirm = "ConfirmReserveren.json";
            var jsonConfirmString = File.ReadAllText(fileNameConfirm);
            var existConfirm = JsonSerializer.Deserialize<NewReservering>(jsonConfirmString)!;
            s = "Voer in de naam van uw reservering";
            string annuleer = "\n(Voer in \"Annuleer\" om uw reservering te annuleren, zonder aanhalingstekens)";
            for (bool reserveren_Loop = true; reserveren_Loop;)
            {
                Console.Clear();
                Console.WriteLine(nameOfOption + s + annuleer);
                string naamVanReserveren = Console.ReadLine();
                if (naamVanReserveren == "Annuleer")
                {
                    return;
                }
                else if (naamVanReserveren.Length > 0)
                {
                    Console.Clear();
                    string allPossibleDates = ReserverenC.GetDates();
                    s = $"Op welke datum wilt u graag reserveren? U kan 2 weken vooruit reserveren.\nVoer in uw gekozen datum van de lijst hieronder:\n\n{allPossibleDates}";
                    for (bool dateLoop = true; dateLoop;)
                    {
                        Console.WriteLine(nameOfOption + s + annuleer);
                        string stringOfDateTime = Console.ReadLine(); 
                        if (stringOfDateTime == "Annuleer")
                        {
                            return;
                        }
                        if (DateTime.TryParse(stringOfDateTime, out var chosenDate))//(DateTime.TryParse(Console.ReadLine(), out var chosenDate))
                        {
                            var todayDate = DateTime.Today;
                            if (chosenDate >= todayDate && chosenDate <= DateTime.Today.AddDays(14) && (chosenDate.DayOfWeek == DayOfWeek.Wednesday || chosenDate.DayOfWeek == DayOfWeek.Thursday || chosenDate.DayOfWeek == DayOfWeek.Friday))
                            {
                                Console.Clear();
                                s = "Op welke tijdslot wilt u graag reserveren?\nEen tijdslot is 2 uren, van 10:00 tot en met 22:00.\n\nVoer in: 10, 12, 14, 16, 18, 20 of 22.";
                                for (bool timeLoop = true; timeLoop;)
                                {
                                    Console.WriteLine(nameOfOption + s + annuleer);
                                    string stringOfChosenTime = Console.ReadLine();
                                    if (stringOfChosenTime == "Annuleer")
                                    {
                                        return;
                                    }
                                    if (int.TryParse(stringOfChosenTime, out int chosenTimeSlot))//(int.TryParse(Console.ReadLine(), out int chosenTimeSlot))
                                    {
                                        var timeSlots = new List<int> { 10, 12, 14, 16, 18, 20, 22 };
                                        if (timeSlots.Contains(chosenTimeSlot))
                                        {
                                            Console.Clear();
                                            int indexOfChosenDate = 0;
                                            for (int i = 0; i < existReserveren.Reserveren.Count; i++)
                                            {
                                                if (existReserveren.Reserveren[i].deDatum == chosenDate.Date.ToString())
                                                {
                                                    indexOfChosenDate = i;
                                                }
                                            }
                                            s = $"Er zijn {existReserveren.Reserveren[indexOfChosenDate].allTime[0].openSlotten[chosenTimeSlot]} beschikbare zitplaatsen op dit tijdslot.\nVoer in voor hoeveel personen u wilt reserveren met minimaal 1 persoon tot maximaal 8 personen.";

                                            for (bool gastLoop = true; gastLoop;)
                                            {

                                                Console.WriteLine(nameOfOption + s + annuleer);
                                                string stringAantalGasten = Console.ReadLine();
                                                if (stringAantalGasten == "Annuleer")
                                                {
                                                    return;
                                                }
                                                if (int.TryParse(stringAantalGasten, out int gastenReserveren))//(int.TryParse(Console.ReadLine(), out int gastenReserveren))
                                                {
                                                    if (gastenReserveren <= 0)
                                                    {
                                                        Console.Clear();
                                                        s = "U kan niet reserveren voor minder dan 1 persoon\n" + s;
                                                        continue;
                                                    }
                                                    else if (gastenReserveren > 8)
                                                    {
                                                        Console.Clear();
                                                        s = "U heeft meer dan de maximale hoeveelheid personen ingevoerd\n" + s;
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        int indexOfReserveren = ReserverenC.GetReserverenIndex(chosenDate);
                                                        string bevestigingCodeMade = chosenDate.ToShortDateString() + chosenTimeSlot + existReserveren.Reserveren[indexOfReserveren].allTime[0].reserveert[chosenTimeSlot];
                                                        s = $"Dit is uw bevestiging code voor deze reservering:\n{bevestigingCodeMade}\n\nOm de reservering te bevestigen druk dan op enter."; //Als u deze reservering wilt annuleren voer dan \"annuleer\" in zonder aanhalingstekens.
                                                        for (bool bevestigLoop = true; bevestigLoop;)
                                                        {
                                                            Console.WriteLine(nameOfOption + s + annuleer);
                                                            if (Console.ReadLine() == "Annuleer")
                                                            {
                                                                return;
                                                            }
                                                            else
                                                            {
                                                                existReserveren.Reserveren[indexOfReserveren].allTime[0].openSlotten[chosenTimeSlot] -= gastenReserveren;
                                                                existReserveren.Reserveren[indexOfReserveren].allTime[0].reserveert[chosenTimeSlot] += 1;
                                                                jsonString = JsonSerializer.Serialize(existReserveren);//Saved naar json file
                                                                File.WriteAllText(fileNameReserveren, jsonString);
                                                                Dictionary<int, string> tmpSmallDict = new Dictionary<int, string>()
                                                                {
                                                                    {10, "10:00"}, {12, "12:00"}, {14, "14:00"}, {16, "16:00"}, {18, "18:00"}, {20, "20:00"}, {22, "22:00"}
                                                                };
                                                                ReserverenC.MakeReserveringConfirm(id, naamVanReserveren, chosenDate, tmpSmallDict[chosenTimeSlot], gastenReserveren, bevestigingCodeMade);
                                                                return;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    s = "U heeft een geen nummer ingevoert.\n" + s;
                                                    continue;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            s = "U heeft een ongeldig tijd ingevoert.\n" + s;
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        s = "U heeft geen nummer ingevoert.\n" + s;
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                s = "U heeft een verkeerde datum ingevoert\n" + s;
                                continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            s = "U heeft een geen datum ingevoert.\n" + s;
                            continue;
                        }
                    }
                }
            }
        }
        public static void Menu()
        {
            string fileNameMenu = "Menu.json";
            var jsonString = File.ReadAllText(fileNameMenu); // json
            var jsonMenu = JsonSerializer.Deserialize<NewKeuken>(jsonString)!;
            string nameOfOption =
@"███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗
████╗░████║██╔════╝████╗░██║██║░░░██║
██╔████╔██║█████╗░░██╔██╗██║██║░░░██║
██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║
██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝
╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░" + "\n";
            for (bool menuLoop = true; menuLoop;)
            {
                string s = nameOfOption + "Kies het menu dat u wilt weergeven.\n";
                List<string> alleKeukens = new List<string>();
                for (int i = 0; i < jsonMenu.Menu.Count; i++)
                {
                    alleKeukens.Add(jsonMenu.Menu[i].keukenNaam + "\n");
                }
                int screenMenu1 = Options.listOfChoice(true, s, "Arabisch Gerechten\n", "Italiaanse Gerechten\n", "Turkse Gerechten\n", "Franse Gerechten\n", "Nieuwe gerechten toevoegen\n", "Ga terug\n");//alleKeukens.ToArray());
                if (screenMenu1 == -1 || screenMenu1 == 5)
                {
                    menuLoop = false;
                    return;
                }
                else if (screenMenu1 == 4)
                {
                    Console.Clear();
                    s = nameOfOption + "Kies de keuken waarin het gerecht word toegevoegd\n";
                    int screenMenu2 = Options.listOfChoice(true, s, "Arabisch Gerechten\n", "Italiaanse Gerechten\n", "Turkse Gerechten\n", "Franse Gerechten\n", "Ga terug\n");
                    if (screenMenu2 == -1 || screenMenu2 == 4)
                    {
                        return;
                    }
                    s = nameOfOption + "Kies de type maaltijd voor het nieuwe gerecht\n";
                    int screenMenu3 = Options.listOfChoice(true, s, "Ontbijt\n", "Lunch\n", "Avondeten\n", "Desert\n", "Ga terug\n");
                    if(screenMenu3 == -1 || screenMenu3 == 4)
                    {
                        return;
                    }
                    var gekozenKeukenJson = jsonMenu.Menu[screenMenu2];
                    var dictOfTypeMenu = new Dictionary<int, List<MenuGerechten>>()
                    {
                        {0, gekozenKeukenJson.ontbijt}, {1, gekozenKeukenJson.lunch}, {2, gekozenKeukenJson.avondeten}, {3, gekozenKeukenJson.desert}
                    };
                    var menuType = dictOfTypeMenu[screenMenu3];
                    Console.Clear();
                    Console.WriteLine(nameOfOption + "Voer in de naam van het nieuwe gerecht.");
                    string naamNewGerecht = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine(nameOfOption + "Voer in de prijs van het nieuwe gerecht.");
                    double prijsNewGerecht = double.Parse(Console.ReadLine());
                    /*if (!int.TryParse(Console.ReadLine(), out prijsGerecht))
                    {

                    }*/
                    menuType.Add(
                        new MenuGerechten
                        {
                            naamGerecht = naamNewGerecht,
                            prijsGerecht = prijsNewGerecht
                        });
                    jsonString = JsonSerializer.Serialize(jsonMenu);//Saved naar json file
                    File.WriteAllText(fileNameMenu, jsonString);
                }
                else
                {
                    string ontbijt = GetMenuBox(screenMenu1, "Ontbijt");
                    string lunch = GetMenuBox(screenMenu1, "Lunch");
                    string avondeten = GetMenuBox(screenMenu1, "Avondeten");
                    string desert = GetMenuBox(screenMenu1, "Desert");
                    s = nameOfOption + $"{jsonMenu.Menu[screenMenu1].keukenNaam}\n";
                    Console.Clear();
                    Console.WriteLine(s + ontbijt + lunch + avondeten + desert);
                    Console.ReadKey();
                }
            }
        }
        public static int GetUserIndex(int id)
        {
            string fileNameAccounts = "Accounts.json";//json file locatie
            var jsonString = File.ReadAllText(fileNameAccounts); // json
            var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!;
            for (int i = 0; i < existAccount.Accounts.Count; i++)
            {
                if (id == existAccount.Accounts[i].id)
                {
                    return i;
                }
            }
            return -1;
        }
        public static string GetMenuBox(int optieKeuken, string typeEten)
        {
            string fileNameMenu = "Menu.json";
            var jsonString = File.ReadAllText(fileNameMenu); // json
            var jsonMenu = JsonSerializer.Deserialize<NewKeuken>(jsonString)!;
            var gekozenKeukenJson = jsonMenu.Menu[optieKeuken];
            string menuBox = $"╔════════════════════════════════════════╦═══════════════╗\n║ {typeEten}";
            for (int i = typeEten.Length + 1; i < 40; i++)
            {
                menuBox += " ";
            }
            var dictOfTypeMenu = new Dictionary<string, List<MenuGerechten>>()
            {
                {"Ontbijt", gekozenKeukenJson.ontbijt}, {"Lunch", gekozenKeukenJson.lunch}, {"Avondeten", gekozenKeukenJson.avondeten}, {"Desert", gekozenKeukenJson.desert}
            };
            var chosen = dictOfTypeMenu[typeEten];
            menuBox += "║ Prijs         ║\n╠════════════════════════════════════════╬═══════════════╣\n";
            if (chosen != null)
            {
                for (int i = 0; i < chosen.Count; i++)
                {
                    var newTypeMenu = chosen[i];
                    menuBox += $"║ {newTypeMenu.naamGerecht}";
                    for (int j = newTypeMenu.naamGerecht.Length + 1; j < 40; j++)
                    {
                        menuBox += " ";
                    }
                    menuBox += $"║ {newTypeMenu.prijsGerecht}";
                    for (int j = newTypeMenu.prijsGerecht.ToString().Length + 2; j < 11; j++)
                    {
                        menuBox += " ";
                    }
                    menuBox += "euro ║\n";
                }
                menuBox += "╚════════════════════════════════════════╩═══════════════╝\n\n";
                return menuBox;
            }
            else { return "Er is nog geen gerecht.\n"; }
        }
    }
}

