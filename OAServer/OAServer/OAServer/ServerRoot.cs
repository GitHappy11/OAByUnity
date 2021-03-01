 using System;
using System.IO;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Photon.SocketServer;
using Common;
using OAServer.Handler;
using System.Collections.Generic;

namespace OAServer
{
    //所有Sever端  主类都要集成ApplicationBase
    public class ServerRoot : ApplicationBase
    {

        public static new ServerRoot Instance
        {
            get;
            private set;
        }
        //存储Handler
        public Dictionary<OperationCode, BaseHandler> handlerDict = new Dictionary<OperationCode, BaseHandler>();

        //配置日志输出
        public  readonly ILogger log = LogManager.GetCurrentClassLogger();

        //当一个客户端请求链接的时候
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            log.Info(initRequest.RemoteIP+ "客户端链接过来了！");
            return new Peer(initRequest);
        }


        //服务器初始化
        protected override void Setup()
        {
            Instance = this;
            //日志初始化
            //设置日志文件输出目录
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "OAServer/log");
            //获取配置文件
            FileInfo configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            if (configFileInfo.Exists)
            {
                //建立日志工厂  使用的是log4net日志插件
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                //让log4net读取配置文件
                XmlConfigurator.Configure(configFileInfo);
            }
            InitHandler();
            log.Info("服务器初始化完毕！");
            
            
            

        }


        //当服务器关闭的时候
        protected override void TearDown()
        {
            
        }


        private void InitHandler()
        {
            DefaultHandler defaultHandler = new DefaultHandler();
            handlerDict.Add(defaultHandler.opCode, defaultHandler);

            LoginHandler loginHandler = new LoginHandler();
            handlerDict.Add(loginHandler.opCode, loginHandler);
        }
    }
}
