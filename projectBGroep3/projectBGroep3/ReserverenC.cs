using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace projectBGroep3
{
    class ReserverenC
    {
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
                        new ReserverenClass
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
            if (id == 0)
            {
                return 0;
            }
            for (int i = 0; i < existConfirm.deReserveringAgenda.Count; i++)
            {
                if (id == existConfirm.deReserveringAgenda[i].deID)
                {
                    return i;
                }
            }
            return -1;
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
                        new ConfirmReservering
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
                        new ConfirmReservering
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

