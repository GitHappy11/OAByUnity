
using NHibernate;
using NHibernate.Cfg;

namespace OAServer
{
    class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory==null)
                {
                    var configuration = new Configuration();
                    //解析数据库配置
                    configuration.Configure();
                    //解析程序集配置
                    configuration.AddAssembly("OAServer");
                    //建立工厂
                    sessionFactory = configuration.BuildSessionFactory();
                }
                return sessionFactory;
            }
            
        }

        //初始化Nhiberna方法
        public static ISession OpenSessionByNhibernate()
        {
            return SessionFactory.OpenSession();
        }
    }
}
