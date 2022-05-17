using System.Collections.Generic;

namespace projectBGroep3
{
    class ConfirmReservering
    {

        public int deID { get; set; }
        public List<Reserveringen> alleReserveringen { get; set; }
    }
    class Reserveringen
    {
        public string naamReservering { get; set; }
        public string datumReservering { get; set; }
        public string tijdReservering { get; set; }
        public int gastenReservering { get; set; }
        public string bevestigingCode { get; set; }
    }
    class NewReservering
    {
        public List<ConfirmReservering> deReserveringAgenda { get; set; }
    }
}

