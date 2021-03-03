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

        

        //当一个客户端请求链接的时候
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            ServerTools.log.Info(initRequest.RemoteIP+ "客户端成功连接！");
            return new Peer(initRequest);
        }


        //服务器初始化
        protected override void Setup()
        {
            
            Instance = this;
            //服务器工具初始化
            ServerTools.InitTools(ApplicationPath,BinaryPath);
            //服务器事件处理方式初始化
            InitHandler();
            ServerTools.log.Info("服务器初始化完毕！");
            
            
            

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
