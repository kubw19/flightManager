using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progZdarzeniowe.Domain
{
    public class Flight
    {
        public virtual int flightId { get; set; }
        public virtual int depPlace { get; set; }
        public virtual int arrPlace { get; set; }

    }

}
