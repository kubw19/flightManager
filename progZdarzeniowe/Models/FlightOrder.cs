namespace progZdarzeniowe.Models
{
    public class FlightOrder
    {
        public virtual int flightOrderId { get; protected set; }
        public virtual string arrPlace { get; set; }
        public virtual string depPlace { get; set; }
        public virtual string arrTime { get; set; }
        public virtual string depTime { get; set; }
        public virtual string price { get; set; }
        public virtual string date { get; set; }
        public virtual string flightNumber { get; set; }
        public virtual User user { get; set; }
    }
}
