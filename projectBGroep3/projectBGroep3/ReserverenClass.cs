using System.Collections.Generic;

namespace projectBGroep3
{
    class ReserverenClass
    {
        public string deDatum { get; set; }
        public List<slotsAndReseveren> allTime { get; set; }
    }
    class slotsAndReseveren
    {
        public Dictionary<int, int> openSlotten { get; set; }
        public Dictionary<int, int> reserveert { get; set; }
    }
    class NewDay
    {
        public List<ReserverenClass> Reserveren { get; set; }
    }
}
