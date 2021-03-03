
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using System.IO;

namespace OAServer
{
    public static class ServerTools
    {

        public static readonly ILogger log = LogManager.GetCurrentClassLogger();
        public static void InitTools(string applicationRootPath, string binaryPath,string tips="工具类初始化完毕！")
        {
            InitLog(applicationRootPath, binaryPath);
            log.Info(tips);
        }


        private static void InitLog(string applicationRootPath, string binaryPath)
        {
            //日志初始化
            //配置日志输出

            //设置日志文件输出目录
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(applicationRootPath, "log");
            //获取配置文件
            FileInfo configFileInfo = new FileInfo(Path.Combine(binaryPath, "log4net.config"));
            if (configFileInfo.Exists)
            {
                //建立日志工厂  使用的是log4net日志插件
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                //让log4net读取配置文件
                XmlConfigurator.Configure(configFileInfo);
            }
        }
    }


}
