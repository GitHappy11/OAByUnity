
using System.Collections.Generic;
using OAServer.Model;
using NHibernate;
using NHibernate.Criterion;

namespace OAServer.Manager
{
    class UserManager : IUserManager
    {
        public void Add(User user)
        {
            ////创建工厂
            //ISession session = NHibernateHelper.OpenSessionByNhibernate();
            ////创建事务
            //ITransaction transaction = session.BeginTransaction();
            ////保存事务
            //session.Save(user);
            ////提交事务
            //transaction.Commit();
            ////关闭事务
            //transaction.Dispose();
            ////关闭工厂
            //session.Close();


            //使用Using可以省下关闭工厂步骤，它会在把工厂内的方法执行完毕后自动关闭工厂，事务同理
            using (ISession session = NHibernateHelper.OpenSessionByNhibernate())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.Save(user);
                    transaction.Commit();
                }
            }
        }

        public void Delete(User user)
        {
            using (ISession session = NHibernateHelper.OpenSessionByNhibernate())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    //根据主键进行更新删除操作，也可以使用Get方法利用主键进行查找后删除
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }

        public ICollection<User> GerAllUsers()
        {
            using (ISession session = NHibernateHelper.OpenSessionByNhibernate())
            {
                //获取整个表的集合
                IList<User> users = session.CreateCriteria(typeof(User)).List<User>();
                return users;
                
            }
        }

        public User GetUser(int id)
        {
            using (ISession session = NHibernateHelper.OpenSessionByNhibernate())
            {
                //根据表内主键进行查询,查询的时候不需要开启事务，因为查询不涉及数据的更改
                User user = session.Get<User>(id);
                return user;
            }
        }


        public User GetUser(string userName)
        {
            using (ISession session = NHibernateHelper.OpenSessionByNhibernate())
            {
                //让NH知道我们查的是哪个表
               ICriteria criteria= session.CreateCriteria(typeof(User));
                //添加查询条件  参数 字段名，查询内容
                criteria.Add(Restrictions.Eq("UserName" ,userName));
                //返回查询到的对象
                User user = criteria.UniqueResult<User>();

                ////一条语句结束
                //User user = session.CreateCriteria(typeof(User)).Add(Restrictions.Eq("UserName"), userName);
                return user; 
            }
        }

        public void Update(User user)
        {
            using (ISession session = NHibernateHelper.OpenSessionByNhibernate())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }

        public bool VerifyUser(string account, string password)
        {
            using (ISession session=NHibernateHelper.OpenSessionByNhibernate())
            {
                //添加多个查询条件
                User user = session.CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("Account", account))
                    .Add(Restrictions.Eq("Password", password))
                    .UniqueResult<User>();
                if (user == null)
                {
                    return false;
                }
                else
                    return true;
            }
        }
    }
}


