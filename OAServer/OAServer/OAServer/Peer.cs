using System;
using Common;
using Common.Tools;
using OAServer.Handler;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace OAServer
{
    public class Peer : ClientPeer
    {
        string ip;
        public Peer(InitRequest initRequest):base(initRequest)
        {
            ip = initRequest.RemoteIP;
        }

        //客户端断开的操作（一般做一些清理操作）
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            ServerRoot.Instance.log.Info(ip+"断开链接" + reasonCode.ToString());
        }

        //客户端链接上的操作
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            ServerRoot.Instance.log.Info("aaaa");
            BaseHandler handler = DictTool.GetValue<OperationCode, BaseHandler>(ServerRoot.Instance.handlerDict, (OperationCode)operationRequest.OperationCode);
            if (handler!=null)
            {
                handler.OnOperationRequest(operationRequest, sendParameters, this);
            }
            else
            {
                //这里可以写一个默认的Handler处理
                BaseHandler deafultHandler = DictTool.GetValue<OperationCode, BaseHandler>(ServerRoot.Instance.handlerDict, OperationCode.Default);
                deafultHandler.OnOperationRequest(operationRequest, sendParameters, this);
            }
            
        }
    }
}
