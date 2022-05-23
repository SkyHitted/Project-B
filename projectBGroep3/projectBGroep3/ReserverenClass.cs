using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace projectBGroep3
{
    class ReserverenClass
    {
        public static void Reserveren(int id)
        {
            string s = "";
            string title =
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
            s = "Voer in de naam van uw reservering\n";
            string annuleer = "\n(Voer in \"Afbreken\" om de reservering te stoppen, zonder aanhalingstekens)";
            string melding = "";
            for (bool reserveren_Loop = true; reserveren_Loop;)
            {
                Console.Clear();
                Console.WriteLine(title);
                projectBGroep3.Program.getMelding(melding);
                Console.WriteLine(s + annuleer);
                string naamVanReserveren = Console.ReadLine();
                if (naamVanReserveren == "Afbreken")
                {
                    return;
                }
                else if (naamVanReserveren.Length > 0)
                {
                    Console.Clear();
                    string allPossibleDates = ReserverenClass.GetDates();
                    melding = "";
                    s = $"Op welke datum wilt u graag reserveren? U kan 2 weken vooruit reserveren.\nVoer in uw gekozen datum van de lijst hieronder:\n\n{allPossibleDates}";
                    for (bool dateLoop = true; dateLoop;)
                    {
                        Console.WriteLine(title);
                        projectBGroep3.Program.getMelding(melding);
                        Console.WriteLine(s + annuleer);
                        string stringOfDateTime = Console.ReadLine();
                        if (stringOfDateTime == "Afbreken")
                        {
                            return;
                        }
                        if (DateTime.TryParse(stringOfDateTime, out var chosenDate))//(DateTime.TryParse(Console.ReadLine(), out var chosenDate))
                        {
                            var todayDate = DateTime.Today;
                            if (chosenDate >= todayDate && chosenDate <= DateTime.Today.AddDays(14) && (chosenDate.DayOfWeek == DayOfWeek.Wednesday || chosenDate.DayOfWeek == DayOfWeek.Thursday || chosenDate.DayOfWeek == DayOfWeek.Friday))
                            {
                                Console.Clear();
                                melding = "";
                                s = "Op welke tijdslot wilt u graag reserveren?\nEen tijdslot is 2 uren, van 10:00 tot en met 22:00.\n\nVoer in: 10, 12, 14, 16, 18, 20 of 22.";
                                for (bool timeLoop = true; timeLoop;)
                                {
                                    Console.WriteLine(title);
                                    projectBGroep3.Program.getMelding(melding);
                                    Console.WriteLine(s + annuleer);
                                    string stringOfChosenTime = Console.ReadLine();
                                    if (stringOfChosenTime == "Afbreken")
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
                                            melding = "";
                                            var gastenOpChosenTime = existReserveren.Reserveren[indexOfChosenDate].allTime[0].openSlotten[chosenTimeSlot];
                                            if (gastenOpChosenTime == 0)
                                            {
                                                melding = $"Er is geen beschikbare zitplaats op tijdslot: {chosenTimeSlot}.\n";
                                                continue;
                                            }
                                            else if (gastenOpChosenTime == 1)
                                            {
                                                s = $"Er is {gastenOpChosenTime} beschikbare zitplaats op dit tijdslot.\nVoer in 1 als u wilt reserveren voor 1 persoon.\n";
                                            }
                                            else
                                            {
                                                s = $"Er zijn {gastenOpChosenTime} beschikbare zitplaatsen op dit tijdslot.\nVoer in voor hoeveel personen u wilt reserveren met minimaal 1 persoon tot maximaal 8 personen.\n";
                                            }
                                            for (bool gastLoop = true; gastLoop;)
                                            {
                                                Console.WriteLine(title);
                                                projectBGroep3.Program.getMelding(melding);
                                                Console.WriteLine(s + annuleer);
                                                string stringAantalGasten = Console.ReadLine();
                                                if (stringAantalGasten == "Afbreken")
                                                {
                                                    return;
                                                }
                                                if (int.TryParse(stringAantalGasten, out int gastenReserveren))//(int.TryParse(Console.ReadLine(), out int gastenReserveren))
                                                {
                                                    if (gastenReserveren <= 0)
                                                    {
                                                        Console.Clear();
                                                        melding = "U kan niet reserveren voor minder dan 1 persoon\n";
                                                        continue;
                                                    }
                                                    else if (gastenOpChosenTime == 1 && gastenReserveren > 1)
                                                    {
                                                        Console.Clear();
                                                        melding = "U heeft meer dan 1 ingevoerd\n";
                                                        continue;
                                                    }
                                                    else if (gastenReserveren > 8)
                                                    {
                                                        Console.Clear();
                                                        melding = "U heeft meer dan de maximale hoeveelheid personen ingevoerd\n";
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        Dictionary<int, string> tmpSmallDict = new Dictionary<int, string>()
                                                                {
                                                                    {10, "10:00"}, {12, "12:00"}, {14, "14:00"}, {16, "16:00"}, {18, "18:00"}, {20, "20:00"}, {22, "22:00"}
                                                                };
                                                        int indexOfReserveren = ReserverenClass.GetReserverenIndex(chosenDate);
                                                        string bevestigingCodeMade = chosenDate.ToShortDateString() + chosenTimeSlot + existReserveren.Reserveren[indexOfReserveren].allTime[0].reserveert[chosenTimeSlot];
                                                        s = $"U heeft een reservering gemaakt met de informatie als volgt:\n\tReserveringnaam: {naamVanReserveren}\n\tDatum: {chosenDate.ToShortDateString()}\n\tTijdslot: {tmpSmallDict[chosenTimeSlot]}\n\tAantal personen: {gastenReserveren}\n\n";
                                                        string invoerBev = "Voer in \"Bevestig\" om de reservering te bevestigen of voer in \"Afbreken\" om de reservering te annuleren, zonder aanhalingstekens";
                                                        melding = "";
                                                        for (bool bevestigLoop = true; bevestigLoop;)
                                                        {
                                                            Console.WriteLine(title);
                                                            projectBGroep3.Program.getMelding(melding);
                                                            Console.WriteLine(s + invoerBev);
                                                            string bevestigedOfNiet = Console.ReadLine();
                                                            if (bevestigedOfNiet == "Afbreken")
                                                            {
                                                                return;
                                                            }
                                                            else if (bevestigedOfNiet == "Bevestig")
                                                            {
                                                                Console.Clear();
                                                                s = $"Dit is uw bevestiging code voor deze reservering:\n{bevestigingCodeMade}\n\nDruk op Enter om verder te gaan"; //Als u deze reservering wilt annuleren voer dan \"annuleer\" in zonder aanhalingstekens.
                                                                Console.WriteLine(s);
                                                                Console.ReadKey();
                                                                existReserveren.Reserveren[indexOfReserveren].allTime[0].openSlotten[chosenTimeSlot] -= gastenReserveren;
                                                                existReserveren.Reserveren[indexOfReserveren].allTime[0].reserveert[chosenTimeSlot] += 1;
                                                                jsonString = JsonSerializer.Serialize(existReserveren);//Saved naar json file
                                                                File.WriteAllText(fileNameReserveren, jsonString);

                                                                ReserverenClass.MakeReserveringConfirm(id, naamVanReserveren, chosenDate, tmpSmallDict[chosenTimeSlot], gastenReserveren, bevestigingCodeMade);
                                                                return;
                                                            }
                                                            else
                                                            {
                                                                Console.Clear();
                                                                melding = "U heeft niet Bevestig of Afbreken ingevoerd\n";
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    melding = "U heeft een geen nummer ingevoert.\n";
                                                    continue;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            melding = "U heeft een ongeldig tijd ingevoert.\n";
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        melding = "U heeft geen nummer ingevoert.\n";
                                        continue;
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                melding = "U heeft een verkeerde datum ingevoert\n";
                                continue;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            melding = "U heeft een geen datum ingevoert.\n";
                            continue;
                        }
                    }
                }
                else
                {
                    melding = "U kan moet een reserveringsnaam invoeren\n";
                    continue;
                }
            }
        }
        public static void HigherReserveren(int id)
        {
            string s = "";
            string title =
@"██████╗░███████╗░██████╗███████╗██████╗░██╗░░░██╗███████╗██████╗░███████╗███╗░░██╗
██╔══██╗██╔════╝██╔════╝██╔════╝██╔══██╗██║░░░██║██╔════╝██╔══██╗██╔════╝████╗░██║
██████╔╝█████╗░░╚█████╗░█████╗░░██████╔╝╚██╗░██╔╝█████╗░░██████╔╝█████╗░░██╔██╗██║
██╔══██╗██╔══╝░░░╚═══██╗██╔══╝░░██╔══██╗░╚████╔╝░██╔══╝░░██╔══██╗██╔══╝░░██║╚████║
██║░░██║███████╗██████╔╝███████╗██║░░██║░░╚██╔╝░░███████╗██║░░██║███████╗██║░╚███║
╚═╝░░╚═╝╚══════╝╚═════╝░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝" + "\n";
            int screenAdminReserveren = Options.listOfChoice(true, title + s, "Reserveren\n", "Zitplaatsen toevoegen of verwijderen\n", "Ga terug\n");
            if (screenAdminReserveren == -1 || screenAdminReserveren == 2)
            {
                return;
            }
            else if (screenAdminReserveren == 0)
            {
                Reserveren(id);
            }
            else if (screenAdminReserveren == 1)
            {
                string fileNameReserveren = "OpenSlotsReserveren.json";
                var jsonReserverenString = File.ReadAllText(fileNameReserveren); // json
                var existReserveren = JsonSerializer.Deserialize<NewDay>(jsonReserverenString)!;
                Console.Clear();
                string allPossibleDates = ReserverenClass.GetDates();
                string melding = "";
                s = $"Op welke datum wilt u de zitplaatsen aanpassen\nVoer in uw gekozen datum van de lijst hieronder:\n\n{allPossibleDates}";
                string annuleer = "\n(Voer in \"Afbreken\" om het aanpassen van zitplaatsen te stoppen, zonder aanhalingstekens)";
                for (bool dateLoop = true; dateLoop;)
                {
                    Console.WriteLine(title);
                    projectBGroep3.Program.getMelding(melding);
                    Console.WriteLine(s + annuleer);
                    string stringOfDateTime = Console.ReadLine();
                    if (stringOfDateTime == "Afbreken")
                    {
                        break;
                    }
                    if (DateTime.TryParse(stringOfDateTime, out var chosenDate))//(DateTime.TryParse(Console.ReadLine(), out var chosenDate))
                    {
                        var todayDate = DateTime.Today;
                        if (chosenDate >= todayDate && chosenDate <= DateTime.Today.AddDays(14) && (chosenDate.DayOfWeek == DayOfWeek.Wednesday || chosenDate.DayOfWeek == DayOfWeek.Thursday || chosenDate.DayOfWeek == DayOfWeek.Friday))
                        {
                            Console.Clear();
                            melding = "";
                            s = "Op welke tijdslot wilt u de zitplaatsen aanpassen?\n\nVoer in: 10, 12, 14, 16, 18, 20 of 22.";
                            for (bool timeLoop = true; timeLoop;)
                            {
                                Console.WriteLine(title);
                                projectBGroep3.Program.getMelding(melding);
                                Console.WriteLine(s + annuleer);
                                string stringOfChosenTime = Console.ReadLine();
                                if (stringOfChosenTime == "Afbreken")
                                {
                                    dateLoop = false;
                                    break;
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
                                        melding = "";
                                        var gastenOpChosenTime = existReserveren.Reserveren[indexOfChosenDate].allTime[0].openSlotten[chosenTimeSlot];
                                        if (gastenOpChosenTime >= 1)
                                        {
                                            s = $"Er is {gastenOpChosenTime} beschikbare zitplaats op dit tijdslot.\nVoer in hoeveel zitplaatsen u wilt toevoegen of verwijderen (verwijderen doormiddel van -).\n";
                                        }
                                        else
                                        {
                                            s = $"Er zijn {gastenOpChosenTime} beschikbare zitplaatsen op dit tijdslot.\nVoer in hoeveel zitplaatsen u wilt toevoegen of verwijderen (verwijderen doormiddel van -).\n";
                                        }
                                        for (bool gastLoop = true; gastLoop;)
                                        {
                                            Console.WriteLine(title);
                                            projectBGroep3.Program.getMelding(melding);
                                            Console.WriteLine(s + annuleer);
                                            string stringAantalGasten = Console.ReadLine();
                                            if (stringAantalGasten == "Afbreken")
                                            {
                                                dateLoop = false;
                                                timeLoop = false;
                                                break;
                                            }
                                            if (int.TryParse(stringAantalGasten, out int gastenReserveren))//(int.TryParse(Console.ReadLine(), out int gastenReserveren))
                                            {
                                                if (gastenOpChosenTime + gastenReserveren < 0)
                                                {
                                                    Console.Clear();
                                                    melding = "U kan niet meer zitplaatsen verwijderen dan de al bestaande beschikbare zitplaatsen.\n";
                                                    continue;
                                                }
                                                Console.Clear();
                                                int indexOfReserveren = ReserverenClass.GetReserverenIndex(chosenDate);
                                                s = "Voer in \"Bevestig\" om de aanpassing te bevestigen of voer in \"Afbreken\" om de aanpassing te annuleren, zonder aanhalingstekens.";
                                                melding = "";
                                                for (bool bevestigLoop = true; bevestigLoop;)
                                                {
                                                    Console.WriteLine(title);
                                                    projectBGroep3.Program.getMelding(melding);
                                                    Console.WriteLine(s);
                                                    string bevestigedOfNiet = Console.ReadLine();
                                                    if (bevestigedOfNiet == "Afbreken")
                                                    {
                                                        dateLoop = false;
                                                        timeLoop = false;
                                                        gastLoop = false;
                                                        break;
                                                    }
                                                    else if (bevestigedOfNiet == "Bevestig")
                                                    {
                                                        Console.Clear();
                                                        existReserveren.Reserveren[indexOfReserveren].allTime[0].openSlotten[chosenTimeSlot] += gastenReserveren;
                                                        var jsonString = JsonSerializer.Serialize(existReserveren);//Saved naar json file
                                                        File.WriteAllText(fileNameReserveren, jsonString);

                                                        dateLoop = false;
                                                        timeLoop = false;
                                                        gastLoop = false;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.Clear();
                                                        melding = "U heeft niet Bevestig of Afbreken ingevoerd\n";
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.Clear();
                                                melding = "U heeft een geen nummer ingevoert.\n";
                                                continue;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        melding = "U heeft een ongeldig tijd ingevoert.\n";
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    melding = "U heeft geen nummer ingevoert.\n";
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            melding = "U heeft een verkeerde datum ingevoert\n";
                            continue;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        melding = "U heeft een geen datum ingevoert.\n";
                        continue;
                    }
                }
            }
        }
    public static int GetReserverenIndex(DateTime chosenTime)
        {
            string fileNameReserveren = "OpenSlotsReserveren.json";
            var jsonString = File.ReadAllText(fileNameReserveren); // json
            var existReserveren = JsonSerializer.Deserialize<NewDay>(jsonString)!;
            for (int i = 0; i < existReserveren.Reserveren.Count; i++)
            {
                if (chosenTime.Date.ToString() == existReserveren.Reserveren[i].deDatum)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void ReserveringChecker(DateTime day)
        {
            string fileNameReserveren = "OpenSlotsReserveren.json";
            var jsonString = File.ReadAllText(fileNameReserveren); // json
            var existReserveren = JsonSerializer.Deserialize<NewDay>(jsonString)!;
            int dateExists = GetReserverenIndex(day);
            if (dateExists > 0)
            {
                return;
            }
            if (day.DayOfWeek == DayOfWeek.Wednesday || day.DayOfWeek == DayOfWeek.Thursday || day.DayOfWeek == DayOfWeek.Friday)
            {
                existReserveren.Reserveren.Add(
                        new ReserverenJson
                        {
                            deDatum = day.Date.ToString(),
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
                    );
                fileNameReserveren = "OpenSlotsReserveren.json";
                jsonString = JsonSerializer.Serialize(existReserveren);//Saved naar json file
                File.WriteAllText(fileNameReserveren, jsonString);
            }
        }
        public static string GetDates()
        {
            string fileNameReserveren = "OpenSlotsReserveren.json";
            var jsonString = File.ReadAllText(fileNameReserveren); // json
            var existReserveren = JsonSerializer.Deserialize<NewDay>(jsonString)!;
            string datum = "";
            for (int i = 0; i < existReserveren.Reserveren.Count; i++)
            {
                string tmpDateString = existReserveren.Reserveren[i].deDatum;
                var tmpDateTime = DateTime.Parse(tmpDateString);
                if (tmpDateTime >= DateTime.Now.Date)
                {

                    datum += tmpDateTime.ToShortDateString() + "\n";
                }
            }
            return datum;
        }
        public static int BevestigChecker(int id)
        {
            string fileNameConfirm = "ConfirmReserveren.json";
            var jsonConfirmString = File.ReadAllText(fileNameConfirm);
            var existConfirm = JsonSerializer.Deserialize<NewReservering>(jsonConfirmString)!;
            if (id == 0) // Id 0 is gast
            {
                return 0;
            }
            for (int i = 0; i < existConfirm.deReserveringAgenda.Count; i++) // Zoekt of de id in json staat, zoja dan stuurt het index
            {
                if (id == existConfirm.deReserveringAgenda[i].deID)
                {
                    return i;
                }
            }
            return -1; // Id zit niet in json
        }
        public static void MakeReserveringConfirm(int id, string naam, DateTime datum, string tijd, int aantalGasten, string deCode)
        {
            string fileNameConfirm = "ConfirmReserveren.json";
            var jsonConfirmString = File.ReadAllText(fileNameConfirm);
            var existConfirm = JsonSerializer.Deserialize<NewReservering>(jsonConfirmString)!;
            int checker = BevestigChecker(id);
            if (checker == 0)
            {
                existConfirm.deReserveringAgenda.Add(
                        new BevestigingCodeJson
                        {
                            alleReserveringen = new List<Reserveringen>
                            {
                                new Reserveringen
                                {
                                    naamReservering = naam,
                                    datumReservering = datum.ToShortDateString(),
                                    tijdReservering = tijd,
                                    gastenReservering = aantalGasten,
                                    bevestigingCode = deCode
                                }
                            }
                        }
                    );
            } 
            else if (checker == -1)
            {
                existConfirm.deReserveringAgenda.Add(
                        new BevestigingCodeJson
                        {
                            deID = id,
                            alleReserveringen = new List<Reserveringen>
                            {
                                new Reserveringen
                                {
                                    naamReservering = naam,
                                    datumReservering = datum.ToShortDateString(),
                                    tijdReservering = tijd,
                                    gastenReservering = aantalGasten,
                                    bevestigingCode = deCode
                                }
                            }
                        }
                    );
            }
            else
            {
                existConfirm.deReserveringAgenda[checker].alleReserveringen.Add(
                    new Reserveringen
                    {
                        naamReservering = naam,
                        datumReservering = datum.ToShortDateString(),
                        tijdReservering = tijd,
                        gastenReservering = aantalGasten,
                        bevestigingCode = deCode
                    }
                 );
            }
            string jsonString = JsonSerializer.Serialize(existConfirm);//Saved naar json file
            File.WriteAllText(fileNameConfirm, jsonString);
        }
    }
}

