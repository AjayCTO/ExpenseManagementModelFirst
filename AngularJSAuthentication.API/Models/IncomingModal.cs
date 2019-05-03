using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.API.Models
{
    public class IncomingModal
    {
        public short incomingID { get; set; }

        public string sourceName { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<System.DateTime> date { get; set; }

        public int projectID { get; set; }
        public string  projectName { get; set; }

        public string receiptPath { get; set; }
    }
}