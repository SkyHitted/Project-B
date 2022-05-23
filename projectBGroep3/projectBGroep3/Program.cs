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
                tmp.Accounts = new List<AccountJson>
                {
                    new AccountJson {id = 1, username = "Admin", password = "Admin1", typeOfAccount = "admin"}//Maakt admin account
                };
                string fileNameAccounts = "Accounts.json";
                string jsonString = JsonSerializer.Serialize(tmp);//Saved naar json file
                File.WriteAllText(fileNameAccounts, jsonString);
            }
            if (!File.Exists("OpenSlotsReserveren.json"))
            {
                var tmp = new NewDay();
                tmp.Reserveren = new List<ReserverenJson>
                {
                    new ReserverenJson
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
                    ReserverenClass.ReserveringChecker(day);
                }
            }
            if (!File.Exists("ConfirmReserveren.json"))
            {
                var tmp = new NewReservering();
                tmp.deReserveringAgenda = new List<BevestigingCodeJson>
                {
                    new BevestigingCodeJson
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
                tmp.Menu = new List<MenuJson>
                {
                    new MenuJson
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
                    new MenuJson
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
                ReserverenClass.ReserveringChecker(day);
            }
            while (mainLoop)//Loop voor hele applicatie
            {
                string fileNameAccounts = "Accounts.json";//json file locatie
                s =
@"░██╗░░░░░░░██╗███████╗██╗░░░░░██╗░░██╗░█████╗░███╗░░░███╗
░██║░░██╗░░██║██╔════╝██║░░░░░██║░██╔╝██╔══██╗████╗░████║
░╚██╗████╗██╔╝█████╗░░██║░░░░░█████═╝░██║░░██║██╔████╔██║
░░████╔═████║░██╔══╝░░██║░░░░░██╔═██╗░██║░░██║██║╚██╔╝██║
░░╚██╔╝░╚██╔╝░███████╗███████╗██║░╚██╗╚█████╔╝██║░╚═╝░██║
░░░╚═╝░░░╚═╝░░╚══════╝╚══════╝╚═╝░░╚═╝░╚════╝░╚═╝░░░░░╚═╝

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
                    string title =
@"██╗███╗░░██╗██╗░░░░░░█████╗░░██████╗░░██████╗░███████╗███╗░░██╗
██║████╗░██║██║░░░░░██╔══██╗██╔════╝░██╔════╝░██╔════╝████╗░██║
██║██╔██╗██║██║░░░░░██║░░██║██║░░██╗░██║░░██╗░█████╗░░██╔██╗██║
██║██║╚████║██║░░░░░██║░░██║██║░░╚██╗██║░░╚██╗██╔══╝░░██║╚████║
██║██║░╚███║███████╗╚█████╔╝╚██████╔╝╚██████╔╝███████╗██║░╚███║
╚═╝╚═╝░░╚══╝╚══════╝░╚════╝░░╚═════╝░░╚═════╝░╚══════╝╚═╝░░╚══╝" + "\n";
                    string melding = "";
                    bool notLoggedIn = false;
                    for (int i = 4; i > 0 && !notLoggedIn; i--)
                    {
                        Console.WriteLine(title);
                        getMelding(melding);
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
                            melding = $"U heeft een foute gebruikersnaam of gebruikerswachtwoord ingevoerd. U heeft nog {i - 1} kans(en) over\n";
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

Welkom gast!" + "\n";
                        int screen_Gast_Start = Options.listOfChoice(true, s, "Inloggen\n", "Registreren\n", "Reserveren\n", "Contact\n");
                        if (screen_Gast_Start == -1)
                        {
                            gastLoop = false;
                        }
                        else if (screen_Gast_Start == 0)
                        {
                            Console.Clear();
                            string title =
@"██╗███╗░░██╗██╗░░░░░░█████╗░░██████╗░░██████╗░███████╗███╗░░██╗
██║████╗░██║██║░░░░░██╔══██╗██╔════╝░██╔════╝░██╔════╝████╗░██║
██║██╔██╗██║██║░░░░░██║░░██║██║░░██╗░██║░░██╗░█████╗░░██╔██╗██║
██║██║╚████║██║░░░░░██║░░██║██║░░╚██╗██║░░╚██╗██╔══╝░░██║╚████║
██║██║░╚███║███████╗╚█████╔╝╚██████╔╝╚██████╔╝███████╗██║░╚███║
╚═╝╚═╝░░╚══╝╚══════╝░╚════╝░░╚═════╝░░╚═════╝░╚══════╝╚═╝░░╚══╝" + "\n";
                            string melding = "";
                            bool notLoggedIn = false;
                            for (int i = 4; i > 0 && !notLoggedIn; i--)
                            {
                                Console.WriteLine(title);
                                getMelding(melding);
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
                                    melding = $"U heeft een foute gebruikersnaam of gebruikerswachtwoord ingevoerd. U heeft nog {i - 1} kans(en) over\n";
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
                            ReserverenClass.Reserveren(0);
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
        public static void getMelding(string s)
        {
            if (s.Length == 0)
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(s);
                Console.ResetColor();
                return;
            }
        }
        public static int Register(string type)
        {
            Console.Clear();
            string fileNameAccounts = "Accounts.json";
            string jsonString = File.ReadAllText(fileNameAccounts);
            var existAccount = JsonSerializer.Deserialize<TypesOfChoice>(jsonString)!; // json
            string title =
@"██████╗░███████╗░██████╗░██╗░██████╗████████╗██████╗░███████╗██████╗░███████╗███╗░░██╗
██╔══██╗██╔════╝██╔════╝░██║██╔════╝╚══██╔══╝██╔══██╗██╔════╝██╔══██╗██╔════╝████╗░██║
██████╔╝█████╗░░██║░░██╗░██║╚█████╗░░░░██║░░░██████╔╝█████╗░░██████╔╝█████╗░░██╔██╗██║
██╔══██╗██╔══╝░░██║░░╚██╗██║░╚═══██╗░░░██║░░░██╔══██╗██╔══╝░░██╔══██╗██╔══╝░░██║╚████║
██║░░██║███████╗╚██████╔╝██║██████╔╝░░░██║░░░██║░░██║███████╗██║░░██║███████╗██║░╚███║
╚═╝░░╚═╝╚══════╝░╚═════╝░╚═╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝" + "\n";
            Console.WriteLine(title);
            Console.WriteLine("Maak uw gebruikers naam");
            string usernameKlant = Console.ReadLine();
            for (int i = 0; i < existAccount.Accounts.Count; i++)
            {
                if (usernameKlant.Length == 0)
                {
                    getMelding("U kan geen leeg gebruikers naam hebben\n");
                    Console.WriteLine("\nDruk enter om verder te gaan");
                    Console.ReadKey();
                    return 0;
                }
                else if (usernameKlant == existAccount.Accounts[i].username)
                {
                    getMelding("Dit gebruikers naam is in gebruik, kies voor een nieuw gebruikers naam");
                    Console.WriteLine("\nDruk enter om verder te gaan");
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
                    new AccountJson { id = idKlant, username = usernameKlant, password = passwordKlant, typeOfAccount = "klant" }
                );
            }
            else
            {
                existAccount.Accounts.Add(
                    new AccountJson { id = idKlant, username = usernameKlant, password = passwordKlant, typeOfAccount = "werknemer" }
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
╚═══════════════════════════════════════════════════════════╝" + "\n";
                s += $"Welkom {nameUser}\n";
                int screen_Klant_Start = Options.listOfChoice(true, s, "Uitloggen\n", "Mijn informatie\n", "Reserveren\n", "Contact\n");
                if (screen_Klant_Start == -1 || screen_Klant_Start == 0)
                {
                    break;
                }
                else if (screen_Klant_Start == 1)
                {
                    MijnInformatie(id, nameUser);
                }
                else if (screen_Klant_Start == 2)
                {
                    ReserverenClass.Reserveren(id);
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
╚═══════════════════════════════════════════════════════════╝" + "\n";
                s += $"Welkom {nameUser}\n";
                int screen_Werknemer_Start = Options.listOfChoice(true, s, "Uitloggen\n", "Mijn Informatie\n", "Menu\n", "Reserveren\n", "Contact\n");
                if (screen_Werknemer_Start == -1 || screen_Werknemer_Start == 0)
                {
                    break;
                }
                else if (screen_Werknemer_Start == 1)
                {
                    MijnInformatie(id, nameUser);
                }
                else if (screen_Werknemer_Start == 2)
                {
                    Menu();
                }
                else if (screen_Werknemer_Start == 3)
                {
                    ReserverenClass.HigherReserveren(id);
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
╚═══════════════════════════════════════════════════════════╝" + "\n";
                s += $"Welkom {nameUser}\n";
                int screen_Admin_Start = Options.listOfChoice(true, s, "Uitloggen\n", "Mijn informatie\n","Account systeem\n", "Menu systeem\n", "Reservering systeem\n", "Contact\n");
                if (screen_Admin_Start == -1 || screen_Admin_Start == 0)
                {
                    break;
                }
                else if (screen_Admin_Start == 1)
                {
                    MijnInformatie(id, nameUser);
                }
                else if (screen_Admin_Start == 2)
                {
                    s = "";
                    string title =
@"░█████╗░░█████╗░░█████╗░░█████╗░██╗░░░██╗███╗░░██╗████████╗░██████╗
██╔══██╗██╔══██╗██╔══██╗██╔══██╗██║░░░██║████╗░██║╚══██╔══╝██╔════╝
███████║██║░░╚═╝██║░░╚═╝██║░░██║██║░░░██║██╔██╗██║░░░██║░░░╚█████╗░
██╔══██║██║░░██╗██║░░██╗██║░░██║██║░░░██║██║╚████║░░░██║░░░░╚═══██╗
██║░░██║╚█████╔╝╚█████╔╝╚█████╔╝╚██████╔╝██║░╚███║░░░██║░░░██████╔╝
╚═╝░░╚═╝░╚════╝░░╚════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝░░░╚═╝░░░╚═════╝░" + "\n";
                    for (bool accountLoop = true; accountLoop;)
                    {
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

                            int screen_Account_Verwijderen = Options.listOfChoice(true, title + s, "Verwijder account\n", "Ga terug\n");
                            if (screen_Account_Verwijderen == -1 || screen_Account_Verwijderen == 1)
                            {
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(title);
                                Console.WriteLine("\nVoer in de ID van de account dat u wilt verwijderen. Voer in 0 om te annuleren.");
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
                else if (screen_Admin_Start == 3)
                {
                    Menu();
                }
                else if (screen_Admin_Start == 4)
                {
                    ReserverenClass.HigherReserveren(id);
                }
                else if (screen_Admin_Start == 5)
                {
                    Console.Clear();
                    Console.WriteLine("No function atm");
                    Console.ReadKey();
                }
            }
        }
        public static void MijnInformatie(int id, string nameOfUser)
        {
            string fileNameReserveren = "OpenSlotsReserveren.json";
            var jsonString = File.ReadAllText(fileNameReserveren); // json met alle datums openen
            var existReserveren = JsonSerializer.Deserialize<NewDay>(jsonString)!;
            string fileNameConfirm = "ConfirmReserveren.json"; // json met alle bevestigingen openen
            var jsonConfirmString = File.ReadAllText(fileNameConfirm);
            var existConfirm = JsonSerializer.Deserialize<NewReservering>(jsonConfirmString)!;
            string title =
@"███╗░░░███╗██╗░░░░░██╗███╗░░██╗  ██╗███╗░░██╗███████╗░█████╗░██████╗░███╗░░░███╗░█████╗░████████╗██╗███████╗
████╗░████║██║░░░░░██║████╗░██║  ██║████╗░██║██╔════╝██╔══██╗██╔══██╗████╗░████║██╔══██╗╚══██╔══╝██║██╔════╝
██╔████╔██║██║░░░░░██║██╔██╗██║  ██║██╔██╗██║█████╗░░██║░░██║██████╔╝██╔████╔██║███████║░░░██║░░░██║█████╗░░
██║╚██╔╝██║██║██╗░░██║██║╚████║  ██║██║╚████║██╔══╝░░██║░░██║██╔══██╗██║╚██╔╝██║██╔══██║░░░██║░░░██║██╔══╝░░
██║░╚═╝░██║██║╚█████╔╝██║░╚███║  ██║██║░╚███║██║░░░░░╚█████╔╝██║░░██║██║░╚═╝░██║██║░░██║░░░██║░░░██║███████╗
╚═╝░░░░░╚═╝╚═╝░╚════╝░╚═╝░░╚══╝  ╚═╝╚═╝░░╚══╝╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝╚══════╝" + "\n"; 
            string boxOfInstructies =
@"╔═══════════════════════════════════════════════════════════╗
║ Navigeer de applicatie door middel van de pijltjestoetsen.║
║ Uw geselecteerd optie is in blauw.                        ║
║ Bevestig uw keuze door middel van de Enter toets.         ║
╚═══════════════════════════════════════════════════════════╝" + "\n";
            for (bool mijnInfoLoop = true; mijnInfoLoop;)
            {
                Console.Clear();
                int reserveerChecker = ReserverenClass.BevestigChecker(id); // kijkt of gebruiker al een reservering heeft
                string s = $"\n{nameOfUser}\n";
                try
                {
                    s += "Uw reservering(en):\n";
                    string alleReserveringen = "";
                    var tmpSmallVariable = existConfirm.deReserveringAgenda[reserveerChecker].alleReserveringen; // shortcut maken voor code
                    for (int i = 0; i < tmpSmallVariable.Count; i++) // string maken met alle reserveringen van de gebruiker
                    {
                        alleReserveringen += $"\tNaam: {tmpSmallVariable[i].naamReservering}, Datum: {tmpSmallVariable[i].datumReservering}, Tijd: {tmpSmallVariable[i].tijdReservering}, Aantal gasten: {tmpSmallVariable[i].gastenReservering}, Bevestigingcode: {tmpSmallVariable[i].bevestigingCode}\n";
                    }
                    int screenMijnInformatie = Options.listOfChoice(true, title + boxOfInstructies + s + alleReserveringen, "Afbreken een reservering\n", "Ga terug\n");
                    if (screenMijnInformatie == -1 || screenMijnInformatie == 1) // escape of Ga terug
                    {
                        mijnInfoLoop = false;
                        break;
                    }
                    else if (screenMijnInformatie == 0) // Reservering annuleren
                    {
                        Console.Clear();
                        string melding = "";
                        s = "Alle geldige reserveringen:\n"; 
                        string invoeren = "\nVoer in de Bevestigingcode van de reservering dat u wilt annuleren\n(Voer in \"Terug\" om naar de vorige scherm te gaan, zonder aanhalingstekens)";
                        for (bool annuleerReserveringLoop = true; annuleerReserveringLoop;)
                        {
                            Console.WriteLine(title);
                            getMelding(melding);
                            Console.WriteLine(s + alleReserveringen + invoeren);
                            string reserveringToDelete = Console.ReadLine(); // invoer gebruiker
                            if (reserveringToDelete == "Terug") // stopt de annulering
                            {
                                break;
                            }
                            else // gaat verder met annuleren
                            {
                                for (int i = 0; i < tmpSmallVariable.Count; i++) // lopen door de reserveringen van gebruiker
                                {
                                    if (reserveringToDelete == tmpSmallVariable[i].bevestigingCode) // de invoer van gebruiker klopt
                                    {
                                        Dictionary<string, int> tmpSmallDict = new Dictionary<string, int>()
                                                                {
                                                                    {"10:00", 10}, {"12:00", 12}, {"14:00", 14}, {"16:00", 16}, {"18:00", 18}, {"20:00", 20}, {"22:00", 22}
                                                                };
                                        DateTime dateChosen = DateTime.Parse(tmpSmallVariable[i].datumReservering); // string naar DateTime veranderen
                                        int indexOfReserveren = ReserverenClass.GetReserverenIndex(dateChosen); // index van datum in jsonfile OpenSlotReserveren

                                        Console.Clear();
                                        Console.WriteLine("U heeft de volgende reservering geannuleerd:");
                                        Console.WriteLine($"\tNaam: { tmpSmallVariable[i].naamReservering}, Datum: { tmpSmallVariable[i].datumReservering}, Tijd: { tmpSmallVariable[i].tijdReservering}, Aantal gasten: { tmpSmallVariable[i].gastenReservering}, Bevestigingcode: { tmpSmallVariable[i].bevestigingCode}\n");
                                        Console.WriteLine("\nDruk op Enter om verder te gaan");
                                        Console.ReadKey();

                                        existReserveren.Reserveren[indexOfReserveren].allTime[0].openSlotten[tmpSmallDict[tmpSmallVariable[i].tijdReservering]] += tmpSmallVariable[i].gastenReservering; // add aantal gasten terug in json
                                        jsonString = JsonSerializer.Serialize(existReserveren);
                                        File.WriteAllText(fileNameReserveren, jsonString); // Saved naar json file

                                        existConfirm.deReserveringAgenda[reserveerChecker].alleReserveringen.RemoveAt(i); // delete reservering van ConfirmReservering json
                                        jsonConfirmString = JsonSerializer.Serialize(existConfirm);
                                        File.WriteAllText(fileNameConfirm, jsonConfirmString); // Saved naar json file

                                        
                                        goto LoopEnd;
                                    }
                                }
                                Console.Clear();
                                melding = "U heeft een incorrect Bevestigingcode in gevoerd\n";
                                continue;
                            }
                        }
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
            LoopEnd:;

            }
        }
        
        public static void Menu()
        {
            string fileNameMenu = "Menu.json";
            var jsonString = File.ReadAllText(fileNameMenu); // json
            var jsonMenu = JsonSerializer.Deserialize<NewKeuken>(jsonString)!;
            string title =
@"███╗░░░███╗███████╗███╗░░██╗██╗░░░██╗
████╗░████║██╔════╝████╗░██║██║░░░██║
██╔████╔██║█████╗░░██╔██╗██║██║░░░██║
██║╚██╔╝██║██╔══╝░░██║╚████║██║░░░██║
██║░╚═╝░██║███████╗██║░╚███║╚██████╔╝
╚═╝░░░░░╚═╝╚══════╝╚═╝░░╚══╝░╚═════╝░" + "\n\n";
            for (bool menuLoop = true; menuLoop;)
            {
                string s = title + "Kies het menu dat u wilt weergeven.\n";
                List<string> alleKeukens = new List<string>();
                for (int i = 0; i < jsonMenu.Menu.Count; i++)
                {
                    alleKeukens.Add(jsonMenu.Menu[i].keukenNaam + "\n");
                }
                alleKeukens.Add("Nieuwe gerechten toevoegen\n");
                alleKeukens.Add("Ga terug\n");

                int screenMenu1 = Options.listOfChoice(true, s, alleKeukens.ToArray());
                if (screenMenu1 == -1 || screenMenu1 == alleKeukens.Count - 1)
                {
                    menuLoop = false;
                    return;
                }
                else if (screenMenu1 == alleKeukens.Count - 2)
                {
                    List<string> voegGerechtKeuken = new List<string>();
                    for (int i = 0; i < jsonMenu.Menu.Count; i++)
                    {
                        voegGerechtKeuken.Add(jsonMenu.Menu[i].keukenNaam + "\n");
                    }
                    voegGerechtKeuken.Add("Ga terug\n");
                    Console.Clear();
                    for (bool loopVanToevoegen = true; loopVanToevoegen;)
                    {
                        s = title + "Kies de keuken waarin het gerecht word toegevoegd\n";
                        int screenToevoegen1 = Options.listOfChoice(true, s, voegGerechtKeuken.ToArray());
                        if (screenToevoegen1 == -1 || screenToevoegen1 == voegGerechtKeuken.Count - 1)
                        {
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            for (bool loopVanMaaltijd = true; loopVanMaaltijd;)
                            {
                                s = title + "Kies de type maaltijd voor het nieuwe gerecht\n";
                                int screenToevoegen2 = Options.listOfChoice(true, s, "Ontbijt\n", "Lunch\n", "Avondeten\n", "Desert\n", "Ga terug\n");
                                if (screenToevoegen2 == -1 || screenToevoegen2 == 4)
                                {
                                    loopVanToevoegen = false;
                                    break;
                                }
                                var gekozenKeukenJson = jsonMenu.Menu[screenToevoegen1];
                                var dictOfTypeMenu = new Dictionary<int, List<MenuGerechten>>()
                                {
                                    {0, gekozenKeukenJson.ontbijt}, {1, gekozenKeukenJson.lunch}, {2, gekozenKeukenJson.avondeten}, {3, gekozenKeukenJson.desert}
                                };
                                var menuType = dictOfTypeMenu[screenToevoegen2];
                                for (bool loopNieuwGerechtNaam = true; loopNieuwGerechtNaam;)
                                {
                                    Console.Clear();
                                    Console.WriteLine(title);
                                    Console.WriteLine("Voer in de naam van het nieuwe gerecht.");
                                    string naamNewGerecht = Console.ReadLine();
                                    if (naamNewGerecht.Length > 0)
                                    {
                                        for (bool loopNieuwGerechtPrijs = true; loopNieuwGerechtPrijs;)
                                        {
                                            Console.Clear();
                                            Console.WriteLine(title + "Voer in de prijs van het nieuwe gerecht.");
                                            double prijsNewGerecht = double.Parse(Console.ReadLine());
                                            if (!double.TryParse(Console.ReadLine(), out double prijsGerecht))
                                            {
                                                menuType.Add(
                                                    new MenuGerechten
                                                    {
                                                        naamGerecht = naamNewGerecht,
                                                        prijsGerecht = prijsNewGerecht
                                                    });
                                                jsonString = JsonSerializer.Serialize(jsonMenu);//Saved naar json file
                                                File.WriteAllText(fileNameMenu, jsonString);
                                                loopNieuwGerechtPrijs = false;
                                                loopNieuwGerechtNaam = false;
                                                loopVanMaaltijd = false;
                                                loopVanToevoegen = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    string ontbijt = GetMenuBox(screenMenu1, "Ontbijt");
                    string lunch = GetMenuBox(screenMenu1, "Lunch");
                    string avondeten = GetMenuBox(screenMenu1, "Avondeten");
                    string desert = GetMenuBox(screenMenu1, "Desert");
                    s = title + $"{jsonMenu.Menu[screenMenu1].keukenNaam}\n";
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

