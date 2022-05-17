using System;
using System.IO;
using System.Collections.Generic;
// json stuff
namespace projectBGroep3
{
    class Account
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string typeOfAccount { get; set; }
    }
    class TypesOfChoice
    {
        public List<Account> Accounts { get; set; }
    }
}
