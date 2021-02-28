
namespace OAServer.Model
{
    public class User
    {
        public virtual int IDUser { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Account { get; set; }
        public virtual string Password { get; set; }
        public virtual int Role { get; set; }
        public virtual int OnlineState { get; set; }
    }
}
