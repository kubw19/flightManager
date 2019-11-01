using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progZdarzeniowe.Models
{
    public class Flight
    {
        protected virtual int flightId { get; set; }
        public virtual string depPlace { get; set; }
        public virtual string arrPlace { get; set; }
        public virtual string depTime { get; set; }
        public virtual string arrTime { get; set; }
        public virtual string economyPrice { get; set; }
        public virtual string businessPrice { get; set; }
        public virtual string flightNumber { get; set; }

    }
}
