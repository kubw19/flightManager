using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progZdarzeniowe.Domain
{
    public class Flight
    {
        public virtual int flightId { get; protected set; }
        public virtual string depPlace { get; set; }
        public virtual string arrPlace { get; set; }

    }

}
