namespace progZdarzeniowe.Models
{
    public class User
    {
        protected virtual int userId { get; set; }
        public virtual string email { get; set; }
        public virtual string password { get; set; }
        public virtual bool isAdmin { get; set; }
    }
}
