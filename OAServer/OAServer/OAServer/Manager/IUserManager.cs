

using OAServer.Model;
using System.Collections.Generic;

namespace OAServer.Manager
{
    interface IUserManager
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        //重载 多种方式获取用户
        User GetUser(int id);
        User GetUser(string userName);
        //得到所有的用户信息
        //ICollection是一种集合的接口,扩展了功能。
        ICollection<User> GerAllUsers();

        //验证账号密码是否正确
        bool VerifyUser(string account, string password);
        
    }
}
