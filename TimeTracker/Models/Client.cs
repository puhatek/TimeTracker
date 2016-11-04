using System.Collections.Generic;

namespace TimeTracker.Models
{
    public class ClientRep
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string postCode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string vat { get; set; }
        public Dictionary<int,string> clientReps { get; set; }

    }
}