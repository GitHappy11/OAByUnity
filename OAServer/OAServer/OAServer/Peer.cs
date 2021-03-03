using Common;
using Common.Tools;
using OAServer.Handler;
using PhotonHostRuntimeInterfaces;
using Photon.SocketServer;

namespace OAServer
{
    public class Peer : ClientPeer
    {
        readonly string ip;
        public Peer(InitRequest initRequest):base(initRequest)
        {
            ip = initRequest.RemoteIP;
            ServerTools.log.Info(ip + "链接" );
        }

        //客户端断开的操作（一般做一些清理操作）
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            ServerTools.log.Info(ip+"断开链接" + reasonCode.ToString());
        }

   

        //客户端链接上的操作
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            ServerTools.log.Info("A");
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
